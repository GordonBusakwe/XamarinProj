using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSProperty4U.Models
{
    public class Developments
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Please enter the Title of the Property")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(3000, ErrorMessage = "Must Not Exceed 3000 Char")]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public string PropertyType { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "{0} Please enter the location of the property")]
        public string Location { get; set; }

        [MaxLength]
        public byte[] Image { get; set; }


        [MaxLength]
        public byte[] Photo2 { get; set; }


        [MaxLength]
        public byte[] Photo3 { get; set; }


        [MaxLength]
        public byte[] Photo4 { get; set; }
    }
}