using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public class HomeView
    {
        public TimeLine timeLine { get; set; }
        public TextPost newPost { get; set; }
        public User SiteUser { get; set; }
    
    }
}