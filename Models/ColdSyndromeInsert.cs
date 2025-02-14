using System;

namespace SymptomApi.Models;

public class ColdSyndromeInsert
{
    public int Id {get; set;}
    public DateOnly? VstDate {get; set;}
    public int Head {get; set;}
    public int Nose {get; set;}
    public int Neck {get; set;}
    public int Fever {get; set;}
}
