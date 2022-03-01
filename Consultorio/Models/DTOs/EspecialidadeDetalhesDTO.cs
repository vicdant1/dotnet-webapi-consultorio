namespace Consultorio.Models.DTOs
{
    public class EspecialidadeDetalhesDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; }
        public int TotalConsultas { get; set; } = new();
        public List<ProfissionalDTO> Profissionais { get; set; }
    }
}
