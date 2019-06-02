using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            
        }
        public void  Inicializador()
        {
            Escuela = new Escuela("Mi Escuela", 2010, ciudad: "Santiago", pais: "Chile", tipoEscuela: TiposEscuela.Primaria);
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