namespace Financeiro.Domain.Entidades
{
    public class Transacao
    {
        public Guid IdTransacao { get; set; }
        public string Comentario { get; set; }
        public Guid IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
