using System;

namespace SDigital.Entities
{
    public class Conta
    {
        public Guid ContaId { get; set; }
        public string Tipo { get; set; }
        public Guid ClienteId { get; set; }
        public decimal Saldo { get; set; }
    }
}