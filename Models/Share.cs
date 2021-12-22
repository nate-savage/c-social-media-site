using System;
using System.ComponentModel.DataAnnotations;



namespace FinalProject.Models
{
    public class Share
    {
        [Key]
        public int ShareId { get; set; }

        public int PostId { get; set; }
        public TextPost Post { get; set; }
        public int SharerId { get; set; }
        public User Sharer { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}