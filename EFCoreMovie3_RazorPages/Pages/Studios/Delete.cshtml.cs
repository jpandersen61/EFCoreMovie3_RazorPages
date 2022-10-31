using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCoreMovie3_RazorPages.Services.Interfaces;
using EFCoreMovie3_RazorPages.Models;

namespace EFCoreMovie3_RazorPages.Pages.Studios
{
    public class DeleteModel : PageModel
    {
        private IStudioService studioService;

        public DeleteModel(IStudioService service)
        {
            studioService = service;
        }

        [BindProperty]
        public Studio Studio { get; set; }
        
        public IActionResult OnGet(int id)
        {
            Studio = studioService.GetStudioById(id); 
            return Page();
        }

        public IActionResult OnPost()
        {
            studioService.DeleteStudio(Studio);
            return RedirectToPage("GetStudios");
        }
    }
}

