using Desafio_PicPay.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Desafio_PicPay.Repository.Transferencia;

public interface ITransferenciaRepository
{
    Task AddTransaction(TransferenciaEntity transferencia);
    
    Task CommitAsync();
    
    Task <IDbContextTransaction> BeginTransactionAsync();
}