namespace Financeiro.Domain.Entidades
{
    public class LancamentoXtransacao
    {
        public Guid Id { get; set; }
        public Guid IdLancamento { get; set; }
        public Guid IdTransacao { get; set; }
    }
}
