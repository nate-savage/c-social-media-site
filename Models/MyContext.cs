using System;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options): base(options){}
        public DbSet<User> Users { get; set; }
        
        
    }
}