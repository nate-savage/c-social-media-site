using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace FinalProject.Models
{
    public class TextPost
    {
        [Key]
        public int TextPostId { get; set; }

        [Required(ErrorMessage ="You have to say something!")]
        [StringLength(140,ErrorMessage ="140 charachters or less.")]
        public string Text { get; set; }
        [Required]
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public List<Like> LikedBy {get;set;}
        public List<Share> SharedBy { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}