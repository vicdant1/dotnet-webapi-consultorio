namespace Consultorio.Models.Entities
{
    public class Paciente : Base
    {
        public string Nome { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public List<Consulta> Consultas { get; set; } = new();
    }
}
