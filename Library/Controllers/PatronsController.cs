using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;

//user directives
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;


namespace Library.Controllers
{
  public class PatronsController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;


    public PatronsController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "View All Patrons";
      return View(_db.Patrons.ToListAsync());
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add new Patron";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Patron patron)
    {
      if (_db.Patrons.FirstOrDefault(p => p.PatronName == patron.PatronName) == null)
      {
        _db.Patrons.Add(patron);
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Patron patron = _db.Patrons.FirstOrDefault(p => p.PatronId == id);
      ViewBag.PageTitle = $"Patron {patron.PatronName}";

      return View(patron);
    }

    public ActionResult Delete(int id)
    {
      Patron patron = _db.Patrons.FirstOrDefault(p => p.PatronId == id);
      return View(patron);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Patron patron = _db.Patrons.FirstOrDefault(p => p.PatronId == id);
      _db.Patrons.Remove(patron);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}