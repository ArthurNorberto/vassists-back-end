﻿using VDominio.Modelo;
using FluentNHibernate.Mapping;

namespace VAssistsInfra.Modelo.Mapeamento
{
    public class TipoMap : ClassMap<Tipo>
    {
        public TipoMap()
        {
            Id(x => x.IdTipo);

            Map(x => x.NomeTipo).Not.Nullable();

            Map(x => x.IdTipo).Not.Nullable();
        }
    }
}