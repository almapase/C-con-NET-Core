using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class Reporteador
    {
        Dictionary<MyKeys, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<MyKeys, IEnumerable<ObjetoEscuelaBase>> dicObjEsc)
        {
            if (dicObjEsc == null)
            {
                throw new ArgumentNullException(nameof(dicObjEsc));
            }
            _diccionario = dicObjEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            // ACCEDIENDO DE FOMRA SEGURA A LOS MIEMBROS DE UN DICCIONARIO
       
            if(_diccionario.TryGetValue(MyKeys.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return  new List<Evaluacion>();
                // REGISTRAR EN UN LOG QUE NO SE ESTA ENCONTRANDO LA LISTA, SE CREA UNA LISTA VACIA PARA DEVOLVER
            }
        }

        public IEnumerable<string> GetListaAsignaturasEvaluadas()
        {
            return GetListaAsignaturasEvaluadas( out var dummy);
        }
        public IEnumerable<string> GetListaAsignaturasEvaluadas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDiccionarioEvaluacionesPorAsignatura()
        {
            var diccionario = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsignaturasEvaluadas = GetListaAsignaturasEvaluadas( out var listaEvaluaciones);

            foreach (var asignatura in listaAsignaturasEvaluadas)
            {
                var evaluacionesAsignatura = from ev in listaEvaluaciones
                                                where ev.Asignatura.Nombre == asignatura
                                                select ev;
                diccionario.Add(asignatura, evaluacionesAsignatura);
            }

            return diccionario;
        }

        public Dictionary<string, IEnumerable<AlumnoPromedio>> GetDiccionarioPromedioAlumnosPorAsignatura()
        {
            var diccionario = new Dictionary<string, IEnumerable<AlumnoPromedio>>();
            var diccionariosEvaluacionesPorAsigatura = GetDiccionarioEvaluacionesPorAsignatura();

            foreach (var asignaturas in diccionariosEvaluacionesPorAsigatura)
            {
                var promedioPorAlumno = from ev in asignaturas.Value
                                        group ev by new { ev.Alumno.UniqueId, ev.Alumno.Nombre} into grupoEvalsAlumno
                                        select new AlumnoPromedio
                                        {
                                            alumnoId = grupoEvalsAlumno.Key.UniqueId,
                                            alumnoNmbre  = grupoEvalsAlumno.Key.Nombre, 
                                            promedio = grupoEvalsAlumno.Average(evaluacion => evaluacion.Nota)
                                        };
                diccionario.Add(asignaturas.Key, promedioPorAlumno);
            }

            return diccionario;
        }
    }
}