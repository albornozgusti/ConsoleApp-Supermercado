using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuPrincipal
{
    class Promociones
    {
        Producto producto;
        int lleva;
        int paga;

       

        public Promociones(Producto p, int lleva, int paga)
        {
            this.producto=p;
            this.lleva = lleva;
            this.paga = paga;
            
        }

        public Producto getProducto()
        {
            return this.producto;
        }

        public int Lleva
        {
            get
            {
                return this.lleva;
            }
        }

        public int Paga
        {
            get
            {
                return this.paga;
            }
        }
        


        override public string ToString()//OVERRIDE PARA IMPRIMIR EL ID, TIPO MARCA ENVASE Y PRECIO DEL PRODUCTO
        {
            return producto.ToString()+" ==> "+lleva+" x "+paga;
        }
    }
}
