using System;
using Microsoft.EntityFrameworkCore;
using SymptomApi.Models;

namespace SymptomApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }

    public DbSet<Syndrome> Syndrome {get; set;}
    public DbSet<SyndromeInsert> SyndromeInsert {get; set; }
    public DbSet<ColdSyndromeInsert> ColdSyndromeInsert {get; set;}

}
