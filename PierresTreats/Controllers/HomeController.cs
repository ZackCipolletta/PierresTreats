using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Diagnostics;

namespace PierresTreats.Controllers;

public class HomeController : Controller
{
    private readonly PierresTreatsContext _db;

    public HomeController(PierresTreatsContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.Treats = _db.Treats
                      .ToList();
      ViewBag.Flavors = _db.Flavors
                      .ToList();
      return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
