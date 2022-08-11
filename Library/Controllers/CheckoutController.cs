using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
  public class CheckoutController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;


    public CheckoutController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }


    public ActionResult Index(int id)
    {
      List<Checkout> model = _db.Checkout.ToList();
      return View(model);
    }

    [HttpPost]
    public ActionResult Index(Copy copy, int PatronId)
    {
        int copyId = copy.CopyId;

        var thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == copyId);
        _db.Checkout.Add(new Checkout() { PatronId = PatronId, CopyId = copy.CopyId });
        _db.SaveChanges();
        return RedirectToAction("Checkout", "Books");
    }
    
    
    public ActionResult Create()
    {
      ViewBag.PatronId = new SelectList(_db.Patrons, "PatronId", "PatronName");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Patron patron, int CopyId)
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        // patron.User = currentUser;
        _db.Patrons.Add(patron);
        _db.SaveChanges();
        if (CopyId != 0)
        {
            // _db.Checkout.Add(new Checkout() { PatronId = PatronId, CopyId = copy.CopyId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisCheckout = _db.Checkout.FirstOrDefault(c => c.CheckoutId == id);
      return View(thisCheckout);
    }


  }
}