using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class T_Reserva
    {
        public virtual T_Cliente cliente { get; set; }
        public virtual T_Voo  voo { get; set; }
        public virtual double? desconto { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as T_Reserva;
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.cliente.codigo == other.cliente.codigo 
                && this.voo.Equals(other.voo);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ cliente.codigo.GetHashCode();
                hash = (hash * 31) ^ voo.GetHashCode();
                return hash;
            }
        }

    }


}
