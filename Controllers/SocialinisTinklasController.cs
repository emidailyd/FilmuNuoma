namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.FilmuNuoma.Repositories;
using Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

/// <summary>
/// Controller for working with 'SocialinisTinklas' entity.
/// </summary>
public class SocialinisTinklasController : ControllerBase
{
    /// <summary>
    /// This is invoked when either 'Index' action is requested or no action is provided.
    /// </summary>
    /// <returns>Entity list view.</returns>
    [HttpGet]
    public ActionResult Index()
    {
        return View(SocialinisTinklasRepo.List());
    }

    /// <summary>
    /// This is invoked when creation form is first opened in browser.
    /// </summary>
    /// <returns>Creation form view.</returns>
    [HttpGet]
    public ActionResult Create()
    {
        var socialinisTinklas = new SocialinisTinklas();
        PopulateSelections(socialinisTinklas);

        return View(socialinisTinklas);
    }

    /// <summary>
    /// This is invoked when buttons are pressed in the creation form.
    /// </summary>
    /// <param name="socialinisTinklas">Entity model filled with latest data.</param>
    /// <returns>Returns creation form view or redirects back to Index if save is successful.</returns>
    [HttpPost]
    public ActionResult Create(SocialinisTinklas socialinisTinklas)
    {
        if (ModelState.IsValid)
        {
            SocialinisTinklasRepo.Insert(socialinisTinklas);
            return RedirectToAction("Index");
        }

        PopulateSelections(socialinisTinklas);
        return View(socialinisTinklas);
    }

    /// <summary>
    /// This is invoked when editing form is first opened in browser.
    /// </summary>
    /// <param name="id">ID of the entity to edit.</param>
    /// <returns>Editing form view.</returns>
    [HttpGet]
    public ActionResult Edit(int id)
    {
        var socialinisTinklas = SocialinisTinklasRepo.Find(id);
        PopulateSelections(socialinisTinklas);

        return View(socialinisTinklas);
    }

    /// <summary>
    /// This is invoked when buttons are pressed in the editing form.
    /// </summary>
    /// <param name="id">ID of the entity being edited.</param>
    /// <param name="socialinisTinklas">Entity model filled with latest data.</param>
    /// <returns>Returns editing form view or redirects back to Index if save is successful.</returns>
    [HttpPost]
    public ActionResult Edit(int id, SocialinisTinklas socialinisTinklas)
    {
        if (ModelState.IsValid)
        {
            SocialinisTinklasRepo.Update(socialinisTinklas);
            return RedirectToAction("Index");
        }

        PopulateSelections(socialinisTinklas);
        return View(socialinisTinklas);
    }

    /// <summary>
    /// This is invoked when deletion confirmation form is first opened in browser.
    /// </summary>
    /// <param name="id">ID of the entity to delete.</param>
    /// <returns>Deletion form view.</returns>
    [HttpGet]
    public ActionResult Delete(int id)
    {
        var socialinisTinklas = SocialinisTinklasRepo.Find(id);
        return View(socialinisTinklas);
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
            SocialinisTinklasRepo.Delete(id);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            var socialinisTinklas = SocialinisTinklasRepo.Find(id);
            return View("Delete", socialinisTinklas);
        }
    }

    /// <summary>
    /// Populates select lists used to render drop down controls.
    /// </summary>
    /// <param name="socialinisTinklas">'SocialinisTinklas' model to append to.</param>
    public void PopulateSelections(SocialinisTinklas socialinisTinklas)
    {
        // list population logic
    }
}
