using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Library.Controllers
{
  public class HomeController : Controller
  {
    private readonly LibraryContext _db;

    public HomeController(LibraryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      ViewBag.PageTitle = "Home";
      return View();
    }

    public async Task<IActionResult> Index(string searchString)
    {
      var books = from b in _db.Books select b;
      if (!String.IsNullOrEmpty(searchString))
      {
        books = books.Where(s => s.Title!.Contains(searchString));
      }
      return View(await books.ToListAsync());
    }
  }
}