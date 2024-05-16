using Database.Contexts;
using Database.Entities.Concretes;
using Database.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Concretes
{
    public class TeamRepository : GenericRepository<TeamUser>, ITeamRepository
    {
        public TeamRepository(AppDbContext context) : base(context)
        {
        }
    }
}
