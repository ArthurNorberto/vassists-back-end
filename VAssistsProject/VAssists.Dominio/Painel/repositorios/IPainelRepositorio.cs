using VDominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDominio.Painel.repositorios
{
    public interface IPainelRepositorio
    {
        IEnumerable<Perfil> ListarPerfil();
        void InserirPerfil(string descricao, string identificao);
        IEnumerable<Tipo> ListarTipo();
        void InserirTipo(string descricao, string identificao);
    }
}
