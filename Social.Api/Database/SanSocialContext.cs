using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Social.Api.Database
{
    public partial class SanSocialContext : DbContext
    {
        public SanSocialContext()
        {
        }

        public SanSocialContext(DbContextOptions<SanSocialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SocialComment> SocialComments { get; set; }
        public virtual DbSet<SocialLike> SocialLikes { get; set; }
        public virtual DbSet<SocialPost> SocialPosts { get; set; }
        public virtual DbSet<SocialUser> SocialUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Polish_CS_AI");

            modelBuilder.Entity<SocialComment>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.SocialComments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SocialComment_SocialUser");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SocialComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SocialComment_SocialUser1");
            });

            modelBuilder.Entity<SocialLike>(entity =>
            {
                entity.HasKey(e => e.LikeId)
                    .HasName("PK_Like");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.SocialLikes)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SocialLike_SocialPost");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SocialLikes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Like_SocialUser");
            });

            modelBuilder.Entity<SocialPost>(entity =>
            {
                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SocialPosts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SocialPost_SocialUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
