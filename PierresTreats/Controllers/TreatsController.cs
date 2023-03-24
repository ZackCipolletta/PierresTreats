using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PierresTreats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierresTreatsContext _db;
    public TreatsController(PierresTreatsContext db)
    {
      _db = db;
    }

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
    //   if (ModelState.IsValid)
    //   {
        _db.Treats.Add(treat);
        _db.SaveChanges();
        return RedirectToAction("Index");
    //   }
    //   else
    //   {
    //     return View("Create");
    //   }
    }
  }
}
