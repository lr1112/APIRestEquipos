namespace APIRestEquipos.Models
{
    public class Equipo
    {
        public int id { get; set; }
        public string nombreEquipo { get; set; }
        public string puntosTotales { get; set; }
        public int lanzamientos { get; set; }
        public int asistencias { get; set; }
        public int rebotes { get; set; }
        public int perdidas { get; set; }
        public int robos { get; set; }
        public int triples { get; set; }

        }
}
