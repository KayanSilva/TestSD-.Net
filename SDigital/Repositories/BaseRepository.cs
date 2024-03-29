﻿using Microsoft.Extensions.Configuration;

namespace SDigital.Repositories
{
    public class BaseRepository
    {
        private readonly IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration) => _configuration = configuration;

        protected string ObterConexao
        {
            get { return _configuration.GetConnectionString("SD"); }
        }
    }
}