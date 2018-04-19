using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xFlix_Proyecto_01.Models
{
    public class Node<E>
    {
        private List<E> keys;
        private Node<E> next;
        private Node<E> prev;
        bool isleaf;
        int nodeSize;

        public Node(int nodeSize, Boolean isLeaf)
        {
            keys = new List<E>();
            this.nodeSize = nodeSize;
            this.isleaf = isLeaf;
        }
        public List<E> getKeys()
        {
            return keys;
        }

        public void setKeys(List<E> keys)
        {
            this.keys = keys;
        }

        public Node<E> getNext()
        {
            return next;
        }

        public void setNext(Node<E> next)
        {
            this.next = next;
        }

        public Node<E> getPrev()
        {
            return prev;
        }

        public void setPrev(Node<E> prev)
        {
            this.prev = prev;
        }

        public bool isLeaf()
        {
            return isleaf;
        }

        public void setLeaf(bool isLeaf)
        {
            this.isleaf = isLeaf;
        }

        public int getNodeSize()
        {
            return nodeSize;
        }

        public void setNodeSize(int nodeSize)
        {
            this.nodeSize = nodeSize;
        }
    }
}
