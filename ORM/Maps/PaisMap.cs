using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ORM.Maps
{
    class PaisMap:ClassMap<T_Pais>
    {
        public PaisMap()
        {
            Id(x => x.codigo, "CDPAIS");
            Map(x => x.nome, "NMPAIS");
            Map(x => x.populacao, "QTDPOPUL");

            HasMany(x => x.Aeroportos).KeyColumn("CDPAIS_AEROP");
            HasMany(x => x.companhias).KeyColumn("CDPAIS_CIA");
            HasMany(x => x.clientes).KeyColumn("CDPAIS_CLI");
            Table("T_PAIS");

        }
    }
}
