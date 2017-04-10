using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ORM.Maps
{
    class VooMap : ClassMap<T_Voo>
    {
        public VooMap()
        {
            CompositeId()
                .KeyProperty(x => x.numero, "NRVOO")
                .KeyProperty(x => x.dataSaida, "DTSAIDA")
                .KeyProperty(x => x.hrSaida, "HRSAIDA");
            References<T_Aeronave>(x => x.areronave, "CDAERON_VOO");
            References<T_Rota>(x => x.rota, "NRROTA_VOO");

            HasMany(x => x.reservas).KeyColumns.Add("NRVOO_RSV", "DTSAIDA_RSV", "HRSAIDA_RSV");
            Table("T_VOO");
        }
    }
}
