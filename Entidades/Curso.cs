using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public TiposJornada TipoJornada { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public List<Asignatura> Asignaturas { get; set; }

        public Curso() => UniqueId = System.Guid.NewGuid().ToString();
       
        // OTRA FORMA DE DECLARAR EL CONSTRUCTOR
        // public Curso()
        // {
        //     UniqueId = System.Guid.NewGuid().ToString();
        // }
    }
}