using System;

namespace SDigital.Entities
{
    public class Lancamento
    {
        public Guid LancamentoId { get; set; }
        public DateTime DataHora { get; set; }
        public char Tipo { get; set; }
        public Guid ContaId { get; set; }
        public decimal Valor { get; set; }
    }
}