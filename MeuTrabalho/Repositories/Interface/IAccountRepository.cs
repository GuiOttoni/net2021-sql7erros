using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho.Repositories.Interface
{
    public interface IAccountRepository
    {
        string Login(string email, string password);
    }
}
