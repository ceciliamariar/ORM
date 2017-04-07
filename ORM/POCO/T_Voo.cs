using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class T_Voo
    {
        public virtual int numero { get; set; }
        public virtual DateTime dataSaida { get; set; }
        public virtual DateTime hrSaida { get; set; }
        public virtual T_Rota rota { get; set; }
        public virtual T_Aeronave areronave { get; set; }
        public virtual IList<T_Reserva> reservas { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as T_Voo;
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.numero == this.numero 
                && other.dataSaida.Date == this.dataSaida.Date
                && other.hrSaida.TimeOfDay == this.hrSaida.TimeOfDay;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ numero.GetHashCode();
                hash = (hash * 31) ^ dataSaida.GetHashCode();
                hash = (hash * 31) ^ hrSaida.GetHashCode();

                return hash;
            }
        }
    }
}
