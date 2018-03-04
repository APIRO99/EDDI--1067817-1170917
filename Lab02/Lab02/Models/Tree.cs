using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02.Models
{
    public class Tree<T> where T : IComparable
    {
        public T valor;
        public Tree<T> izquierdo;
        public Tree<T> derecho;

        public Tree<T> Insertar(Tree<T> newNode, T newValor)
        {
            if (newNode == null) newNode = new Tree<T> { valor = newValor };
            else if (newNode.valor.CompareTo(newValor) < 0) newNode.izquierdo = Insertar(newNode.izquierdo, newValor);
            else newNode.derecho = Insertar(newNode.derecho, newValor);
            return newNode;
        }//?

//        public Tree<T> Delete(Tree<T> DelNode, T DelValor)
//        {
//            if (DelNode.valor.CompareTo(DelValor) == 0)
//            {
//
//            }
//            else if (DelNode.valor.CompareTo(DelValor) == 0) 
//           //Validar si tiene un hijo
//           //Validar si tiene dos
//           //Validar si no tiene
//       }//?

        public bool EsDegenerado(Tree<T> TreeRoot)
        {
            if (this.MaxDepth(TreeRoot, 0, 0) == this.NumOfNodes(TreeRoot, 0)) return true;
            else return false;
        }//Ya testeado
        public bool EsLleno(Tree<T> TreeRoot)
        {
            if (this.NumOfNodes(TreeRoot, 0) == (Math.Pow(2, this.MaxDepth(TreeRoot, 0, 0)) - 1))
                return true;
            return false;
        }//Ya testeado

        public int MaxDepth(Tree<T> TreeRoot, int Piz, int Pder)
        {
            if (TreeRoot.izquierdo != null)
            {
                Piz = MaxDepth(TreeRoot.izquierdo, Piz, Pder);
                Piz++;
            }
            else
                Piz = 0;

            if (TreeRoot.derecho != null)
            {
                Pder = MaxDepth(TreeRoot.derecho, Piz, Pder);
                Pder++;
            }
            else
                Pder = 0;

            if (Piz == 0 && Pder == 0) return 1;
            else if (Piz >= Pder) return Piz;
            else return Pder;
        }//Ya testeado
        public int NumOfNodes(Tree<T> TreeRoot, int n)
        {
            n++;
            if (TreeRoot.izquierdo != null) n += NumOfNodes(TreeRoot.izquierdo, 0);
            if (TreeRoot.derecho != null) n += NumOfNodes(TreeRoot.derecho, 0);
            return n;
        }//Ya testeado

        public void PreOrden(Tree<T> TreeRoot, ref LinkedList<T> Data)
        {
            Data.AddLast(TreeRoot.valor);
            if (TreeRoot.izquierdo != null) PreOrden(TreeRoot.izquierdo, ref Data);
            if (TreeRoot.derecho != null) PreOrden(TreeRoot.derecho, ref Data);
        }//Ya testeado
        public void InOrden(Tree<T> TreeRoot, ref LinkedList<T> Data)
        {
            if (TreeRoot.izquierdo != null) InOrden(TreeRoot.izquierdo, ref Data);
            Data.AddLast(TreeRoot.valor);
            if (TreeRoot.derecho != null) InOrden(TreeRoot.derecho, ref Data);
        }//Ya testeado
        public void PostOrden(Tree<T> TreeRoot, ref LinkedList<T> Data)
        {
            if (TreeRoot.izquierdo != null) PostOrden(TreeRoot.izquierdo, ref Data);
            if (TreeRoot.derecho != null) PostOrden(TreeRoot.derecho, ref Data);
            Data.AddLast(TreeRoot.valor);
        }//Ya testeado
    }

    public class Pais : IComparable
    {
        public string nombre { get; set; }
        public string Grupo { get; set; }

        public int CompareTo(object obj)
        {
            Pais compareToObj = (Pais)obj;
            return this.nombre.CompareTo(compareToObj.nombre);
        }
    }
}