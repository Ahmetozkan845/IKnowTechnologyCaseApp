using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.BLL.Models.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="Enter Full Name")]
        //[MinLength(3,ErrorMessage ="Name must have at least 3 characters")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Enter Username")]
        //[MinLength(3, ErrorMessage = "Username must have at least 3 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        //[MinLength(3, ErrorMessage = "Password must have at least 3 characters")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Repeat Password")]
        //[MinLength(3, ErrorMessage = "Both passwords must have at least 3 characters")]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
       
        public DateTime CreationDate => DateTime.Now;
        public bool IsActive => true;
    }
}
