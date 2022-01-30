using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Context.MappingFluentAPI
{
    public class PacienteMapping : BaseMap<Paciente>
    {
        public PacienteMapping() : base("tb_paciente")
        {
        }

        public override void Configure(EntityTypeBuilder<Paciente> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Nome).HasColumnName("nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Cpf).HasColumnName("cpf").HasColumnType("varchar(11)").IsRequired();
            builder.Property(p => p.Email).HasColumnName("email").HasColumnType("varchar(50)");
            builder.Property(p => p.Celular).HasColumnName("celular").HasColumnType("varchar(100)").IsRequired();



        }
    }
}
