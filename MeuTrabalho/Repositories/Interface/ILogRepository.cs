using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho.Repositories.Interface
{
    public interface ILogRepository
    {
        int TotalRegistros();
        void InsereLog(string pagina);
    }
}
