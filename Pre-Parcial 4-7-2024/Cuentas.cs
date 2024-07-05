using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_Parcial_4_7_2024
{
    internal class Cuentas
    {
        public int ID {  get; set; }
        public int Saldo { get; set; }
        public int Evento { get; set; }
        public int Fecha_Creacion { get; set; }

        public Cuentas()
        {
            ID = 0;
            Saldo = 0;
            Evento = 0;
            Fecha_Creacion = 0; 
        }
    }
}
