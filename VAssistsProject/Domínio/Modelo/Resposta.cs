using System;

namespace Domínio.Modelo
{
    public class Resposta
    {
        public virtual int IdResposta { get; set; }
        public virtual DateTime DataResposta { get; set; }
        public virtual string Texto { get; set; }
        public virtual Ponto Ponto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}