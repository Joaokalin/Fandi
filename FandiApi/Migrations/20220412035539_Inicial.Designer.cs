﻿// <auto-generated />
using System;
using FandiApi.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FandiApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20220412035539_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FandiApi.Modelos.Entidades.Produtos.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Qtde_estoque")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Ultima_atualizaçao_em")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Ultima_venda_em")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("Valor_ultima_venda")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Valor_unitario")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Produto", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
