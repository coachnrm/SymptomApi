using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SymptomApi.Data;
using SymptomApi.Model2s;
using SymptomApi.Models;

namespace SymptomApi.Controllers;

[Route("/api/[controller]/[action]")]
[ApiController]
public class SymptomController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly HosXpDbContext _context;
    public SymptomController(ApplicationDbContext db, HosXpDbContext context)
    {
        _db = db; 
        _context = context; 
    } 

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var syndromes = await _db.Syndrome.ToListAsync();
        return Ok(syndromes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var syndrome = await _db.Syndrome.FindAsync(id);
        if (syndrome == null) return NotFound();
        return Ok(syndrome);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Syndrome syndrome)
    {
        _db.Syndrome.Add(syndrome);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = syndrome.Id }, syndrome );
    }

    [HttpPost]
    public async Task<IActionResult> InsertData()
    {
        using var transaction = await _db.Database.BeginTransactionAsync(); 
        try 
        {
            // 1. Get data from the source table
            var sourceData = await _db.Syndrome.ToListAsync();

            if (sourceData == null || !sourceData.Any())
            {
                return NotFound("No data found in the source table.");
            }

            // 2. Insert data into the destination table
            var destinationData = sourceData.Select(item => new SyndromeInsert
            {
                Id = item.Id,
                Cc = item.ChiefComplain,
                Pi = item.PresentIllness,
                //Dx = item.Diagnosis
                Dx = item.ChiefComplain.Contains("ไข้") ? "common cold" : "" // condition added here
            }).ToList();

            _db.SyndromeInsert.AddRange(destinationData);
            await _db.SaveChangesAsync();

            // 3. Commit the transaction
            await transaction.CommitAsync(); 

            return Ok("Data transferred successfully.");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> InsertColdData(DateOnly _date)
    {
        using var transaction = await _db.Database.BeginTransactionAsync(); 
        try 
        {
            // 1. Get data from the source table
            var sourceData = await (from o in _context.Opdscreens
                        join v in _context.VnStats on o.Vn equals v.Vn into joined
                        from v in joined.DefaultIfEmpty()
                        where v.Pdx == "J00" && o.Vstdate == _date
                        select new 
                        {
                            o.Hn,
                            o.Vstdate,
                            o.Symptom,
                            v.Pdx
                        })
                        .Take(100)
                        .ToListAsync();

            if (sourceData == null || !sourceData.Any())
            {
                return NotFound("No data found in the source table.");
            }

            // 2. Insert data into the destination table
            var destinationData = sourceData.Select(item => new ColdSyndromeInsert
            {
                VstDate = item.Vstdate,
                Head = (item.Symptom.Contains("ปวดศีรษะ") || item.Symptom.Contains("ปวดหัว")) ? 1 : 0,
                Nose = (item.Symptom.Contains("น้ำมูกไหล") || item.Symptom.Contains("คัดจมูก") || item.Symptom.Contains("แน่นจมูก")) ? 1 : 0,
                Neck = (item.Symptom.Contains("เจ็บคอ") || item.Symptom.Contains("ไอ") || item.Symptom.Contains("แน่นจมูก")) ? 1 : 0,
                Fever = item.Symptom.Contains("ไข้") ? 1 : 0,
            }).ToList();

            _db.ColdSyndromeInsert.AddRange(destinationData);
            await _db.SaveChangesAsync();

            // 3. Commit the transaction
            await transaction.CommitAsync(); 

            return Ok("Data transferred successfully.");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Syndrome updatedSyndrome)
    {
        if (id != updatedSyndrome.Id) return BadRequest();

        _db.Entry(updatedSyndrome).State = EntityState.Modified;

        try 
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_db.Syndrome.Any(s => s.Id == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var syndrome = await _db.Syndrome.FindAsync(id);
        if (syndrome == null) return NotFound();

        _db.Syndrome.Remove(syndrome);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
