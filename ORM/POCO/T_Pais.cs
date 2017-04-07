using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class T_Pais
    {
        public virtual string codigo { get; set; }
        public virtual string nome { get; set; }
        public virtual int populacao { get; set; }

        public virtual IList<T_Aeroporto> Aeroportos { get; set; }
        public virtual IList<T_Companhia> companhias { get; set; }
        public virtual IList<T_Cliente> clientes { get; set; }
    }
}
