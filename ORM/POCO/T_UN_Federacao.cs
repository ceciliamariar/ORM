using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class T_UN_Federacao
    {
        public virtual string sigla { get; set; }
        public virtual string nome { get; set; }
        public virtual IList<T_Aeroporto> Aeroportos { get; set; }

    }
}
