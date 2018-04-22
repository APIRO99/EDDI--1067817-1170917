using Lab1_1170917.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1_1170917.Class
{
    public class Data
    {
        //Instancear la clase Data
        private static Data instance;
        public static Data Instance
        {
            get
            {
                // Crear una nueva instancia si instance esta vacio
                if (instance == null) instance = new Data();
                return instance;
            }
        }

        //Lista de jugadores
        public List<Jugador> Jugadores;

        //Datos de los jugadores en una lista con objeto
        public Data()
        {
            Jugadores = new List<Jugador>();
        }
    }
}