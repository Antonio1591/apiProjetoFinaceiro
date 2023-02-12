using apiProjetoFinaceiro.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiProjetoFinaceiro.Data.Mapping
{
    public class MovimentacaoFinaceiraMapping : IEntityTypeConfiguration<MovimentacaoFinanceira>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoFinanceira> builder)
        {
            builder.Property(U => U.Id).HasColumnType("int").IsRequired().IsUnicode();
            builder.HasKey(U => U.Id);

            builder.Property(U => U.DatamovimentacaoEntrada)
                         .IsRequired().
                         HasColumnType("date");
            builder.Property(U => U.Datamovimentacaolancamento)
                        .IsRequired().
                        HasColumnType("date");
            builder.Property(M => M.ValorMovimentacao)
                            .IsRequired()
                            .HasColumnType("decimal(10,2)");
            builder.Property(M => M.Situacao)
                            .IsRequired() 
                            .HasConversion(
                                            v => v.ToString(),
                                            v => (SituacaoEnum)Enum.Parse(typeof(SituacaoEnum), v));

        }
    }
}