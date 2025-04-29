namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Org.Ktu.Isk.P175B602.FilmuNuoma.Repositories;
using Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

/// <summary>
/// Controller for working with 'Preke' entity.
/// </summary>
public class PrekeController : ControllerBase
{
    /// <summary>
    /// This is invoked when either 'Index' action is requested or no action is provided.
    /// </summary>
    /// <returns>Entity list view.</returns>
    [HttpGet]
    public ActionResult Index()
    {
        return View(PrekeRepo.List());
    }

    /// <summary>
    /// This is invoked when creation form is first opened in browser.
    /// </summary>
    /// <returns>Creation form view.</returns>
    [HttpGet]
    public ActionResult Create()
    {
        return View(new Preke());
    }

    /// <summary>
    /// This is invoked when buttons are pressed in the creation form.
    /// </summary>
    /// <param name="preke">Entity model filled with latest data.</param>
    /// <returns>Returns creation form view or redirects back to Index if save is successful.</returns>
    [HttpPost]
    public ActionResult Create(Preke preke)
    {
        if (ModelState.IsValid)
        {
            PrekeRepo.Insert(preke);
            return RedirectToAction("Index");
        }
        return View(preke);
    }

    /// <summary>
    /// This is invoked when editing form is first opened in browser.
    /// </summary>
    /// <param name="id">ID of the entity to edit.</param>
    /// <returns>Editing form view.</returns>
    [HttpGet]
    public ActionResult Edit(int id)
    {
        var preke = PrekeRepo.Find(id);
        return View(preke);
    }

    /// <summary>
    /// This is invoked when buttons are pressed in the editing form.
    /// </summary>
    /// <param name="id">ID of the entity being edited</param>
    /// <param name="preke">Entity model filled with latest data.</param>
    /// <returns>Returns editing form view or redirects back to Index if save is successful.</returns>
    [HttpPost]
    public ActionResult Edit(int id, Preke preke)
    {
        if (ModelState.IsValid)
        {
            PrekeRepo.Update(preke);
            return RedirectToAction("Index");
        }
        return View(preke);
    }

    /// <summary>
    /// This is invoked when deletion form is first opened in browser.
    /// </summary>
    /// <param name="id">ID of the entity to delete.</param>
    /// <returns>Deletion form view.</returns>
    [HttpGet]
    public ActionResult Delete(int id)
    {
        var preke = PrekeRepo.Find(id);
        return View(preke);
    }

    /// <summary>
    /// This is invoked when deletion is confirmed in deletion form.
    /// </summary>
    /// <param name="id">ID of the entity to delete.</param>
    /// <returns>Deletion form view on error, redirects to Index on success.</returns>
    [HttpPost]
    public ActionResult DeleteConfirm(int id)
    {
        try
        {
            PrekeRepo.Delete(id);
            return RedirectToAction("Index");
        }
        catch (MySql.Data.MySqlClient.MySqlException)
        {
            ViewData["deletionNotPermitted"] = true;
            var preke = PrekeRepo.Find(id);
            return View("Delete", preke);
        }
    }
}
