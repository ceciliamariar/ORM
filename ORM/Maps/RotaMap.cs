using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ORM.Maps
{
    class RotaMap : ClassMap<T_Rota>
    {
        public RotaMap()
        {
            Id(x => x.numero, "NRROTA_VOO");
            Map(x => x.valorbilhete, "VRBILHE_ROTA");
            References<T_Aeroporto>(x => x.origem, "CDAEROP_ORI");
            References<T_Aeroporto>(x => x.destino, "CDAEROP_DES");
            Table("T_ROTA");
        }
    }
}
