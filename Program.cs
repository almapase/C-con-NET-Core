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

            var listaObjetos = engine.GetObjetosEscuelas();

            /// Filtramos la lista de objetas que implementen la interfaz Ilugar.
            var listaIlugar = from obj in listaObjetos
                              where obj is ILugar
                              select (ILugar)obj;

            //engine.Escuela.LimpiarLugar();

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
