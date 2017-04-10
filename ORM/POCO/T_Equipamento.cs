using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class T_Equipamento
    {
        public virtual string codigo { get; set; }
        public virtual string nome { get; set; }
        public virtual string tipo { get; set; }
        public virtual int? qtdmotor { get; set; }
        public virtual string tipoprop { get; set; }
        public virtual int? qtdpassag { get; set; }
         
    }
}
