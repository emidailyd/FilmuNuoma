namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Org.Ktu.Isk.P175B602.FilmuNuoma.Repositories;
using Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

/// <summary>
/// Controller for working with 'Rezisierius' entity.
/// </summary>
public class RezisieriusController : ControllerBase
{
	[HttpGet]
	public ActionResult Index()
	{
		return View(RezisieriusRepo.List());
	}

	[HttpGet]
	public ActionResult Create()
	{
		return View(new Rezisierius());
	}

	[HttpPost]
	public ActionResult Create(Rezisierius rezisierius)
	{
		if (ModelState.IsValid)
		{
			RezisieriusRepo.Insert(rezisierius);
			return RedirectToAction("Index");
		}
		return View(rezisierius);
	}

	[HttpGet]
	public ActionResult Edit(int id)
	{
		var rezisierius = RezisieriusRepo.Find(id);
		return View(rezisierius);
	}

	[HttpPost]
	public ActionResult Edit(int id, Rezisierius rezisierius)
	{
		if (ModelState.IsValid)
		{
			RezisieriusRepo.Update(rezisierius);
			return RedirectToAction("Index");
		}
		return View(rezisierius);
	}

	[HttpGet]
	public ActionResult Delete(int id)
	{
		var rezisierius = RezisieriusRepo.Find(id);
		return View(rezisierius);
	}

	[HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		try
		{
			RezisieriusRepo.Delete(id);
			return RedirectToAction("Index");
		}
		catch (MySql.Data.MySqlClient.MySqlException)
		{
			ViewData["deletionNotPermitted"] = true;
			var rezisierius = RezisieriusRepo.Find(id);
			return View("Delete", rezisierius);
		}
	}
}
