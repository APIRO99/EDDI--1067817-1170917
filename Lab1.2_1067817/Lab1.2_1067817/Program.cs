using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._2_1067817
{
    public delegate bool DelegateComparacion(Libro l);

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Libro> lista = new LinkedList<Libro>();
            lista.AddLast(new Libro() { ID = 1, nombre = "El Quijote", edicion = "Primera" });
            lista.AddLast(new Libro() { ID = 2, nombre = "Baldor", edicion = "Tercera" });
            lista.AddLast(new Libro() { ID = 3, nombre = "Sr. Presidente", edicion = "Segunda" });
            lista.AddLast(new Libro() { ID = 4, nombre = "Los juegos del hambre", edicion = "Segunda" });
            lista.AddLast(new Libro() { ID = 5, nombre = "Harry Potter", edicion = "Primera" });
            lista.AddLast(new Libro() { ID = 6, nombre = "El hombre que cuenta", edicion = "Primera" });
            lista.AddLast(new Libro() { ID = 7, nombre = "Alex dogboy", edicion = "Primera" });
            lista.AddLast(new Libro() { ID = 8, nombre = "La biblia", edicion = "Tercera" });
            lista.AddLast(new Libro() { ID = 9, nombre = "el señor de los anillos", edicion = "Primera" });
            lista.AddLast(new Libro() { ID = 10, nombre = "Crepusculo", edicion = "Primera" });

            //Instancia del delegado
            DelegateComparacion delegado = new DelegateComparacion(EsPrimeraEdicion);
            Console.WriteLine(delegado(lista.First()));
            Console.WriteLine(delegado(lista.Last()));
            
            //Parametros evaluacion
            DelegateComparacion delegado2 = x => x.edicion == "Primera";
            DelegateComparacion delegado3 = x =>
            {
                if (x.edicion == "Primera")
                    return true;
                return false;
            };

            //buscar el libro con nombre baldor
            var result = lista.Where(libro => libro.edicion == "Primera").ToList();
            var datos = lista.Where(variable => variable.ID == 1).ToList();
            int resultsize = result.Count();
            for (int i = 0; i < resultsize; i++)
            {
                Console.WriteLine(result.First().nombre);
                result.Remove(result.First());
            }
            Console.ReadKey();
        }


        static bool EsPrimeraEdicion(Libro l)
        {
            if (l.edicion == "Primera")
                return true;
            return false;
        }
    }

    public class Libro
    {
        public int ID { get; set; }

        public string nombre { get; set; }

        public string edicion { get; set; } 
    }
}
