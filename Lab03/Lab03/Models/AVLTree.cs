using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab03.Models
{
    public class AVLTree <T>
    {
        private  class Node
        {
            T elemento;
            AVLTree<T> Left;
            AVLTree<T> Right;
        }

        AVLTree<T> root;

    }

    public class Match : IComparable
    {
            public int NoMatch { get; set; }
            public DateTime MatchDay { get; set; }
            public string Group { get; set; }
            public string Team1 { get; set; }
            public string Team2 { get; set; }
            public string Stadium { get; set; }

        public int CompareTo(object obj)
        {
            Match compareToObj = (Match)obj;
            return this.NoMatch.CompareTo(compareToObj.NoMatch);
        }

    }
}