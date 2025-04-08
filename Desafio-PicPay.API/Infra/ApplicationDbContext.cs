using Desafio_PicPay.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_PicPay.Infra;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<CarteiraEntity> Carteira { get; set; }
    public DbSet<TransferenciaEntity> Transferencia { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CarteiraEntity>()
            .HasIndex(x => new { x.CPFCNPJ, x.Email })
            .IsUnique();
        
        modelBuilder.Entity<CarteiraEntity>()
            .Property(x => x.SaldoConta)
            .HasColumnType("decimal(18, 2)");
        
        modelBuilder.Entity<CarteiraEntity>()
            .Property(x => x.UserType)
            .HasConversion<string>();

        modelBuilder.Entity<TransferenciaEntity>()
            .HasKey(x => x.IdTransferencia);
        
        modelBuilder.Entity<TransferenciaEntity>()
            .HasOne(x => x.Sender)
            .WithMany()
            .HasForeignKey(x => x.SenderId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Transferencia_Sender");
        
        modelBuilder.Entity<TransferenciaEntity>()
            .HasOne(x => x.Receiver)
            .WithMany()
            .HasForeignKey(x => x.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Transferencia_Receiver");
    }
}