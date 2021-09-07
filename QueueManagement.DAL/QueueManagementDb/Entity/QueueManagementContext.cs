using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QueueManagement.DAL.QueueManagementDb.Entity
{
    public partial class QueueManagementContext : DbContext
    {
        public QueueManagementContext()
        {
        }

        public QueueManagementContext(DbContextOptions<QueueManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Queue> Queues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=QueueManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NameEN");

                entity.Property(e => e.NameFa).HasMaxLength(50);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.BodyBinary).IsRequired();

                entity.Property(e => e.BodyJson).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Identity)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Client");

                entity.HasOne(d => d.Queue)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.QueueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Queue");
            });

            modelBuilder.Entity<Queue>(entity =>
            {
                entity.ToTable("Queue");

                entity.Property(e => e.Description).HasMaxLength(400);

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NameEN");

                entity.Property(e => e.NameFa).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
