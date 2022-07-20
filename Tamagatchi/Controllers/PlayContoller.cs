using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

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
    public ActionResult Index(string name, int hunger, int happy, int training, int discipline, int age, int weight)
    {
      BaseTamagatchi user = new BaseTamagachi();
      user.Name = name;
      user.Age = age;
      user.Hunger = hunger;
      user.Happy = happy;
      user.Training = training;
      user.Discipline = discipline;
      user.Weight = weight;
      return RedirectToAction("Index");
    }
  }
}