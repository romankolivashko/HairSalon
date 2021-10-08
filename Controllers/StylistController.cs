using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylist.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist Stylist)
    {
      _db.Stylist.Add(Stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Stylist thisStylist = _db.Stylist.FirstOrDefault(Stylist => Stylist.StylistId == id);
      return View(thisStylist);
    }
    public ActionResult Edit(int id)
    {
      var thisStylist = _db.Stylist.FirstOrDefault(Stylist => Stylist.StylistId == id);
      return View(thisStylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylist Stylist)
    {
      _db.Entry(Stylist).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisStylist = _db.Stylist.FirstOrDefault(Stylist => Stylist.StylistId == id);
      return View(thisStylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStylist = _db.Stylist.FirstOrDefault(Stylist => Stylist.StylistId == id);
      _db.Stylist.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Search()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Search(string name)
    {
      string searchName = name.ToLower();
      List<Stylist> searchResults = _db.Stylist.Where(stylist => stylist.Name.ToLower().Contains(searchName)).ToList();
      return View("Index", searchResults);
    }
  }
}