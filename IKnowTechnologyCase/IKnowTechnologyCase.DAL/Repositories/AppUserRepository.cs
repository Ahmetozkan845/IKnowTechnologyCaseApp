using IKnowTechnologyCase.CORE.Entities;
using IKnowTechnologyCase.CORE.IRepositories;
using IKnowTechnologyCase.DAL.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.DAL.Repositories
{
    public class AppUserRepository:BaseRepository<AppUser>,IAppUserRepository
    {
        public AppUserRepository(AppDbContext db):base(db)
        {

        }
    }
}
