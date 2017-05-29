using FluentNHibernate.Mapping;
using VDominio.Modelo;

namespace VAssistsInfra.Modelo.Mapeamento
{
    public class RespostaMap : ClassMap<Resposta>
    {
        public RespostaMap()
        {
            Id(x => x.IdResposta);

            Map(x => x.DataResposta).Not.Nullable();

            Map(x => x.Texto).Not.Nullable();

            References(x => x.Usuario).Column("IdUsuario").Cascade.SaveUpdate();
            References(x => x.Ponto).Column("IdPonto").Cascade.SaveUpdate();
        }
    }
}