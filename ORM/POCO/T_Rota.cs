using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class T_Rota
    {
        public virtual int numero { get; set; }
        public virtual T_Aeroporto origem { get; set; }
        public virtual T_Aeroporto destino { get; set; }
        public virtual double valorbilhete { get; set; }
    }
}
