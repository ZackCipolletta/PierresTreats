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
              ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
              ViewBag.TreatCount = ((SelectList)ViewBag.TreatId).Count();
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Flavors.Update(flavor);
      _db.SaveChanges();
      return RedirectToAction("Edit", new { id = flavor.FlavorId});
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int treatId)
    {
#nullable enable
      flavor = _db.Flavors.FirstOrDefault(flav => flav.FlavorId == flavor.FlavorId);  
      FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(join => (join.TreatId == treatId && join.FlavorId == flavor.FlavorId));
#nullable disable
      if (joinEntity == null && treatId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { TreatId = treatId, FlavorId = flavor.FlavorId });
        _db.Flavors.Update(flavor);
        _db.SaveChanges();
      }
      return RedirectToAction("Edit", new { id = flavor.FlavorId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      FlavorTreat joinEntity = _db.FlavorTreats.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
        _db.FlavorTreats.Remove(joinEntity);
        _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}