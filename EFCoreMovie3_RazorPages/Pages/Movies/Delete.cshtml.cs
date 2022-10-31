using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EFCoreMovie3_RazorPages.Services.Interfaces;
using EFCoreMovie3_RazorPages.Models;

namespace EFCoreMovie3_RazorPages.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private IMovieService movieService;

        public DeleteModel(IMovieService service)
        {
            movieService = service;
        }

        [BindProperty]
        public Movie Movie { get; set; }
        public void OnGet(int id)
        {
            Movie = movieService.GetMovieById(id);
        }

        public IActionResult OnPost()
        {
            movieService.DeleteMovie(Movie);
            return RedirectToPage("GetMovies");
        }
    }
}
