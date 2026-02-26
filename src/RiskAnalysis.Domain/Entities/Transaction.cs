using RiskAnalysis.Domain.Enums;

namespace RiskAnalysis.Domain;

public class Transaction
{
    public Guid Id {get; init;}
    public string ContaOrigem {get; init;}
    public string ContaDestino {get; init;}
    public decimal ValorTransacao {get; init;}
    public DateTime DataHora {get; init;}
    public TransactionStatus Status {get; private set;}
    public string? MotivoRejeicao {get; private set;}

    public Transaction(string ContaOrigem, string ContaDestino, decimal ValorTransacao)
    {   
        if (string.IsNullOrWhiteSpace(ContaOrigem) || string.IsNullOrWhiteSpace(ContaDestino))
            throw new ArgumentException("As contas de origem e destino são obrigatórias.");

        if (ContaOrigem == ContaDestino)
            throw new ArgumentException("A conta de origem não pode ser igual à de destino.");

        if (ValorTransacao <= 0)
            throw new ArgumentException("O valor da transação deve ser maior que zero.");

        this.Id = Guid.NewGuid();
        this.ContaOrigem = ContaOrigem;
        this.ContaDestino = ContaDestino;
        this.ValorTransacao = ValorTransacao;
        this.DataHora = DateTime.UtcNow;
        this.Status = TransactionStatus.Pendente;
        this.MotivoRejeicao = MotivoRejeicao;
    }

    public void Accept()
    {   
        if (this.Status != TransactionStatus.Pendente)
            throw new ArgumentException("Apenas transações pendentes podem ser aprovadas.");
        
        this.Status = TransactionStatus.Aprovada;
    }

    public void Reject(string motivo)
    {   
        if (Status != TransactionStatus.Pendente)
            throw new InvalidOperationException("Apenas transações pendentes podem ser rejeitadas.");

        this.Status = TransactionStatus.Rejeitada;
        this.MotivoRejeicao = motivo;
    }
}
