using AutoMapper;
using SDigital.Entities;
using System;

namespace SDigital.Mappers
{
    public class LancamentoProfile : Profile
    {
        public LancamentoProfile()
        {
            CreateMap<Conta, Lancamento>()
                .ForMember(dest => dest.DataHora, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => "T"))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Saldo))
                .ForMember(dest => dest.LancamentoId, opt => opt.Ignore());
        }
    }
}