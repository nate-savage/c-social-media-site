using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }
        public int OrigId { get; set; }
        public Post Orig { get; set; }
        public int ResponseId { get; set; }
        public Post Response { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
