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
                Printer.WriteTitle("El valor del nombre es requerido");
                WriteLine("Saliendo del programa");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre fue ingresado correctamente");
            }

            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneENTER();
            notaString = ReadLine();

            /* if (string.IsNullOrWhiteSpace(notaString))
            {
                Printer.WriteTitle("El valor de la nota es requerido");
                WriteLine("Saliendo del programa");
            }
            else
            { */
                try
                {
                    newEval.Nota = float.Parse(notaString); 
                    if (newEval.Nota < 0 || newEval.Nota > 5)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5");
                    }
                    WriteLine("La nota fue ingresada correctamente");   
                }
                catch (System.ArgumentOutOfRangeException ex)
                {
                    Printer.WriteTitle(ex.Message);
                    WriteLine("Saliendo del programa");
                }
                catch (System.Exception)
                {
                    
                    Printer.WriteTitle("El valor de la nota no es un número válido");
                    WriteLine("Saliendo del programa");
                } 
                finally
                {
                    Printer.WriteTitle("Finally se ejecuta siempre");
                }
           /*  } */

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
