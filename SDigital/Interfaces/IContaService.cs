using SDigital.Models;
using System.Threading.Tasks;

namespace SDigital.Interfaces
{
    public interface IContaService
    {
        Task<BaseResponse> Transferir(ClienteRouteRequest rota, ClienteBodyRequest corpo);
    }
}