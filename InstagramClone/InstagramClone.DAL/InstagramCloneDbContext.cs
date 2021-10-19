using System;
using InstagramClone.DAL.Configurations;
using InstagramClone.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.DAL
{
    public class InstagramCloneDbContext : IdentityDbContext<InstagramUser, IdentityRole<Guid>, Guid>
    {
        public InstagramCloneDbContext(DbContextOptions<InstagramCloneDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserRelation> UserRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserSubscriptionsConfigurations());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            base.OnModelCreating(modelBuilder);
        }


    }
}
