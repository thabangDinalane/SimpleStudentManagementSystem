using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NetFrameworkFA1.Models
{
    public class FacilitatorTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [Index(IsUnique = true)]
        [Column(TypeName = "VARCHAR")]
        public string UserName { get; set; }

        [Required]
        [MinLength(5)]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "The Password and CONFIRMATION Password do not match!")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

      
    }
}