using SDigital.Entities;
using System;
using System.Threading.Tasks;

namespace SDigital.Interfaces
{
    public interface IContaRepository
    {
        Task<Conta> Obter(Guid contaId);

        Task<int> AlterarSaldo(Guid contaId, decimal valor);
    }
}