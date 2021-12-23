using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Follow
    {
        [Key]
        public int FollowId { get; set; }
        [ForeignKey("Follower")]
        public int FollowerId { get; set; }
        [NotMapped]
        public User Follower { get; set; }
        [ForeignKey("Followee")]
        public int FolloweeId { get; set; }
        public User Followee { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
