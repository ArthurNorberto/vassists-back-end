using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssists.DataTransfer.Mensagens.responses
{
    public class MensagensPaginacaoResponse
    {
        public IEnumerable<MensagemResponse> mensagens { get; set; }
        public int quantidade { get; set; }
        public int pagina { get; set; }
    }
}
