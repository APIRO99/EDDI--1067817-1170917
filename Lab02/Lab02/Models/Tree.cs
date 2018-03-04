using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab02.Models
{
    public class Tree<T> where T: IComparable
    {
        public class BinaryTree
        {
            public T Valor;
            public BinaryTree izquierdo;
            public BinaryTree derecho;
        }
        BinaryTree root;

        public BinaryTree GetRoot()
        {
            return root;
        }//Ya testeado

        public BinaryTree Insertar(BinaryTree newNode, T newValor)
        {
            if (newNode == null)
            {
                newNode = new BinaryTree();
                newNode.Valor = newValor;
            }
            else if (newNode.Valor.CompareTo(newValor) <= 0)
            {
                newNode.izquierdo = Insertar(newNode.izquierdo, newValor);
            }
            else
            {
                newNode.derecho = Insertar(newNode.derecho, newValor);
            }

            return newNode;
        }//?

        public T Delete()
        {
            return default(T);
        }//?

        public bool EsDegenerado() {            
            if (this.MaxDepth(root, 0, 0) == this.NumOfNodes(root, 0)) return true;
            else return false;
        }//Ya testeado
        public bool EsLleno()
        {
            if (this.NumOfNodes(root, 0) == (Math.Pow(2, this.MaxDepth(root, 0, 0)) - 1))
                return true;
            return false;
        }//Ya testeado

        public int MaxDepth(BinaryTree TreeRoot, int Piz, int Pder)
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
        public int NumOfNodes(BinaryTree TreeRoot, int n)
        {
            n++;
            if (TreeRoot.izquierdo != null) n += NumOfNodes(TreeRoot.izquierdo, 0);
            if (TreeRoot.derecho != null) n += NumOfNodes(TreeRoot.derecho, 0);
            return n;
        }//Ya testeado

        public void PreOrden(BinaryTree TreeRoot, ref LinkedList<T> Data)
        {
            Data.AddLast(TreeRoot.Valor);
            if (TreeRoot.izquierdo != null) PreOrden(TreeRoot.izquierdo, ref Data);
            if (TreeRoot.derecho != null) PreOrden(TreeRoot.derecho, ref Data);
        }//Ya testeado
        public void InOrden(BinaryTree TreeRoot, ref LinkedList<T> Data)
        {
            if (TreeRoot.izquierdo != null) InOrden(TreeRoot.izquierdo, ref Data);
            Data.AddLast(TreeRoot.Valor);
            if (TreeRoot.derecho != null) InOrden(TreeRoot.derecho, ref Data);
        }//Ya testeado
        public void PostOrden(BinaryTree TreeRoot, ref LinkedList<T> Data)
        {
            if (TreeRoot.izquierdo != null) PostOrden(TreeRoot.izquierdo, ref Data);
            if (TreeRoot.derecho != null) PostOrden(TreeRoot.derecho, ref Data);
            Data.AddLast(TreeRoot.Valor);
        }//Ya testeado
    }

    public class Pais : IComparable
    {
        string nombre;
        string Grupo;

        public int CompareTo(object obj)
        {
            Pais compareToObj = (Pais)obj;
            return this.nombre.CompareTo(compareToObj.nombre);
        }
    }   
}