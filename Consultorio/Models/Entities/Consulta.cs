namespace Consultorio.Models.Entities
{
    public class Consulta : Base
    {
        public DateTime DataHorario { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }

        public Paciente Paciente { get; set; } = new();
        public int PacienteId { get; set; }

        public Profissional Profissional { get; set; } = new ();
        public int ProfissionalId { get; set; }

        public Especialidade Especialidade { get; set; } = new();
        public int EspecialidadeId { get; set; }
    }
}
