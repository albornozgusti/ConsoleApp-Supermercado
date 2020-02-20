using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MenuPrincipal
{
    class Supermercado
    {
        static ArrayList listaproducto = new ArrayList();
        static ArrayList cajeros = new ArrayList();
        static ArrayList cliente = new ArrayList();
        static ArrayList promociones = new ArrayList();
        static ArrayList carro = new ArrayList();
        public static Caja[] caja = new Caja[5] { new Caja(1), new Caja(2), new Caja(3), new Caja(4), new Caja(5) };
        public static int opcion;//variable a usar globalmente
        static int lleva;//
        static int paga;//
        public static int cantidad;//variable usada para la cantidad de productos del carro
        static float total_ganado;

        public static int getCantidadProductosCarro()//funcion que devuelve la cantidad de productos en total en el carro
        {
            return carro.Count;
        }

        public static void limpiarCarro()//funcion para limpiar carro ya que en esta clase esta como privada
        {
        	carro.Clear();
        }
        
        public static int getCantidadProductos()
        {
        	return listaproducto.Count;
        }
        
        public static void nuevoProducto()//DAR DE ALTA A PRODUCTOS
        {
            try
            {
                Console.WriteLine("Ingrese el tipo de producto");
                string tipo = Console.ReadLine();
                Console.WriteLine("Ingrese la marca");
                string marca = Console.ReadLine();
                Console.WriteLine("Ingrese el envase");
                string envase = Console.ReadLine();
                Console.WriteLine("Ingrese el precio");
                float precio = float.Parse(Console.ReadLine());
                if (tipo=="" | marca=="" | envase=="")
                {
                    throw new DatoInvalidoException("Hay un error en los datos ingresados, el producto no fue dado de alta");
                }
                listaproducto.Add(new Producto(tipo, marca, envase, precio));
                Console.WriteLine("El producto fue dado de alta correctamente.");

            }
            catch (FormatException)
            {
                Console.WriteLine("Hay un error en los datos ingresados, el producto no fue dado de alta");
            }
            catch(DatoInvalidoException e)
            {
                Console.WriteLine(e.mensaje);
            }
            catch
            {
                Console.WriteLine("ha habido un error, el produco no fue dado de alta");
            }
        }
        
        public static void mostrarProductos()//funcion para ver los productos
        {
            Console.WriteLine("Listado de productos:");
            Console.WriteLine("");
            foreach (Producto p in listaproducto)
            {
                Console.WriteLine(p);
            }
            
        }

        public static void nuevaPromocion()//funcion que añade una nueva promocion
        {

            mostrarProductos();
            try
            {
                if (listaproducto.Count == 0)
                    throw new NoHayProductoException();
                Console.WriteLine();
                Console.WriteLine("Selecciones el producto para la promocion");
                opcion = int.Parse(Console.ReadLine());
                if (opcion > listaproducto.Count | opcion <= 0)
                    throw new ProductoInexistenteException();
                Console.Write("Llevando: ");
                lleva = int.Parse(Console.ReadLine());
                Console.Write("Paga: ");
                paga = int.Parse(Console.ReadLine());
                if (lleva < paga)
                    throw new DatoInvalidoException("error, no se debe poner que lleve menos y pague mas");
                promociones.Add(new Promociones(getProducto(opcion), lleva, paga));
                Console.WriteLine("La promocion fue dada de alta correctamente");
            }
            catch (FormatException)
            {
                Console.WriteLine("hay un error en los datos ingresados, la promocion no fue dada de alta");
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey(true);
            }
            
            catch (ProductoInexistenteException)
            {
                Console.WriteLine("El producto seleccionado no esta en la lista, la promocion no se ha dado de alta");
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey(true);
            }
            catch (NoHayProductoException)
            {
                Console.WriteLine("no hay productos disponibles");
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey(true);
            }
            catch(DatoInvalidoException e)
            {
                Console.WriteLine(e.mensaje);
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey(true);
            }
            catch
            {
                Console.WriteLine("ha habido un error, la promocion no fue dada de alta");
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey(true);
            }
        }

        public static void mostrarPromociones()//funcion para mostrar la lista de promociones
        {
            Console.WriteLine("Listado de promociones:");
            Console.WriteLine("");
            foreach(Promociones p in promociones)
            {
                Console.WriteLine(p);
            }
            

        }

        public static void mostrarCarro()//funcion que muestra los productos agregados al carro
        {
            foreach (Carro c in carro)
            {
                Console.WriteLine(c);
            }
        }

        public static void agregarProductoAlCarro()//funcion para agregar productos al carro
        {
            foreach (Carro c in carro)
            {
                if (c.getProducto().Id == getProducto(opcion).Id)
                {
                    c.agregarMasCantidad(cantidad);
                    return;
                }
            }
            carro.Add(new Carro(getProducto(opcion),cantidad));
        }

        public static Producto getProducto(int opcion)//funcion que devuelve "Producto" desde el arraylist de listaproducto
        {
            if (opcion <= listaproducto.Count)
                return (Producto)listaproducto[opcion - 1];
            else
                throw new DatoInvalidoException("definido, dato fuera de rango");
        }

        public static float getTotalCarro()//devuelve el gasto total del carro, sirve para realizar la resta general con los descuentos
        {
            float total=0;//variable acumuladora
            foreach (Carro c in carro)
            {
                total += c.getPrecioProductoCarro()*c.Cantidad;//acumulo sin imporar si tiene descuento o no
            }
            return total;//retorno el total
        }

        public static Cajero getCajero(int opcion)// usada para que retorne el tipo cajero del arraylist cajeros
        {
            
            return (Cajero)cajeros[opcion - 1];
        }

        public static void nuevocajero()//DAR DE ALTA CAJEROS
        {
            try
            {
                Console.WriteLine("Ingrese el nombre: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido: ");
                string apellido = Console.ReadLine();
                Console.WriteLine("Ingrese el DNI: ");
                int dni = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese horario: ");
                string horario = Console.ReadLine();
                if (nombre == "" | apellido == "" | dni <=0 | horario == "")
                    throw new DatoInvalidoException("hay un error en los datos ingresados, no se dio de alta al cajero");

                cajeros.Add(new Cajero(nombre, apellido, dni, horario));
                Console.WriteLine("El cajero fue dado de alta correctamente ");
            }
            catch (FormatException)
            {
                Console.WriteLine("hay un error en los datos ingresados, no se dio de alta al cajero");
            }
            catch(DatoInvalidoException e)
            {
                Console.WriteLine(e.mensaje);
            }
            
        }

        public static void asignacion_cajas()//ASIGNAR CAJEROS A CAJAS
        {
            int num_opc;
            try
            {
                if (cajeros.Count == 0)
                    throw new NoHayCajerosException("no se puede abrir cajas ya que no hay ningun cajero disponible");
                int cont = 0;
                Console.WriteLine("¿Que caja desea abrir? [1-5] ");
                num_opc = int.Parse(Console.ReadLine());
                if (caja[num_opc - 1].Abierto == true)//si la caja esta abierta
                    throw new CajaAbiertaException(num_opc);//excepcion que lanza un mensaje de la caja abierta (VER LINEA 246)
                Console.WriteLine("Ingrese el cajero que va a atender la caja ");
                foreach (Cajero c in cajeros)
                {
                    cont++;
                    Console.WriteLine(cont + ")" + c);
                }

                int id_cajero = int.Parse(Console.ReadLine());//INDICE EN DONDE SE GUARDA EL NOMBRE DEL CAJERO
                foreach (Caja c in caja)// foreach para poner al cajero del arraylist cajeros activo
                {
                    if (c.Abierto==true && c.getDniCajero() == getCajero(id_cajero).Dni)//busqueda de caja en caja (al ser solamente 5 cajas la busqueda es mas corta) de identificar el dni de cada cajero trabajando con el dni del cajero elejido
                    {
                        throw new CajeroTrabajandoException(getCajero(id_cajero));
                    }
                    else//si es falso
                    {
                        getCajero(id_cajero).Activo = true;//se le cambia el estado Activo a True indicando que esta trabajando
                    }
                }
                caja[num_opc - 1].abrirCajero(id_cajero);//se abre la caja con el cajero seleccionado
                
                Console.WriteLine("La caja " + num_opc + " fue abierta");
                
            }
            catch (FormatException)
            {
                Console.WriteLine("hay un error en los datos ingresados, el cajero no fue asignado");
            }
            catch (CajaAbiertaException e)
            {
                Console.WriteLine("La caja " +e.opc + " ya esta siendo atendida por " + caja[e.opc - 1].getNombreCajero() + " " + caja[e.opc - 1].getApellidoCajero());
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey(true);
            }
            catch (CajeroTrabajandoException e)
            {
                Console.WriteLine(e.c.Nombre + " " + e.c.Apellido + " ya esta trabajando en otra caja.");
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey(true);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("el dato ingresado no es valido!");
            }
            catch(NoHayCajerosException e)
            {
                Console.WriteLine(e.mensaje);
            }
            catch
            {
                Console.WriteLine("hubo un error inesperado");
            }
        }

        public static void cerra_cajas()//funcion que cierra una caja elejida por el usuario 
        {
            Console.WriteLine("¿Que caja desea cerrar? [1-5] ");
            try
            {
                opcion = int.Parse(Console.ReadLine());//toma el valor que seria la caja a cerrar
                if (opcion>5|opcion<0)//si es un dato fuera de las 5 cajas existentes
                    throw new DatoInvalidoException("el numero de caja no existe");//tira una excepcion
                if (caja[opcion - 1].Abierto == false)//en caso de que la caja ya este cerrada
                {
                    throw new CajaCerradaException();//lanza una excepcion
                }
                else//sino...
                {
                    caja[opcion - 1].cerrarCaja();//cierra la caja
                    Console.WriteLine("La caja " + caja[opcion - 1] + " fue cerrada");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("opcion invalida, por favor elija la opcion correcta");
            }
            catch (CajaCerradaException)
            {
                Console.WriteLine("la caja "+ opcion +"ya se encuentra cerrada");
            }

            Console.ReadKey(true);
        }

        public static void listado_cajas()//funcion que imprime el listado de cajas e indica cual esta abierta o cerrada
        {   
            //int cont = 0;
            Console.WriteLine("Listado cajas ");

            foreach (Caja i in caja)
            {
                i.estadoCaja();// invoco al metodo tostring para imprimir el estado
                //cont++;
                //Console.WriteLine(cont+") "+i);
            }
            Console.ReadKey(true);
        }
        public static bool hayCajaAbierta()//USADO PARA COMPROBAR QUE HAYA 1 CAJA ABIERTA COMO MINIMO
        {
            foreach(Caja c in caja)
            {
                if (c.Abierto == true)
                    return true;
                
            }
            return false;
        }

        public static void cajasAbiertas()//usado en el modulo CLIENTE PARA LISTAR CAJAS ABIERTAS UNICAMENTE
        {
            foreach (Caja i in caja)
            {
                if (i.Abierto == true)
                    i.estadoCaja();
            }
        }
        public static void nuevoCliente(int dni)//REGISTRA UN NUEVO CLIENTE EN EL ARRAYLIST CLIENTE
        {
            try { 
            Console.WriteLine("Nuevo Cliente");
            Console.WriteLine("Ingrese el nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido");
            string apellido= Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de nacimiento");
            string nacimiento = Console.ReadLine();
                if (nombre == "" | apellido == "" | dni <= 0 | nacimiento=="")
                    throw new DatoInvalidoException("hay un error en los datos ingresados, no se dio de alta al cajero");
            cliente.Add(new Cliente(nombre, apellido, dni, nacimiento));
                Console.WriteLine("el cliente fue registrado exitosamente!");
            }
            catch (FormatException)
            {
                Console.WriteLine("hay un error en los datos ingresados, no se dio de alta al cliente");
            }
            catch (DatoInvalidoException e)
            {
                Console.WriteLine(e.mensaje);
            }
            Console.ReadKey(true);
        }

        public static bool existeCliente(int dni)//FUNCION QUE DEVUELVE TRUE SI EN EL ARRAYLIST CLIENTE EXISTE UN CLIENTE QUE COINCIDA CON EL DNI DEL ARGUMENTO
        {
            foreach (Cliente a in cliente)
            {
                if (a.Dni == dni)
                {
                    Console.WriteLine(a.ToString());
                    return true;   
                }
                else
                {
                    //Console.WriteLine("no existe el cliente");
                }
            }
            return false;
        }

        public static void TotalRecaudado()//MUESTRA EL TOTAL RECAUDADO DE TODAS LAS COMPRAS
        {
            Console.WriteLine("Total recaudado en el supermercado: " + total_ganado + " pesos");
        }

        public static void TotalRecaudado_caja()//MUESTRA EL TOTAL RECAUDADO POR CAJAS SIN IMPORTAR SU CAJERO
        {
            int cont = 0;
            Console.WriteLine("Total recaudado en el supermercado discriminado por caja: ");
            Console.WriteLine("");
            foreach (Caja i in caja)
            {
                cont++;
                Console.WriteLine("Caja " + cont + " :" + i.Recaudado + " pesos");
            }        
        }

        public static void totalRecaudadoPorCajero()//MUESTRA EL TOTAL RECAUDADO POR CADA CAJERO QUE TRABAJO
        {
            Console.WriteLine("Total recaudado en el supermercado discriminando por cajero:");
            Console.WriteLine("");
            foreach(Cajero c in cajeros)
            {
                Console.WriteLine(c.Nombre+" "+c.Apellido+": " +c.Recaudado+" pesos");
            }
        }

        public static void totalRecaudadoPorCliente()//funcion que devuelve la lista de clientes registrados junto con lo que gastaron en total
        {
            Console.WriteLine("Total recaudado en el supermercado discriminando por cliente:");
            foreach (Cliente c in cliente)
            {
                Console.WriteLine(c.Nombre+" "+c.Apellido+": "+ c.Recaudado+" Pesos");
            }
        }

        public static void acumularDineroCajero(int ca)//FUNCION QUE ACUMULA EL DINERO RECAUDADO POR LOS CAJEROS 
        {
            foreach(Cajero c in cajeros)//recorro los cajeros
            {
                if (caja[ca - 1].getDniCajero() == c.Dni)//si el dni del cajero trabajando coincide con el dni del cajero rgistrado
                    c.Recaudado += pagarConDescuento();//le acumulo lo que recaudo por la venta
            }
        }

        public static void acumularDineroPersonas(int dni)//FUNCION QUE ACUMULA EL DINERO GASTADO POR CADA UNO DE LOS CLIENTES
        {
            foreach (Cliente c in cliente)
            {
                if (c.Dni==dni)//busca el cliente registrado
                    c.Recaudado += pagarConDescuento();//acumula lo que gasto en la compra
            }
        }

        public static void acumularDineroTotal()//funcion que acumula todas las compras realizadas
        {
            total_ganado += pagarConDescuento();//acumula todas las compras que se hacen
        }

        public static float pagarConDescuento()//esta funcion devuelve el total a pagar con descuento aplicado//probar, en teoria eta arreglado (ult. revision por gus)
        {
            int cantidadapagar=0;
            int cantidadsobrante;
            float total=0;
            float pagarcondescuento=0;//inicializo en 0 para poder acumularlo directamente
            foreach(Carro c in carro)//recorro el carro de productos
            {
                
                foreach (Promociones p in promociones)
                {//recorro las promociones
                    if (c.getProducto().Id == p.getProducto().Id)//analizo si el producto del carro tiene alguna promocion
                    {
                        cantidadapagar = c.Cantidad / p.Lleva;//calculo cuantas veces deberia multiplicar el p.paga, ej: llevo (c.cantidad)=7 unidades y tiene un (p.lleva)=3x(p.paga)=2, el resultado es 2
                        cantidadapagar = cantidadapagar * p.Paga;//teniendo en cuenta el comentario anterior, aqui multiplico el resultado por la cantidad de veces que se aplica el p.paga
                        pagarcondescuento += sumarProductosCantidad(cantidadapagar, c.getProducto().Precio);//habiendo acumulado el total de unidades a pagar con el descuento, aplico el precio del producto para acumular al total a pagar realmente
                        cantidadsobrante = c.Cantidad % p.Lleva;//porque faltan las unidades que sobraron, teniendo en cuenta el mismo ejemplo, sobra 1 unidad, aqui aplico las unidades restantes
                        pagarcondescuento += sumarProductosCantidad(cantidadsobrante, c.getProducto().Precio);//multiplico la unidad restante y se la agrego al pago total, asi... obteniendo el precio final con el descuento
                    }  
                }
                if (pagarcondescuento > 0)//si hubo algun descuento
                {
                    total += pagarcondescuento;//acumulo el total a pagar
                    pagarcondescuento = 0;
                    cantidadapagar = 0;//se asignan a 0 las 2 variables, porque al terminar con el 1er producto, estas ultimas 2 variables mantienen sus valores, lo cual llevaria a un error (no fatal)
                }
                else//si no hubo descuento
                {
                    total += sumarProductosCantidad(c.Cantidad,c.getPrecioProductoCarro());//se suma directamente en el acumulador total mediante la funcion recursiva(esta funcion se aplica mas arriba en caso de haber descuento)
                }
            }
            return total;//retorna el total a pagar con el descuento aplicado arriba
        }

        static float sumarProductosCantidad(int cantidad, float precio)//funcion recursiva que suma los precios de los productos, obtiene los argumentos de la cantidad y precio, el caso base es si la cantidad llegase a 0
        {
            if (cantidad == 0)//caso base
            {
                return 0;
            }
            else
            {
                return sumarProductosCantidad(cantidad-1, precio) + precio;//recursividad
            }
        }
        

    }//FIN CLASE SUPERMERCADO
}
