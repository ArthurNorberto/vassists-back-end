using Dominio.Mensagens.entidades;
using Dominio.Mensagens.repositorios;
using Dominio.Modelo;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using VAssistsInfra.Auxiliares;
using VDominio.Modelo;

namespace VAssistsInfra.Mensagens.repositorios
{
    public class MensagensRepositorio : GenericoRepositorio, IMensagensRepositorio
    {
        public MensagensRepositorio(ISession session) : base(session)
        {
        }

        public void DeletarMensagem(int codigoMensagem)
        {
            var mensagem = session.Query<Mensagem>().Where(x => x.IdMensagem == codigoMensagem).FirstOrDefault();

            session.Delete(mensagem);
        }

        public void InserirMensagem(Usuario usuario, string texto)
        {
            Mensagem mensagem = new Mensagem
            {
                DataInserida = DateTime.Now,
                Texto = texto,
                Usuario = usuario
            };

            session.Save(mensagem);
        }

        public ListaMensagens ListarMensagens(int pg, int qt)
        {
            ListaMensagens response = new ListaMensagens();

            var pagina = pg - 1;
            var query = session.Query<Mensagem>();

            var result = query.Skip(pagina * qt).Take(qt).ToList();

            response.mensagens = result;
            response.pagina = pg;
            response.quantidade = result.Count;

            return response;
        }

        public IEnumerable<Mensagem> ListarUltimasMensagens()
        {
            var result = session.Query<Mensagem>().OrderBy(x => x.DataInserida.Date).Take(5).ToList();

            return result;
        }
    }
}