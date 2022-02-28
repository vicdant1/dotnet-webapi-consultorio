using Consultorio.Models.Entities;

namespace Consultorio.Models.DTOs
{
    public class PacienteDetalhesDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public List<Consulta> Consultas { get; set; } = new();
    }
}
