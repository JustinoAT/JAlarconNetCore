using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class JalarconNetCoreContext : DbContext
{
    public JalarconNetCoreContext()
    {
    }

    public JalarconNetCoreContext(DbContextOptions<JalarconNetCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<RecetaMedica> RecetaMedicas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-GJD4HQTI; Database= JAlarconNetCore;TrustServerCertificate=True; Trusted_Connection=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__C93DB49BDF6D980C");

            entity.ToTable("Paciente");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RecetaMedica>(entity =>
        {
            entity.HasKey(e => e.IdReceta).HasName("PK__RecetaMe__2CEFF15773B19CBB");

            entity.ToTable("RecetaMedica");

            entity.Property(e => e.Diagnostico)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaDeConsulta).HasColumnType("datetime");
            entity.Property(e => e.NombreMedico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NotasAdicionales)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.RecetaMedicas)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IdPaciente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
