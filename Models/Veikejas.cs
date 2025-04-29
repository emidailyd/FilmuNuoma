namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


/// <summary>
/// Model of 'Veikejas' entity.
/// </summary>

public class Veikejas
{
    public int Id { get; set; }
    public string Vardas { get; set; }
    public string Pavarde { get; set; }
    public int GimimoMetai { get; set; }

    public int FilmasId { get; set; }
    public int AktoriusId { get; set; }
}
