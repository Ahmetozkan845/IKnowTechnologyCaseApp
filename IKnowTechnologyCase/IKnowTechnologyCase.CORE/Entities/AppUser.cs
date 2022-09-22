using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.CORE.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public AppUser()
        {
            Notebooks = new HashSet<Notebook>();
        }
        public string FullName { get; set; }
        public DateTime CreationDate { get; set; }= DateTime.Now;   
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Notebook> Notebooks { get; set; }
       

        

    }
}
