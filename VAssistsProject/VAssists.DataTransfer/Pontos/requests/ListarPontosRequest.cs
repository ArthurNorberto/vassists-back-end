﻿using System;

namespace VAssists.DataTransfer.Pontos.requests
{
    public class ListarPontosRequest
    {
        public string NomeUsuario { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public int CodigoTipo { get; set; }
        public string Endereco { get; set; }
        public int qt { get; set; }
        public int pg { get; set; }
    }
}