using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xFlix_Proyecto_01.Models
{
    public class BinaryTree<T> where T : IComparable
    {
        public T valor;
        public BinaryTree<T> izquierdo;
        public BinaryTree<T> derecho;

        public BinaryTree<T> Insertar(BinaryTree<T> newNode, T newValor)
        {
            if (newNode == null) newNode = new BinaryTree<T> { valor = newValor };
            else if (newNode.valor.CompareTo(newValor) < 0) newNode.izquierdo = Insertar(newNode.izquierdo, newValor);
            else newNode.derecho = Insertar(newNode.derecho, newValor);
            return newNode;
        }//?

        //        public BinaryTree<T> Delete(BinaryTree<T> DelNode, T DelValor)
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

        public bool EsDegenerado(BinaryTree<T> BinaryTreeRoot)
        {
            if (this.MaxDepth(BinaryTreeRoot, 0, 0) == this.NumOfNodes(BinaryTreeRoot, 0)) return true;
            else return false;
        }//Ya testeado
        public bool EsLleno(BinaryTree<T> BinaryTreeRoot)
        {
            if (this.NumOfNodes(BinaryTreeRoot, 0) == (Math.Pow(2, this.MaxDepth(BinaryTreeRoot, 0, 0)) - 1))
                return true;
            return false;
        }//Ya testeado

        public int MaxDepth(BinaryTree<T> BinaryTreeRoot, int Piz, int Pder)
        {
            if (BinaryTreeRoot.izquierdo != null)
            {
                Piz = MaxDepth(BinaryTreeRoot.izquierdo, Piz, Pder);
                Piz++;
            }
            else
                Piz = 0;

            if (BinaryTreeRoot.derecho != null)
            {
                Pder = MaxDepth(BinaryTreeRoot.derecho, Piz, Pder);
                Pder++;
            }
            else
                Pder = 0;

            if (Piz == 0 && Pder == 0) return 1;
            else if (Piz >= Pder) return Piz;
            else return Pder;
        }//Ya testeado
        public int NumOfNodes(BinaryTree<T> BinaryTreeRoot, int n)
        {
            n++;
            if (BinaryTreeRoot.izquierdo != null) n += NumOfNodes(BinaryTreeRoot.izquierdo, 0);
            if (BinaryTreeRoot.derecho != null) n += NumOfNodes(BinaryTreeRoot.derecho, 0);
            return n;
        }//Ya testeado

        public void PreOrden(BinaryTree<T> BinaryTreeRoot, ref LinkedList<T> Data)
        {
            Data.AddLast(BinaryTreeRoot.valor);
            if (BinaryTreeRoot.izquierdo != null) PreOrden(BinaryTreeRoot.izquierdo, ref Data);
            if (BinaryTreeRoot.derecho != null) PreOrden(BinaryTreeRoot.derecho, ref Data);
        }//Ya testeado
        public void InOrden(BinaryTree<T> BinaryTreeRoot, ref LinkedList<T> Data)
        {
            if (BinaryTreeRoot.izquierdo != null) InOrden(BinaryTreeRoot.izquierdo, ref Data);
            Data.AddLast(BinaryTreeRoot.valor);
            if (BinaryTreeRoot.derecho != null) InOrden(BinaryTreeRoot.derecho, ref Data);
        }//Ya testeado
        public void PostOrden(BinaryTree<T> BinaryTreeRoot, ref LinkedList<T> Data)
        {
            if (BinaryTreeRoot.izquierdo != null) PostOrden(BinaryTreeRoot.izquierdo, ref Data);
            if (BinaryTreeRoot.derecho != null) PostOrden(BinaryTreeRoot.derecho, ref Data);
            Data.AddLast(BinaryTreeRoot.valor);
        }//Ya testeado
    }

    public class Movies : IComparable
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }

        public int CompareTo(object obj)
        {
            Movies compareToObj = (Movies)obj;
            return this.Name.CompareTo(compareToObj.Name);
        }
    }
}