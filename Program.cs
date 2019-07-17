﻿using System;
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
            foreach (var item in promedioPorAsignatura)
            {
                foreach (var alumno in item.Value)
                {
                    
                }
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
