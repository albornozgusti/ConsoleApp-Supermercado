using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuPrincipal
{
    class Cliente:Persona
    {
        string nacimiento;
        

        public Cliente(string nombre, string apellido, int dni, string nacimiento)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.nacimiento = nacimiento;
            this.recaudado = 0;

        }



        string Nacimiento
        {
            set
            {
                this.nacimiento = value;
            }
            get
            {
                return this.nacimiento;
            }
        }
        
        override public string ToString()//OVERRIDE PARA IMPRIMIR EL ID, TIPO MARCA ENVASE Y PRECIO DEL PRODUCTO, ESTO SE VA A USAR EN LA SIMULACION DE LA COMPRA
        {
            return "cliente" +" "+ Nombre+" "+Apellido;
        }

    }
}
