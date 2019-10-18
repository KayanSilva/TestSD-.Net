using System;

namespace SDigital.Models
{
    public class ClienteBodyRequest
    {
        public Guid ContaOrigem { get; set; }
        public Guid ContaDestino { get; set; }
        public decimal Valor { get; set; }
    }
}