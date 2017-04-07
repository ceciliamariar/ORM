using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ORM.Maps
{
    class AeronaveMap : ClassMap<T_Aeronave>
    {
        public AeronaveMap()
        {
            Id(x => x.codigo, "CDAERON");
            References<T_Companhia>(x => x.ciaarea, "CDCIA");
            References<T_Equipamento>(x => x.equipamento, "CDEQP");
            Table("T_AERONAVE");
        }
    }
}
