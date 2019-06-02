using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Mi Escuela", 2010, ciudad:"Santiago");
            escuela.Pais = "Chile";
            escuela.TipoEscuela = 0;

            var curso1 = new Curso()
            {
                Nombre = "101"
            };
            var curso2 = new Curso()
            {
                Nombre = "201"
            };
            var curso3 = new Curso()
            {
                Nombre = "301"
            };

            Console.WriteLine(escuela);
            Console.WriteLine("===============");
            Console.WriteLine($"Curso: {curso1.Nombre}, ID: {curso1.UniqueId}");
            Console.WriteLine($"Curso: {curso2.Nombre}, ID: {curso2.UniqueId}");
            Console.WriteLine($"Curso: {curso3.Nombre}, ID: {curso3.UniqueId}");

        }
    }
}
