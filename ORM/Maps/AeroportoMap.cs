using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ORM.Maps
{
    class AeroportoMap : ClassMap<T_Aeroporto>
    {
        public AeroportoMap()
        {
            Id(x => x.codigo, "CDAEROP");
            Map(x => x.cidade, "NMCID_AEROP");
            References<T_Pais>(x => x.pais, "CDPAIS_AEROP");
            References<T_UN_Federacao>(x => x.estado, "SGUF_AEROP");

            HasMany(x => x.RotasDeChegada).KeyColumn("CDAEROP_ORI");
            HasMany(x => x.RotasDeSaida).KeyColumn("CDAEROP_DES");

            Table("T_AEROPORTO");
        }
    }
}
