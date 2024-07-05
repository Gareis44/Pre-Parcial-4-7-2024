using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pre_Parcial_4_7_2024
{
    internal class Logica 
    {
        List<Cuentas> cuentas = new List<Cuentas>();
        List<Clientes> clientes = new List<Clientes>();
        public void importarCuent(List<Cuentas>cuentass)
        {
            cuentas = cuentass;
        }
        public void importarClient(List<Clientes> clientess)
        {
            clientes = clientess;
        }

        //Transformar este metodo en una funcion que devuelva el booleano de que salio todo bien o mal
        public bool CorroborarAcceso(string Contraseña, string dniAcceso, int evento, int monto)
        {
            bool accion = false;
            foreach (var cliente in clientes)
            {
                if (cliente.DNI == dniAcceso && cliente.Contraseña == Contraseña) //recordar como se arma este IF
                {
                    accion = true;
                    if (evento == 1) //osea sacar dinero
                    {
                        foreach (var cuenta in cuentas)
                        {
                           if (cuenta.ID == cliente.Nro_Cuenta)
                           {
                                cuenta.Saldo -= monto;
                                cuenta.Evento = evento;
                                break;
                           }                              
                        }
                    }else if (evento == 2) //osea ingresar dinero
                    {
                        foreach (var cuenta in cuentas)
                        {
                            if (cuenta.ID == cliente.Nro_Cuenta)
                            {
                                cuenta.Saldo += monto;
                                cuenta.Evento = evento;
                                break;
                            }
                        }
                    }
                    break; //Para cerrar el foreach ya que encontro el dni indicado                  
                }
            }
            return accion;
        }
        public bool Prestamos(string Contraseña, string dniAcceso)
        {
            bool accion = false;
            foreach (var cliente in clientes)
            {
                if (cliente.DNI == dniAcceso && cliente.Contraseña == Contraseña) //recordar como se arma este IF
                {
                    accion = true;
                    foreach (var cuenta in cuentas)
                    {
                        if (cuenta.ID == cliente.Nro_Cuenta)
                        {
                            int MontoPrestamo = (DateTime.Now.Year - (cuenta.Fecha_Creacion/1000))*50000;
                            cuenta.Saldo += MontoPrestamo;
                            cuenta.Evento = 3;
                            break;
                        }
                    }
                    break; //Para cerrar el foreach ya que encontro el dni indicado                  
                }
            }
            return accion;
        }
    }
}
