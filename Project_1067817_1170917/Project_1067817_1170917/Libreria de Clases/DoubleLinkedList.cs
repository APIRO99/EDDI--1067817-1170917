using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1067817_1170917.Libreria_de_Clases
{
    public class DoubleLinkedList<T>
    {
        private class Node
        {
            Node next = null;
            Node prev = null;
            T element = default(T);

            public Node(Node p, Node n, T e)
            {
                next = n;
                prev = p;
                element = e;
            }//builder
            public void SetNext(Node n)
            {
                next = n;
            }//Set the next node
            public Node GetNext()
            {
                return next;
            }//get the next node
            public void SetPrev(Node p)
            {
                prev = p;
            }//Set the prev node
            public Node GetPrev()
            {
                return prev;
            }//get the prev node
            public T GetElement()
            {
                return element;
            }//Return the element of the node
            public void DeleteReferences()
            {
                next = null; prev = null;
            }//Delete the references to the next and the prev node
        }//Node class

        Node head = null;
        Node trailer = null;
        int size;
        public DoubleLinkedList()
        {
            head = new Node(null, null, default(T));
            trailer = new Node(head, null, default(T));
            head.SetNext(trailer);
            size = 0;
        }//builder

        public void AddFirst(T element)
        {
            Node p = new Node(head, head.GetNext(), element);
            if (head.GetNext() == trailer)
            {
                head.SetNext(p);
                trailer.SetPrev(p);
            }
            else
            {
                head.GetNext().SetPrev(p);
                head.SetNext(p);
            }
            size++;
        }//Insertion − Adds an element at the beginning of the list.

        public void AddLast(T element)
        {
            Node p = new Node(trailer.GetPrev(), trailer, element);
            if (head.GetNext() == trailer)
            {
                head.SetNext(p);
                trailer.SetPrev(p);
            }
            else
            {
                trailer.GetPrev().SetNext(p);
                trailer.SetPrev(p);
            }
            size++;
        }//Insert Last − Adds an element at the end of the list.

        public T RemoveFirst()
        {
            Node e;
            if (head.GetNext() == trailer)
            {
                return default(T);
            }
            e = head.GetNext();
            head.SetNext(head.GetNext().GetNext());
            head.GetNext().SetPrev(head);
            e.DeleteReferences();
            size--;
            return e.GetElement();
        }//Deletion − Deletes an element at the beginning of the list.

        public T RemoveLast()
        {
            Node e;
            if (head.GetNext() == trailer)
            {
                return default(T);
            }
            e = trailer.GetPrev();
            trailer.SetPrev(trailer.GetPrev().GetPrev());
            trailer.GetPrev().SetNext(trailer);
            e.DeleteReferences();
            size--;
            return e.GetElement();
        }//Delete Last − Deletes an element from the end of the list.

        public void InsertAfter(T referenceElement, T newElement)
        {
            Node p;
            p = head;
            while (!p.GetElement().Equals(referenceElement))
            {
                p = p.GetNext();
            }
            p.SetNext(new Node(p, p.GetNext(), newElement));
            p.GetNext().GetNext().SetPrev(p.GetNext());
            size++;
        }//Insert After − Adds an element after an item of the list.

        public T[] GetDataInArray()
        {
            T[] array = new T[size];
            Node p = new Node(null, head.GetNext(), default(T));
            for (int i = 0; i < size; i++)
            {
                array[i] = p.GetNext().GetElement();
                p.SetNext(p.GetNext().GetNext());
            }
            return array;
        }
    }
}