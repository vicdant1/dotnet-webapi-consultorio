namespace Consultorio.Models.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public List<Consulta> Consultas { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
