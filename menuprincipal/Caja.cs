/*
 * Creado por SharpDevelop.
 * Usuario: Cristian
 * Fecha: 23/05/2016
 * Hora: 18:56
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace MenuPrincipal
{
    /// <summary>
    /// Description of Caja.
    /// </summary>
    class Caja
    {
        int numero;
        Cajero cajero;
        bool abierto=false;
        float recaudado=0;

        public Caja(int numero)
        {
            this.numero = numero;
            this.abierto = false;
        }

        public void estadoCaja()
        {
            if (abierto == false)
            {
                Console.WriteLine("Caja " + numero + " CERRADA");
            }
            else
            {
                Console.WriteLine("Caja " + numero + " atendida por " + cajero.Nombre + " " + cajero.Apellido);
            }

        }

        public void cerrarCaja()
        {
            abierto = false;
        }

        public void abrirCajero(int opc)//
        {
            cajero = Supermercado.getCajero(opc);//obtenemos desde el arraylist de cajeros y asignamos al cajero a la caja elejida
            abierto = true;//seteamos que esta abierta
        }

        public int getDniCajero()
        {
            return this.cajero.Dni;
        }

        public string getNombreCajero()
        {
            return cajero.Nombre;
        }

        public string getApellidoCajero()
        {
            return cajero.Apellido;
        }

        public bool Abierto
        {
            get
            {
                return this.abierto;
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

        override public string ToString()//OVERRIDE 
        {
            if (abierto == false)
            {
                return "Caja" + " " +/*numerodecaja*/"" + " " + "CERRADA";
            }
            else
            {
                return "Caja" + " " +/*numerodecaja*/"" + " " + "atendida por " + cajero.Nombre + " " + cajero.Apellido;
            }

        }
    }
}