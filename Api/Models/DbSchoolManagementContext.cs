using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentTodo.Api.Models;

public partial class DbSchoolManagementContext : DbContext
{
    public DbSchoolManagementContext()
    {
    }

    public DbSchoolManagementContext(DbContextOptions<DbSchoolManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbStudentList> TbStudentLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=db_school_management;Username=postgres;Password=rkdwkrkehlfk;Pooling=true");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbStudentList>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("tb_student_list_pkey");

            entity.ToTable("tb_student_list");

            entity.Property(e => e.StudentId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("student_id");
            entity.Property(e => e.StudentDescription).HasColumnName("student_description");
            entity.Property(e => e.StudentGender).HasColumnName("student_gender");
            entity.Property(e => e.StudentName).HasColumnName("student_name");
            entity.Property(e => e.StudentTitle).HasColumnName("student_title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
