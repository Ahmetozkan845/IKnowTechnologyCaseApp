using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.BLL.Models.VMs
{
    public  class GetNoteVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}
