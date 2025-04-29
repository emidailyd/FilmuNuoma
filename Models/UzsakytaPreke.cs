namespace Org.Ktu.Isk.P175B602.Autonuoma.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'UzsakytaPreke' entity.
/// </summary>

public class UzsakytaPreke
{
    public int Id { get; set; }
    public int Kiekis { get; set; }
    public decimal Kaina { get; set; }

    public int PrekeId { get; set; }
    public int SutartisNumeris { get; set; }
}
