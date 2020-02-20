using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuPrincipal
{
    class Persona
    {
        protected string nombre;
        protected string apellido;
        protected int dni;
        protected float recaudado;

       

        public string Nombre
        {
            set
            {
                this.nombre = value;
            }
            get
            {
                return this.nombre;
            }
        }
        public string Apellido
        {
            set
            {
                this.apellido = value;
            }
            get
            {
                return this.apellido;
            }
        }
        public int Dni
        {
            set
            {
                this.dni = value;
            }
            get
            {
                return this.dni;
            }
        }
        public float Recaudado
        {
            set
            {
                this.recaudado = value;
            }
            get
            {
                return this.recaudado;
            }
        }
    }
}
