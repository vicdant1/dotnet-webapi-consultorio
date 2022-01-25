namespace Consultorio.Models.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Filhos { get; set; }
        public string Endereco { get; set; }
    }
}
