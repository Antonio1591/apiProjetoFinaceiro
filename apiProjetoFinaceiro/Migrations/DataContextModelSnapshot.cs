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

            modelBuilder.Entity("apiProjetoFinaceiro.Model.Domain.Bairro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("situacao");

                    b.HasKey("Id")
                        .HasName("pk_bairro");

                    b.ToTable("bairro", (string)null);
                });

            modelBuilder.Entity("apiProjetoFinaceiro.Model.Domain.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("cep");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("situacao");

                    b.HasKey("Id")
                        .HasName("pk_cidade");

                    b.ToTable("cidade", (string)null);
                });

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

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("situacao");

                    b.Property<int>("TipoMovimentacaoId")
                        .HasColumnType("int")
                        .HasColumnName("tipo_movimentacao_id");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuario_id");

                    b.Property<decimal>("ValorMovimentacao")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("valor_movimentacao");

                    b.HasKey("Id")
                        .HasName("pk_movimentacao_finaceira");

                    b.HasIndex("TipoMovimentacaoId")
                        .HasDatabaseName("ix_movimentacao_finaceira_tipo_movimentacao_id");

                    b.HasIndex("UsuarioId")
                        .HasDatabaseName("ix_movimentacao_finaceira_usuario_id");

                    b.ToTable("movimentacao_finaceira", (string)null);
                });

            modelBuilder.Entity("apiProjetoFinaceiro.Model.Domain.TipoMovimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(true)
                        .HasColumnType("int")
                        .HasColumnName("id");

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

            modelBuilder.Entity("apiProjetoFinaceiro.Model.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(true)
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("BairroId")
                        .HasColumnType("int")
                        .HasColumnName("bairro_id");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("longtext")
                        .HasColumnName("cpf");

                    b.Property<int>("CidadeId")
                        .HasColumnType("int")
                        .HasColumnName("cidade_id");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("Date")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("senha");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("situacao");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("telefone");

                    b.HasKey("Id")
                        .HasName("pk_usuario");

                    b.HasIndex("BairroId")
                        .HasDatabaseName("ix_usuario_bairro_id");

                    b.HasIndex("CidadeId")
                        .HasDatabaseName("ix_usuario_cidade_id");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("apiProjetoFinaceiro.Model.Domain.MovimentacaoFinanceira", b =>
                {
                    b.HasOne("apiProjetoFinaceiro.Model.Domain.TipoMovimentacao", "TipoMovimentacao")
                        .WithMany()
                        .HasForeignKey("TipoMovimentacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_movimentacao_finaceira_tipo_movimentacao_tipo_movimentacao_id");

                    b.HasOne("apiProjetoFinaceiro.Model.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_movimentacao_finaceira_usuario_usuario_id");

                    b.Navigation("TipoMovimentacao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("apiProjetoFinaceiro.Model.Domain.Usuario", b =>
                {
                    b.HasOne("apiProjetoFinaceiro.Model.Domain.Bairro", "Bairro")
                        .WithMany()
                        .HasForeignKey("BairroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_usuario_bairro_bairro_id");

                    b.HasOne("apiProjetoFinaceiro.Model.Domain.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_usuario_cidade_cidade_id");

                    b.Navigation("Bairro");

                    b.Navigation("Cidade");
                });
#pragma warning restore 612, 618
        }
    }
}
