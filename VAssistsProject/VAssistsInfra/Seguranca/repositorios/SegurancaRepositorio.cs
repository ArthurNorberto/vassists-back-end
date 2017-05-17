using Domínio.Modelo;
using Domínio.Seguranca.repositorios;
using System;

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
                IdUsuario = 1,
                NomeUsuario = "Arthur Costa Lima Norberto",
                Email = "arthurcostalima@hotmail.com",
                Perfil = new Perfil()
                {
                    IdPerfil = 1,
                    IdtPerfil = "A",
                    NomePerfil = "Administrador"
                }
            };
        }
    }
}