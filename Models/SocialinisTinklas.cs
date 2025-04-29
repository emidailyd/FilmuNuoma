namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'SocialinisTinklas' entity.
/// </summary>

public class SocialinisTinklas
{
    public int Id { get; set; }
    public string Vadovas { get; set; }
    public string Pavadinimas { get; set; }
    public DateTime IkurimoData { get; set; }
    public decimal Reitingas { get; set; }
}
