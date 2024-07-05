using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_Parcial_4_7_2024
{
    internal class Clientes
    {
        public  string DNI {  get; set; }
        public  string Nombre {  get; set; }
        public  string Direccion { get; set; }
        public  int COD_P {  get; set; }
        public int Fecha_Nac {  get; set; }
        public int Nro_Cuenta {  get; set; } //Asociada a una mutual
        public string Contraseña {  get; set; } //Aleatoria


        //Con esto invoco el objeto clientes y sus propiedades
        private static int i = 999;
        public Clientes(string dni, string nombre, string direccion, int cod_p, int fecha_nac, int nro_cuenta, string contraseña)
        {
            DNI = dni;
            Nombre = nombre;
            Direccion = direccion;
            COD_P = cod_p;
            Fecha_Nac = fecha_nac;
            Nro_Cuenta = GenerarMutual();
            Contraseña = GenerarContraseña();
        }

        //genero una contraseña aleatoria creando uan lista de caracteres sacados de los caracteres permitidios de una constante
        private string GenerarContraseña()
        {
            const string CaracteresPermitidos = "0123456789";
            Random random = new Random();
            char[] contraseñalista = new char[6]; //Para una contraseña de 6 digitos
            for (int i = 0; i < contraseñalista.Length; i++)
            {
                contraseñalista[i] = CaracteresPermitidos[random.Next(CaracteresPermitidos.Length)];
            }
            return new string(contraseñalista);
        }
        private int GenerarMutual()
        {
            i++;
            return i;
        }
    }

}
