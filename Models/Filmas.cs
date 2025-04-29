namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Filmas' entity.
/// </summary>

public class Filmas
{
    public int Numeris { get; set; }
    public int IsleidimoMetai { get; set; }
    public string Pavadinimas { get; set; }
    public int Trukme { get; set; }
    public decimal IMDbReitingas { get; set; }
    public string Aprasymas { get; set; }
    public decimal Biudzetas { get; set; }
    public string Apdovanojimai { get; set; }
    public int FilmavimoMetai { get; set; }

    public int ZanrasId { get; set; }
    public int RezisieriusId { get; set; }
}
