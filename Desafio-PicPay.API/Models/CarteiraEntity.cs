using Desafio_PicPay.Models.Enum;

namespace Desafio_PicPay.Models;

public class CarteiraEntity
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string CPFCNPJ { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public decimal SaldoConta { get; set; }
    public UserType UserType { get; set; }

    public CarteiraEntity(string nomeCompleto, string cpfcnpj, string email, string senha, UserType userType, decimal saldoConta = 0)
    {
        NomeCompleto = nomeCompleto;
        CPFCNPJ = cpfcnpj;
        Email = email;
        Senha = senha;
        UserType = userType;
        SaldoConta = saldoConta;
    }
    
    private CarteiraEntity(){}

    public void DebitarSaldo(decimal valor)
    {
        SaldoConta -= valor;
    }
    
    public void CreditarSaldo(decimal valor)
    {
        SaldoConta += valor;
    }
}