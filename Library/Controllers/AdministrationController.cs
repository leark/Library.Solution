using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Library.Models;
using System.Threading.Tasks;
using Library.ViewModels;
using System.Linq;

namespace Library.Controllers
{
  public class AdministrationController : Controller
  {
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;
    public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
      _roleManager = roleManager;
      _userManager = userManager;
    }

    public IActionResult CreateRole()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
    {
      if (ModelState.IsValid)
      {
        IdentityRole identityRole = new IdentityRole
        {
          Name = model.RoleName
        };
        IdentityResult result = await _roleManager.CreateAsync(identityRole);
        if (result.Succeeded)
        {
          return RedirectToAction("ListRoles");
        }

        foreach(IdentityError error in result.Errors)
        {
          ModelState.AddModelError("", error.Description);
        }
      }
      return View(model);
    }

    public IActionResult ListRoles()
    {
      var roles = _roleManager.Roles;
      return View(roles);
    }

    public async Task<IActionResult> EditRole(string id)
    {
      var role = await _roleManager.FindByIdAsync(id);
      if (role == null)
      {
        ViewBag.ErrorMessage = $"Role with ID = {id} cannot be found";
        return View();
      }
      var model = new EditRoleViewModel
      {
        Id = role.Id,
        RoleName = role.Name
      };
      foreach(var user in _userManager.Users.ToList())
      {
        if (await _userManager.IsInRoleAsync(user, role.Name))
        {
          model.Users.Add(user.UserName);
        }
      }
      return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditRole(EditRoleViewModel model)
    {
      var role = await _roleManager.FindByIdAsync(model.Id);
      if (role == null)
      {
        ViewBag.ErrorMessage = $"Role with ID = {model.Id} cannot be found";
        return View();
      }
      else
      {
        role.Name = model.RoleName;
        var result = await _roleManager.UpdateAsync(role);

        if(result.Succeeded)
        {
          return RedirectToAction("ListRoles");
        }

        foreach(var error in result.Errors)
        {
          ModelState.AddModelError("", error.Description);
        }
        return View(model);
      }
    }
  }
}