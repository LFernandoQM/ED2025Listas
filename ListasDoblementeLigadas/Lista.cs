using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListasDoblementeLigadas
{
    internal class ListaDoble
    {
        private Nodo _nodoInicial;

        public ListaDoble()
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

            Nodo nodoNuevo = new Nodo
            {
                Dato = dato,
                Anterior = nodoActual
            };

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
                    if (nodoActual.Anterior != null)
                    {
                        nodoActual.Anterior.Siguiente = nodoActual.Siguiente;
                    }

                    if (nodoActual.Siguiente != null)
                    {
                        nodoActual.Siguiente.Anterior = nodoActual.Anterior;
                    }

                    nodoActual.Siguiente = null;
                    nodoActual.Anterior = null;
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

    internal class Nodo
    {
        public string Dato { get; set; }
        public Nodo? Siguiente { get; set; }
        public Nodo? Anterior { get; set; }
    }
}
