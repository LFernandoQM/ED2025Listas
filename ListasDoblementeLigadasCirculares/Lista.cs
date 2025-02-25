 using System.Text;

    namespace ListasDobleLigadasCirculares
    {
        internal class ListaDobleCircular
        {
            private NodoDoble _nodoInicial;

            public ListaDobleCircular()
            {
                _nodoInicial = new NodoDoble();
                _nodoInicial.Siguiente = _nodoInicial;
                _nodoInicial.Anterior = _nodoInicial;
            }

            public void Agregar(string dato)
            {
                NodoDoble nodoActual = _nodoInicial;

                while (nodoActual.Siguiente != _nodoInicial)
                {
                    nodoActual = nodoActual.Siguiente;
                }

                NodoDoble nodoNuevo = new NodoDoble();
                nodoNuevo.Dato = dato;

                nodoNuevo.Siguiente = _nodoInicial;
                nodoNuevo.Anterior = nodoActual;
                nodoActual.Siguiente = nodoNuevo;
                _nodoInicial.Anterior = nodoNuevo;
            }

            public bool EstaVacio()
            {
                return (_nodoInicial.Siguiente == _nodoInicial);
            }

            public void Vaciar()
            {
                _nodoInicial.Siguiente = _nodoInicial;
                _nodoInicial.Anterior = _nodoInicial;
            }

            public NodoDoble? Buscar(string dato)
            {
                if (!EstaVacio())
                {
                    NodoDoble nodoActual = _nodoInicial.Siguiente;

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

            public void Eliminar(string dato)
            {
                if (!EstaVacio())
                {
                    NodoDoble? nodoActual = Buscar(dato);

                    if (nodoActual != null)
                    {
                        nodoActual.Anterior.Siguiente = nodoActual.Siguiente;
                        nodoActual.Siguiente.Anterior = nodoActual.Anterior;

                        nodoActual.Siguiente = null;
                        nodoActual.Anterior = null;
                    }
                }
            }

            public string ObtenerValores()
            {
                StringBuilder datos = new StringBuilder();
                NodoDoble nodoActual = _nodoInicial.Siguiente;

                while (nodoActual != _nodoInicial)
                {
                    datos.AppendLine(nodoActual.Dato);
                    nodoActual = nodoActual.Siguiente;
                }

                return datos.ToString();
            }
        }

        internal class NodoDoble
        {
            public string Dato { get; set; }
            public NodoDoble Siguiente { get; set; }
            public NodoDoble Anterior { get; set; }

            public NodoDoble()
            {
                Dato = string.Empty;
                Siguiente = this;
                Anterior = this;
            }
        }
    }
