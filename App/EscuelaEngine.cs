using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }
        public void Inicializador()
        {
            Escuela = new Escuela("Mi Escuela", 2010, ciudad: "Santiago", pais: "Chile", tipoEscuela: TiposEscuela.Primaria);
            CargarCursos();
            CargarAsignaturas();
            CargarAlumnos();
            CargarEvaluaciones();

        }

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
    }
}