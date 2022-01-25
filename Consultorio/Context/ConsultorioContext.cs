using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Context
{
    public class ConsultorioContext : DbContext
    {
        public ConsultorioContext(DbContextOptions<ConsultorioContext> opt) : base(opt)
        {}

        public DbSet<Agendamento> Agendamentos { get; set; }

    }
}
