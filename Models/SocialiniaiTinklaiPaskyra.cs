namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'SocialiniaiTinklaiPaskyra' entity.
/// </summary>

public class SocialiniaiTinklaiPaskyra
{
    public int Id { get; set; }
    public string UrlAdresas { get; set; }
    public bool Aktyvumas { get; set; }

    public int? AktoriusId { get; set; }
    public int? RezisieriusId { get; set; }
    public int SocialinisTinklasId { get; set; }
}
