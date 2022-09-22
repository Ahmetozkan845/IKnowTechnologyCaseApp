using IKnowTechnologyCase.CORE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.BLL.Models.DTOs
{
    public class CreateNoteDTO
    {
        [Required(ErrorMessage = "Enter Name")]
        [MinLength(3, ErrorMessage = "Name must have at least 3 characters")]
        public string Title { get; set; }
       
        public string Description { get; set; }
        public DateTime CreationDate => DateTime.Now;
        public bool IsActive => true;
       
        public string UserId { get; set; }
    }
}
