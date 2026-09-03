 namespace ArticulosCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string titulo = "gestor de articulos";
            string[] opciones = ["Agregar", "Listar", "Buscar", "Modificar", "Eliminar"]; 
            Menu menu = new Menu();
            menu.MostrarMenu();
        }
    }
}
