namespace Consultorio.Models.DTOs
{
    public class ProfissionalDetalhesDTO
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int TotalConsultas { get; set; }
        public string[] Especialidades { get; set; }
    }
}
