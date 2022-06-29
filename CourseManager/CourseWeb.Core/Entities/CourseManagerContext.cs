using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CourseWeb.Core.Entities
{
    public partial class CourseManagerContext : DbContext
    {
        public CourseManagerContext()
        {
        }

        public CourseManagerContext(DbContextOptions<CourseManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ConfigSystem> ConfigSystems { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseCategory> CourseCategories { get; set; }
       
        public virtual DbSet<New> News { get; set; }
        public virtual DbSet<NewCategory> NewCategories { get; set; }
        public virtual DbSet<PaymentOfCouse> PaymentOfCouses { get; set; }
   
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ADMIN;Database=CourseManager;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId).ValueGeneratedNever();

                entity.Property(e => e.ClassCode).HasMaxLength(50);

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TeacherName).HasMaxLength(50);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Class_Teacher");
            });

            modelBuilder.Entity<ConfigSystem>(entity =>
            {
                entity.HasKey(e => e.SystemId);

                entity.ToTable("ConfigSystem");

                entity.Property(e => e.SystemId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Hotline1).HasMaxLength(50);

                entity.Property(e => e.Hotline2).HasMaxLength(50);

                entity.Property(e => e.IdNo).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.Property(e => e.Information).HasMaxLength(2000);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.TitleDefault).HasMaxLength(500);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CourseName).HasMaxLength(500);

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.CourseCategory)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CourseCategoryId)
                    .HasConstraintName("FK_Course_CourseCategory");

                entity.HasOne(d => d.Teachers)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Course_Teacher");
            });

            modelBuilder.Entity<CourseCategory>(entity =>
            {
                entity.ToTable("CourseCategory");

                entity.Property(e => e.CourseCategoryId).ValueGeneratedNever();

                entity.Property(e => e.CourseCategoryName).HasMaxLength(500);

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.Createdate).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

          

            modelBuilder.Entity<New>(entity =>
            {
                entity.ToTable("New");

                entity.Property(e => e.NewId).ValueGeneratedNever();

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.LastEditBy).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.NewCategory)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.NewCategoryId)
                    .HasConstraintName("FK_New_NewCategory");
            });

            modelBuilder.Entity<NewCategory>(entity =>
            {
                entity.ToTable("NewCategory");

                entity.Property(e => e.NewCategoryId).ValueGeneratedNever();

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.Createdate).HasColumnType("datetime");

                entity.Property(e => e.NewCategoryName).HasMaxLength(500);

                entity.Property(e => e.UpdateBy).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PaymentOfCouse>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("PaymentOfCouse");

                entity.Property(e => e.PaymentId).ValueGeneratedNever();

                entity.Property(e => e.ContentPayment).HasMaxLength(500);

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Money).HasColumnType("money");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.PaymentOfCouses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_PaymentOfCouse_Course");

                entity.HasOne(d => d.Students)
                    .WithMany(p => p.PaymentOfCouses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentOfCouse_Student");
            });

          

           
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.CreateBy).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Know)
                    .HasMaxLength(50)
                   ;

                entity.Property(e => e.Level)
                    .HasMaxLength(50);
         

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.StudentCode).HasMaxLength(50);

                entity.Property(e => e.StudentName).HasMaxLength(250);

                entity.Property(e => e.UpdateBy).HasMaxLength(250);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Student_Class");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Regular).HasColumnName("regular");

                entity.Property(e => e.Say).HasColumnName("say");

                entity.Property(e => e.TeacherCode).HasMaxLength(50);

                entity.Property(e => e.TeacherName).HasMaxLength(250);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

         
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
