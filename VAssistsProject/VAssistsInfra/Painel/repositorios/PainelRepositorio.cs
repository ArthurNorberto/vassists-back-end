using Domínio.Painel.repositorios;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAssistsInfra.Conexão;
using Domínio.Modelo;
using NHibernate.Linq;

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
