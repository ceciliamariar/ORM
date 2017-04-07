using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class T_Companhia
    {
        public virtual string codigo { get; set; }
        public virtual string nome { get; set; }
        public virtual T_Pais pais { get; set; }

        public virtual IList<T_Aeronave> aeronaves { get; set; }
    }
}
