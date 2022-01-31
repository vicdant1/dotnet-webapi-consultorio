namespace Consultorio.Models.Entities
{
    public class Profissional : Base
    {
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public List<Consulta> Consultas { get; set; } = new();
        //public List<Especialidade> Especialidades { get; set; }
    }
}
