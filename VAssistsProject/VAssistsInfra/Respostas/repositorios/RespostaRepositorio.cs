using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAssistsInfra.Auxiliares;
using NHibernate;
using Dominio.Respostas.repositorios;
using VDominio.Modelo;
using NHibernate.Linq;

namespace VAssistsInfra.Respostas.repositorios
{
    public class RespostaRepositorio : GenericoRepositorio, IRespostaRepositorio
    {
        public RespostaRepositorio(ISession session) : base(session)
        {
        }

        public void InserirResposta(Ponto ponto, Usuario usuario, string texto)
        {
            Resposta resposta = new Resposta
            {
                Ponto = ponto,
                DataResposta = DateTime.Now,
                Usuario = usuario,
                Texto = texto

            };

            session.Save(resposta);
        }

        public IEnumerable<Resposta> ListarRespostas(int codigoPonto)
        {
            return session.Query<Resposta>().Where(x => x.Ponto.IdPonto == codigoPonto).OrderBy(x => x.DataResposta.Date).ToList();
        }
    }
}
