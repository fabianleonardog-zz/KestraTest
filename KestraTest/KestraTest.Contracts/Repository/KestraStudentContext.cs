using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KestraTest.Contracts.Repository
{
    public partial class KestraStudentContext : DbContext
    {
        public KestraStudentContext(DbContextOptions<KestraStudentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentGrade> StudentGrade { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=localhost;Database=KestraStudent;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentGrade)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GradeStudent_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentGrade)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Subject");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });
        }
    }
}
