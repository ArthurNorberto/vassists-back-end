using VDominio.Modelo;
using FluentNHibernate.Mapping;

namespace VAssistsInfra.Modelo.Mapeamento
{
    public class PontoMap : ClassMap<Ponto>
    {
        public PontoMap()
        {
            Id(x => x.IdPonto);

            Map(x => x.DataCadastrado).Not.Nullable();

            Map(x => x.DataResponsido).Not.Nullable();

            Map(x => x.Latitude).Not.Nullable();

            Map(x => x.Longitude).Not.Nullable();

            Map(x => x.Observacao).Not.Nullable();


            References(x => x.Tipo).Column("IdTipo").Cascade.All();
            References(x => x.Usuario).Column("IdUsuario").Cascade.All();

        }
    }
}