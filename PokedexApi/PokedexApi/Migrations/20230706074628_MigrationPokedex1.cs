using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokedexApi.Migrations
{
    /// <inheritdoc />
    public partial class MigrationPokedex1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokemonStats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hp = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    SpecialAttack = table.Column<int>(type: "int", nullable: false),
                    SpecialDefense = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonStats", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonWeaknesses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonWeaknesses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PokemonStatsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pokemons_PokemonStats_PokemonStatsid",
                        column: x => x.PokemonStatsid,
                        principalTable: "PokemonStats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonPokemonType",
                columns: table => new
                {
                    PokemonTypesid = table.Column<int>(type: "int", nullable: false),
                    Pokemonsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonPokemonType", x => new { x.PokemonTypesid, x.Pokemonsid });
                    table.ForeignKey(
                        name: "FK_PokemonPokemonType_PokemonTypes_PokemonTypesid",
                        column: x => x.PokemonTypesid,
                        principalTable: "PokemonTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonPokemonType_Pokemons_Pokemonsid",
                        column: x => x.Pokemonsid,
                        principalTable: "Pokemons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonPokemonWeakness",
                columns: table => new
                {
                    pokemonWeaknessesid = table.Column<int>(type: "int", nullable: false),
                    pokemonsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonPokemonWeakness", x => new { x.pokemonWeaknessesid, x.pokemonsid });
                    table.ForeignKey(
                        name: "FK_PokemonPokemonWeakness_PokemonWeaknesses_pokemonWeaknessesid",
                        column: x => x.pokemonWeaknessesid,
                        principalTable: "PokemonWeaknesses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonPokemonWeakness_Pokemons_pokemonsid",
                        column: x => x.pokemonsid,
                        principalTable: "Pokemons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonPokemonType_Pokemonsid",
                table: "PokemonPokemonType",
                column: "Pokemonsid");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonPokemonWeakness_pokemonsid",
                table: "PokemonPokemonWeakness",
                column: "pokemonsid");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_PokemonStatsid",
                table: "Pokemons",
                column: "PokemonStatsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonPokemonType");

            migrationBuilder.DropTable(
                name: "PokemonPokemonWeakness");

            migrationBuilder.DropTable(
                name: "PokemonTypes");

            migrationBuilder.DropTable(
                name: "PokemonWeaknesses");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "PokemonStats");
        }
    }
}
