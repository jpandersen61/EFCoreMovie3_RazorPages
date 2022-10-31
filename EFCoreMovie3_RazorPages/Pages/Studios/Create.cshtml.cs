using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCoreMovie3_RazorPages.Models;
using EFCoreMovie3_RazorPages.Services.Interfaces;

namespace EFCoreMovie3_RazorPages.Pages.Studios
{
    public class CreateModel : PageModel
    {
        private IStudioService studioService;

        public CreateModel(IStudioService service)
        {
            studioService = service;
        }

        [BindProperty]
        public Studio Studio { get; set; } 
        public void OnGet()
        {
            Studio studio = new Studio();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            studioService.AddStudio(Studio);

            return RedirectToPage("GetStudios");
        }
    }
}
