using System;
using System.Collections.Generic;
using System.Linq;
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

            var listaObjetos = engine.GetObjetosEscuelas( 
                out int conteoEvaluaciones,
                out int conteoAlumnos,
                out int conteoAsignaturas,
                out int conteoCursos
            );

            /// Filtramos la lista de objetas que implementen la interfaz Ilugar.
            var listaIlugar = from obj in listaObjetos
                              where obj is ILugar
                              select (ILugar)obj;

            //engine.Escuela.LimpiarLugar();

            Dictionary<int, string> diccionario = new Dictionary<int, string>();

            diccionario.Add(10, "Almapase");
            diccionario.Add(432, "Lorem Ipsum");

            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key}, Value: {keyValPair.Value}");
            }

            Printer.DibujarLinea();
            WriteLine(diccionario[432]);

            Printer.DibujarLinea();
            diccionario[0] = "Otro Lorem Ipsum";
            WriteLine(diccionario[0]);

            Printer.WriteTitle("OTRO DICCIONARIO");
            var dic = new Dictionary<string, string>();
            dic["Luna"] = "Cuerpo celeste que gira alrededor de la Tierra";
            WriteLine(dic["Luna"]);


        }


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
