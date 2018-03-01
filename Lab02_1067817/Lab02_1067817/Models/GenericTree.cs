using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02_1067817.Models
{
    
    public class GenericTree<T>
    { 
        private class Tree<T>
        {
            T element;
            Tree<T> Izquierdo = null;
            Tree<T> Derecho = null;
        }

        LinkedList<T> Orden = new LinkedList<T>;










        public void Insertar(T newElement)
        {

        }

        public T Delete()
        {
            return default(T);
        }

        public bool EsDegenerado() { return true; }
        public bool EsLleno() { return true; }

        public LinkedList<T> PreOrden(GenericTree<T> AB)
        {
        }
        public void InOrden()
        {

        }
        public void PostOrden()
        {

        }
    }
}