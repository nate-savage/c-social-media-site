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
        [NotMapped]
        public bool isRT { get; set; }= false;
        [NotMapped]
        public int Reposter { get; set; }
        [NotMapped]
        public double Quality { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public void SetQuality(){
            int age = (int)(DateTime.Now - CreatedAt).TotalSeconds;
            //this gives a half life of 10 minutes
            double k = -.0011552;

            double ageFactor = Math.Exp(age*k);
            // System.Console.WriteLine(ageFactor);
            int likeFactor = 2*(LikedBy.Count+1);

            int shareFactor = 5 * (SharedBy.Count+1);

            Quality = 10000*(likeFactor + shareFactor)*ageFactor;


        }
    }
}