using System.Text; // Esto permite utilizar la clase StringBuilder

namespace ListasSimplementeLigadas // Nombre del proyecto
{
    // Es la clase de una lista simplemente ligada
    internal class Lista
    {
        // Nodo inicial de la lista
        private Nodo _nodoInicial;

        // Constructor que inicializa la lista con un nodo vacío
        public Lista()
        {
            _nodoInicial = new Nodo();
        }

        // Metodo para agregar un nuevo dato a la lista
        public void Agregar(string dato)
        {
            Nodo nodoActual = _nodoInicial;

            // Recorre la lista hasta encontrar el ultimo nodo
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }

            // Crear un nuevo nodo con el dato proporcionado
            Nodo nodoNuevo = new Nodo();
            nodoNuevo.Dato = dato;

            // Enlazar el nuevo nodo al final de la lista
            nodoActual.Siguiente = nodoNuevo;
        }

        // Metodo que verifica si la lista esta vacía
        public bool EstaVacio()
        {
            return (_nodoInicial.Siguiente == null);
        }

        // Metodo para vaciar la lista
        public void Vaciar()
        {
            _nodoInicial.Siguiente = null;
        }

        // Metodo para buscar un dato en la lista
        public Nodo? Buscar(string dato)
        {
            if (!EstaVacio())
            {
                Nodo nodoActual = _nodoInicial;

                // Recorre la lista en busca del dato
                while (nodoActual.Siguiente != null)
                {
                    nodoActual = nodoActual.Siguiente;

                    // Si se encuentra el dato... retorna el nodo correspondiente
                    if (nodoActual.Dato == dato)
                    {
                        return nodoActual;
                    }
                }
            }
            // Si no se encuentra el dato... retorna null
            return null;
        }

        // Metodo para buscar el nodo anterior al que contiene el dato proporcionado
        private Nodo? BuscarAnterior(string dato)
        {
            if (!EstaVacio())
            {
                Nodo nodoActual = _nodoInicial;

                // Recorre la lista en busca del nodo anterior
                while (nodoActual.Siguiente != null)
                {
                    if (nodoActual.Siguiente.Dato == dato)
                    {
                        return nodoActual;
                    }

                    nodoActual = nodoActual.Siguiente;
                }
            }
            // Si no se encuentra el nodo anterior...retorna null
            return null;
        }

        // Metodo para eliminar un nodo que contiene el dato proporcionado
        public void Eliminar(string dato)
        {
            if (!EstaVacio())
            {
                // Buscar el nodo que contiene el dato
                Nodo? nodoActual = Buscar(dato);

                if (nodoActual != null)
                {
                    // Buscar el nodo anterior al que contiene el dato
                    Nodo? nodoAnterior = BuscarAnterior(dato);

                    if (nodoAnterior != null)
                    {
                        // Eliminar el nodo de la lista
                        nodoAnterior.Siguiente = nodoActual.Siguiente;
                        nodoActual.Siguiente = null;
                    }
                }
            }
        }

        // Metodo para obtener todos los valores de la lista en forma de cadena
        public string ObtenerValores()
        {
            StringBuilder datos = new StringBuilder();
            Nodo nodoActual = _nodoInicial;

            // Recorre la lista y agrega cada dato a la cadena
            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;

                datos.AppendLine(nodoActual.Dato);
            }

            // Retorna la cadena con todos los datos de la lista
            return datos.ToString();
        }
    }
}
