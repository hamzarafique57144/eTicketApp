using _eTicketSystem.Data;
using _eTicketSystem.Data.Services;
using _eTicketSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _eTicketSystem.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducersService service;

        public ProducerController(IProducersService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await service.GetAllAsync();
            return View(allProducers);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                await service.AddAsync(producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);

        }
        public async Task<IActionResult> Details(int id)
        {
            var producersDetail = await service.GetByIdAsync(id);
            return View(producersDetail);
            if (producersDetail == null)
            {
                return View("NotFound");
            }
            return View(producersDetail);
        }
    }
}
