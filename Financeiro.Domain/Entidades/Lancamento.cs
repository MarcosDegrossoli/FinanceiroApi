namespace Financeiro.Domain.Entidades
{
    public class Lancamento
    {
        public Guid IdLancamento { get; set; }
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public Guid IdConta { get; set; }
        public Conta Conta { get; set; }
    }
}
