using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssists.DataTransfer.Mensagens.requests
{
    public class InserirMensagemRequest
    {
        public int CodigoUsuario { get; set; }
        public string Texto { get; set; }
    }
}
