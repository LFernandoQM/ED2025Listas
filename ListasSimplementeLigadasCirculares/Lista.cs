using System.Text;

namespace ListasSimplementeLigadasCirculares 
{
    internal class ListaCircular
    {
        private Nodo _nodoInicial;

        public ListaCircular()
        {
            _nodoInicial = new Nodo();
            _nodoInicial.Siguiente = _nodoInicial;
        }

        public void Agregar(string dato)
        {
            Nodo nodoActual = _nodoInicial;

            while (nodoActual.Siguiente != _nodoInicial)
            {
                nodoActual = nodoActual.Siguiente;
            }

            Nodo nodoNuevo = new Nodo();
            nodoNuevo.Dato = dato;

            nodoNuevo.Siguiente = _nodoInicial;
            nodoActual.Siguiente = nodoNuevo;
        }

        public bool EstaVacio()
        {
            return (_nodoInicial.Siguiente == _nodoInicial);
        }

        public void Vaciar()
        {
            _nodoInicial.Siguiente = _nodoInicial;
        }

        public Nodo? Buscar(string dato)
        {
            if (!EstaVacio())
            {
                Nodo nodoActual = _nodoInicial.Siguiente;

                while (nodoActual != _nodoInicial)
                {
                    if (nodoActual.Dato == dato)
                    {
                        return nodoActual;
                    }

                    nodoActual = nodoActual.Siguiente;
                }
            }
            return null;
        }

        private Nodo? BuscarAnterior(string dato)
        {
            if (!EstaVacio())
            {
                Nodo nodoActual = _nodoInicial;

                while (nodoActual.Siguiente != _nodoInicial)
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
            Nodo nodoActual = _nodoInicial.Siguiente;

            while (nodoActual != _nodoInicial)
            {
                datos.AppendLine(nodoActual.Dato);
                nodoActual = nodoActual.Siguiente;
            }

            return datos.ToString();
        }
    }

    internal class Nodo
    {
        public string Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo()
        {
            Dato = string.Empty;
            Siguiente = this;
        }
    }
}
