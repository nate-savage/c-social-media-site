using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public class TimeLineView
    {
        public List<TextPost> TLPosts { get; set; }
        public TextPost newPost { get; set; }
        public User SiteUser { get; set; }
    
    }
}