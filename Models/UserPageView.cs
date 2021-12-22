using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public class UserPageView
    {
        public User PageOwner { get; set; }
        public bool follows {get;set;}
        public List<TextPost> TLPosts { get; set; }
        public User SiteUser   { get; set; }
    }
}