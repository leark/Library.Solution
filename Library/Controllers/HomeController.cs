using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.PageTitle = "Home";
      return View();
    }
  }
}