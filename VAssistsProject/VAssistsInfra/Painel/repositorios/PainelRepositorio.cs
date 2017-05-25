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

        public IEnumerable<Perfil> ListarPerfil()
        {
            return session.Query<Perfil>();
        }
    }
}
