using Microsoft.AspNetCore.Mvc;
using Tamagatchi.Models;
using System.Collections.Generic;

namespace Tamagatchi.Controllers
{
  public class PlayController : Controller
  {
    [HttpGet("/play")]
    public ActionResult Index()
    {
      List<BaseTamagatchi> newTama = BaseTamagatchi.GetAll();
      return View(newTama);
    }

    [HttpGet("/play/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/play")]
    public ActionResult Index(string name)
    {
      BaseTamagatchi user = new BaseTamagatchi(name);
      return RedirectToAction("Index");
    }

    [HttpGet("/play/{id}")]
    public ActionResult Show(int id)
    {
      BaseTamagatchi foundMinion = BaseTamagatchi.Find(id);
      return View(foundMinion);
    }
  }
}