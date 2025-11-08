using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL;

    public partial class AHernandezPruebaContex : DbContext
    {
        public AHernandezPruebaContex()
        {
        }

        public AHernandezPruebaContex(DbContextOptions<AHernandezPruebaContex> options)
            : base(options)
        {
        }

        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=GWTN141-10;Initial Catalog=DLAHernandezPrueba;Integrated Security=True;TrustServerCertificate=True; ");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.IdTarea).HasName("PK__Tarea__IdTarea");

                entity.ToTable("Tarea");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);                 
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdStatusNavigation)
                .WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK_Tarea_Status");
            });
            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus).HasName("PK__Status__IdStatus");

                entity.ToTable("Status");

                entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            });

        OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    
    
