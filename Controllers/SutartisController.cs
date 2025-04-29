namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.FilmuNuoma.Repositories;
using Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

/// <summary>
/// Controller for working with 'Sutartis' entity.
/// </summary>
public class SutartisController : ControllerBase
{
    /// <summary>
    /// This is invoked when either 'Index' action is requested or no action is provided.
    /// </summary>
    /// <returns>Entity list view.</returns>
    [HttpGet]
    public ActionResult Index()
    {
        return View(SutartisRepo.List());
    }

    /// <summary>
    /// This is invoked when creation form is first opened in browser.
    /// </summary>
    /// <returns>Creation form view.</returns>
    [HttpGet]
    public ActionResult Create()
    {
        var sutartis = new Sutartis();
        PopulateSelections(sutartis);

        return View(sutartis);
    }

    /// <summary>
    /// This is invoked when buttons are pressed in the creation form.
    /// </summary>
    /// <param name="sutartis">Entity model filled with latest data.</param>
    /// <returns>Returns creation form view or redirects back to Index if save is successful.</returns>
    [HttpPost]
    public ActionResult Create(Sutartis sutartis)
    {
        if (ModelState.IsValid)
        {
            SutartisRepo.Insert(sutartis);
            return RedirectToAction("Index");
        }

        PopulateSelections(sutartis);
        return View(sutartis);
    }

    /// <summary>
    /// This is invoked when editing form is first opened in browser.
    /// </summary>
    /// <param name="numeris">Number of the entity to edit.</param>
    /// <returns>Editing form view.</returns>
    [HttpGet]
    public ActionResult Edit(int numeris)
    {
        var sutartis = SutartisRepo.Find(numeris);
        PopulateSelections(sutartis);

        return View(sutartis);
    }

    /// <summary>
    /// This is invoked when buttons are pressed in the editing form.
    /// </summary>
    /// <param name="numeris">Number of the entity being edited.</param>
    /// <param name="sutartis">Entity model filled with latest data.</param>
    /// <returns>Returns editing form view or redirects back to Index if save is successful.</returns>
    [HttpPost]
    public ActionResult Edit(int numeris, Sutartis sutartis)
    {
        if (ModelState.IsValid)
        {
            SutartisRepo.Update(sutartis);
            return RedirectToAction("Index");
        }

        PopulateSelections(sutartis);
        return View(sutartis);
    }

    /// <summary>
    /// This is invoked when deletion confirmation form is first opened in browser.
    /// </summary>
    /// <param name="numeris">Number of the entity to delete.</param>
    /// <returns>Deletion form view.</returns>
    [HttpGet]
    public ActionResult Delete(int numeris)
    {
        var sutartis = SutartisRepo.Find(numeris);
        return View(sutartis);
    }

    /// <summary>
    /// This is invoked when deletion is confirmed in deletion form.
    /// </summary>
    /// <param name="numeris">Number of the entity to delete.</param>
    /// <returns>Redirects to Index on success or returns to delete form on failure.</returns>
    [HttpPost]
    public ActionResult DeleteConfirm(int numeris)
    {
        try
        {
            SutartisRepo.Delete(numeris);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            var sutartis = SutartisRepo.Find(numeris);
            return View("Delete", sutartis);
        }
    }

    /// <summary>
    /// Populates select lists used to render drop down controls.
    /// </summary>
    /// <param name="sutartis">'Sutartis' model to append to.</param>
    public void PopulateSelections(Sutartis sutartis)
    {
        // list population logic
    }
}
