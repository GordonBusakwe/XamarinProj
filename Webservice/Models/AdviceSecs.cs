using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSProperty4U.Models
{
    public class AdviceSecs
    {
        [Key]
        public int AID{ get; set; }

        [Required(ErrorMessage = "Please Enter New Title")]
        [StringLength(1000, ErrorMessage = "Must Not Exceed 30 Char")]
        public string ATitle { get; set; }


        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(3000, ErrorMessage = "Must Not Exceed 3000 Char")]
        public string ADescription { get; set; }

        [MaxLength]
        public byte[] APhoto { get; set; }
    }
}