using Altice.Domain.Models;
using Altice.Domain.Request;
using Altice.Infrastructure.Data.Repository.Commun;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altice.Infrastructure.Data.Repository.FormRepository
{
    public class FormRepository : BaseRepository, IFormRepository
    {
        public FormRepository(IConfiguration configuration)
            : base(configuration)
        { }

        public async Task<IEnumerable<FormResponse>> GetAllFormByEmail(string email)
        {
            try
            {
                var query = "SELECT FormId, Email, Nome, Nif, Morada, DataNascimento as Nascimento FROM Form WITH(NOLOCK) Where email like '" + email + "%'";

                IEnumerable<FormResponse> response = new List<FormResponse>();

                using (var connection = CreateConnection())
                {
                    response = await connection.QueryAsync<FormResponse>(query);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<FormResponse> NewForm(FormRequest formRequest)
        {
            try
            {
                CleanTheBase();

                var query = "INSERT INTO Form (Nome, Email, Morada, Nif, DataNascimento, DataInclusao) VALUES (@Nome, @Email, @Morada, @Nif, @DataNascimento, @DataInclusao)";

                var parameters = new DynamicParameters();
                parameters.Add("Nome", formRequest.Nome, DbType.String);
                parameters.Add("Email", formRequest.Email, DbType.String);
                parameters.Add("Nif", formRequest.Nif, DbType.String);
                parameters.Add("Morada", formRequest.Morada, DbType.String);
                parameters.Add("DataNascimento", formRequest.Nascimento, DbType.DateTime);
                parameters.Add("DataInclusao", DateTime.Now, DbType.DateTime);

                using (var connection = CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                    var createdForm = new FormResponse
                    {
                        Nome = formRequest.Nome,
                        Morada = formRequest.Morada,
                        Nif = formRequest.Nif,
                        Email = formRequest.Email,
                    };
                    return createdForm;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async void CleanTheBase()
        {
            // - validação caso tenha 50 registro, apagar dados da tabela 
            var query = "if((select count(*) from Form) > 50) begin delete from Form end";

            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }

        }


    }
}
