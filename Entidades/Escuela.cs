namespace CoreEscuela.Entidades
{
    class Escuela
    {
        public string Nombre { get; set; }
        public int AnioCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public Curso[] Cursos { get; set; }

        public Escuela (string nombre, int anio) => (Nombre, AnioCreacion) = (nombre, anio);
        public Escuela (string nombre, int anio, string pais = "", string ciudad = "")
        {
            (Nombre, AnioCreacion, Pais, Ciudad)
             = 
            (nombre, anio, pais, ciudad);
        }
        
        // SOBRE ESCRITURAS DE METODOS
        public override string ToString()
        {
        return $"Nombre: \"{Nombre}\", {System.Environment.NewLine} Tipo: {TipoEscuela} \n Pais: {Pais}, Ciudad: {Ciudad}";
        }
    }
}