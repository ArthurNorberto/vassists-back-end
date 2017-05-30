using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAssists.DataTransfer.Respostas.responses
{
    public class RespostaResponse
    {
        public int Codigo { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataRespondido { get; set; }
        public string Texto { get; set; }
    }
}
