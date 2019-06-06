using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }
        public EscuelaEngine() { }
        public void Inicializador()
        {
            Escuela = new Escuela("Mi Escuela 2019 con Net Core", 2010, ciudad: "Santiago", pais: "Chile", tipoEscuela: TiposEscuela.Primaria);
            CargarCursos();
            CargarAsignaturas();
            CargarAlumnos();
            CargarEvaluaciones();

        }

        public void ImprimirDicionario(
            Dictionary<MyKeys, IEnumerable<ObjetoEscuelaBase>> dic,
            bool imprEval = false,
            bool imprEsc = false,
            bool imprAl = false,
            bool imprAsg = false,
            bool imprCur = false
        )
        {
            foreach (var obj in dic)
            {
                Printer.WriteTitle(obj.Key.ToString());
                foreach (var value in obj.Value)
                {
                    if (value is Evaluacion)
                    {
                        if (imprEval)
                            Console.WriteLine(value);
                    }
                    else if (value is Escuela)
                    {
                        if (imprEsc)
                            Console.WriteLine("Escuela: " + value);
                    }
                    else if (value is Alumno)
                    {
                        if (imprAl)
                            Console.WriteLine("Alumno: " + value.Nombre);
                    }
                    else if (value is Asignatura)
                    {
                        if (imprAsg)
                            Console.WriteLine("Asignatura: " + value.Nombre);
                    }
                    else if (value is Curso)
                    {
                        if (imprCur)
                            Console.WriteLine("Curso: " + value.Nombre);
                    }
                    else
                    {
                        Console.WriteLine(value);
                    }
                }
            }
        }
        public Dictionary<MyKeys, IEnumerable<ObjetoEscuelaBase>> GetOjetosEscuelaDiccionario()
        {
            var dic = new Dictionary<MyKeys, IEnumerable<ObjetoEscuelaBase>>();

            dic.Add(MyKeys.Escuela, new[] { Escuela });
            dic.Add(MyKeys.Curso, Escuela.Cursos);

            var listatmpEva = new List<Evaluacion>();
            var listatmpAl = new List<Alumno>();
            var listatmpAsi = new List<Asignatura>();
            foreach (var curso in Escuela.Cursos)
            {
                listatmpAsi.AddRange(curso.Asignaturas);
                listatmpAl.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listatmpEva.AddRange(alumno.Evaluaciones);
                }
            }

            dic.Add(MyKeys.Evaluacion, listatmpEva);
            dic.Add(MyKeys.Asignatura, listatmpAsi);
            dic.Add(MyKeys.Alumno, listatmpAl);
            return dic;
        }

        /// SOBRECARGA QUE NO PIDE PARAMETROS DE SALIDA, SIN ESCRIBIR EL METODO DE NUEVO
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuelas(
           bool traeEvaluaciones = true,
           bool traeAlumnos = true,
           bool traeAsignaturas = true,
           bool traeCursos = true
       )
        {
            return GetObjetosEscuelas(out int dummy, out dummy, out dummy, out dummy);
        }
        /// SOBRECARGA CON SOLO UN PARAMETRO DE SALIDA, SIN ESCRIBIR EL METODO DE NUEVO
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuelas(
           out int conteoEvaluaciones,
           bool traeEvaluaciones = true,
           bool traeAlumnos = true,
           bool traeAsignaturas = true,
           bool traeCursos = true
       )
        {
            return GetObjetosEscuelas(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuelas(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
        )
        {
            conteoEvaluaciones = 0;
            conteoAsignaturas = 0;
            conteoAlumnos = 0;
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            if (traeCursos)
                listaObj.AddRange(Escuela.Cursos);

            conteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;
                if (traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);
                if (traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }
            return listaObj.AsReadOnly();
        }
        #region Metodos de Carga
        private void CargarAlumnos()
        {
            foreach (var curso in Escuela.Cursos)
            {
                curso.Alumnos = (GenerarAlumnos(20));
            }
        }
        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> ListaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre = "Matemáticas"},
                    new Asignatura{Nombre = "Educación Física"},
                    new Asignatura{Nombre = "Castellano"},
                    new Asignatura{Nombre = "Ciencias Naturales"}
                };
                curso.Asignaturas = (ListaAsignaturas);
            }
        }
        private void CargarEvaluaciones()
        {
            var random = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        List<Evaluacion> evaluaciones = new List<Evaluacion> { };
                        for (int i = 0; i < 5; i++)
                        {
                            var eval = new Evaluacion
                            {
                                Nombre = $"{curso.Nombre}_{asignatura.Nombre}_Eva#{i + 1}",
                                Nota = (float)(5 * random.NextDouble()),
                                Asignatura = asignatura,
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(eval);
                        }
                    }
                }
            }
        }
        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>{
                new Curso { Nombre = "101", TipoJornada = TiposJornada.Mañana },
                new Curso { Nombre = "201", TipoJornada = TiposJornada.Mañana },
                new Curso { Nombre = "301", TipoJornada = TiposJornada.Mañana },
                new Curso { Nombre = "102", TipoJornada = TiposJornada.Tarde },
                new Curso { Nombre = "202", TipoJornada = TiposJornada.Tarde },
                new Curso { Nombre = "302", TipoJornada = TiposJornada.Tarde },
                new Curso { Nombre = "401", TipoJornada = TiposJornada.Mañana },
                new Curso { Nombre = "402", TipoJornada = TiposJornada.Tarde }
            };
        }
        private List<Alumno> GenerarAlumnos(int cantidadAlumno)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((alumno) => alumno.UniqueId).Take(cantidadAlumno).ToList();
        }
        #endregion
    }
}