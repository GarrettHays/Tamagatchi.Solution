using Microsoft.AspNetCore.Mvc;
using Tamagatchi.Models;
using System;
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
      // if (button == "feed")    
      // {
      //   if (foundMinion.Hunger < 10 && foundMinion.Hunger > 0)
      //   {
      //     foundMinion.Hunger = foundMinion.Hunger + 1;
      //     foundMinion.CheckFood = "You fed " + foundMinion.Name;
      //   }
      //   else if (foundMinion.Hunger == 10)
      //   {
      //     foundMinion.CheckFood = foundMinion.Name + " is full!";
      //   }
      //   else
      //   {
      //     foundMinion.CheckFood = foundMinion.Name + " is " + foundMinion.Status + " you can't feed a corpse.";
      //   }
      // }
      foundMinion.Feed();
      foundMinion.MakeHappy();
      return View(foundMinion);
    }
                      //6
    // [HttpPost("/play/{id}")]        //6
    // public ActionResult FeedTest()
    // { 

    //   //else if (button == "fappy")
    //   return RedirectToAction("Show");
    // }

  }
}