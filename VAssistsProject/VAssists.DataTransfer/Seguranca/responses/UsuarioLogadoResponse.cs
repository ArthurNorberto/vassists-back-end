using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssists.DataTransfer.Seguranca.responses
{
    public class UsuarioLogadoResponse
    {
        public string nomeUsuario { get; set; }
        public long idUsuario { get; set; }
        public string perfil { get; set; }
    }
}
