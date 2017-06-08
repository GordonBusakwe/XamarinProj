using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSProperty4U.Models
{
    public class Rental
    {
        [Key]
        public int RID { get; set; }


        [Required(ErrorMessage = "{0} Please enter the Title of the Property")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(2000, ErrorMessage = "Must Not Exceed 2000 Char")]
        public string RentalDescription { get; set; }
    

        [Required(ErrorMessage = "{0} is required")]
        public string PropertyType { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal RentPrice { get; set; }
    



        [DataType(DataType.Date)]
        public DateTime OccupationDate { get; set; }


        [Required(ErrorMessage = "{0} Please enter number of Baths")]
     
        public string NumberOfBaths { get; set; }


        [Required(ErrorMessage = "{0} Please enter number of Beds")]
       
        public string NumberOfBeds { get; set; }



        [Required(ErrorMessage = "{0} Please enter the Location of the Property")]
        public string RProvince { get; set; }


  
        [MaxLength]
        public byte[] Images { get; set; }

        [MaxLength]
        public byte[]Image2 { get; set; }

        [MaxLength]
        public byte[]Image3 { get; set; }

        [MaxLength]
        public byte[]Image4 { get; set; }
        [MaxLength]
        public byte[] RCompany { get; set; }

        [Required(ErrorMessage = "{0} Please Select Garage")]
        public string RGarage { get; set; }

        [Required(ErrorMessage = "{0} Please enter the size of the room")]
        public string RSize { get; set; }

        

        [Required(ErrorMessage = "{0} Please enter township or suburb")]
        public string RTownship { get; set; }


        [Required(ErrorMessage = "{0} Please enter the city")]
        public string RCity { get; set; }
        public virtual int Id { get; set; }
        [ForeignKey("Id")]
        public virtual User User { get; set; }
    }
}