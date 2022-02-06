using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Context.MappingFluentAPI
{
    public class ProfissionalMapping : BaseMap<Profissional>
    {
        public ProfissionalMapping() : base("tb_profissional")
        {
        }

        public override void Configure(EntityTypeBuilder<Profissional> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo");


            // configuracao da tabela intermediaria n to n:
                // * poderia ter sido feito em um arquivo a parte
            builder.HasMany(x => x.Especialidades)
                   .WithMany(x => x.Profissionais)
                   .UsingEntity<ProfissionalEspecialidade>(
                        x => x.HasOne(p => p.Especialidade).WithMany().HasForeignKey(x => x.EspecialidadeId),
                        x => x.HasOne(p => p.Profissionais).WithMany().HasForeignKey(x => x.ProfissionalId),
                        x =>
                        {
                            x.ToTable("tb_profissional_especialidade");
                            //chave composta => new object
                            x.HasKey(p => new { p.EspecialidadeId, p.ProfissionalId });

                            x.Property(x => x.EspecialidadeId).HasColumnName("id_especialidade").IsRequired();
                            x.Property(x => x.ProfissionalId).HasColumnName("id_profissional").IsRequired();
                        }
                    );
        }
    }
}
