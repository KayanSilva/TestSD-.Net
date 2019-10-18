using AutoMapper;
using SDigital.Mappers;
using Xunit;

namespace SDigitalTest.Mappers
{
    public class LancamentoProfileTest
    {
        private readonly MapperConfiguration config;

        public LancamentoProfileTest() => config = new MapperConfiguration(cfg => cfg.AddProfile<LancamentoProfile>());

        [Fact]
        public void T001_TesteConfigMapper() => config.AssertConfigurationIsValid();
    }
}