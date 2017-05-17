using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domínio.Modelo
{
    public class Resposta
    {
        public virtual int IdResposta { get; set; }
        public virtual DateTime DataResposta { get; set; }
        public virtual Ponto Ponto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
