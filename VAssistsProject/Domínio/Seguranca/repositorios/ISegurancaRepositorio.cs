using Domínio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domínio.Seguranca.repositorios
{
    public interface ISegurancaRepositorio
    {
        Usuario LogarNoSistema(string login, string senha);
        void CadastroSistema(string nome, string email);
    }
}
