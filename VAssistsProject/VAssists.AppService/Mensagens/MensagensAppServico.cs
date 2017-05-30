using Dominio.Mensagens.repositorios;
using System.Linq;
using VAssists.AppService.Auxiliares;
using VAssists.AppService.Auxiliares.Interfaces;
using VAssists.AppService.Mensagens.interfaces;
using VAssists.DataTransfer.Mensagens.requests;
using VAssists.DataTransfer.Mensagens.responses;
using VAssistsInfra.Mensagens.repositorios;
using VAssistsInfra.Usuarios.repositorios;
using VDominio.Usuarios.repositorios;
using System;

namespace VAssists.AppService.Mensagens
{
    public class MensagensAppServico : GenericoAppServico, IMensagensAppServico
    {
        private readonly IMensagensRepositorio mensagensRepositorio;
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public MensagensAppServico(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.mensagensRepositorio = new MensagensRepositorio(unitOfWork.Session);
            this.usuarioRepositorio = new UsuarioRepositorio(unitOfWork.Session);
        }

        public void DeletarMensagem(int codigoMensagem)
        {
            try
            {
                unitOfWork.BeginTransaction();
              
                mensagensRepositorio.DeletarMensagem(codigoMensagem);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
            finally
            {
                unitOfWork.Dispose();
            }
        }

        public void InserirMensagem(InserirMensagemRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var usuario = usuarioRepositorio.RetornaUsuario(request.CodigoUsuario);
                mensagensRepositorio.InserirMensagem(usuario, request.Texto);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
            finally
            {
                unitOfWork.Dispose();
            }
        }

        public MensagensPaginacaoResponse ListarMensagens(ListarMensagensRequest request)
        {
            var retorno = mensagensRepositorio.ListarMensagens(request.pg, request.qt);

            MensagensPaginacaoResponse response = new MensagensPaginacaoResponse()
            {
                quantidade = retorno.quantidade,
                pagina = retorno.pagina,
                mensagens = retorno.mensagens.Select(resultado => new MensagemResponse
                {
                    Codigo = resultado.IdMensagem,
                    Data = resultado.DataInserida,
                    NomeUsuario = resultado.Usuario.NomeUsuario,
                    Texto = resultado.Texto
                })
            };

            return response;
        }
    }
}