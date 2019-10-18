using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SDigital.Controllers;
using SDigital.Interfaces;
using AutoFixture;
using SDigital.Models;
using System;
using Xunit;
using NSubstitute.ExceptionExtensions;
using Microsoft.AspNetCore.Http;

namespace SDigitalTest.Controllers
{
    public class ContasControllerTests
    {
        protected readonly Fixture fixture;
        protected readonly IContaService _service;
        protected readonly ContasController _controller;
        ClienteRouteRequest _clienteRouteRequest;
        ClienteBodyRequest _clienteBodyRequest;
        BaseResponse _baseResponse;

        public ContasControllerTests()
        {
            fixture = new Fixture();
            _clienteRouteRequest = fixture.Create<ClienteRouteRequest>();
            _clienteBodyRequest = fixture.Create<ClienteBodyRequest>();
            _baseResponse = fixture.Create<BaseResponse>();

            _controller = new ContasController(_service);
        }

        [Fact]
        public async void TesteDeExcepcionNoController()
        {
            _service.Transferir(Arg.Any<ClienteRouteRequest>(), Arg.Any<ClienteBodyRequest>()).Throws(new Exception());

            var resultado = (ObjectResult)await _controller.Transferir(_clienteRouteRequest, _clienteBodyRequest);

            resultado.StatusCode.Should().Be(500);
        }

        [Fact]
        public async void ObterPraca_QuandoEstiverTudoCerto_DeveRetornarOK()
        {
            _service.Transferir(_clienteRouteRequest, _clienteBodyRequest).Returns(_baseResponse);
            _baseResponse.StatusCode = StatusCodes.Status200OK;

            var result = (ObjectResult)await _controller.Transferir(_clienteRouteRequest, _clienteBodyRequest);

            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}