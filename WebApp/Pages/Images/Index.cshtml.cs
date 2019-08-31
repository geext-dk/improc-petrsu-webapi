using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Images
{
    public class IndexModel : PageModel
    {
        public List<ImageDto> Images { get; set; }
        [Authorize]
        public void OnGet()
        {
            Images = new List<ImageDto>();
        }

        public async Task OnPostAsync()
        {
        }
    }

    public class ImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
    }
}