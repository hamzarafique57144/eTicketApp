using _eTicketSystem.Data.Base;
using _eTicketSystem.Data.Services;
using _eTicketSystem.Data;
using _eTicketSystem.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _eTicketSystem.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {
        }
    }
}
