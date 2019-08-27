using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;

namespace WebApp.Pages.Auth
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public LoginModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Email, Password,
                    isPersistent: true,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToPage("Index");
                }
                
                ModelState.AddModelError(string.Empty, "Incorrect username or password");
            }
            
            return Page();
        }
    }
}