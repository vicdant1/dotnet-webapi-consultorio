using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Context.MappingFluentAPI
{
    public class EspecialidadeMapping : BaseMap<Especialidade>
    {
        public EspecialidadeMapping() : base("tb_especialidade")
        { }

        public override void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Nome).HasColumnName("nome").IsRequired();
            builder.Property(e => e.Ativa).HasColumnName("ativa");
        }
    }
}
