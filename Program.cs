using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Mi Escuela", 2010, ciudad: "Santiago");
            escuela.Pais = "Chile";
            escuela.TipoEscuela = 0;

            var cursos = new Curso[3];

            cursos[0] = new Curso() { Nombre = "101" };

            var curso2 = new Curso()
            {
                Nombre = "201"
            };

            cursos[1] = curso2;

            cursos[2] = new Curso { Nombre = "301" };

            Console.WriteLine(escuela);
            Console.WriteLine("===============");

            ImprimirCursos(cursos);
            Console.WriteLine("===============");
            ImprimirCursosForEach(cursos);
        }

        private static void ImprimirCursosForEach(Curso[] cursos)
        {
            foreach (var curso in cursos)
            {
                Console.WriteLine($"Curso: {curso.Nombre}, ID: {curso.UniqueId}");
            }
        }

        private static void ImprimirCursos(Curso[] cursos)
        {
            int i = 0;
            while (i < cursos.Length)
            {
                Console.WriteLine($"Curso: {cursos[i].Nombre}, ID: {cursos[i].UniqueId}");
                i++;
            }
        }
    }
}
