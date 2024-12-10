using _eTicketSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace _eTicketSystem.Controllers
{
    public class CinemaController : Controller
    {
        private readonly AppDbContext context;

        public CinemaController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await context.Cinemas.ToListAsync();
            return View(allCinemas);
        }
    }
}
