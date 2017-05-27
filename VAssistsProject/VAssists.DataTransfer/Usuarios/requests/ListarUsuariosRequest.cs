using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssists.DataTransfer.Usuarios.requests
{
    public class ListarUsuariosRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Perfil { get; set; }
        public int qt { get; set; }
        public int pg { get; set; }
    }
}
