using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domínio.Seguranca.repositorios
{
    public interface ISegurancaRepositorio
    {
        dynamic LogarNoSistema(string login, string senha);
    }
}
