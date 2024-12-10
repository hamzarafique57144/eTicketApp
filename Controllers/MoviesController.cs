using _eTicketSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _eTicketSystem.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext context;

        public MoviesController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await context.Movies.Include(n=>n.Cinema).OrderBy(n =>n.Name).ToListAsync();
            return View(data);
        }
    }
}
