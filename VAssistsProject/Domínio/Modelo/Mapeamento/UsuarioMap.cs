using FluentNHibernate.Mapping;

namespace Domínio.Modelo.Mapeamento
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.IdUsuario);
            
        }
    }
}