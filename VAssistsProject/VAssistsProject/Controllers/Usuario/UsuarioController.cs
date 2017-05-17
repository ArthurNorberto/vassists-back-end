using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VAssists.AppService.Usuarios.Interfaces;
using VAssists.DataTransfer.Usuarios.requests;
using VAssists.DataTransfer.Usuarios.responses;

namespace VAssistsProject.Controllers.Usuario
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppServico usuarioAppServico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioAppServico"></param>
        public UsuarioController(IUsuarioAppServico usuarioAppServico)
        {
            this.usuarioAppServico = usuarioAppServico;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoUsuario"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/usuario/{codigoUsuario:int}")]
        [ResponseType(typeof(UsuarioResponse))]
        public IHttpActionResult RetornaUsuario([FromUri] int codigoUsuario)
        {
            return Ok(usuarioAppServico.RetornaUsuario(codigoUsuario));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/usuario")]
        [ResponseType(typeof(UsuarioResponse))]
        public IHttpActionResult CadastrarUsuario([FromBody] CadastrarUsuariosRequest request)
        {
            usuarioAppServico.CadastrarUsuario(request);
            return Ok();
        }


    }
}
