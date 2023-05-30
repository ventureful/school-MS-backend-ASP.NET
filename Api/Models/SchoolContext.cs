using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentTodo.Api.Models
{
    public class SchoolContext: DbContext
    {

        public DbSet<Student> Student { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                connectionString: "User ID=postgres;Password=rkdwkrkehlfk;Host=localhost;Port=5432;Database=db_school_management;Pooling=true;"); 
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(e => e.ToTable("tb_student"));
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                                    .HasColumnName("student_id");
                entity.Property(e => e.Name).IsRequired().HasColumnName("student_name");
                entity.Property(e => e.Title).HasColumnName("student_title");
                entity.Property(e => e.Description).HasColumnName("student_description");
                entity.Property(e => e.Gender).HasColumnName("student_gender");
            });

            base.OnModelCreating(modelBuilder);
        } 
    }
}