using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssists.DataTransfer.Usuarios.requests
{
    public class CadastrarUsuariosRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int CodigoPerfil { get; set; }
    }
}
