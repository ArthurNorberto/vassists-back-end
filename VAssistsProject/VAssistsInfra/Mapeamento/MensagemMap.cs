using Dominio.Modelo;
using FluentNHibernate.Mapping;

namespace VAssistsInfra.Mapeamento
{
    public class MensagemMap : ClassMap<Mensagem>
    {
        public MensagemMap()
        {
            Id(x => x.IdMensagem);

            Map(x => x.DataInserida).Not.Nullable();

            Map(x => x.Texto).Not.Nullable();

            References(x => x.Usuario).Column("IdUsuario").Cascade.SaveUpdate();
        }
    }
}