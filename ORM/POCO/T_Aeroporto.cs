using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class T_Aeroporto
    {
        public virtual string codigo { get; set; }
        public virtual T_Pais pais { get; set; }
        public virtual T_UN_Federacao estado { get; set; }
        public virtual string cidade { get; set; }

        public virtual IList<T_Rota> RotasDeChegada { get; set; }

        public virtual IList<T_Rota> RotasDeSaida { get; set; }


    }
}
