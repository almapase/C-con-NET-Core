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

            var listaObjetos = engine.GetObjetosEscuelas();

            /*
            Printer.DibujarLinea(20);
            Printer.WriteTitle("Pruebas de Polifomrfismo");

            var alumnoTest = new Alumno { Nombre = "Claire UnderWood" };

            Printer.WriteTitle("AlumnoTest");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("ObjetoEscuelaBase");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            var objDummy = new ObjetoEscuelaBase() { Nombre = "Frank Underwood" };
            Printer.WriteTitle("bjDummy");
            WriteLine($"Alumno: {objDummy.Nombre}");
            WriteLine($"Alumno: {objDummy.UniqueId}");
            WriteLine($"Alumno: {objDummy.GetType()}");

            alumnoTest = (Alumno) ob;
            Printer.WriteTitle("AlumnoTest");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");
            
            //GENERA ERROR EN TIEMPO DE EJECUCIÓN
             alumnoTest = (Alumno) objDummy;
            Printer.WriteTitle("AlumnoTest");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}"); 

            var evaluacion = new Evaluacion(){Nombre = "Evaluacion 1", Nota=4.5f};
            Printer.WriteTitle("evaluacion");
            WriteLine($"Alumno: {evaluacion.Nombre}");
            WriteLine($"Alumno: {evaluacion.UniqueId}");
            WriteLine($"Alumno: {evaluacion.Nota}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            ob = evaluacion;
            Printer.WriteTitle("ObjetoEscuelaBase evaluacion");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            //GENERA ERROR EN TIEMPO DE EJECUCIÓN
            alumnoTest = (Alumno)(ObjetoEscuelaBase)evaluacion;

            //COMO EVITAR ERRORES EN TIEMPO DE EJECUCIÓN
            ob = evaluacion;  //ob es de tipo Evaluacion
            if (ob is Alumno)
            {
                Alumno alumnoRecuperado = (Alumno)ob;
            }

            //SI NO LO PUEDE CONVERTIR DE VUELVE NULL
            Alumno alumnoRecuperado2 = ob as Alumno; */





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
