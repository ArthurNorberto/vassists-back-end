using Domínio.Modelo;
using Domínio.Seguranca.repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssistsInfra.Seguranca.repositorios
{
    public class SegurancaRepositorio : ISegurancaRepositorio
    {
        public void CadastroSistema(string nome, string email)
        {
            throw new NotImplementedException();
        }

        public Usuario LogarNoSistema(string login, string senha)
        {
            return new Usuario()
            {
                idUsuario = 1,
                nomeUsuario = "Arthur Costa Lima Norberto",
                email = "arthurcostalima@hotmail.com",
                perfil = new Perfil()
                {
                    idPerfil = 1,
                    idtPerfil = "A",
                    nomePerfil = "Administrador"
                }
            };
        }
    }
}
