﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokedexApi.Context;

#nullable disable

namespace PokedexApi.Migrations
{
    [DbContext(typeof(PokemonDbContext))]
    partial class PokemonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PokedexApi.Model.Pokemon", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PokemonStatsid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("PokemonStatsid");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("PokedexApi.Model.PokemonStat", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<int>("SpecialAttack")
                        .HasColumnType("int");

                    b.Property<int>("SpecialDefense")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("PokemonStats");
                });

            modelBuilder.Entity("PokedexApi.Model.PokemonType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PokemonTypes");
                });

            modelBuilder.Entity("PokedexApi.Model.PokemonWeakness", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PokemonWeaknesses");
                });

            modelBuilder.Entity("PokemonPokemonType", b =>
                {
                    b.Property<int>("PokemonTypesid")
                        .HasColumnType("int");

                    b.Property<int>("Pokemonsid")
                        .HasColumnType("int");

                    b.HasKey("PokemonTypesid", "Pokemonsid");

                    b.HasIndex("Pokemonsid");

                    b.ToTable("PokemonPokemonType");
                });

            modelBuilder.Entity("PokemonPokemonWeakness", b =>
                {
                    b.Property<int>("pokemonWeaknessesid")
                        .HasColumnType("int");

                    b.Property<int>("pokemonsid")
                        .HasColumnType("int");

                    b.HasKey("pokemonWeaknessesid", "pokemonsid");

                    b.HasIndex("pokemonsid");

                    b.ToTable("PokemonPokemonWeakness");
                });

            modelBuilder.Entity("PokedexApi.Model.Pokemon", b =>
                {
                    b.HasOne("PokedexApi.Model.PokemonStat", "PokemonStats")
                        .WithMany()
                        .HasForeignKey("PokemonStatsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PokemonStats");
                });

            modelBuilder.Entity("PokemonPokemonType", b =>
                {
                    b.HasOne("PokedexApi.Model.PokemonType", null)
                        .WithMany()
                        .HasForeignKey("PokemonTypesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokedexApi.Model.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("Pokemonsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonPokemonWeakness", b =>
                {
                    b.HasOne("PokedexApi.Model.PokemonWeakness", null)
                        .WithMany()
                        .HasForeignKey("pokemonWeaknessesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokedexApi.Model.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("pokemonsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
