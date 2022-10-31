using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCoreMovie3_RazorPages.Services.Interfaces;
using EFCoreMovie3_RazorPages.Models;

namespace EFCoreMovie3_RazorPages.Pages.Movies
{
    public class CreateModel : PageModel
    {
        IMovieService movieService { get; set; }
        public CreateModel(IMovieService service)
        {
            movieService = service;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public void OnGet(int id)
        {
            Movie = new Movie()
            {
                 StudioId = id,
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            movieService.AddMovie(Movie);

            return RedirectToPage("GetMovies");
        }
    }
}
