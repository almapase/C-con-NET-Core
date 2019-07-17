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

            WriteLine("BIENVENIDOS A LA ESCUELA");

            var reporteador = new Reporteador(engine.GetOjetosEscuelaDiccionario());
            var evalList = reporteador.GetListaEvaluaciones();
            var asigEavalList = reporteador.GetListaAsignaturasEvaluadas();
            var evalPorAsignaturasLista = reporteador.GetDiccionarioEvaluacionesPorAsignatura();
            var promedioPorAsignatura = reporteador.GetDiccionarioPromedioAlumnosPorAsignatura();
            var TopPromedioAlumnosPorAsignatura = reporteador.GetTopPromedioAlumnosPorAsignatura(5);


            Printer.WriteTitle("Captura de una evaluación por consola");
            var newEval = new Evaluacion();
            string nombre, notaString;
            float nota;

            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneENTER();
            nombre = ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El valor del nombre es requerido");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre fue ingresado correctamente");
            }

            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneENTER();
            notaString = ReadLine();

            if (string.IsNullOrWhiteSpace(notaString))
            {
                throw new ArgumentException("El valor de la nota es requerido");
            }
            else
            {
                newEval.Nota = float.Parse(notaString);
                WriteLine("La nota fue ingresada correctamente");
            }

            /* WriteLine(engine.Escuela);
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

           var dictmp = engine.GetOjetosEscuelaDiccionario();
           engine.ImprimirDicionario(dictmp, imprAl:true, imprCur:true); */


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
