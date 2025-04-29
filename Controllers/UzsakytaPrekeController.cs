namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.FilmuNuoma.Repositories;
using Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

/// <summary>
/// Controller for working with 'Uzsakytapreke' entity.
/// </summary>
public class UzsakytaprekeController : ControllerBase
{
    /// <summary>
    /// This is invoked when either 'Index' action is requested or no action is provided.
    /// </summary>
    /// <returns>Entity list view.</returns>
    [HttpGet]
    public ActionResult Index()
    {
        return View(UzsakytaprekeRepo.List());
    }

    /// <summary>
    /// This is invoked when creation form is first opened in browser.
    /// </summary>
    /// <returns>Creation form view.</returns>
    [HttpGet]
    public ActionResult Create()
    {
        var uzsakytapreke = new Uzsakytapreke();
        PopulateSelections(uzsakytapreke);

        return View(uzsakytapreke);
    }

    /// <summary>
    /// This is invoked when buttons are pressed in the creation form.
    /// </summary>
    /// <param name="uzsakytapreke">Entity model filled with latest data.</param>
    /// <returns>Returns creation form view or redirects back to Index if save is successful.</returns>
    [HttpPost]
    public ActionResult Create(Uzsakytapreke uzsakytapreke)
    {
        if (ModelState.IsValid)
        {
            UzsakytaprekeRepo.Insert(uzsakytapreke);
            return RedirectToAction("Index");
        }

        PopulateSelections(uzsakytapreke);
        return View(uzsakytapreke);
    }

    /// <summary>
    /// This is invoked when editing form is first opened in browser.
    /// </summary>
    /// <param name="id">ID of the entity to edit.</param>
    /// <returns>Editing form view.</returns>
    [HttpGet]
    public ActionResult Edit(int id)
    {
        var uzsakytapreke = UzsakytaprekeRepo.Find(id);
        PopulateSelections(uzsakytapreke);

        return View(uzsakytapreke);
    }

    /// <summary>
    /// This is invoked when buttons are pressed in the editing form.
    /// </summary>
    /// <param name="id">ID of the entity being edited.</param>
    /// <param name="uzsakytapreke">Entity model filled with latest data.</param>
    /// <returns>Returns editing form view or redirects back to Index if save is successful.</returns>
    [HttpPost]
    public ActionResult Edit(int id, Uzsakytapreke uzsakytapreke)
    {
        if (ModelState.IsValid)
        {
            UzsakytaprekeRepo.Update(uzsakytapreke);
            return RedirectToAction("Index");
        }

        PopulateSelections(uzsakytapreke);
        return View(uzsakytapreke);
    }

    /// <summary>
    /// This is invoked when deletion confirmation form is first opened in browser.
    /// </summary>
    /// <param name="id">ID of the entity to delete.</param>
    /// <returns>Deletion form view.</returns>
    [HttpGet]
    public ActionResult Delete(int id)
    {
        var uzsakytapreke = UzsakytaprekeRepo.Find(id);
        return View(uzsakytapreke);
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
            UzsakytaprekeRepo.Delete(id);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            var uzsakytapreke = UzsakytaprekeRepo.Find(id);
            return View("Delete", uzsakytapreke);
        }
    }

    /// <summary>
    /// Populates select lists used to render drop down controls.
    /// </summary>
    /// <param name="uzsakytapreke">'Uzsakytapreke' model to append to.</param>
    public void PopulateSelections(Uzsakytapreke uzsakytapreke)
    {
        var prekes = PrekeRepo.List();
        var klientai = KlientasRepo.List();

        ViewBag.PrekeSelectList = prekes.Select(it =>
            new SelectListItem {
                Value = it.Id.ToString(),
                Text = it.Pavadinimas
            }).ToList();

        ViewBag.KlientasSelectList = klientai.Select(it =>
            new SelectListItem {
                Value = it.Id.ToString(),
                Text = it.Vardas + " " + it.Pavarde
            }).ToList();
    }
}
