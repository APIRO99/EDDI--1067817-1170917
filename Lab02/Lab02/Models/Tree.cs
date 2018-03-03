using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02.Models
{
    public class Tree<T>
    {
        public T Valor;
        public Tree<T> izquierdo = null;
        public Tree<T> derecho = null;


        public void Insertar(T newValor)
        {

        }
        public T Delete()
        {
            return default(T);
        }

        public bool EsDegenerado() { return true; }
        public bool EsLleno() { return true; }

        public void PreOrden(Tree<T> AB, ref LinkedList<T> Data)
        {
            Data.AddLast(AB.Valor);
            while (AB.izquierdo != null)
            {
                PreOrden(AB.izquierdo, ref Data);
            }
            while (AB.derecho != null)
            {
                PreOrden(AB.derecho, ref Data);
            }
        }
        public void InOrden(Tree<T> AB, ref LinkedList<T> Data)
        {
            while (AB.izquierdo != null)
            {
                InOrden(AB.izquierdo, ref Data);
            }
            Data.AddLast(AB.Valor);
            while (AB.derecho != null)
            {
                InOrden(AB.derecho, ref Data);
            }
        }
        public void PostOrden(Tree<T> AB, ref LinkedList<T> Data)
        {
            while (AB.izquierdo != null)
            {
                PostOrden(AB.izquierdo, ref Data);
            }
            while (AB.derecho != null)
            {
                PostOrden(AB.derecho, ref Data);
            }
            Data.AddLast(AB.Valor);
        }
    }

    public class Pais
    {
        string nombre;
        string Grupo;
    }   
}