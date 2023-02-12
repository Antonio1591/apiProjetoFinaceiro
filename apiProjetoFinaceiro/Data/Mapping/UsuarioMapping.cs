using apiProjetoFinaceiro.Model.Domain;
using MathNet.Numerics.Interpolation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace apiProjetoFinaceiro.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(U => U.Id).HasColumnType("int").IsRequired().IsUnicode();
            builder.Property(b => b.Nome).
                        IsRequired()
                        .HasColumnType("longtext");
            builder.Property(U => U.CPF)
                        .IsRequired()
                        .HasColumnType("longtext")
                        .IsUnicode();
            builder.Property(U => U.DataNascimento)
                         .IsRequired().
                         HasColumnType("Date");


        }
    }
  
}