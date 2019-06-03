using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializador();

            WriteLine(engine.Escuela);
            ImprimirCursosEscuela(engine.Escuela);
        }

        //private static bool Predicado(Curso obj) => obj.Nombre == "301";

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la escuela: " + escuela.Nombre);

            //EL SIGNO DE ? VERIFICA PRIMERO, QUE ESCUELA NO SE NULL
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Curso: {curso.Nombre}, Jornada: {curso.TipoJornada}, ID: {curso.UniqueId}");
                }
            }
        }
    }
}
