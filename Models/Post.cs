using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace FinalProject.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [MinLength(1,ErrorMessage ="Must Have Something")]
        public string Text { get; set; }
        [Required]
        public int CreaterId { get; set; }
        public User Creator { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}