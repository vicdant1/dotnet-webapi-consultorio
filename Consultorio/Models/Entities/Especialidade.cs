﻿namespace Consultorio.Models.Entities
{
    public class Especialidade : Base
    {
        public string? Nome { get; set; }
        public bool Ativa { get; set; }
        public List<Consulta> Consultas { get; set; } = new();
        public List<Profissional> Profissionais { get; set; }
    }
}
