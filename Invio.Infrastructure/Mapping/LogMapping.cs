using Invio.Domain.Entities;
using Invio.Domain.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Infrastructure.Mapping;
public class LogMapping : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("Log");

        builder.HasKey(l => l.Id)
            .HasName("PK_Log");

        builder.Property(l => l.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("LogId")
            .HasColumnOrder(1)
            .HasComment("Chave Primária do Log");

        builder.Property(l => l.UsuarioId)
                .HasColumnName("UsuarioId")
                .HasColumnOrder(2)
                .HasComment("Chave Estrangeira para o Usuário");

        builder.Property(l => l.Acao)
                .HasColumnName("Acao")
                .HasColumnOrder(3)
                .HasMaxLength(300)
                .HasComment("Ação realizada no log");

        builder.Property(l => l.EntidadeAfetada)
                .HasColumnName("EntidadeAfetada")
                .HasColumnOrder(4)
                .HasMaxLength(200)
                .HasComment("Entidade afetada pela ação");

        builder.Property(l => l.Data)
                .HasColumnName("Data")
                .HasColumnOrder(5)
                .HasDefaultValueSql("GETDATE()")
                .HasComment("Data e hora em que o log foi gerado");
    }
}
