using System;

namespace Domínio.Modelo
{
    public class Ponto
    {
        public virtual int idPonto { get; set; }
        public virtual DateTime dataCadastrado { get; set; }
        public virtual DateTime dataResponsido { get; set; }
        public virtual string observacao { get; set; }
        public virtual decimal latitude { get; set; }
        public virtual decimal longitude { get; set; }
        public virtual Usuario usuario { get; set; }
        public virtual Tipo tipo { get; set; }

    }
}
