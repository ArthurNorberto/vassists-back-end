using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VAssists.DataTransfer.Respostas.requests;
using VAssists.DataTransfer.Respostas.responses;

namespace VAssists.AppService.Respostas.Interfaces
{
    public interface IRespostaAppServico
    {
        IEnumerable<RespostaResponse> ListarRespostas(int codigoPonto);
        void InserirResposta(int codigoPonto, InserirRespostaRequest request);
    }
}