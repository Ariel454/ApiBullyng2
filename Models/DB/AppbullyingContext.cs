using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiBullyng2.Models.DB;

public partial class AppbullyingContext : DbContext
{
    public AppbullyingContext()
    {
    }

    public AppbullyingContext(DbContextOptions<AppbullyingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cuento> Cuentos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Formulario> Formularios { get; set; }

    public virtual DbSet<Informacion> Informacions { get; set; }

    public virtual DbSet<Institucion> Institucions { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<Pagina> Paginas { get; set; }

    public virtual DbSet<Preguntum> Pregunta { get; set; }

    public virtual DbSet<Respuestum> Respuesta { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cuento>(entity =>
        {
            entity.HasKey(e => e.IdCuento).HasName("PK_ID_Cuento");

            entity.ToTable("Cuento");

            entity.Property(e => e.IdCuento).HasColumnName("id_Cuento");
            entity.Property(e => e.IdInstitucionF).HasColumnName("id_InstitucionF");
            entity.Property(e => e.TituloCuento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tituloCuento");

            entity.HasOne(d => d.IdInstitucionFNavigation).WithMany(p => p.Cuentos)
                .HasForeignKey(d => d.IdInstitucionF)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_Institucion2");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK_ID_Curso");

            entity.ToTable("Curso");

            entity.Property(e => e.IdCurso).HasColumnName("id_Curso");
            entity.Property(e => e.IdInstitucionF).HasColumnName("id_InstitucionF");
            entity.Property(e => e.Nivel).HasColumnName("nivel");
            entity.Property(e => e.Paralelo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("paralelo");

            entity.HasOne(d => d.IdInstitucionFNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdInstitucionF)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_Institucion1");
        });

        modelBuilder.Entity<Formulario>(entity =>
        {
            entity.HasKey(e => e.IdFormulario).HasName("PK_ID_Formulario");

            entity.ToTable("Formulario");

            entity.Property(e => e.IdFormulario).HasColumnName("id_Formulario");
            entity.Property(e => e.Detalle)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.Fecha)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("fecha");
            entity.Property(e => e.IdUsuarioF).HasColumnName("id_UsuarioF");
            entity.Property(e => e.TituloCaso)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tituloCaso");

            entity.HasOne(d => d.IdUsuarioFNavigation).WithMany(p => p.Formularios)
                .HasForeignKey(d => d.IdUsuarioF)
                .HasConstraintName("FK_ID_Usuario3");
        });

        modelBuilder.Entity<Informacion>(entity =>
        {
            entity.HasKey(e => e.IdInformacion).HasName("PK_ID_Informacion");

            entity.ToTable("Informacion");

            entity.Property(e => e.IdInformacion).HasColumnName("id_Informacion");
            entity.Property(e => e.IdInstitucionF).HasColumnName("id_InstitucionF");
            entity.Property(e => e.Texto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("texto");
            entity.Property(e => e.TituloInfo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tituloInfo");

            entity.HasOne(d => d.IdInstitucionFNavigation).WithMany(p => p.Informacions)
                .HasForeignKey(d => d.IdInstitucionF)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_Institucion");
        });

        modelBuilder.Entity<Institucion>(entity =>
        {
            entity.HasKey(e => e.IdInstitucion).HasName("PK_ID_Institucion");

            entity.ToTable("Institucion");

            entity.Property(e => e.IdInstitucion).HasColumnName("id_Institucion");
            entity.Property(e => e.Info)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("info");
            entity.Property(e => e.Logo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("logo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasKey(e => e.IdMensaje).HasName("PK_ID_Mensaje");

            entity.ToTable("Mensaje");

            entity.Property(e => e.IdMensaje).HasColumnName("id_Mensaje");
            entity.Property(e => e.Foto)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("foto");
            entity.Property(e => e.IdUsuarioF).HasColumnName("id_UsuarioF");
            entity.Property(e => e.Latitud)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("latitud");
            entity.Property(e => e.Longitud)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("longitud");
            entity.Property(e => e.Texto)
                .IsUnicode(false)
                .HasColumnName("texto");
            entity.Property(e => e.Video)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("video");

            entity.HasOne(d => d.IdUsuarioFNavigation).WithMany(p => p.Mensajes)
                .HasForeignKey(d => d.IdUsuarioF)
                .HasConstraintName("FK_ID_Usuario2");
        });

        modelBuilder.Entity<Pagina>(entity =>
        {
            entity.HasKey(e => e.IdPagina).HasName("PK_ID_Pagina");

            entity.ToTable("Pagina");

            entity.Property(e => e.IdPagina).HasColumnName("id_Pagina");
            entity.Property(e => e.IdCuentoF).HasColumnName("id_CuentoF");
            entity.Property(e => e.Texto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("texto");

            entity.HasOne(d => d.IdCuentoFNavigation).WithMany(p => p.Paginas)
                .HasForeignKey(d => d.IdCuentoF)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_Cuento");
        });

        modelBuilder.Entity<Preguntum>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PK_ID_Pregunta");

            entity.Property(e => e.IdPregunta).HasColumnName("id_Pregunta");
            entity.Property(e => e.IdTestF).HasColumnName("id_TestF");
            entity.Property(e => e.TextoPregunta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("textoPregunta");

            entity.HasOne(d => d.IdTestFNavigation).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.IdTestF)
                .HasConstraintName("FK_ID_Test");
        });

        modelBuilder.Entity<Respuestum>(entity =>
        {
            entity.HasKey(e => e.IdRespuesta).HasName("PK_ID_Respuesta");

            entity.Property(e => e.IdRespuesta).HasColumnName("id_Respuesta");
            entity.Property(e => e.IdPreguntaF).HasColumnName("id_PreguntaF");
            entity.Property(e => e.TextoRespuesta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("textoRespuesta");

            entity.HasOne(d => d.IdPreguntaFNavigation).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.IdPreguntaF)
                .HasConstraintName("FK_ID_Pregunta");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.IdTest).HasName("PK_ID_Test");

            entity.ToTable("Test");

            entity.Property(e => e.IdTest).HasColumnName("id_Test");
            entity.Property(e => e.IdUsuarioF).HasColumnName("id_UsuarioF");
            entity.Property(e => e.NombreTest)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreTest");

            entity.HasOne(d => d.IdUsuarioFNavigation).WithMany(p => p.Tests)
                .HasForeignKey(d => d.IdUsuarioF)
                .HasConstraintName("FK_ID_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_ID_Usuario");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.NombreUsuario, "UK_NombreUsuario").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Genero).HasColumnName("genero");
            entity.Property(e => e.IdCursoF).HasColumnName("id_CursoF");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreUsuario");
            entity.Property(e => e.Rol).HasColumnName("rol");

            entity.HasOne(d => d.IdCursoFNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdCursoF)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_Curso");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
