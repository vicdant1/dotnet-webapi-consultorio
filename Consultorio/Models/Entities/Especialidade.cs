namespace Consultorio.Models.Entities
{
    public class Especialidade : Base
    {
        public string Nome { get; set; } = string.Empty;
        public bool Ativa { get; set; }
        //public List<Profissional> Profissionais { get; set; }
        //public List<Consulta> Consultas { get; set; }
    }
}
