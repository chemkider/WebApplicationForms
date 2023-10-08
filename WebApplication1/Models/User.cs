using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User
    {
        [Required]
        public string UserName { set; get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}