namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Zanras' entity.
/// </summary>

public class Zanras
{
    public int Id { get; set; }
    public string Pavadinimas { get; set; }
    public string Aprasymas { get; set; }
    public decimal Populiarumas { get; set; }
}
