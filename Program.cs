using System;
using CoreEscuela.Entidades;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Mi Escuela", 2010, ciudad: "Santiago");
            escuela.Pais = "Chile";
            escuela.TipoEscuela = 0;

            escuela.Cursos = new Curso[]{
                new Curso { Nombre = "101" },
                new Curso { Nombre = "201" },
                new Curso { Nombre = "301" }
            };

            WriteLine(escuela);
            ImprimirCursosEscuela(escuela);
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("======================================");
            WriteLine("Cursos de la escuela: " + escuela.Nombre);
            WriteLine("======================================");
            
            //EL SIGNO DE ? VERIFICA PRIMERO QUE ESCUELA NO SE NULL
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Curso: {curso.Nombre}, ID: {curso.UniqueId}");
                }
            }
        }
    }
}
