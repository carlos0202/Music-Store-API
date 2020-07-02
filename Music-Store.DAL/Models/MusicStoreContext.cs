using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Music_Store.DAL.Models
{
    public partial class MusicStoreContext : DbContext
    {
        public MusicStoreContext()
        {
        }

        public MusicStoreContext(DbContextOptions<MusicStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Reproduction> Reproductions { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=Context");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Albums_Artist");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Albums_Genres");
            });

            modelBuilder.Entity<Reproduction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DatePlayed).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Reproductions)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reproductions_Songs");

                entity.HasOne(d => d.SongNavigation)
                    .WithMany(p => p.Reproductions)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reproductions_Users");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.DateReviewed).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Albums");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Users");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Songs_Albums");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Songs_Artist");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Songs_Genres");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.SignUpDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
