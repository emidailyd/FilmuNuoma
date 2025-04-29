namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Aktorius' entity.
/// </summary>
/// 
public class Aktorius
{
    public int Id { get; set; }
    public string Vardas { get; set; }
    public string Pavarde { get; set; }
    public int GimimoMetai { get; set; }
    public string Tautybe { get; set; }
    public string SocialiniaiTinklai { get; set; }
    public string Biografija { get; set; }
}
