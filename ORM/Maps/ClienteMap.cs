using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ORM.Maps
{
    class ClienteMap : ClassMap<T_Cliente>
    {
        public ClienteMap()
        {
            Id(x => x.codigo, "CDCLI");
            Map(x => x.nome, "NMCLI");
            Map(x => x.estadocivil, "IDEST_CVL");
            Map(x => x.sexo, "IDSEX_CLI");
            Map(x => x.dtnascimento, "DTNASC_CLI");
            References<T_Cliente>(x => x.responsavel, "CDCLI_RSP");
            References<T_Pais>(x => x.pais, "CDPAIS_CLI");

            HasMany(x => x.reservas).KeyColumn("CDCLI_RSV");
            HasMany(x => x.dependente).KeyColumn("CDCLI_RSP");
            Table("T_CLIENTE");
        }
    }
}
