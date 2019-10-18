using Dapper;
using Microsoft.Extensions.Configuration;
using SDigital.Entities;
using SDigital.Interfaces;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SDigital.Repositories
{
    public class ContaRepository : BaseRepository, IContaRepository
    {
        public ContaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> AlterarSaldo(Guid contaId, decimal valor)
        {
            const string update = @"UPDATE Conta SET Valor = @valor WHERE ContaId = @contaId;";

            using var con = new SqlConnection(ObterConexao);
            await con.OpenAsync();
            return await con.ExecuteScalarAsync<int>(update, new
            {
                contaId,
                valor
            });
        }

        public async Task<Conta> Obter(Guid contaId)
        {
            const string select = @"SELECT * FROM Conta WHERE ContaId = @contaId;";

            using var con = new SqlConnection(ObterConexao);
            await con.OpenAsync();
            return await con.QueryFirstOrDefaultAsync<Conta>(select, new
            {
                contaId
            });
        }
    }
}