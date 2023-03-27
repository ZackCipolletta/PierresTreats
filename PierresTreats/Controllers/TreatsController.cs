using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace PierresTreats.Controllers
{
  
  [Authorize(Roles = "Admin")]
  public class TreatsController : Controller
  {
    private readonly PierresTreatsContext _db;
    public TreatsController(PierresTreatsContext db)
    {
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      return View(_db.Treats.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }
    

    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      if (ModelState.IsValid)
      {
        _db.Treats.Add(treat);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      else
      {
        return View("Create");
      }
    }

        public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats
                              .Include(Treat => Treat.JoinEntities)
                              .ThenInclude(join => join.Flavor)
                              .FirstOrDefault(treats => treats.TreatId == id);
              ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
              ViewBag.FlavorCount = ((SelectList)ViewBag.FlavorId).Count();
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
        _db.Treats.Update(treat);
        _db.SaveChanges();
        return RedirectToAction("Edit");
    }

[HttpPost]
    public ActionResult AddFlavor(Treat treat, int flavorId)
    {
#nullable enable
      treat = _db.Treats.FirstOrDefault(t => t.TreatId == treat.TreatId);  
      FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(join => (join.FlavorId == flavorId && join.TreatId == treat.TreatId));
#nullable disable
      if (joinEntity == null && flavorId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = flavorId, TreatId = treat.TreatId });
        _db.Treats.Update(treat);
        _db.SaveChanges();
      }
      return RedirectToAction("Edit", new { id = treat.TreatId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      FlavorTreat joinEntity = _db.FlavorTreats.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
        _db.FlavorTreats.Remove(joinEntity);
        _db.SaveChanges();
      return RedirectToAction("Index");
    }

      public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
                              .Include(treat => treat.JoinEntities)
                              .ThenInclude(join => join.Flavor)
                              .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }
  }
}
