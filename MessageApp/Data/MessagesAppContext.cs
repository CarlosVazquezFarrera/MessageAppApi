using System;
using System.Collections.Generic;
using MessageApp.Enetities;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Data;

public partial class MessagesAppContext : DbContext
{
    public MessagesAppContext()
    {
    }

    public MessagesAppContext(DbContextOptions<MessagesAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("messages_pkey");

            entity.ToTable("messages");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Studentid).HasColumnName("studentid");
            entity.Property(e => e.Text)
                .HasColumnType("character varying")
                .HasColumnName("text");

            entity.HasOne(d => d.Student).WithMany(p => p.Messages)
                .HasForeignKey(d => d.Studentid)
                .HasConstraintName("fk_student_messages");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("student_pkey");

            entity.ToTable("student");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Clave)
                .HasColumnType("character varying")
                .HasColumnName("clave");
            entity.Property(e => e.Nombre)
                .HasColumnType("character varying")
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
