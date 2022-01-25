namespace Consultorio.Models.Entities
{
    public class Agendamento
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataAgendamento { get; set; }
    }
}
