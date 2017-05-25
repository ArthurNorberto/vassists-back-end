using VDominio.Modelo;
using FluentNHibernate.Mapping;

namespace VAssistsInfra.Modelo.Mapeamento
{
    public class PerfilMap : ClassMap<Perfil>
    {
        public PerfilMap()
        {
            Id(x => x.IdPerfil);

            Map(x => x.NomePerfil).Not.Nullable();

            Map(x => x.IdtPerfil).Not.Nullable();
        }
    }
}