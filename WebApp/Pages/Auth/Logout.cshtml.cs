using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;

namespace MyApp.Namespace
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        public LogoutModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult OnGet()
        {
            return NotFound();
        }

        public async Task OnPostASync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}