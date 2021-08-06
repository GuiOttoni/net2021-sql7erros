using MeuTrabalho.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private IConfiguration _configuration;

        public AccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Login(string email, string password)
        {
            string username = string.Empty;

            using (var connection = new SqlConnection(_configuration.GetConnectionString("BancoTeste")))
            {
                connection.Open();
                string query = "SELECT username FROM tbLogin WHERE email=@email AND pwd=@pass";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@email", email));
                    command.Parameters.Add(new SqlParameter("@pass", password));

                    command.ExecuteScalar();
                    username = command.ExecuteScalar().ToString();
                }
            }

            return username;
        }
    }
}
