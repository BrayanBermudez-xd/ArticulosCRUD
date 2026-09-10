using System;
using System.Collections.Generic;
using System.Linq;
namespace ArticulosCRUD
{
    internal class Menu
    {
        private readonly string Titulo;
        private readonly string[] Opciones;

        public ManejadorArticulos Manejador { get; set; }

        public Menu(string titulo, string[] opciones)
        {
            Titulo = titulo;
            Opciones = opciones;
            Manejador = new ManejadorArticulos();
        }

        public void MostrarMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();

                Console.WriteLine(Titulo);
                Console.WriteLine(new string('=', Titulo.Length));

                for (int i = 0; i < Opciones.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Opciones[i]}");
                }

                Console.WriteLine("0. Salir");

                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "0":
                        continuar = false;
                        break;

                    case "1":
                        MostrarAgregar();
                        break;

                    case "2":
                        MostrarListar();
                        break;

                    case "3":
                        MostrarMenuBuscar();
                        break;

                    case "4":
                        MostrarModificar();
                        break;

                    case "5":
                        MostrarEliminar();
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public void MostrarAgregar()
        {
            Console.Clear();

            Console.WriteLine("Agregar Producto");
            Console.WriteLine("================");
            Console.WriteLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Precio: ");
            decimal precio = decimal.TryParse(
                Console.ReadLine(),
                out decimal valor
            ) ? valor : 0;

            Console.Write("Cantidad: ");
            int cantidad = int.TryParse(
                Console.ReadLine(),
                out int valor2
            ) ? valor2 : 0;

            Manejador.AgregarProducto(nombre, cantidad, precio);

            Console.WriteLine();
            Console.WriteLine("Producto creado correctamente.");
            Console.ReadLine();
        }

        public void MostrarListar()
        {
            Console.Clear();

            Console.WriteLine("Listar Productos");
            Console.WriteLine("================");
            Console.WriteLine();

            Manejador.ListarProductos();

            Console.ReadLine();
        }

        public void MostrarBuscar()
        {
            Console.Clear();

            Console.WriteLine("Buscar Producto por ID");
            Console.WriteLine("======================");
            Console.WriteLine();

            int id = PedirValorEntero("ID");

            Producto? resultado = Manejador.BuscarProductoPorID(id);

            Console.WriteLine();

            if (resultado != null)
            {
                Console.WriteLine(resultado.ToString());
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }

            Console.ReadLine();
        }

        public void MostrarBuscarNombre()
        {
            Console.Clear();

            Console.WriteLine("Buscar Por Nombre");
            Console.WriteLine("=================");
            Console.WriteLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            var productos = Manejador.BuscarProductosPorNombre(nombre);

            Console.WriteLine();

            if (productos.Count == 0)
            {
                Console.WriteLine("No se encontraron productos.");
            }
            else
            {
                foreach (Producto item in productos)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            Console.ReadLine();
        }

        public int PedirValorEntero(string titulo)
        {
            while (true)
            {
                Console.Write($"{titulo}: ");

                if (int.TryParse(Console.ReadLine(), out int valor))
                {
                    return valor;
                }

                Console.WriteLine("Valor no permitido. Ingresa nuevamente.");
            }
        }

        public void MostrarModificar()
        {
            Console.Clear();

            Console.WriteLine("Modificar Producto");
            Console.WriteLine("==================");
            Console.WriteLine();

            int id = PedirValorEntero("ID de producto");

            Producto? producto = Manejador.BuscarProductoPorID(id);

            if (producto is null)
            {
                Console.WriteLine("Producto no encontrado.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine(producto.ToString());

            Console.WriteLine();
            Console.WriteLine("Ingrese los datos nuevos.");
            Console.WriteLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";

            Console.Write("Precio: ");
            decimal precio = decimal.TryParse(
                Console.ReadLine(),
                out decimal valor
            ) ? valor : 0;

            Console.Write("Cantidad: ");
            int cantidad = int.TryParse(
                Console.ReadLine(),
                out int valor2
            ) ? valor2 : 0;

            Manejador.ModificarProducto(
                id,
                nombre,
                precio,
                cantidad
            );

            Console.WriteLine();
            Console.WriteLine("Producto modificado correctamente.");

            Console.ReadLine();
        }

        public void MostrarEliminar()
        {
            Console.Clear();

            Console.WriteLine("Eliminar Producto");
            Console.WriteLine("=================");
            Console.WriteLine();

            int id = PedirValorEntero("ID del producto");

            Producto? producto = Manejador.BuscarProductoPorID(id);

            if (producto is null)
            {
                Console.WriteLine("Producto no encontrado.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine(producto.ToString());

            Console.WriteLine();
            Console.Write("¿Deseas eliminar el producto? (s/n): ");

            string respuesta = Console.ReadLine()?.Trim() ?? "n";

            if (!respuesta.Equals(
                "s",
                StringComparison.OrdinalIgnoreCase
            ))
            {
                Console.WriteLine();
                Console.WriteLine("Operación cancelada.");
                Console.ReadLine();
                return;
            }

            Manejador.EliminarProducto(id);

            Console.WriteLine();
            Console.WriteLine("Producto eliminado correctamente.");

            Console.ReadLine();
        }

        public void MostrarMenuBuscar()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();

                Console.WriteLine("Buscar Artículos");
                Console.WriteLine("================");
                Console.WriteLine("1. Por ID");
                Console.WriteLine("2. Por Nombre");
                Console.WriteLine("0. Regresar");

                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "0":
                        continuar = false;
                        break;

                    case "1":
                        MostrarBuscar();
                        break;

                    case "2":
                        MostrarBuscarNombre();
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}