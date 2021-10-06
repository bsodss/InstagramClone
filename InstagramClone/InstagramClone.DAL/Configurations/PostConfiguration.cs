using System;
using System.Collections.Generic;
using System.Text;
using InstagramClone.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstagramClone.DAL.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(s => s.Posts)
                .HasForeignKey(k => k.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
