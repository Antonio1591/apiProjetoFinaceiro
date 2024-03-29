﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace apiProjetoFinaceiro.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("apiProjetoFinaceiro.Model.Domain.MovimentacaoFinanceira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(true)
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("DatamovimentacaoEntrada")
                        .HasColumnType("date")
                        .HasColumnName("datamovimentacao_entrada");

                    b.Property<DateTime>("Datamovimentacaolancamento")
                        .HasColumnType("date")
                        .HasColumnName("datamovimentacaolancamento");

                    b.Property<Guid>("IdUsuarioIdentity")
                        .HasColumnType("char(36)")
                        .HasColumnName("id_usuario_identity");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("situacao");

                    b.Property<int>("TipoMovimentacaoId")
                        .HasColumnType("int")
                        .HasColumnName("tipo_movimentacao_id");

                    b.Property<decimal>("ValorMovimentacao")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("valor_movimentacao");

                    b.HasKey("Id")
                        .HasName("pk_movimentacao_finaceira");

                    b.HasIndex("TipoMovimentacaoId")
                        .HasDatabaseName("ix_movimentacao_finaceira_tipo_movimentacao_id");

                    b.ToTable("movimentacao_finaceira", (string)null);
                });

            modelBuilder.Entity("apiProjetoFinaceiro.Model.Domain.TipoMovimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(true)
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<Guid>("IdUsuarioIdentity")
                        .HasColumnType("char(36)")
                        .HasColumnName("id_usuario_identity");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("situacao");

                    b.Property<string>("TipoDescriscao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("tipo_descriscao");

                    b.Property<string>("TipoOperacao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("tipo_operacao");

                    b.HasKey("Id")
                        .HasName("pk_tipo_movimentacao");

                    b.ToTable("tipo_movimentacao", (string)null);
                });

            modelBuilder.Entity("apiProjetoFinaceiro.Model.Domain.MovimentacaoFinanceira", b =>
                {
                    b.HasOne("apiProjetoFinaceiro.Model.Domain.TipoMovimentacao", "TipoMovimentacao")
                        .WithMany()
                        .HasForeignKey("TipoMovimentacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_movimentacao_finaceira_tipo_movimentacao_tipo_movimentacao_id");

                    b.Navigation("TipoMovimentacao");
                });
#pragma warning restore 612, 618
        }
    }
}
