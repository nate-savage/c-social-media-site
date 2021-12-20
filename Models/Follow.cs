using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Follow
    {
        [Key]
        public int FollowId { get; set; }
        public int FollowerId { get; set; }
        public User Follower { get; set; }
        public int FolloweeId { get; set; }
        public User Followee { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
