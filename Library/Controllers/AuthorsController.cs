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
  public class AuthorsController : Controller
  {
    private readonly LibraryContext _db;

    public AuthorsController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "View All Authors";
      return View(_db.Authors.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add New Author";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Author author)
    {
      if (_db.Authors.FirstOrDefault(a => a.Name == author.Name) == null)
      {
        _db.Authors.Add(author);
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Author author = _db.Authors.FirstOrDefault(a => a.AuthorId == id);
      ViewBag.PageTitle = $"Author {author.Name}";

      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
      return View(author);
    }

    [HttpPost]
    public ActionResult Details(AuthorBook ab)
    {
      if (_db.AuthorBook.FirstOrDefault(a => a.AuthorId == ab.AuthorId && a.BookId == ab.BookId) == null)
      {
        _db.AuthorBook.Add(ab);
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = ab.AuthorId });
    }

    public ActionResult Edit(int id)
    {
      Author author = _db.Authors.FirstOrDefault(a => a.AuthorId == id);
      ViewBag.PageTitle = $"Edit {author.Name}";
      return View(author);
    }

    [HttpPost]
    public ActionResult Edit(Author author)
    {
      _db.Entry(author).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = author.AuthorId });
    }

    public ActionResult Delete(int id)
    {
      Author author = _db.Authors.FirstOrDefault(a => a.AuthorId == id);
      ViewBag.PageTitle = $"Delete {author.Name}?";
      return View(author);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult Deleted(int id)
    {
      Author author = _db.Authors.FirstOrDefault(a => a.AuthorId == id);
      _db.Authors.Remove(author);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteAuthor(int authorBookId)
    {
      var ab = _db.AuthorBook.FirstOrDefault(a => a.AuthorBookId == authorBookId);
      if (ab != null)
      {
        _db.AuthorBook.Remove(ab);
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = ab.AuthorId });
    }
  }
}