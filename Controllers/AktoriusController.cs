namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Org.Ktu.Isk.P175B602.FilmuNuoma.Repositories;
using Org.Ktu.Isk.P175B602.FilmuNuoma.Models;

/// <summary>
/// Controller for working with 'Aktorius' entity.
/// </summary>
public class AktoriusController : ControllerBase
{
	[HttpGet]
	public ActionResult Index()
	{
		return View(AktoriusRepo.List());
	}

	[HttpGet]
	public ActionResult Create()
	{
		return View(new Aktorius());
	}

	[HttpPost]
	public ActionResult Create(Aktorius aktorius)
	{
		if (ModelState.IsValid)
		{
			AktoriusRepo.Insert(aktorius);
			return RedirectToAction("Index");
		}
		return View(aktorius);
	}

	[HttpGet]
	public ActionResult Edit(int id)
	{
		var aktorius = AktoriusRepo.Find(id);
		return View(aktorius);
	}

	[HttpPost]
	public ActionResult Edit(int id, Aktorius aktorius)
	{
		if (ModelState.IsValid)
		{
			AktoriusRepo.Update(aktorius);
			return RedirectToAction("Index");
		}
		return View(aktorius);
	}

	[HttpGet]
	public ActionResult Delete(int id)
	{
		var aktorius = AktoriusRepo.Find(id);
		return View(aktorius);
	}

	[HttpPost]
	public ActionResult DeleteConfirm(int id)
	{
		try
		{
			AktoriusRepo.Delete(id);
			return RedirectToAction("Index");
		}
		catch (MySql.Data.MySqlClient.MySqlException)
		{
			ViewData["deletionNotPermitted"] = true;
			var aktorius = AktoriusRepo.Find(id);
			return View("Delete", aktorius);
		}
	}
}
