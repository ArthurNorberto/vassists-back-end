using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssists.DataTransfer.Mensagens.responses
{
    public class MensagemResponse
    {
        public int Codigo { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime Data { get; set; }
        public string Texto { get; set; }
    }
}
