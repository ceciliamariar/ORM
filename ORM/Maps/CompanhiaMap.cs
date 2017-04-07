using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ORM.Maps
{
    class CompanhiaMap : ClassMap<T_Companhia>
    {
        public CompanhiaMap()
        {
            Id(x => x.codigo, "CDAERON");
            Map(x => x.nome, "NMCIA");
            References<T_Pais>(x => x.pais, "CDPAIS_CIA");

            HasMany(x => x.aeronaves).KeyColumn("CDCIA");

            Table("T_COMPANHIA");
        }
    }
}
