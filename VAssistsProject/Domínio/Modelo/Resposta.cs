using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domínio.Modelo
{
    public class Resposta
    {
        public virtual int idResposta { get; set; }
        public virtual DateTime dataResposta { get; set; }
        public virtual Ponto ponto { get; set; }
        public virtual Usuario usuario { get; set; }
    }
}
