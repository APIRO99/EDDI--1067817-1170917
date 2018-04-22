using Lab_001_Office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Lab_001_Office.Classes
{
    public class Data
    {
        private static Data instance;
        public static Data Instance
        {
            get
            {
                if (instance == null) instance = new Data();
                return instance;
            }
        }

        public List<MLS> Jugadores;

        public Data()
        {
            Jugadores = new List<MLS>();
        }
    }
}