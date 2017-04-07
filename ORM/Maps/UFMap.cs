using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ORM.Maps
{
    class UFMap : ClassMap<T_UN_Federacao>
    {
        public UFMap()
        {
            Id(x => x.sigla, "SGUF");
            Map(x => x.nome, "NMUF");

            HasMany(x => x.Aeroportos).KeyColumn("SGUF_AEROP");

            Table("T_UN_FEDERACAO");
        }
    }
}
