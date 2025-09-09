namespace Financeiro.Domain.Entidades
{
    public class Conta
    {
        public Guid IdConta { get; set; }
        public string NumeroConta { get; set; }
        public Guid IdBanco { get; set; }
        public Banco Banco { get; set; }
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
