using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class SForm
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int formID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [RegularExpression(@"^\d{9}$", ErrorMessage = "The number must be 9 digits.")]
        public int MobileNumber { get; set; }


        public DateTime SubTime{ get; set; }
        public string RequeStstatus { get; set; }

        
    }
}