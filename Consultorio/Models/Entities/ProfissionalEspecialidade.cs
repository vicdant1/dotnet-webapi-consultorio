namespace Consultorio.Models.Entities
{
    public class ProfissionalEspecialidade
    {
        public int Id { get; set; }
        public Profissional Profissional { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}
