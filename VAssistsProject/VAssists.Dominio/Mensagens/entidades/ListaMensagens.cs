using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Mensagens.entidades
{
    public class ListaMensagens
    {
        public IEnumerable<Mensagem> mensagens { get; set; }
        public int quantidade { get; set; }
        public int pagina { get; set; }
    }
}
