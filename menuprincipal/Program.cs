
using System;
using System.Collections;


namespace MenuPrincipal
{
    class DatoInvalidoException : Exception
    {
        public string mensaje;
        public DatoInvalidoException(string m)
        {
            mensaje = m;
        }
    }

    class ProductoInexistenteException: Exception
    {

    }

    class CajaAbiertaException : Exception
    {
        public int opc;
        public CajaAbiertaException(int opc)
        {
            this.opc = opc;
        }
    }

    class CajeroTrabajandoException : Exception
    {
        public Cajero c;
        public CajeroTrabajandoException(Cajero c)
        {
            this.c = c;
        }
    }

    class CajaCerradaException : Exception
    {

    }

    class NoHayProductoException : Exception
    {

    }

    class NoHayCajerosException : Exception
    {
        public string mensaje;
        public NoHayCajerosException(string m)
        {
            mensaje = m;
        }
    }

    class CarroVacioException : Exception
    {
        public string mensaje;
        public CarroVacioException(string m)
        {
            mensaje = m;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            //DECLARACION DE VARIABLES
            int opc=0;//hacer publica esta variable
            do//bucle del menu principal
                {
                    Console.Clear();//limpia la pantalla, a continuacion, muestra el menu
                    Console.WriteLine("*******************************************************************************");
                    Console.WriteLine("******                             SUPERMERCADO                          ******");
                    Console.WriteLine("*******************************************************************************");
                    Console.WriteLine("A que modulo desea ingresar?");
                    Console.WriteLine("");
                    Console.WriteLine("1-Productos");
                    Console.WriteLine("2-Cajas");
                    Console.WriteLine("3-Clientes");
                    Console.WriteLine("4-Administracion");
                    Console.WriteLine("5-Salir del sistema");
                try
                {
                    opc = int.Parse(Console.ReadLine());//unicamente a esta linea ya que el usuario puede ingresar una letra como opcion y no es valido
                }//fin try
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, ingrese el numero correcto entre las opciones 1-5");
                    Console.ReadKey(true);
                    continue;

                }//fin catch
                catch
                {
                    Console.WriteLine("Por favor, ingrese el numero correcto entre las opciones 1-5");
                    Console.ReadKey(true);
                }

                switch (opc)
                    {
                        case 1:
                            productos();
                            break;
                        case 2:
                            cajas();
                            break;
                        case 3:
                            Supermercado.limpiarCarro();//limpiamos el carro en caso de que ya haya comprado alguien
                        try
                        {
                            if (Supermercado.getCantidadProductos() >= 1)//si la cantidad de productos en la lista del supermercado no esta vacia y...
                            {
                                if (Supermercado.hayCajaAbierta() == true) //hay una caja abierta como minimo
                                    cliente();//se ejecuta el modulo cliente
                                else
                                    throw new CajaCerradaException();
                            }
                            else
                            {
                                throw new NoHayProductoException();
                            }
                        }
                        catch (CajaCerradaException)
                        {
                            Console.WriteLine("error al acceder al modulo, no hay cajas abiertas, por favor, abra una caja y vuelva a intentarlo");
                            Console.WriteLine("presione una tecla para continuar");
                            Console.ReadKey(true);
                            }
                        catch (NoHayProductoException)
                        {
                            Console.WriteLine("error al acceder al modulo, no hay productos disponibles, por favor, asigne por lo menos 1 producto y vuelva a intentarlo");
                            Console.WriteLine("presione una tecla para continuar");
                            Console.ReadKey(true);
                        }
                        break;
                        case 4:
                            administracion();
                            break;
                        case 5:
                            Console.WriteLine("saliendo...");
                            break;
                        default:
                            Console.WriteLine("opcion equivocada, por favor elija una opcion correcta");

                            break;
                    }//fin switch
                }//fin do while
                while (opc != 5);
        }//FIN MAIN
            
        public static void productos()
        {
            int opc=0;
            do{//menu de productos
                Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("******                             SUPERMERCADO                          ******");
                Console.WriteLine("******                           Modulo Productos                        ******");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("");
                Console.WriteLine("1-Nuevo producto");
                Console.WriteLine("2-Nueva promocion");
                Console.WriteLine("3-Listado de productos");
                Console.WriteLine("4-Listado de promociones");
                Console.WriteLine("5-Volver");

                try
                {
                    opc = int.Parse(Console.ReadLine());//unicamente a esta linea ya que el usuario puede ingresar una letra como opcion y no es valido
                }//fin try
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, ingrese el numero correcto entre las opciones 1-5");
                    Console.ReadKey(true);
                    continue;

                }//fin catch

                switch (opc)
                {
                case 1:
                        Supermercado.nuevoProducto();
                        Console.ReadKey(true);
                        break;
                case 2:
                        Supermercado.nuevaPromocion();
                        Console.ReadKey(true);
                        break;
                case 3:
                        Supermercado.mostrarProductos();
                        Console.ReadKey(true);
                        break;
                case 4:
                        Supermercado.mostrarPromociones();
                        Console.ReadKey(true);
                        break;
                case 5:
                        Console.WriteLine("Volviendo al menu anterior.......");
                        break;
                default:
                        Console.WriteLine("Opcion ingresada incorrecta... Vuelva a seleccionar una opcion");
                        break;
                }//fin switch
              }while(opc!=5);
        }//fin productos()

        public static void cajas()
        {
            int opc=0;
            do{
                Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("******                             SUPERMERCADO                          ******");
                Console.WriteLine("******                             Modulo Cajas                          ******");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("");
                Console.WriteLine("Seccion cajas y cajeros");
                Console.WriteLine("");
                Console.WriteLine("1-Nuevo cajero");
                Console.WriteLine("2-Abrir caja");
                Console.WriteLine("3-Cerrar caja");
                Console.WriteLine("4-Listado de cajas");
                Console.WriteLine("5-Volver");

                try
                {
                    opc = int.Parse(Console.ReadLine());//unicamente a esta linea ya que el usuario puede ingresar una letra como opcion y no es valido
                }//fin try
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, ingrese el numero correcto entre las opciones 1-5");
                    Console.ReadKey(true);
                    continue;

                }//fin catch

                switch (opc)
				{
					case 1:
                        Supermercado.nuevocajero();
                        Console.WriteLine("presione una tecla para continuar");
                        Console.ReadKey(true);
                        break;
					case 2:
                        Supermercado.asignacion_cajas();
                        Console.WriteLine("presione una tecla para continuar");
                        Console.WriteLine("");
                        Console.ReadKey(true);
                        break;
					case 3:
                        Supermercado.cerra_cajas();
						Console.WriteLine("");
						break;
					case 4:
                        Supermercado.listado_cajas();
						break;
					case 5:
						Console.WriteLine("Volviendo al Menu principal...");
						break;
					default:
						Console.WriteLine("La opcion ingresada es incorrecta. Por favor ingrese nuevamente una opcion.");
                        Console.ReadKey(true);
						break;
				}
            }while(opc!=5);
        }

        public static void cliente()
        {
            bool error = false;
            int caja;//variable para usar cuando se deba elejir una caja en la cual pagar
            int dni=0;//dni para obtener el dni del cliente, se declara aqui para poder tener un control global sobre el resto del metodo cliente
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("*******************************************************************************");
                    Console.WriteLine("******                             SUPERMERCADO                          ******");
                    Console.WriteLine("******                            Modulo Cliente                         ******");
                    Console.WriteLine("*******************************************************************************");
                    Console.WriteLine("Productos disponibles");
                    Console.WriteLine();
                    Supermercado.mostrarProductos();
                    Console.WriteLine();
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("Productos en el carro");
                    Supermercado.mostrarCarro();
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("Agregue un producto al carro o 0 para finalizar");
                    try
                    {
                        Supermercado.opcion = int.Parse(Console.ReadLine());
                        if (Supermercado.opcion < 0 | Supermercado.opcion > Supermercado.getCantidadProductos())//si se ingresa un valor fuera del rango de la lista de productos
                            throw new DatoInvalidoException("valor ingresado no válido, indice fuera de rango excepcion definida");//se lanza la excepcion
                        if (Supermercado.opcion != 0)//si es distinto de 0
                        {
                            try
                            {
                                Console.WriteLine("Cuantas unidades agrega?");
                                Supermercado.cantidad = int.Parse(Console.ReadLine());
                                if (Supermercado.cantidad <= 0)
                                    throw new DatoInvalidoException("no se puede ingresar el valor 0 o mas bajo");
                                Supermercado.agregarProductoAlCarro();
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("la opcion elejida no esta en la lista");
                                Console.WriteLine("indice fuera del rango");
                                Console.WriteLine("Presiones una tecla para continuar");
                                Console.ReadKey(true);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("el valor ingresado no esta en la lista");
                                Console.WriteLine("valor ingresado fuera de rango");
                                Console.WriteLine("Presiones una tecla para continuar");
                                Console.ReadKey(true);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("la opcion elejida no es valida");
                                Console.WriteLine("Presiones una tecla para continuar");
                                Console.ReadKey(true);
                            }
                            catch (DatoInvalidoException e)
                            {
                                Console.WriteLine(e.mensaje);
                                Console.WriteLine("Presiones una tecla para continuar");
                                Console.ReadKey(true);
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("la opcion elegida no es válida");
                        error = true;
                    }
                    catch (DatoInvalidoException e)
                    {
                        Console.WriteLine(e.mensaje);
                        error = true;
                    }


                } while (Supermercado.opcion != 0);
            } while (error == true);


            //
            do {//UNA VEZ QUE FINALIZA LA COMPRA
                try
                {
                    if (Supermercado.getCantidadProductosCarro() == 0)
                        throw new CarroVacioException("el carro esta vacio, no se ejecutara el pago en la caja");
                
                
                    Console.Clear();
                    Console.WriteLine("*******************************************************************************");
                    Console.WriteLine("******                             SUPERMERCADO                          ******");
                    Console.WriteLine("******                            Modulo Cliente                         ******");
                    Console.WriteLine("*******************************************************************************");
                    Console.WriteLine();
                    Console.WriteLine("Productos en el carro");
                    Supermercado.mostrarCarro();
                    Console.WriteLine("**********************************************");
                    Console.WriteLine();
                    Console.WriteLine("Cajas abiertas: ");
                    Supermercado.cajasAbiertas();
                    Console.WriteLine();
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("Que caja elije para pagar?");
                    Console.WriteLine();
                
                    caja = int.Parse(Console.ReadLine());//elejimos la caja
                    if (Supermercado.caja[caja - 1].Abierto == false)//comprobamos que la caja este abierta
                        throw new CajaCerradaException();//si esta cerrada lanza la excepcion, sino se ognora esta linea

                }
                catch (FormatException)
                {
                    Console.WriteLine("El dato ingresado no es valido!");
                    caja = -1;//se usa la opcion para poder volver a mostrar los productos y darle la oportunidad nuevamente de elejir una caja
                    Console.WriteLine("presione una tecla para continuar");
                    Console.ReadKey(true);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("el numero de caja es invalido, intente de vuelta");
                    caja = -1;
                    Console.WriteLine("presione una tecla para continuar");
                    Console.ReadKey(true);
                }
                catch (CajaCerradaException)
                {
                    Console.WriteLine("se ha ingresado una caja que no esta abierta");
                    caja = -1;
                    Console.WriteLine("presione una tecla para continuar");
                    Console.ReadKey(true);

                }
                catch (CarroVacioException e)
                {
                    Console.WriteLine(e.mensaje);
                    Console.WriteLine("presione una tecla para continuar");
                    Console.ReadKey(true);
                    return;
                }

                } while (caja==-1);//-1 si hubo algun error, si no cometio ningun error, sale de este while
            try
            {
                
                Console.WriteLine("Ingrese el dni del cliente");//pedimos el dni del cliente para poder proceder con la compra, y acumular los gastos de su compra
                dni = int.Parse(Console.ReadLine());
                if (Supermercado.existeCliente(dni) == false)//en caso de que el dni del cliente no este en el arraylist de los clientes
                {
                    Supermercado.nuevoCliente(dni);//ejecutamos la funcion para obtener  los datos del nuevo cliente
                }
                Console.WriteLine("total a pagar: " + Supermercado.pagarConDescuento());//mostramos el total a pagar por el cliente con los descuentos de las promociones si hubiese (dentro de la funcion se detalla todo)
                Console.WriteLine("con su compra ahorro: " + (Supermercado.getTotalCarro() - Supermercado.pagarConDescuento()));//se muestra lo que ahorra el cliente gracias a las promociones
                Supermercado.caja[caja - 1].Recaudado += Supermercado.pagarConDescuento();//aca se va acumulando lo recaudado por la caja
                Supermercado.acumularDineroCajero(caja);//aca se va acmulando lo recaudado por el cajero que esta atendiendo
                Supermercado.acumularDineroPersonas(dni);//aqui se acumula el dinero que gastaron los clientes
                Supermercado.acumularDineroTotal();//aqui se acumula el total de las ganancias
                Console.WriteLine("presiona una tecla para continuar");
                Console.ReadKey(true);
            }
            catch (FormatException)
            {
                Console.WriteLine("El dato ingresado no es valido!");
            }
            catch
            {
                Console.WriteLine("ha ocurrido un error");
                Console.ReadKey(true);
            }
            
            
            
        }

        public static void administracion()
        {
            int opc=0;
            do{
                Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("******                             SUPERMERCADO                          ******");
                Console.WriteLine("******                         Modulo Administracion                     ******");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("");
                Console.WriteLine("Seccion administracion");
                Console.WriteLine("");
                Console.WriteLine("1-Total recaudado");
                Console.WriteLine("2-Recaudado por caja");
                Console.WriteLine("3-Recaudado por cajero");
                Console.WriteLine("4-Recaudado por cliente");
                Console.WriteLine("5-Volver");

                try
                {
                    opc = int.Parse(Console.ReadLine());//unicamente a esta linea ya que el usuario puede ingresar una letra como opcion y no es valido
                    switch (opc)
                    {
                        case 1:
                            Supermercado.TotalRecaudado();
                            Console.WriteLine("");
                            Console.WriteLine("Presione una tecla para continuar");
                            Console.ReadKey(true);
                            break;
                        case 2:
                            Supermercado.TotalRecaudado_caja();
                            Console.WriteLine("");
                            Console.WriteLine("Presione una tecla para continuar");
                            Console.ReadKey(true);
                            break;
                        case 3:
                            Supermercado.totalRecaudadoPorCajero();
                            Console.WriteLine("");
                            Console.WriteLine("Presione una tecla para continuar");
                            Console.ReadKey(true);
                            break;
                        case 4:
                            Supermercado.totalRecaudadoPorCliente();
                            Console.WriteLine("");
                            Console.WriteLine("Presione una tecla para continuar");
                            Console.ReadKey(true);
                            break;
                        case 5:
                            Console.WriteLine("Volviendo al Menu principal");
                            break;
                        default:
                            Console.WriteLine("La opcion ingresada es incorrecta. Por favor ingrese nuevamente una opcion.");
                            break;
                    }
                }//fin try
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, ingrese el numero correcto entre las opciones 1-5");
                    Console.ReadKey(true);
                    continue;

                }//fin catch

                

            }while(opc!=5);
            
        }

        

    }//  <---ESTE CORCHETE MARCA EL FIN DE LA CLASE, TODA FUNCION DEBE ESTAR ANTES DE ESTE CORCHETE
}