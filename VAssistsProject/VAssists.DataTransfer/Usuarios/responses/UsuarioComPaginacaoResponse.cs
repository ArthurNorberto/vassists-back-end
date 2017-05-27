using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssists.DataTransfer.Usuarios.responses
{
    public class UsuarioComPaginacaoResponse
    {
        public IEnumerable<UsuarioResponse> usuarios { get; set; }
        public int quantidade { get; set; }
        public int pagina { get; set; }
    }
}
