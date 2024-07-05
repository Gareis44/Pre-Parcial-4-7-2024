using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pre_Parcial_4_7_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Clientes> clientes = new List<Clientes>(); //Lista de clientes
            List<Cuentas> cuentas = new List<Cuentas>(); //Lista de cuentas asociadas a los clientes
            Logica logica = new Logica();
            bool sesion = true;
            while (sesion == true)
            {
                Console.WriteLine("Bienvenido al sistema de administracion de la mutual, las opciones son:");
                Console.WriteLine("0 para cerrar el programa");
                Console.WriteLine("1 para crear un CLIENTE");
                Console.WriteLine("2 para generar movimiento");
                Console.WriteLine("3 para pedir prestamo");
                int eleccion = int.Parse(Console.ReadLine());
                if (eleccion == 0)
                {
                    sesion = false;
                    break;
                }                  
                if (eleccion == 1)
                {
                    #region Ingreso de Clientes                 
                    bool corte = true;
                    while (corte == true)
                    {
                        Console.WriteLine("Ingresar nuevo cliente");
                        Console.WriteLine("DNI:");
                        string dni = Console.ReadLine();
                        Console.WriteLine("Nombre:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Direccion:");
                        string direccion = Console.ReadLine();
                        Console.WriteLine("Codigo Postal:");
                        int cod_p = int.Parse(Console.ReadLine());
                        Console.WriteLine("Fecha Nacimiento:");
                        int fecha_nac = int.Parse(Console.ReadLine());
                        int nro_cuenta = 1;
                        string contraseña = "1";
                        Clientes cliente = new Clientes(dni, nombre, direccion, cod_p, fecha_nac, nro_cuenta, contraseña); //objeto cliente
                        Cuentas cuenta = new Cuentas(); //objeto cuenta
                        cuenta.ID = cliente.Nro_Cuenta;
                        int año = DateTime.Now.Year;
                        int mes = DateTime.Now.Month;
                        int dia = DateTime.Now.Day;
                        int fecha = año * 1000 + mes * 100 + dia;
                        cuenta.Fecha_Creacion = fecha; //y aca agregamos la fecha de creacion
                        clientes.Add(cliente);
                        cuentas.Add(cuenta);


                        Console.WriteLine("Ingresar cliente? si o no");
                        string opcion = Console.ReadLine();
                        if (opcion.Equals("no", StringComparison.OrdinalIgnoreCase))
                            corte = false;
                    }
                    //Al terminar paso todo a la logica para poder operar
                    logica.importarCuent(cuentas);
                    logica.importarClient(clientes);


                    foreach (var cliente in clientes) //Muestra lista de clientes
                    {
                        Console.WriteLine("Muestro los datos");
                        Console.WriteLine(cliente.DNI);
                        Console.WriteLine(cliente.Nombre);
                        Console.WriteLine(cliente.Direccion);
                        Console.WriteLine(cliente.COD_P);
                        Console.WriteLine(cliente.Fecha_Nac);
                        Console.WriteLine(cliente.Nro_Cuenta);
                        Console.WriteLine(cliente.Contraseña);
                    }
                    #endregion
                }
                else if (eleccion == 2)
                {
                    Console.WriteLine("Ingrese su contraseña:");
                    string contraseña = Console.ReadLine();
                    Console.WriteLine("Ingrese su DNI:");
                    string dniAcceso = Console.ReadLine();
                    Console.WriteLine("Ingrese Accion 1 sacar / 2 Ingresar:");
                    int evento = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese Monto:");
                    int monto = int.Parse(Console.ReadLine());

                    //devuelo lo indicado
                    if (logica.CorroborarAcceso(contraseña, dniAcceso, evento, monto) == true)
                        Console.WriteLine("Operacion Exitosa");
                    else
                        Console.WriteLine("Ocurrio un error en el guardado del evento");
                }
                else //Prestamo eleccion 3
                {
                    Console.WriteLine("Ingrese su contraseña:");
                    string contraseña = Console.ReadLine();
                    Console.WriteLine("Ingrese su DNI:");
                    string dniAcceso = Console.ReadLine();

                    //devuelo lo indicado
                    if (logica.Prestamos(contraseña, dniAcceso) == true)
                        Console.WriteLine("Operacion Exitosa");
                    else
                        Console.WriteLine("No se puede acceder al prestamo");
                }
            }
            Console.ReadKey();
        }
    }
}
