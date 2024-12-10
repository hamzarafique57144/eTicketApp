using _eTicketSystem.Data.Base;
using _eTicketSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace _eTicketSystem.Data.Services
{
    public class ActorsService :EntityBaseRepository<Actor>, IActorService
    {


        public ActorsService(AppDbContext context) : base(context) { }
        
        
    }
}
