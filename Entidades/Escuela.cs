using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela: ObjetoEscuelaBase, ILugar
    {
        public int AnioCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        public Escuela (string nombre, int anio) => (Nombre, AnioCreacion) = (nombre, anio);
        public Escuela (string nombre, int anio, string pais = "", string ciudad = "", TiposEscuela tipoEscuela = 0)
        {
            (Nombre, AnioCreacion, Pais, Ciudad, TipoEscuela)
             = 
            (nombre, anio, pais, ciudad, tipoEscuela);
        }
        
        // SOBRE ESCRITURAS DE METODOS
        public override string ToString()
        {
        return $"Nombre: \"{Nombre}\", {System.Environment.NewLine} Tipo: {TipoEscuela} \n Pais: {Pais}, Ciudad: {Ciudad}";
        }

        public void LimpiarLugar(){
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Escuela ...");
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            
            Printer.WriteTitle($"Escuela {Nombre}, Limpia");
        }
    }
}