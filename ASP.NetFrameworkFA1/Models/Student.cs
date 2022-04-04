using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NetFrameworkFA1.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "FirstName Required")]
        public string FirstName { get; set; }

        [Required (ErrorMessage = "LastName Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address1 Required")]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        //Need to confrim
        public string Email { get; set; }
       


    }
}