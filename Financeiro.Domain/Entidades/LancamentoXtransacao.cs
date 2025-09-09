namespace Financeiro.Domain.Entidades
{
    public class LancamentoXtransacao
    {
        public Guid Id { get; set; }
        public Guid IdLancamento { get; set; }
        public Lancamento Lancamento { get; set; }
        public Guid IdTransacao { get; set; }
        public Transacao Transacao { get; set; }
    }
}
