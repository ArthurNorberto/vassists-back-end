using System;
using VDominio.Modelo;

namespace Dominio.Modelo
{
    public class Mensagem
    {
        public virtual int IdMensagem { get; set; }
        public virtual string Texto { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual DateTime DataInserida { get; set; }
    }
}