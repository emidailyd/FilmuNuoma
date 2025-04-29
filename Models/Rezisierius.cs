namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Rezisierius' entity.
/// </summary>

public class Rezisierius
{
    public int Id { get; set; }
    public string Vardas { get; set; }
    public string Pavarde { get; set; }
    public int GimimoMetai { get; set; }
    public string Tautybe { get; set; }
    public string SocialiniaiTinklai { get; set; }
    public string Biografija { get; set; }
}
