﻿using Dominio.Seguranca.entidades;
using System;
using System.Collections.Generic;
using VDominio.Modelo;

namespace VDominio.Pontos.repositorios
{
    public interface IRegistroPontoRepositorio
    {
        Ponto RetornarPonto(int codigo);

        void RegistrarPonto(Usuario usuario, decimal latitude, decimal longitude, Tipo tipo, string observacao, string enderecoCompleto, string cidade, string estado, string pais);

        void DeletarPonto(int codigoPonto);

        ListaPontos ListarPontos(string nomeUsuario, DateTime? dataInicial, DateTime? dataFinal, string endereco, int codigoTipo, int pg, int qt);

        ListaPontos ListarMeusPontos(int codigoUsuario, DateTime? dataInicial, DateTime? dataFinal, string endereco, int codigoTipo, int pg, int qt);
        
        IEnumerable<Ponto> ListarTodosPontos();
    }
}