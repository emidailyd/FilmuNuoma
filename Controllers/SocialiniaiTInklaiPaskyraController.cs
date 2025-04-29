namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.FilmuNuoma.Repositories;
using Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

/// <summary>
/// Controller for working with 'SocialiniaiTinklaiPaskyra' entity.
/// </summary>
public class SocialiniaiTinklaiPaskyraController : ControllerBase
{
    /// <summary>
    /// This is invoked when either 'Index' action is requested or no action is provided.
    /// </summary>
    /// <returns>Entity list view.</returns>
    [HttpGet]
    public ActionResult Index()
    {
        return View(SocialiniaiTinklaiPaskyraRepo.List());
    }

    /// <summary>
    /// This is invoked when creation form is first opened in browser.
    /// </summary>
    /// <returns>Creation form view.</returns>
    [HttpGet]
    public ActionResult Create()
    {
        var socialiniaiTinklaiPaskyra = new SocialiniaiTinklaiPaskyra();
        PopulateSelections(socialiniaiTinklaiPaskyra);

        return View(socialiniaiTinklaiPaskyra);
    }

    /// <summary>
    /// This is invoked when buttons are pressed in the creation form.
    /// </summary>
    /// <param name="socialiniaiTinklaiPaskyra">Entity model filled with latest data.</param>
    /// <returns>Returns creation form view or redirects back to Index if save is successful.</returns>
    [HttpPost]
    public ActionResult Create(SocialiniaiTinklaiPaskyra socialiniaiTinklaiPaskyra)
    {
        if (ModelState.IsValid)
        {
            SocialiniaiTinklaiPaskyraRepo.Insert(socialiniaiTinklaiPaskyra);
            return RedirectToAction("Index");
        }

        PopulateSelections(socialiniaiTinklaiPaskyra);
        return View(socialiniaiTinklaiPaskyra);
    }

    /// <summary>
    /// This is invoked when editing form is first opened in browser.
    /// </summary>
    /// <param name="id">ID of the entity to edit.</param>
    /// <returns>Editing form view.</returns>
    [HttpGet]
    public ActionResult Edit(int id)
    {
        var socialiniaiTinklaiPaskyra = SocialiniaiTinklaiPaskyraRepo.Find(id);
        PopulateSelections(socialiniaiTinklaiPaskyra);

        return View(socialiniaiTinklaiPaskyra);
    }

    /// <summary>
    /// This is invoked when buttons are pressed in the editing form.
    /// </summary>
    /// <param name="id">ID of the entity being edited.</param>
    /// <param name="socialiniaiTinklaiPaskyra">Entity model filled with latest data.</param>
    /// <returns>Returns editing form view or redirects back to Index if save is successful.</returns>
    [HttpPost]
    public ActionResult Edit(int id, SocialiniaiTinklaiPaskyra socialiniaiTinklaiPaskyra)
    {
        if (ModelState.IsValid)
        {
            SocialiniaiTinklaiPaskyraRepo.Update(socialiniaiTinklaiPaskyra);
            return RedirectToAction("Index");
        }

        PopulateSelections(socialiniaiTinklaiPaskyra);
        return View(socialiniaiTinklaiPaskyra);
    }

    /// <summary>
    /// This is invoked when deletion confirmation form is first opened in browser.
    /// </summary>
    /// <param name="id">ID of the entity to delete.</param>
    /// <returns>Deletion form view.</returns>
    [HttpGet]
    public ActionResult Delete(int id)
    {
        var socialiniaiTinklaiPaskyra = SocialiniaiTinklaiPaskyraRepo.Find(id);
        return View(socialiniaiTinklaiPaskyra);
    }

    /// <summary>
    /// This is invoked when deletion is confirmed in deletion form.
    /// </summary>
    /// <param name="id">ID of the entity to delete.</param>
    /// <returns>Redirects to Index on success or returns to delete form on failure.</returns>
    [HttpPost]
    public ActionResult DeleteConfirm(int id)
    {
        try
        {
            SocialiniaiTinklaiPaskyraRepo.Delete(id);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            var socialiniaiTinklaiPaskyra = SocialiniaiTinklaiPaskyraRepo.Find(id);
            return View("Delete", socialiniaiTinklaiPaskyra);
        }
    }

    /// <summary>
    /// Populates select lists used to render drop down controls.
    /// </summary>
    /// <param name="socialiniaiTinklaiPaskyra">'SocialiniaiTinklaiPaskyra' model to append to.</param>
    public void PopulateSelections(SocialiniaiTinklaiPaskyra socialiniaiTinklaiPaskyra)
    {
        // list population logic
    }
}
