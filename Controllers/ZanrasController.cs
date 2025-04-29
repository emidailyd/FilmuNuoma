namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Controllers;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for working with 'Zanras' entity.
/// </summary>
public class ZanrasController : ControllerBase
{
	/// <summary>
	/// This is invoked when either 'Index' action is requested or no action is provided.
	/// </summary>
	/// <returns>Entity list view.</returns>
	[HttpGet]
	public ActionResult Index()
	{
		return View(ZanrasRepo.List());
	}

	/// <summary>
	/// This is invoked when creation form is first opened in browser.
	/// </summary>
	/// <returns>Creation form view.</returns>
	[HttpGet]
	public ActionResult Create()
	{
		return View(new Zanras());
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the creation form.
	/// </summary>
	/// <param name="zanras">Entity model filled with latest data.</param>
	/// <returns>Returns creation form view or redirects back to Index if save is successful.</returns>
	[HttpPost]
	public ActionResult Create(Zanras zanras)
	{
		if (ModelState.IsValid)
		{
			ZanrasRepo.Insert(zanras);
			return RedirectToAction("Index");
		}
		return View(zanras);
	}

	/// <summary>
	/// This is invoked when editing form is first opened in browser.
	/// </summary>
	/// <param name="id">ID of the entity to edit.</param>
	/// <returns>Editing form view.</returns>
	[HttpGet]
	public ActionResult Edit(int id)
	{
		var zanras = ZanrasRepo.Find(id);
		return View(zanras);
	}

	/// <summary>
	/// This is invoked when buttons are pressed in the editing form.
	/// </summary>
	/// <param name="id">ID of the entity being edited</param>		
	/// <param name="zanras">Entity model filled with latest data.</param>
	/// <returns>Returns editing form view or redirects back to Index if save is successful.</returns>
	[HttpPost]
	public ActionResult Edit(int id, Zanras zanras)
	{
		if (ModelState.IsValid)
		{
			ZanrasRepo.Update(zanras);
			return RedirectToAction("Index");
		}
		return View(zanras);
	}

	/// <summary>
	/// This is invoked when deletion is confirmed in deletion form.
	/// </summary>
	/// <param name="id">ID of the entity to delete.</param>
	/// <returns>Deletion form view.</returns>
	[HttpGet]
	public ActionResult Delete(int id)
	{
		var zanras = ZanrasRepo.Find(id);
		return View(zanras);
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
			ZanrasRepo.Delete(id);
			return RedirectToAction("Index");
		}
		catch (MySql.Data.MySqlClient.MySqlException)
		{
			ViewData["deletionNotPermitted"] = true;
			var zanras = ZanrasRepo.Find(id);
			return View("Delete", zanras);
		}
	}
}
