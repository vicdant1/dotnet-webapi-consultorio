namespace Consultorio.Models.DTOs
{
    public class AgendamentoAdicionarDTO
    {
        public DateTime DataHorario { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public int PacienteId { get; set; }
        public int ProfissionalId { get; set; }
        public int EspecialidadeId { get; set; }
    }
}
