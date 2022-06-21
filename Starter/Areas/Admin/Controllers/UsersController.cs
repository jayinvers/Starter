using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Starter.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Starter.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public UsersController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
    }

        public async Task<IActionResult> Index()
        {

            var everyone = await _userManager.Users.ToListAsync();

            return View(everyone);
        }

        public async Task<IActionResult> Groups()
        {

            var groups = await _roleManager.Roles.ToListAsync();

            return View(groups);
        }
    }
}
