﻿// <auto-generated />
using System;
using InstagramClone.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InstagramClone.DAL.Migrations
{
    [DbContext(typeof(InstagramCloneDbContext))]
    partial class InstagramCloneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InstagramClone.DAL.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("InstagramClone.DAL.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PostText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("InstagramClone.DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InstagramClone.DAL.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("InstagramClone.DAL.Entities.UserRelations", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RequestedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RequestedToId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestedById");

                    b.HasIndex("RequestedToId");

                    b.ToTable("UserRelations");
                });

            modelBuilder.Entity("InstagramClone.DAL.Entities.Comment", b =>
                {
                    b.HasOne("InstagramClone.DAL.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InstagramClone.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InstagramClone.DAL.Entities.Post", b =>
                {
                    b.HasOne("InstagramClone.DAL.Entities.User", null)
                        .WithMany("Posts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("InstagramClone.DAL.Entities.UserProfile", b =>
                {
                    b.HasOne("InstagramClone.DAL.Entities.User", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("InstagramClone.DAL.Entities.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InstagramClone.DAL.Entities.UserRelations", b =>
                {
                    b.HasOne("InstagramClone.DAL.Entities.User", "RequestedBy")
                        .WithMany("Subscriptions")
                        .HasForeignKey("RequestedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("InstagramClone.DAL.Entities.User", "RequestedTo")
                        .WithMany("Subscribers")
                        .HasForeignKey("RequestedToId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RequestedBy");

                    b.Navigation("RequestedTo");
                });

            modelBuilder.Entity("InstagramClone.DAL.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("InstagramClone.DAL.Entities.User", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("Subscribers");

                    b.Navigation("Subscriptions");

                    b.Navigation("UserProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
