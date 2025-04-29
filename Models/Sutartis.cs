namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Sutartis' entity.
/// </summary>

public class Sutartis
{
    public int Numeris { get; set; }
    public DateTime PirkimoData { get; set; }
    public decimal Kaina { get; set; }
    public decimal PristatymoArKitiMokesciai { get; set; }
    public string GrazinimoAdresas { get; set; }
    public string PristatymoAdresas { get; set; }
    public decimal PristatymoKaina { get; set; }
    public string UzsakymoBusena { get; set; }
}
