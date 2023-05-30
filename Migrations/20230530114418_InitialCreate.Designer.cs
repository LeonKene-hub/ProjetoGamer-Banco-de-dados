﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoGamer_Banco_de_dados.Infra;

#nullable disable

namespace ProjetoGamer_Banco_de_dados.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230530114418_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.1.23111.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoGamer_Banco_de_dados.Models.Equipe", b =>
                {
                    b.Property<int>("IdEquipe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEquipe"));

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEquipe");

                    b.ToTable("Equipe");
                });

            modelBuilder.Entity("ProjetoGamer_Banco_de_dados.Models.Jogador", b =>
                {
                    b.Property<int>("IdJogador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJogador"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEquipe")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdJogador");

                    b.HasIndex("IdEquipe");

                    b.ToTable("jogador");
                });

            modelBuilder.Entity("ProjetoGamer_Banco_de_dados.Models.Jogador", b =>
                {
                    b.HasOne("ProjetoGamer_Banco_de_dados.Models.Equipe", "Equipe")
                        .WithMany("Jogador")
                        .HasForeignKey("IdEquipe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("ProjetoGamer_Banco_de_dados.Models.Equipe", b =>
                {
                    b.Navigation("Jogador");
                });
#pragma warning restore 612, 618
        }
    }
}
