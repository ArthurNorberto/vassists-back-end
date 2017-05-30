using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDominio.Modelo;

namespace Dominio.Respostas.repositorios
{
    public interface IRespostaRepositorio
    {
        IEnumerable<Resposta> ListarRespostas(int codigoPonto);
        void InserirResposta(Ponto ponto, Usuario usuario, string texto);
    }
}
