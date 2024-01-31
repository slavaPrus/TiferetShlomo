using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TiferetShlomoDAL.Models
{
    public partial class TIFERET_SHLOMOContext : DbContext
    {
        public TIFERET_SHLOMOContext()
        {
        }

        public TIFERET_SHLOMOContext(DbContextOptions<TIFERET_SHLOMOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookPart> BookParts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Flyer> Flyers { get; set; } = null!;
        public virtual DbSet<Joining> Joinings { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<LessonSubject> LessonSubjects { get; set; } = null!;
        public virtual DbSet<LessonType> LessonTypes { get; set; } = null!;
        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<ParashatShavua> ParashatShavuas { get; set; } = null!;
        public virtual DbSet<Picture> Pictures { get; set; } = null!;
        public virtual DbSet<PictureSale> PictureSales { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;
        public virtual DbSet<Tsfile> Tsfiles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-H37566O\\MSSQLSERVER01;Database=TIFERET_SHLOMO;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.BookName).HasMaxLength(100);

                entity.Property(e => e.BookUrl)
                    .HasMaxLength(50)
                    .HasColumnName("BookURL");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Describe).HasMaxLength(300);

                entity.Property(e => e.PictureId).HasColumnName("PictureID");
            });

            modelBuilder.Entity<BookPart>(entity =>
            {
                entity.HasKey(e => e.PartId)
                    .HasName("PK__BookPart__7C3F0D300434B92A");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Describe).HasMaxLength(300);

                entity.Property(e => e.FileId).HasColumnName("FileID");

                entity.Property(e => e.FilePartUrl)
                    .HasMaxLength(50)
                    .HasColumnName("FilePartURL");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookParts)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookParts__BookI__75A278F5");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.BookParts)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FK__BookParts__FileI__3E52440B");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Describe).HasMaxLength(50);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__Contact__AA2FFB853CE241EA");

                entity.ToTable("Contact");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.ContactDate).HasColumnType("date");

                entity.Property(e => e.Describe).HasMaxLength(300);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Flyer>(entity =>
            {
                entity.Property(e => e.FlyerId).HasColumnName("FlyerID");

                entity.Property(e => e.FlyerUrl)
                    .HasMaxLength(50)
                    .HasColumnName("FlyerURL");

                entity.Property(e => e.ParashatShavuaId).HasColumnName("ParashatShavuaID");

                entity.Property(e => e.PictureId).HasColumnName("PictureID");

                entity.Property(e => e.PictureUrl)
                    .HasMaxLength(50)
                    .HasColumnName("PictureURL");

                entity.Property(e => e.PublishDate).HasColumnType("date");

                entity.HasOne(d => d.ParashatShavua)
                    .WithMany(p => p.Flyers)
                    .HasForeignKey(d => d.ParashatShavuaId)
                    .HasConstraintName("FK__Flyers__Parashat__534D60F1");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.Flyers)
                    .HasForeignKey(d => d.PictureId)
                    .HasConstraintName("FK__Flyers__PictureI__5441852A");
            });

            modelBuilder.Entity<Joining>(entity =>
            {
                entity.HasKey(e => e.JoinId)
                    .HasName("PK__Joining__AD6AA8BA06855E33");

                entity.ToTable("Joining");

                entity.Property(e => e.JoinId).HasColumnName("JoinID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Joinings)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Joining__Categor__5AEE82B9");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.Property(e => e.LessonName).HasMaxLength(50);

                entity.Property(e => e.LessonSubjectId).HasColumnName("LessonSubjectID");

                entity.Property(e => e.LessonTypeId).HasColumnName("LessonTypeID");

                entity.Property(e => e.LessonUrl)
                    .HasMaxLength(50)
                    .HasColumnName("LessonURL");

                entity.HasOne(d => d.LessonSubject)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.LessonSubjectId)
                    .HasConstraintName("FK__Lessons__LessonS__4E88ABD4");

                entity.HasOne(d => d.LessonType)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.LessonTypeId)
                    .HasConstraintName("FK__Lessons__LessonT__4D94879B");
            });

            modelBuilder.Entity<LessonSubject>(entity =>
            {
                entity.Property(e => e.LessonSubjectId).HasColumnName("LessonSubjectID");

                entity.Property(e => e.Describe).HasMaxLength(50);
            });

            modelBuilder.Entity<LessonType>(entity =>
            {
                entity.Property(e => e.LessonTypeId).HasColumnName("LessonTypeID");

                entity.Property(e => e.Describe).HasMaxLength(50);
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.Property(e => e.MarkId)
                    .ValueGeneratedNever()
                    .HasColumnName("MarkID");

                entity.Property(e => e.TestId).HasColumnName("TestID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__Marks__TestID__46E78A0C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Marks__TestID__45F365D3");
            });

            modelBuilder.Entity<ParashatShavua>(entity =>
            {
                entity.ToTable("ParashatShavua");

                entity.Property(e => e.ParashatShavuaId).HasColumnName("ParashatShavuaID");

                entity.Property(e => e.Describe).HasMaxLength(50);
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.Property(e => e.PictureId)
                    .ValueGeneratedNever()
                    .HasColumnName("PictureID");

                entity.Property(e => e.PictureName)
                    .HasMaxLength(100)
                    .HasColumnName("pictureName");
            });

            modelBuilder.Entity<PictureSale>(entity =>
            {
                entity.ToTable("PictureSale");

                entity.Property(e => e.PictureSaleId).HasColumnName("PictureSaleID");

                entity.Property(e => e.Describe).HasMaxLength(300);

                entity.Property(e => e.PictureId).HasColumnName("PictureID");

                entity.Property(e => e.PictureSaleName).HasMaxLength(100);

                entity.Property(e => e.PictureUrl)
                    .HasMaxLength(50)
                    .HasColumnName("PictureURL");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.PictureSales)
                    .HasForeignKey(d => d.PictureId)
                    .HasConstraintName("FK__PictureSa__Pictu__5DCAEF64");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.Property(e => e.TestId)
                    .ValueGeneratedNever()
                    .HasColumnName("TestID");

                entity.Property(e => e.Describe).HasMaxLength(300);

                entity.Property(e => e.TestDate).HasColumnType("date");
            });

            modelBuilder.Entity<Tsfile>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__Files__6F0F989F7312D9EC");

                entity.ToTable("TSFiles");

                entity.Property(e => e.FileId)
                    .ValueGeneratedNever()
                    .HasColumnName("FileID");

                entity.Property(e => e.NameFile).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.UserPassword).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
