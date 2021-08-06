using MeuTrabalho.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly IConfiguration _configuration;

        public LogRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void InsereLog(string pagina)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("BancoTeste")))
            {
                connection.Open();
                string query = "INSERT tbLog VALUES (@pagina)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@pagina", pagina));
                    command.ExecuteScalar();
                }
            }
        }

        public int TotalRegistros()
        {
            try
            {
                int total = 0;

                using (var connection = new SqlConnection(_configuration.GetConnectionString("BancoTeste")))
                {
                    connection.Open();
                    string query = "SELECT * FROM tbLog ORDER BY 1";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using(var reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                total = total + 1;
                            }
                        }
                    }
                }

                return total;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
