using BrokerService.Core.Data.Repositories.Base;
using BrokerService.Domain.Entities;
using BrokerService.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BrokerService.Core.Data.Repositories
{
    public class PlanoRepo : Repository<Plano>, IPlanoRepo
    {
        public PlanoRepo(DbContext context) : base(context)
        {
        }
    }
}