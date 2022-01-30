using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Consultorio.Context
{
    public class ConsultorioContext : DbContext
    {
        public ConsultorioContext(DbContextOptions<ConsultorioContext> opt) : base(opt)
        {}

        public DbSet<Consulta> Consultas { get; set; }
        //public DbSet<Especialidade> Especialidades { get; set; }
        //public DbSet<Paciente> Pacientes { get; set; }
        //public DbSet<Profissional> Profissionais { get; set; }

        //public DbSet<ProfissionalEspecialidade> ProfissionaisEspecialidades { get; set; }
        //public DbSet<Agendamento> Agendamentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // esse metodo esta basicamente falando: "a partir de agora, todo mundo que implementar IEntityTypeConfiguration deve ser 'ouvido' e ter suas mudanças aplicadas. Estou passando a assembly em execução para que as classes de mapeamento sejam exergadas". Isso facilita muita coisa a partir do momento em que a aplicação cresce e o modelo de dados fica maior e maior.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            /*
            // alterando nome tabela
            modelBuilder.Entity<Agendamento>().ToTable("tb_agendamento");
            // setando pk
            modelBuilder.Entity<Agendamento>().HasKey(a => a.Id);
            modelBuilder.Entity<Agendamento>().Property(a => a.Id).HasColumnName("id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Agendamento>().Property(a => a.NomePaciente)
                                              .HasColumnType("varchar(240)").IsRequired()
                                              .HasColumnName("nome_paciente");
            modelBuilder.Entity<Agendamento>().Property(a => a.Horario).IsRequired().HasColumnName("horario");
            */
        }
    }
}
