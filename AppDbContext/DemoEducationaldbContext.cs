using System;
using System.Collections.Generic;
using DemoMvc.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DemoMvc.AppDbContext;

public partial class DemoEducationaldbContext : DbContext
{
    public DemoEducationaldbContext()
    {
    }

    public DemoEducationaldbContext(DbContextOptions<DemoEducationaldbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Courseentrollment> Courseentrollments { get; set; }

    public virtual DbSet<Cousre> Cousres { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Reference> References { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=demo_educationaldb;user=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.1.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Courseentrollment>(entity =>
        {
            entity.HasKey(e => new { e.CousreCourseId, e.StudentStudetId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("courseentrollments");

            entity.HasIndex(e => e.CousreCourseId, "fk_cousre_has_student_cousre1_idx");

            entity.HasIndex(e => e.StudentStudetId, "fk_cousre_has_student_student1_idx");

            entity.Property(e => e.CousreCourseId).HasColumnName("cousre_CourseId");
            entity.Property(e => e.StudentStudetId).HasColumnName("student_StudetId");
            entity.Property(e => e.Degree).HasColumnName("degree");

            entity.HasOne(d => d.CousreCourse).WithMany(p => p.Courseentrollments)
                .HasForeignKey(d => d.CousreCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cousre_has_student_cousre1");

            entity.HasOne(d => d.StudentStudet).WithMany(p => p.Courseentrollments)
                .HasForeignKey(d => d.StudentStudetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cousre_has_student_student1");
        });

        modelBuilder.Entity<Cousre>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PRIMARY");

            entity.ToTable("cousre");

            entity.HasIndex(e => e.InstructorId, "fk_Cousre_Instructor_idx");

            entity.HasIndex(e => e.ReferenceRefId, "fk_Cousre_Reference1_idx");

            entity.Property(e => e.CrsCategory).HasMaxLength(45);
            entity.Property(e => e.CrsName).HasMaxLength(45);
            entity.Property(e => e.FullMark)
                .HasDefaultValueSql("'100'")
                .HasColumnName("fullMark");
            entity.Property(e => e.Hours)
                .HasPrecision(10)
                .HasColumnName("hours");
            entity.Property(e => e.ReferenceRefId).HasColumnName("Reference_RefId");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Cousres)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cousre_Instructor");

            entity.HasOne(d => d.ReferenceRef).WithMany(p => p.Cousres)
                .HasForeignKey(d => d.ReferenceRefId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cousre_Reference1");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("PRIMARY");

            entity.ToTable("instructor");

            entity.Property(e => e.InstAddress).HasMaxLength(45);
            entity.Property(e => e.InstName).HasMaxLength(45);
            entity.Property(e => e.InstPhone).HasMaxLength(45);
        });

        modelBuilder.Entity<Reference>(entity =>
        {
            entity.HasKey(e => e.RefId).HasName("PRIMARY");

            entity.ToTable("reference");

            entity.Property(e => e.RefName).HasMaxLength(45);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudetId).HasName("PRIMARY");

            entity.ToTable("student");

            entity.Property(e => e.StdAddress).HasMaxLength(45);
            entity.Property(e => e.StdName).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
