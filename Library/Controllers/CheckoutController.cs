// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Mvc;
// using Library.Models;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
// using System.Threading.Tasks;
// using System.Security.Claims;

// namespace Library.Controllers
// {
//   public class CheckoutController : Controller
//   {
    // private readonly LibraryContext _db;
    // private readonly UserManager<ApplicationUser> _userManager;


    // public CheckoutController(UserManager<ApplicationUser> userManager, LibraryContext db)
    // {
    //   _userManager = userManager;
    //   _db = db;
    // }

    // public async Task<ActionResult> Index()
    // {
    //   var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //   var currentUser = await _userManager.FindByIdAsync(userId);
    //   var userCopies = _db.Copies.Where(entry => entry.User.Id == currentUser.Id).ToList();
    //   return View(userCopies);
    // }

    // // [AllowAnonymous]
    // public ActionResult Index()
    // {
    //   return View(_db.Copies.ToList());
    // }

    // public ActionResult Create()
    // {
    //   ViewBag.CheckoutId = new SelectList(_db.Checkout, "CheckoutId", "Title");
    //   return View();
    // }

    // [HttpPost]
    // public async Task<ActionResult> Create(Copy copy, int BookId)
    // {
    //     var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //     var currentUser = await _userManager.FindByIdAsync(userId);
    //     copy.User = currentUser;
    //     _db.Checkout.Add(checkout);
    //     _db.SaveChanges();
    //     if (BookId != 0)
    //     {
    //         _db.Checkout.Add(new Checkout() { BookId = BookId, CopyId = copy.CopyId });
    //     }
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }
//   }
// }