using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuPrincipal
{
    class Cajero:Persona
    {
        string horario;
        
        bool activo;

        public Cajero(string nombre, string apellido, int dni, string horario)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.horario = horario;
            this.activo = false;
            recaudado = 0;

        }

        public bool Activo
        {
            set
            {
                this.activo = value;
            }
            get
            {
                return this.activo;
            }
        }

        

       

        override public string ToString()//OVERRIDE PARA IMPRIMIR EL NOMBRE Y APELLIDO
        {
            return Nombre + " " + Apellido;
        }
    }
}
