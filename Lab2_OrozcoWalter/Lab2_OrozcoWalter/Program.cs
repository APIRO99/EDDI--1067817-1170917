using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_OrozcoWalter
{
    public delegate bool DelegateComparacion(Libro libro);

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Libro> lista = new LinkedList<Libro>();
            lista.AddLast(new Libro() {Id = 1, Nombre = "El quijote", Edicion = "Primera"});
            lista.AddLast(new Libro() {Id = 2, Nombre = "Baldor", Edicion = "Tercera"});
            lista.AddLast(new Libro() {Id = 3, Nombre = "Sr. Presidente", Edicion = "Segunda"});

            // Instancia del delegado
            DelegateComparacion delegado = new DelegateComparacion(EsPrimeraEdicion);
            Console.WriteLine(delegado(lista.First()));
            DelegateComparacion delegado2 = x => x.Edicion == "Primera";
            DelegateComparacion delegado3 = x =>
                {
                    if (x.Edicion == "Primera")
                        return true;
                    else
                        return false;
                    };
            //buscar el libro con nombre Baldor
            var result = lista.Where(libro => libro.Nombre == "Baldor").ToList();
            var datos = lista.Where(variable => variable.Id == 1).ToList();
            Libro paraEliminar = lista.Where(variable => variable.Id == 1).First();
            Console.WriteLine(result.First().Nombre);
            lista.Remove(paraEliminar);//para eliminar un dato


            Console.ReadKey();
        }

        static bool EsPrimeraEdicion(Libro libro)
        {
            if (libro.Edicion == "Primera")
                return true;
            else
                return false;

        }

        //static Libro EsBaldor(Libro libro)
        //{
        //    if (libro.Nombre == "Baldor")
        //        return libro;
        //    else
        //        return null;

        //}
    }

    public class Libro
    {
        public int Id { get; set;}
        public string Nombre { get; set;}
        public string Edicion { get; set; }

    }
}
