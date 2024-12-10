using _eTicketSystem.Data;
using _eTicketSystem.Data.Services;
using _eTicketSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _eTicketSystem.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService service;

        public ActorController(IActorService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await service.GetAllAsync();
            return View(data);
        }

        //Get request Actors/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); // For debugging
                }
                await service.AddAsync(actor);
                return RedirectToAction(nameof(Index));


            }
            return View(actor);

        }

        
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("id,FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
               


                await service.UpdateAsync(id, actor);
                return RedirectToAction(nameof(Index));

            }
            return View(actor);
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
