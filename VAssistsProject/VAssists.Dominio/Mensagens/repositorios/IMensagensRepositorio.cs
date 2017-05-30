using Dominio.Mensagens.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDominio.Modelo;

namespace Dominio.Mensagens.repositorios
{
    public interface IMensagensRepositorio
    {
        ListaMensagens ListarMensagens(int pg, int qt);
        void InserirMensagem(Usuario usuario, string texto);
        void DeletarMensagem(int codigoMensagem);
    }
}
