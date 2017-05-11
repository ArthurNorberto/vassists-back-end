using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using VAssistsProject.Models;
using VAssistsProject.Providers;
using VAssistsProject.Results;
using System.Web.Http.Description;
using VAssists.DataTransfer.Seguranca.requests;
using VAssists.AppService.Seguranca.Interfaces;
using VAssists.DataTransfer.Seguranca.responses;

namespace VAssistsProject.Controllers
{
    public class LoginController : ApiController
    {
        public ISegurancaAppServico segurancaAppServico;

       public LoginController(ISegurancaAppServico segurancaAppServico)
        {
            this.segurancaAppServico = segurancaAppServico;

        }

        [HttpPost]
        [Route("seguranca/login")]
        [ResponseType(typeof(UsuarioLogadoResponse))]
        public IHttpActionResult LogarNoSistema([FromUri] LoginSistemaRequest request)
        {

            return Ok(segurancaAppServico.LogarNoSistema(request));

        }









    }
}
