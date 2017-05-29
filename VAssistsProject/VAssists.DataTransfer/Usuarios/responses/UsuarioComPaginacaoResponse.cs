using System.Collections.Generic;

namespace VAssists.DataTransfer.Usuarios.responses
{
    public class UsuarioComPaginacaoResponse
    {
        public IEnumerable<UsuarioResponse> usuarios { get; set; }
        public int quantidade { get; set; }
        public int pagina { get; set; }
    }
}