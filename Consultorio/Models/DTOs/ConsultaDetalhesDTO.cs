namespace Consultorio.Models.DTOs
{
    public class ConsultaDetalhesDTO
    {
        public int Id { get; set; }
        public DateTime DataHorario { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public ProfissionalDTO Profissional { get; set; }
        public EspecialidadeDTO Especialidade { get; set; }
        public PacienteDTO Paciente { get; set; }
    }
}
