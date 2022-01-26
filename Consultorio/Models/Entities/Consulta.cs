namespace Consultorio.Models.Entities
{
    public class Consulta
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime DataHorario { get; set; }
        public decimal Preco { get; set; }
        public Paciente Paciente { get; set; }
        public Especialidade Especialidade { get; set; }
        public Profissional Profissional { get; set; }
    }
}
