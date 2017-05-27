using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssists.DataTransfer.Pontos.responses
{
    public class PontosComPaginacaoResponse
    {
        public IEnumerable<PontoResponse> pontos { get; set; }
        public int quantidade { get; set; }
        public int pagina { get; set; }
    }
}
