namespace RiskAnalysis.Domain;

public class Transaction
{
    public Guid Id {get; init;}
    public string ContaOrigem {get; init;}
    public string ContaDestino {get; init;}
    public decimal ValorTransacao {get; init;}
    public DateTime DataHora {get; init;}

    public Transaction(string ContaOrigem, string ContaDestino, decimal ValorTransacao)
    {
        this.Id = Guid.NewGuid();
        this.ContaOrigem = ContaOrigem;
        this.ContaDestino = ContaDestino;
        this.ValorTransacao = ValorTransacao;
        this.DataHora = DateTime.Now;
    }
}
