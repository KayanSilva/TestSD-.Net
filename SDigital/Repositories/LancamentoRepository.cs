using Dapper;
using Microsoft.Extensions.Configuration;
using SDigital.Entities;
using SDigital.Interfaces;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SDigital.Repositories
{
    public class LancamentoRepository : BaseRepository, ILancamentoRepository
    {
        public LancamentoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> Inserir(Lancamento lancamento)
        {
            const string insert = @"INSERT INTO Lancamento(DataHora, Tipo, ContaId, Valor)
                       output INSERTED.LancamentoId VALUES(@DataHora, @Tipo, @ContaId, @Valor);";

            using var con = new SqlConnection(ObterConexao);
            await con.OpenAsync();
            return await con.ExecuteScalarAsync<int>(insert, new
            {
                lancamento.ContaId
            });
        }
    }
}