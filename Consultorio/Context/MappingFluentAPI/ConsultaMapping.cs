﻿using Consultorio.Models.Entities;
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
            builder.Property(c => c.Status).HasColumnName("status").HasDefaultValue(1);
            builder.Property(c => c.Preco).HasColumnType("decimal(7,2)").HasColumnName("preco");
            builder.Property(c => c.DataHorario).HasColumnName("data_horario").IsRequired();
        }
    }
}
