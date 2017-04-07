using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class T_Aeronave
    {
        public virtual string codigo { get; set; }
        public virtual T_Equipamento equipamento { get; set; }
        public virtual T_Companhia ciaarea { get; set; }

        public virtual IList<T_Voo> Voos { get; set; }
    }
}
