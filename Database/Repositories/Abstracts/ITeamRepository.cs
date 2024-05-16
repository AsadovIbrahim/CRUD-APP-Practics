using Database.Contexts;
using Database.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Abstracts
{
    public interface ITeamRepository:IGenericRepository<TeamUser>
    {
    }
}
