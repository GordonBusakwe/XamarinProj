using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSProperty4U.Models
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }

        [Required]
       
        [Display(Name = "Please enter Username")]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PASSWORD { get; set; }
    }
}