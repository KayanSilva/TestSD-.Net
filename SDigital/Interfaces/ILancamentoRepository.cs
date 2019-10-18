using SDigital.Entities;
using System.Threading.Tasks;

namespace SDigital.Interfaces
{
    public interface ILancamentoRepository
    {
        Task<int> Inserir(Lancamento lancamento);
    }
}