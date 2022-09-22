using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.BLL.Models.DTOs
{
    public  class UpdateNoteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [MinLength(3, ErrorMessage = "Name must have at least 3 characters")]
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime UpdateDate => DateTime.Now;
        public bool IsActive => true;
    }
}
