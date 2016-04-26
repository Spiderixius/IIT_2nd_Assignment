using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IIT_2nd_Assignment_admur13.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

/// <summary>
/// A lot of what is made here is made from inspiration from the existing AccountController.cs and ManageController.cs
/// Lots of inspiration from https://docs.asp.net/en/latest/tutorials/first-mvc-app/ aswell.
/// Furhtermore, since by default the user can be edited (by the logged in user), I have simply chosen to list all users and simply
/// reuse the editting method. This is also why I have not made a model for the usersList, since users are stored in the db already.
/// </summary>

namespace IIT_2nd_Assignment_admur13.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _appDbContext;

        // Just a Constructor 
        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appDbContext = appDbContext;
        }

        // Here I check id with the logged in user and the user I want to modify
        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await _userManager.FindByIdAsync(HttpContext.User.GetUserId());
        }

        // GET: /Users/UsersList/
        [HttpGet]
        [Authorize]
        public IActionResult UsersList()
        {
            List<ApplicationUser> users = _userManager.Users.ToList();
            return View(users);

        }

        // This method is to actually navigate to the Delete screen
        // GET: /Users/DeleteUser/
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteUser(string id)
        {

            if (id == null)
                RedirectToAction("UsersList");
            var user = await GetCurrentUserAsync();
            if (id != user.Id)
                RedirectToAction("UsersList");
            return View(user);

        }

        // This method is to actually delete the user
        // POST: /Users/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    RedirectToAction("UsersList");
                }

                ApplicationUser user = await GetCurrentUserAsync();

                if (user.Id == id)
                {
                    var logins = user.Logins;
                    foreach (var login in logins)
                    {
                        _appDbContext.UserLogins.Remove(login);
                    }
                    await _signInManager.SignOutAsync();
                    _appDbContext.Users.Remove(user);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("UsersList");
                }
            }
            else
            {
                return View();
            }
        }

    }
}
