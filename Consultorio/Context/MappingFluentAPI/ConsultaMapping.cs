using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Context.MappingFluentAPI
{
    public class ConsultaMapping : BaseMap<Consulta>
    {
        // como baseMap nao eh interface, eu teria que implementar aquele vitual method dando override. Felizmente o vs me ajuda. Basta colocar a lupinha encima da classe e ir em gerenciar overrides: isso irá gerar o método configure aqui.

        // estou passando "na mão" o nome das tabelas que coloquei para serem implementadas via construtor.
        public ConsultaMapping() : base("tb_consulta")
        { }

        public override void Configure(EntityTypeBuilder<Consulta> builder)
        {
            // never remove this, it is NOT default.

            base.Configure(builder);

            builder.Property(c => c.Status).HasColumnName("status").HasDefaultValue(1);
            builder.Property(c => c.Preco).HasColumnType("decimal(8,2)").HasColumnName("preco");
            builder.Property(c => c.DataHorario).HasColumnName("data_horario").IsRequired();

            builder.Property(c => c.PacienteId).HasColumnName("id_paciente").IsRequired();
            builder.HasOne(c => c.Paciente).WithMany(c => c.Consultas).HasForeignKey(c => c.PacienteId);

            builder.Property(c => c.ProfissionalId).HasColumnName("id_profissional").IsRequired();
            builder.HasOne(c => c.Profissional).WithMany(c => c.Consultas).HasForeignKey(c => c.ProfissionalId);

            builder.Property(c => c.EspecialidadeId).HasColumnName("id_especialidade").IsRequired();
            builder.HasOne(c => c.Especialidade).WithMany(c => c.Consultas).HasForeignKey(c => c.EspecialidadeId);
        }
    }
}
