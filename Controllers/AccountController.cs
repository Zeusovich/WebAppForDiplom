using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAppForDiplom.Context;
using WebAppForDiplom.Models;

namespace WebAppForDiplom.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
                
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            var user1 = new User
            {
                UserName = "User1",
                FirstName = "Danya"
            };

            var result1 = _userManager.CreateAsync(user1, "123456789").GetAwaiter().GetResult();

            if (result1.Succeeded)
            {
                _userManager.AddClaimAsync(user1,new Claim(ClaimTypes.Role , "Administrator")).GetAwaiter().GetResult();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }  

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("UserName", "User not found");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password,false,false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }

            return View(model); 
            /*var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,model.UserName),
                new Claim(ClaimTypes.Role, "Administrator")
            };
            var claimIdentity = new ClaimsIdentity(claims,"Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);*/
            
        }

        
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }    
}
