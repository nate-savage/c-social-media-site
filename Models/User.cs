using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace FinalProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(2,ErrorMessage ="Name too short!")]
        
        public string DisplayName { get; set; }
        [Required]
        [MinLength(2,ErrorMessage ="Handle too short!")]
        public string Handle { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Must be a valid email address.")]
        public string Email { get; set; }
        [Required]
        [MinLength(8,ErrorMessage ="Password must be at least 8 charachters.")]
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage ="Passwords must match.")]
        public string Confirm { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}