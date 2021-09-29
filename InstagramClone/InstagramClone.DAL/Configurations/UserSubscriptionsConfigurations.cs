using System;
using System.Collections.Generic;
using System.Text;
using InstagramClone.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InstagramClone.DAL.Configurations
{
    public class UserSubscriptionsConfigurations : IEntityTypeConfiguration<UserRelations>
    {
        public void Configure(EntityTypeBuilder<UserRelations> builder)
        {
            builder.HasOne(o => o.RequestedBy)
                .WithMany(m => m.Subscriptions)
                .HasForeignKey(f => f.RequestedById).OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(o => o.RequestedTo)
                .WithMany(m => m.Subscribers)
                .HasForeignKey(f => f.RequestedToId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
