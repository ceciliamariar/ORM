using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace ORM.Maps
{
    class EquipamentoMap: ClassMap<T_Equipamento>
    {
        public EquipamentoMap()
        {
            Id(x => x.codigo,"CDEQU");
            Map(x => x.nome,"NMEQP");
            Map(x => x.tipo,"DCTIP_EQP");
            Map(x => x.qtdmotor,"QTDMOTOR");
            Map(x => x.tipoprop,"IDTIP_PROP");
            Map(x => x.qtdpassag,"QTDPASSAG");
            Table("T_EQUIPAMENTO");
        }

    }
}
