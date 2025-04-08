using Desafio_PicPay.Infra;
using Desafio_PicPay.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Desafio_PicPay.Repository.Transferencia;

public class TransferenciaRepository : ITransferenciaRepository
{
    private readonly ApplicationDbContext _context;

    public TransferenciaRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task AddTransaction(TransferenciaEntity transferencia)
    {
        await _context.Transferencia.AddAsync(transferencia);
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }
}