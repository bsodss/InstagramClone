using System;
using InstagramClone.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.DAL
{
    public class InstagramCloneDbContext : DbContext
    {
        public InstagramCloneDbContext(DbContextOptions<InstagramCloneDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            //Database.EnsureCreated();
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
