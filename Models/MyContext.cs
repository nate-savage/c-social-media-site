using System;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options): base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<TextPost> TextPosts { get; set; }
        public DbSet<Follow> Follows {get;set;}
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Like> Likes {get; set;}
        public DbSet<Share> Shares { get; set; }
        
        
    }
}