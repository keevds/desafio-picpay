using Desafio_PicPay.Infra;
using Desafio_PicPay.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_PicPay.Repository.Carteiras;

public class CarteiraRepository : ICarteiraRepository
{
   private readonly ApplicationDbContext _context;
    
    public CarteiraRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(CarteiraEntity carteira)
    {
        await _context.AddAsync(carteira);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CarteiraEntity carteira)
    {
        _context.Update(carteira);
        await _context.SaveChangesAsync();
    }
    
    public async Task<CarteiraEntity?> GetByCpfCnpj(string cpfCnpj, string email)
    {
        return await _context.Carteira.FirstOrDefaultAsync(carteira =>
            carteira.CPFCNPJ == cpfCnpj || carteira.Email == email);
    }
    
    public async Task<CarteiraEntity?> GetById(int id)
    {
        return await _context.Carteira.FindAsync(id);
    }
    
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}