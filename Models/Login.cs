using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public class Login
    {
        [Required]
        [Display(Name ="Email or Handle (case sensitive)")]
        public string LogEmail { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string LogPassword { get; set; }
    
    }
}