using FluentNHibernate.Mapping;
using VDominio.Modelo;

namespace VAssistsInfra.Modelo.Mapeamento
{
    public class PontoMap : ClassMap<Ponto>
    {
        public PontoMap()
        {
            Id(x => x.IdPonto);

            Map(x => x.DataCadastrado).Not.Nullable();

            Map(x => x.DataRespondido);

            Map(x => x.Latitude).Not.Nullable();

            Map(x => x.Longitude).Not.Nullable();

            Map(x => x.Observacao).Not.Nullable();

            Map(x => x.Cidade).Not.Nullable();

            Map(x => x.Estado).Not.Nullable();

            Map(x => x.Pais).Not.Nullable();

            Map(x => x.EnderecoCompleto).Not.Nullable();

            References(x => x.Tipo).Column("IdTipo").Cascade.SaveUpdate();
            References(x => x.Usuario).Column("IdUsuario").Cascade.SaveUpdate();
        }
    }
}