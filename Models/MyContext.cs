using System;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options): base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Follow> Follows {get;set;}
        public DbSet<Reply> Replies { get; set; }
        
        
    }
}