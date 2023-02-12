using apiProjetoFinaceiro.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiProjetoFinaceiro.Data.Mapping
{
    public class TipoMovimentacaoMapping : IEntityTypeConfiguration<TipoMovimentacao>
    {
        public void Configure(EntityTypeBuilder<TipoMovimentacao> builder)
        {
            builder.Property(U => U.Id).HasColumnType("int").IsRequired().IsUnicode();
            builder.HasKey(U => U.Id);
            builder.Property(P=>P.TipoOperacao)
                             .IsRequired()
                             .HasConversion(
                                            v => v.ToString(),
                                            v => (TipoMovimentacaoEnum)Enum.Parse(typeof(TipoMovimentacaoEnum), v));
            builder.Property(M => M.Situacao)
                            .IsRequired()
                             .HasConversion(
                                            v => v.ToString(),
                                            v => (SituacaoEnum)Enum.Parse(typeof(SituacaoEnum), v));
        }
    }
}