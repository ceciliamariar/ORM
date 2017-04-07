using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class T_Cliente
    {
        public virtual string codigo { get; set; }
        public virtual string nome { get; set; }
        public virtual char sexo { get; set; }
        public virtual DateTime dtnascimento { get; set; }
        public virtual T_Pais pais { get; set; }
        public virtual char estadocivil { get; set; }
        public virtual T_Cliente responsavel { get; set; }
        public virtual IList<T_Reserva> reservas { get; set; }
        public virtual IList<T_Cliente> dependente { get; set; }
    }
}
