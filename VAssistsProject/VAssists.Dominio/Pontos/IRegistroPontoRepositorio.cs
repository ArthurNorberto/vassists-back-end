﻿using VDominio.Modelo;

namespace VDominio.Pontos
{
    public interface IRegistroPontoRepositorio
    {
        Ponto RetornarPonto(int codigo);

        void RegistrarPonto(Usuario usuario, decimal latitude, decimal longitude, Tipo tipo, string observacao);
        void DeletarPonto(int codigoPonto);
    }
}