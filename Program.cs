using System;
using System.Collections.Generic;
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

            escuela.Cursos = new List<Curso>{
                new Curso { Nombre = "101", TipoJornada = TiposJornada.Mañana },
                new Curso { Nombre = "201", TipoJornada = TiposJornada.Mañana },
                new Curso { Nombre = "301", TipoJornada = TiposJornada.Mañana }
            };

            escuela.Cursos.Add(new Curso { Nombre = "102", TipoJornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso { Nombre = "202", TipoJornada = TiposJornada.Tarde });

            var otraColeccion = new List<Curso>{
                new Curso { Nombre = "302", TipoJornada = TiposJornada.Tarde },
                new Curso { Nombre = "401", TipoJornada = TiposJornada.Mañana },
                new Curso { Nombre = "402", TipoJornada = TiposJornada.Tarde }
            };

            escuela.Cursos.AddRange(otraColeccion);

            /* escuela.Cursos.RemoveAll(delegate (Curso curObj)
                                    {
                                        return curObj.Nombre == "301"
                                    }); */
            
            escuela.Cursos.RemoveAll((curObj) => curObj.Nombre == "301");

            WriteLine(escuela);
            ImprimirCursosEscuela(escuela);
        }

        //private static bool Predicado(Curso obj) => obj.Nombre == "301";

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
                    WriteLine($"Curso: {curso.Nombre}, Jornada: {curso.TipoJornada}, ID: {curso.UniqueId}");
                }
            }
        }
    }
}
