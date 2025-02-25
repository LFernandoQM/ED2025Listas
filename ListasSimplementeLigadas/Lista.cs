using System.Text;

namespace ListasSimplementeLigadas
{
    internal class Lista
    {
        private Nodo _nodoInicial;

        public Lista() 
        {
            _nodoInicial = new Nodo();
        }

        public void Agregar(string dato)
        {
            Nodo nodoActual = _nodoInicial;

            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;
            }

            Nodo nodoNuevo = new Nodo();
            nodoNuevo.Dato = dato;

            nodoActual.Siguiente = nodoNuevo;
        }

        public bool EstaVacio() 
        {
            return (_nodoInicial.Siguiente == null); 
        }

        public void Vaciar()
        {
            _nodoInicial.Siguiente = null;
        }

        public Nodo? Buscar(string dato) 
        {
            if (!EstaVacio())
            {
                Nodo nodoActual = _nodoInicial;

                while (nodoActual.Siguiente != null)
                {
                    nodoActual = nodoActual.Siguiente;

                    if (nodoActual.Dato == dato)
                    {
                        return nodoActual;
                    }
                }
            }
            return null;
        }

        private Nodo? BuscarAnterior(string dato)
        {
            if (!EstaVacio())
            {
                Nodo nodoActual = _nodoInicial;

                while (nodoActual.Siguiente != null)
                {
                    if (nodoActual.Siguiente.Dato == dato)
                    {
                        return nodoActual;
                    }

                    nodoActual = nodoActual.Siguiente;
                }
            }
            return null;
        }

        public void Eliminar(string dato)
        {
            if (!EstaVacio())
            {
                Nodo? nodoActual = Buscar(dato);

                if (nodoActual != null)
                {
                    Nodo? nodoAnterior = BuscarAnterior(dato);

                    if (nodoAnterior != null)
                    {
                        nodoAnterior.Siguiente = nodoActual.Siguiente;
                        nodoActual.Siguiente = null;
                    }
                }
            }
        }

        public string ObtenerValores() 
        {
            StringBuilder datos = new StringBuilder();
            Nodo nodoActual = _nodoInicial;

            while (nodoActual.Siguiente != null)
            {
                nodoActual = nodoActual.Siguiente;

                datos.AppendLine(nodoActual.Dato);
            }

            return datos.ToString();
        }
    }
}
