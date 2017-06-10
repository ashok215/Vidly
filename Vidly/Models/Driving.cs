using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Driving: IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string DrivingLicense { get; set; }
    }
}