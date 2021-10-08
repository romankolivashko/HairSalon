using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Clinet> model = _db.Client.Include(Client => Client.Stylist).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.StylistId = new SelectList(_db.Stylist, "StylistId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Client Client)
    {
      _db.Clinet.Add(Client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Clinet
       thisClient = _db.Client.FirstOrDefault(Client => Client.ClientId == id);
      return View(thisClient);
    }

    public ActionResult Edit(int id)
    {
      var thisClient = _db.Clinet.FirstOrDefault(Client => Client.ClientId == id);
      ViewBag.StylistId = new SelectList(_db.Stylist, "StylistId", "Name");
      return View(thisClient);
    }

    [HttpPost]
    public ActionResult Edit(Client Client)
    {
      _db.Entry(Client).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisClient = _db.Clinet.FirstOrDefault(Client => Client.ClientId == id);
      return View(thisClient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisClient = _db.Clinet.FirstOrDefault(Client => Client.ClientId == id);
      _db.Clinet.Remove(thisClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Search()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Search(string description)
    {
      string searchDescription = description.ToLower();
      List<Clinet
      > searchResults = _db.Clinet.Where(Client => Client.Description.ToLower().Contains(searchDescription)).ToList();
      return View("Index", searchResults);
    }
  }
}