using System;
using System.Linq;
using VAssists.AppService.Auxiliares;
using VAssists.AppService.Auxiliares.Interfaces;
using VAssists.AppService.Usuarios.Interfaces;
using VAssists.DataTransfer.Usuarios.requests;
using VAssists.DataTransfer.Usuarios.responses;
using VAssistsInfra.Conexao;
using VAssistsInfra.Painel.repositorios;
using VAssistsInfra.Usuarios.repositorios;
using VDominio.Painel.repositorios;
using VDominio.Usuarios.repositorios;

namespace VAssists.AppService.Usuarios
{
    public class UsuarioAppServico : GenericoAppServico, IUsuarioAppServico
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly IPainelRepositorio painelRepositorio;

        public UsuarioAppServico(IUnitOfWork unitOfWork/*, IUsuarioRepositorio usuarioRepositorio, IPainelRepositorio painelRepositorio*/) : base(unitOfWork)
        {
            // this.usuarioRepositorio = usuarioRepositorio;
            //this.painelRepositorio = painelRepositorio;
             this.usuarioRepositorio = new UsuarioRepositorio(unitOfWork.Session);
            this.painelRepositorio = new PainelRepositorio(unitOfWork.Session);
        }

        public void AlterarSenha(int codigoUsuario, AlterarSenhaRequest request)
        {
            if (request.SenhaAntiga == request.SenhaNova)
            {
                throw new Exception("A senha antiga é a mesma que a nova");
            }

            if (request.SenhaNova != request.SenhaNovaConfirme)
            {
                throw new Exception("As senhas não são parecidas!");
            }

            try
            {
                unitOfWork.BeginTransaction();

                usuarioRepositorio.AlterarSenha(codigoUsuario, request.SenhaNova);

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

        public void AlterarUsuario(int codigoUsuario, AlterarUsuarioRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var perfil = painelRepositorio.RetornarPerfil(request.CodigoPerfil);

                usuarioRepositorio.AlterarUsuario(perfil, codigoUsuario, request.Email, request.Nome);

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

        public void CadastrarUsuario(CadastrarUsuariosRequest request)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var perfil = painelRepositorio.RetornarPerfil(request.CodigoPerfil);

                usuarioRepositorio.CadastrarUsuario(perfil, request.Email, request.Nome);

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

        public void ExcluirUsuario(int codigoUsuario)
        {
            try
            {
                unitOfWork.BeginTransaction();

                usuarioRepositorio.ExcluirUsuario(codigoUsuario);

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

        public UsuarioComPaginacaoResponse ListarUsuarios(ListarUsuariosRequest request)
        {
            try
            {
                 
                var resultado = usuarioRepositorio.ListarUsuarios(request.Nome, request.Email, request.CodigoPerfil, request.pg, request.qt);

                UsuarioComPaginacaoResponse response = new UsuarioComPaginacaoResponse()
                {
                    quantidade = resultado.quantidade,
                    pagina = resultado.pagina,
                    usuarios = resultado.usuarios.Select(t => new UsuarioResponse
                    {
                        CodigoUsuario = t.IdUsuario,
                        DataUltimoLogin = t.Dataultimologin,
                        Email = t.Email,
                        Nome = t.NomeUsuario,
                        Perfil = t.Perfil.NomePerfil
                    })
                };

             
                return response;
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

        public void ResetarSenha(int codigoUsuario)
        {
            try
            {
                unitOfWork.BeginTransaction();

                usuarioRepositorio.ResetarSenha(codigoUsuario);

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

        public UsuarioResponse RetornaUsuario(int codigoUsuario)
        {
            try
            {
           

                var result = usuarioRepositorio.RetornaUsuario(codigoUsuario);

                UsuarioResponse response = new UsuarioResponse()
                {
                    CodigoUsuario = result.IdUsuario,
                    Nome = result.NomeUsuario,
                    DataUltimoLogin = result.Dataultimologin,
                    Email = result.Email,
                    Perfil = result.Perfil.NomePerfil,
                    Identificacao = result.Perfil.IdtPerfil,
                    CodigoPerfil = result.Perfil.IdPerfil
                };

          
                return response;
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
    }
}