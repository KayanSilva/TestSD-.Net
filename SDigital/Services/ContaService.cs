using AutoMapper;
using Microsoft.AspNetCore.Http;
using SDigital.Entities;
using SDigital.Interfaces;
using SDigital.Models;
using System.Threading.Tasks;

namespace SDigital.Services
{
    public class ContaService : IContaService
    {
        IContaRepository _contaRepository;
        ILancamentoRepository _lancamentoRepository;
        IMapper _mapper;
        public ContaService(IMapper mapper,IContaRepository contaRepository, ILancamentoRepository lancamentoRepository)
        {
            _mapper = mapper;
            _contaRepository = contaRepository;
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<BaseResponse> Transferir(ClienteRouteRequest rota, ClienteBodyRequest corpo)
        {
            var contaCredito = await _contaRepository.Obter(corpo.ContaOrigem);
            if (contaCredito == null)
                return new BaseResponse { StatusCode = StatusCodes.Status400BadRequest, Mensagem = "Conta inexistente." };

            var contaDebito = await _contaRepository.Obter(corpo.ContaDestino);
            if (contaDebito == null)
                return new BaseResponse { StatusCode = StatusCodes.Status400BadRequest, Mensagem = "Conta inexistente." };
            else if (corpo.Valor > contaDebito.Saldo)
                return new BaseResponse { StatusCode = StatusCodes.Status400BadRequest, Mensagem = "Saldo insufiente. " };

            contaDebito.Saldo -= corpo.Valor;
            contaCredito.Saldo += corpo.Valor;
            var lancamento = _mapper.Map<Lancamento>(contaCredito);

            await Task.WhenAll(_contaRepository.AlterarSaldo(contaCredito.ContaId, contaCredito.Saldo),
                _contaRepository.AlterarSaldo(contaDebito.ContaId, contaDebito.Saldo), _lancamentoRepository.Inserir(lancamento));

            return new BaseResponse { StatusCode = StatusCodes.Status200OK };
        }
    }
}