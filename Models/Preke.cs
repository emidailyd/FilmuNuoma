namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Preke' entity.
/// </summary>

public class Preke
{
    public int Id { get; set; }
    public string FilmoPavadinimas { get; set; }
    public decimal Kaina { get; set; }
    public string Bukle { get; set; }
    public DateTime IsleidimoData { get; set; }
    public string DvdSpecifinisKodas { get; set; }
    public string Kalbos { get; set; }
    public string Subtitrai { get; set; }
    public int Trukme { get; set; }
    public string Tipas { get; set; }

    public int FilmasId { get; set; }
}
