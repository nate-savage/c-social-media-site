using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string LogEmail { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string LogPassword { get; set; }
    
    }
}