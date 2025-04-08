using Desafio_PicPay.Models;

namespace Desafio_PicPay.Repository.Carteiras;

public interface ICarteiraRepository
{
    Task AddAsync(CarteiraEntity carteira);
    
    Task UpdateAsync(CarteiraEntity carteira);

    Task<CarteiraEntity?> GetByCpfCnpj(string cpfCnpj, string email);

    Task<CarteiraEntity?> GetById(int id);

    Task CommitAsync();
}