using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PierresTreats.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly PierresTreatsContext _db;
    public FlavorsController(PierresTreatsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Flavors.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
    //   if (ModelState.IsValid)
    //   {
        _db.Flavors.Add(flavor);
        _db.SaveChanges();
        return RedirectToAction("Index");
    //   }
    //   else
    //   {
    //     return View("Create");
    //   }
    }


    public ActionResult Edit(int id)
    {
      Flavor thisFlavor = _db.Flavors
                              .Include(Flavor => Flavor.JoinEntities)
                              .ThenInclude(join => join.Treat)
                              .FirstOrDefault(flavors => flavors.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Flavors.Update(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}