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
    public class RegisterModel : PageModel
    {
        [BindProperty]
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public RegisterModel(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = EmailAddress,
                    UserName = EmailAddress
                };

                var result = await _userManager.CreateAsync(user, Password);

                if (result.Succeeded)
                {
                    return Redirect("/");
                }
            }

            return Page();
        }
    }
}