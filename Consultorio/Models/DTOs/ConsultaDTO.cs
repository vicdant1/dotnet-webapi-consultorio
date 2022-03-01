namespace Consultorio.Models.DTOs
{
    public class ConsultaDTO
    {
        public DateTime DataHorario { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public string Profissional { get; set; }
        public string Especialidade { get; set; }
    }
}
