namespace ListasDoblementeLigadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaDoble lista = new ListaDoble();

            lista.Agregar("A");

            lista.Agregar("B");
            lista.Agregar("C");
            lista.Agregar("D");
            lista.Agregar("E");

            Console.WriteLine(lista.ObtenerValores());

            lista.Eliminar("C");

            Console.WriteLine();
            Console.WriteLine(lista.ObtenerValores());
        }
    }
}
