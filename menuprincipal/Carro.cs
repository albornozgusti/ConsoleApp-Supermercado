using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuPrincipal
{
    class Carro
    {
        int cantidad;
        Producto producto;


        public Carro(Producto p, int c)//constructor
        {
            producto = p;//que producto agrega al carro y..
            cantidad = c;//que cantidad agrega al carro

        }

        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
        }

        public Producto getProducto()
        {
            return this.producto;
        }

        public void agregarMasCantidad(int cant)
        {
            this.cantidad += cant;
        }

        public float getPrecioProductoCarro()
        {
            return producto.Precio;//retorno el precio del producto
        }

        public override string ToString()
        {
            return producto +" "+ "("+cantidad+")";
        }
    }
}
