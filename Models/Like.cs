using System;
using System.ComponentModel.DataAnnotations;



namespace FinalProject.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        public int PostId { get; set; }
        public TextPost Post { get; set; }
        public int LikerId { get; set; }
        public User Liker { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}