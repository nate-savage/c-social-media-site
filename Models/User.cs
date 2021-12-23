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
        
        [RegularExpression(@"^\w+$",ErrorMessage ="No spaces or symbols allowed.")]
        [MinLength(2,ErrorMessage ="Handle too short!")]
        public string Handle { get; set; }
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",ErrorMessage ="Must be a valid email.")]
        public string Email { get; set; }
        [Required]
        [MinLength(8,ErrorMessage ="Password must be at least 8 charachters.")]
        //add pword regex
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage ="Passwords must match.")]
        public string Confirm { get; set; }
        [NotMapped]
        public List<Follow> Follows { get; set; }
        [NotMapped]
        public int NumFollowers { get; set; }
        [NotMapped]
        public int NumFollowing { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}