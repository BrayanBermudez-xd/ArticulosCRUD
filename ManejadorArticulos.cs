using System;
using System.Collections.Generic;
using System.Linq;

namespace ArticulosCRUD
{
    internal class ManejadorArticulos
    {
        private List<Producto> ListaProductos;

        public ManejadorArticulos()
        {
            ListaProductos = new List<Producto>();
        }

        public void AgregarProducto(string nombre, int cantidad, decimal precio)
        {
            int nuevoId;

            if (ListaProductos.Count == 0)
            {
                nuevoId = 1;
            }
            else
            {
                nuevoId = ListaProductos.Max(p => p.Id) + 1;
            }

            Producto producto = new Producto(
                nuevoId,
                nombre,
                cantidad,
                precio
            );

            ListaProductos.Add(producto);
        }

        public void ListarProductos()
        {
            if (ListaProductos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                return;
            }

            foreach (Producto item in ListaProductos)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public Producto? BuscarProductoPorID(int id)
        {
            foreach (Producto producto in ListaProductos)
            {
                if (producto.Id == id)
                {
                    return producto;
                }
            }

            return null;
        }

        public List<Producto> BuscarProductosPorNombre(string nombre)
        {
            return ListaProductos
                .Where(p => p.Nombre.Contains(
                    nombre,
                    StringComparison.OrdinalIgnoreCase
                ))
                .ToList();
        }

        public void ModificarProducto(
            int id,
            string nombre,
            decimal precio,
            int cantidad
        )
        {
            Producto? producto = BuscarProductoPorID(id);

            if (producto is not null)
            {
                producto.Nombre = nombre;
                producto.Precio = precio;
                producto.Cantidad = cantidad;
            }
        }

        public void EliminarProducto(int id)
        {
            Producto? producto = BuscarProductoPorID(id);

            if (producto is not null)
            {
                ListaProductos.Remove(producto);
            }
        }
    }
}