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
     public class NotebookRepository: BaseRepository<Notebook>, INotebookRepository
    {
        public NotebookRepository(AppDbContext db) : base(db)
        {

        }
    }
}
