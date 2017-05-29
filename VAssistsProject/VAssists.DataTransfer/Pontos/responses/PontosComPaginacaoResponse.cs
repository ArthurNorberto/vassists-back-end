using System.Collections.Generic;

namespace VAssists.DataTransfer.Pontos.responses
{
    public class PontosComPaginacaoResponse
    {
        public IEnumerable<PontoResponse> pontos { get; set; }
        public int quantidade { get; set; }
        public int pagina { get; set; }
    }
}