using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ORM.Maps
{
    class ReservaMap : ClassMap<T_Reserva>
    {
        public ReservaMap()
        {
            CompositeId()
                .KeyReference(x => x.cliente, "CDCLI_RSV")
                .KeyReference(x => x.voo, "NRVOO_RSV", "DTSAIDA_RSV", "HRSAIDA_RSV");
            Map(x => x.desconto, "PCDESC_RSV");
            Table("T_RESERVA");
        }
    }
}
