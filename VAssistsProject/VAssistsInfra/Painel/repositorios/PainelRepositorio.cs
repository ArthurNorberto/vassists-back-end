using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAssistsInfra.Conexao;
using NHibernate.Linq;
using VDominio.Painel.repositorios;
using VDominio.Modelo;

namespace VAssistsInfra.Painel.repositorios
{
    public class PainelRepositorio : IPainelRepositorio
    {
        private readonly ISession session;

        public PainelRepositorio()
        {
            session = SessionFactory.OpenSession();
        }

        public void InserirPerfil(string descricao, string identificao)
        {
            Perfil perfil = new Perfil
            {
               NomePerfil = descricao,
               IdtPerfil = identificao
            };

            session.Save(perfil);
        }

        public void InserirTipo(string descricao, string identificao)
        {
            Tipo tipo = new Tipo
            {
                NomeTipo = descricao,
                IdtTipo = identificao
            };

            session.Save(tipo);
        }

        public IEnumerable<Perfil> ListarPerfil()
        {
            return session.Query<Perfil>();
        }

        public IEnumerable<Tipo> ListarTipo()
        {
            return session.Query<Tipo>();
        }
    }
}
