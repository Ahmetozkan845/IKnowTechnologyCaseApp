using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.BLL.Models.VMs
{
    public class DeleteNoteVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}
