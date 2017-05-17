using System;

namespace Domínio.Modelo
{
    public class Ponto
    {
        public virtual int IdPonto { get; set; }
        public virtual DateTime DataCadastrado { get; set; }
        public virtual DateTime DataResponsido { get; set; }
        public virtual string Observacao { get; set; }
        public virtual decimal Latitude { get; set; }
        public virtual decimal Longitude { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Tipo Tipo { get; set; }

    }
}
