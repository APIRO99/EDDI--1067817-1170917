using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xFlix_Proyecto_01.Models
{
    namespace IntentoArbol
    {
        class BinaryTree<E> where E : IComparable
        {
            private int leafSize;
            private int internalSize;
            private Node<E> root;
            private int size;
            private List<Node<E>> buffer;
            private int bufferboolSize;

            public BinaryTree(int leafSize, int internalSize, int bufferbool)
            {
                this.leafSize = leafSize;
                this.internalSize = internalSize;
                this.root = new Node<E>(leafSize, true);
                buffer = new List<Node<E>>();
                this.bufferboolSize = bufferbool;
            }
            public void insetNode(E key, Object data)
            {
                LinkedList<Node<E>> stack = new LinkedList<Node<E>>();
                Node<E> n = root;
            }
            public Node<E> search(E key)
            {
                for (int i = 0; i < buffer.Count; i++)
                {
                    List<E> find = buffer[i].getKeys();
                    if (find.Contains(key))
                    {
                        return buffer[i];
                    }
                }
                Node<E> n = root;
                while (!(n.isLeaf()))
                {

                    if (key.CompareTo(n.getKeys()[0]) < 0)
                    {
                    }
                    else if (key.CompareTo(n.getKeys()[n.getKeys().Count - 1]) >= 0)
                    {
                    }
                    else
                    {
                        for (int i = 0; i < n.getKeys().Count - 1; i++)
                        {
                            if (n.getKeys().Count > 1 && key.CompareTo(n.getKeys()[i]) >= 0 && key.CompareTo(n.getKeys()[i + 1]) < 0)
                            {
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < n.getKeys().Count; i++)
                {
                    if (key.CompareTo(n.getKeys()[i]) == 0)
                    {
                        if (buffer.Count == bufferboolSize)
                        {
                            buffer.RemoveAt(0);
                            buffer.Add(n);
                        }
                        else
                        {
                            buffer.Add(n);
                        }
                        return n;
                    }
                }
                return null;
            }

            public int getLeafSize()
            {
                return leafSize;
            }

            public void setLeafSize(int leafSize)
            {
                this.leafSize = leafSize;
            }

            public int getInternalSize()
            {
                return internalSize;
            }

            public void setInternalSize(int internalSize)
            {
                this.internalSize = internalSize;
            }

            public Node<E> getRoot()
            {
                return root;
            }

            public void setRoot(Node<E> root)
            {
                this.root = root;
            }

            public int getSize()
            {
                return size;
            }

            public void setSize(int size)
            {
                this.size = size;
            }
        }
    }
}