using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QueueManagement.Common.Config.Interface;

#nullable disable

namespace QueueManagement.DAL.QueueManagementDb.Entity
{
    public partial class QueueManagementContext : DbContext
    {
        //public IConnectionStringConfig connectionStringConfig;
        public QueueManagementContext(/*IConnectionStringConfig connectionStringConfig*/)
        {
            //this.connectionStringConfig = connectionStringConfig;
        }

        public QueueManagementContext(DbContextOptions<QueueManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Queue> Queues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=QueueManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.HasIndex(e => new { e.Identity, e.ProducerId }, "NonClusteredIndex-20210908-094356")
                    .IsUnique();

                entity.Property(e => e.BodyBinary).IsRequired();

                entity.Property(e => e.BodyJson).IsRequired();

                entity.Property(e => e.Identity)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.InsertedAt).HasColumnType("datetime");

                entity.Property(e => e.InsertedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Producer");

                entity.HasOne(d => d.Queue)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.QueueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Queue");

                entity.HasOne(d => d.RelatedMessage)
                    .WithMany(p => p.InverseRelatedMessage)
                    .HasForeignKey(d => d.RelatedMessageId)
                    .HasConstraintName("FK_Message_Message1");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.ToTable("Producer");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NameEN");

                entity.Property(e => e.NameFa).HasMaxLength(50);
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
