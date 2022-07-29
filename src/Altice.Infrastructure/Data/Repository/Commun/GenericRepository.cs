using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altice.Infrastructure.Data.Repository.Commun
{
    public abstract class BaseRepository
    {
        private readonly IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("AlticeConnection"));
        }
    }
}
