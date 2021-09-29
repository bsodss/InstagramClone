using System;
using InstagramClone.DAL.Configurations;
using InstagramClone.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.DAL
{
    public class InstagramCloneDbContext : DbContext
    {
        public InstagramCloneDbContext(DbContextOptions<InstagramCloneDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserRelations> UserRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserSubscriptionsConfigurations());
            base.OnModelCreating(modelBuilder);
        }


    }
}
