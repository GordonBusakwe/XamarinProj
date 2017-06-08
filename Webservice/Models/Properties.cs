using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSProperty4U.Models
{
    public class Properties
    { 
        [Key]
        public int PropId { get; set; }

        [Required(ErrorMessage = "{0} Please enter the Title of the Property")]
        public string PropertyTitle {get; set;}

        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(3000, ErrorMessage = "Must Not Exceed 3000 Char")]
        public string PropDescription { get; set; }


        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "{0} Please enter Number of Baths")]

        public string NumberOfBaths { get; set; }

        /// <summary>
        /// /////////////////////////////////////////
        /// </summary>
        [Required(ErrorMessage = "{0} Please enter Number of Beds")]
       
        public string NumberOfBeds { get; set; }
        /// <summary>
        /// //////////////////////////////////////////
        /// </summary>
        /// 
        ////////////////////////////////////////////////
        [Required(ErrorMessage = "{0} Please enter the location of the property")]
        public string Location { get; set; }

        /// <summary>
        /// ///////////////////////////////////////////////
        /// </summary>

        [MaxLength]
        public byte [] ViewImages { get; set;}


        [MaxLength]
        public byte[] Photo2 { get; set; }


        [MaxLength]
        public byte[] Photo3 { get; set; }


        [MaxLength]
        public byte[] Photo4 { get; set; }
        [Required(ErrorMessage = "{0} Please select if there is a garage or not")]
        public string Garage { get; set; }

        [Required(ErrorMessage = "{0} Please specify the size of Accommodation")]
        public string Size { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


        [MaxLength]
        public byte[] Company { get; set; }


        [Required(ErrorMessage = "{0} Please select property type")]
        public string PropertyType { get; set; }

        [Required(ErrorMessage = "{0} Please enter Township")]
        public string Township { get; set; }

        public string City { get; set; }

 
       
       
        public virtual int Id { get; set; }
        [ForeignKey("Id")]
        public virtual User User { get; set; }
        

      

    }
}