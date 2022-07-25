using Microsoft.AspNetCore.Mvc;
using Tamagatchi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Tamagatchi.Controllers
{
  public class PlayController : Controller
  {
    [HttpGet("/play")]
    public ActionResult Index()
    {
      return View();
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
      user.Save();
      return RedirectToAction("Index");
    }

    [HttpPost("/play/{id}/update")]        //6
    public ActionResult Show(int id)
    { 
      BaseTamagatchi foundMinion = BaseTamagatchi.Find(id);
      foundMinion.Feed();
      foundMinion.MakeHappy();
      foundMinion.GetAge();
      return View(foundMinion);
    }

    [HttpGet("/play/{id}")]
    public ActionResult Show(int id, string button)
    {
      BaseTamagatchi foundMinion = BaseTamagatchi.Find(id);
      foundMinion.Timer();
      return View(foundMinion);
    }

  }
}