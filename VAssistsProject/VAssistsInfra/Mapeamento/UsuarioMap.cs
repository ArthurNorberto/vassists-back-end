using VDominio.Modelo;
using FluentNHibernate.Mapping;

namespace VAssistsInfra.Modelo.Mapeamento
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.IdUsuario);

            Map(x => x.NomeUsuario).Not.Nullable();

            Map(x => x.Email).Not.Nullable();

            Map(x => x.Senha).Not.Nullable();

            Map(x => x.Dataultimologin);

            References(x => x.Perfil).Column("IdPerfil").Cascade.All();
        }
    }
}