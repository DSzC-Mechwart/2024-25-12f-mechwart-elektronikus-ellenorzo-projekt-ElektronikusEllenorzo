using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DH_EE_IKT_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Szakok",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Szak_Nev = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szakok", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tanarok",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "longtext", nullable: false),
                    P_Salt = table.Column<string>(type: "longtext", nullable: false),
                    P_Hash = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanarok", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Osztalyok",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Evfolyam = table.Column<int>(type: "int", nullable: false),
                    Ofo_ID = table.Column<int>(type: "int", nullable: false),
                    Szak_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osztalyok", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Osztalyok_Szakok_Szak_ID",
                        column: x => x.Szak_ID,
                        principalTable: "Szakok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Osztalyok_Tanarok_Ofo_ID",
                        column: x => x.Ofo_ID,
                        principalTable: "Tanarok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tantargyak",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "longtext", nullable: false),
                    Osztaly_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Szakmai_e = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Tanar_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tantargyak", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tantargyak_Osztalyok_Osztaly_ID",
                        column: x => x.Osztaly_ID,
                        principalTable: "Osztalyok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tantargyak_Tanarok_Tanar_ID",
                        column: x => x.Tanar_ID,
                        principalTable: "Tanarok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tanulok",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "longtext", nullable: false),
                    Szul_Ido = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Szul_Hely = table.Column<string>(type: "longtext", nullable: false),
                    Anya_Nev = table.Column<string>(type: "longtext", nullable: false),
                    Koli = table.Column<string>(type: "longtext", nullable: true),
                    Osztaly_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Torzslapszam = table.Column<int>(type: "int", nullable: false),
                    P_Salt = table.Column<string>(type: "longtext", nullable: false),
                    P_Hash = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanulok", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tanulok_Osztalyok_Osztaly_ID",
                        column: x => x.Osztaly_ID,
                        principalTable: "Osztalyok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tanorak",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Terem = table.Column<string>(type: "longtext", nullable: false),
                    Tantargy_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanorak", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tanorak_Tantargyak_Tantargy_ID",
                        column: x => x.Tantargy_ID,
                        principalTable: "Tantargyak",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Jegyek",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tantargy_ID = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Jegy_Ertek = table.Column<int>(type: "int", nullable: false),
                    Tema = table.Column<string>(type: "longtext", nullable: false),
                    Tanulo_ID = table.Column<int>(type: "int", nullable: false),
                    Tanar_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jegyek", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Jegyek_Tanarok_Tanar_ID",
                        column: x => x.Tanar_ID,
                        principalTable: "Tanarok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jegyek_Tantargyak_Tantargy_ID",
                        column: x => x.Tantargy_ID,
                        principalTable: "Tantargyak",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jegyek_Tanulok_Tanulo_ID",
                        column: x => x.Tanulo_ID,
                        principalTable: "Tanulok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orarendek",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Osztaly_ID = table.Column<string>(type: "longtext", nullable: false),
                    Elso_Tanora_ID = table.Column<int>(type: "int", nullable: true),
                    Masodik_Tanora_ID = table.Column<int>(type: "int", nullable: true),
                    Harmadik_Tanora_ID = table.Column<int>(type: "int", nullable: true),
                    Negyedik_Tanora_ID = table.Column<int>(type: "int", nullable: true),
                    Otodik_Tanora_ID = table.Column<int>(type: "int", nullable: true),
                    Hatodik_Tanora_ID = table.Column<int>(type: "int", nullable: true),
                    Hetedik_Tanora_ID = table.Column<int>(type: "int", nullable: true),
                    Nyolcadik_Tanora_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orarendek", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orarendek_Tanorak_Elso_Tanora_ID",
                        column: x => x.Elso_Tanora_ID,
                        principalTable: "Tanorak",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Orarendek_Tanorak_Harmadik_Tanora_ID",
                        column: x => x.Harmadik_Tanora_ID,
                        principalTable: "Tanorak",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Orarendek_Tanorak_Hatodik_Tanora_ID",
                        column: x => x.Hatodik_Tanora_ID,
                        principalTable: "Tanorak",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Orarendek_Tanorak_Hetedik_Tanora_ID",
                        column: x => x.Hetedik_Tanora_ID,
                        principalTable: "Tanorak",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Orarendek_Tanorak_Masodik_Tanora_ID",
                        column: x => x.Masodik_Tanora_ID,
                        principalTable: "Tanorak",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Orarendek_Tanorak_Negyedik_Tanora_ID",
                        column: x => x.Negyedik_Tanora_ID,
                        principalTable: "Tanorak",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Orarendek_Tanorak_Nyolcadik_Tanora_ID",
                        column: x => x.Nyolcadik_Tanora_ID,
                        principalTable: "Tanorak",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Orarendek_Tanorak_Otodik_Tanora_ID",
                        column: x => x.Otodik_Tanora_ID,
                        principalTable: "Tanorak",
                        principalColumn: "ID");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Jegyek_Tanar_ID",
                table: "Jegyek",
                column: "Tanar_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Jegyek_Tantargy_ID",
                table: "Jegyek",
                column: "Tantargy_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Jegyek_Tanulo_ID",
                table: "Jegyek",
                column: "Tanulo_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orarendek_Elso_Tanora_ID",
                table: "Orarendek",
                column: "Elso_Tanora_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orarendek_Harmadik_Tanora_ID",
                table: "Orarendek",
                column: "Harmadik_Tanora_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orarendek_Hatodik_Tanora_ID",
                table: "Orarendek",
                column: "Hatodik_Tanora_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orarendek_Hetedik_Tanora_ID",
                table: "Orarendek",
                column: "Hetedik_Tanora_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orarendek_Masodik_Tanora_ID",
                table: "Orarendek",
                column: "Masodik_Tanora_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orarendek_Negyedik_Tanora_ID",
                table: "Orarendek",
                column: "Negyedik_Tanora_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orarendek_Nyolcadik_Tanora_ID",
                table: "Orarendek",
                column: "Nyolcadik_Tanora_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orarendek_Otodik_Tanora_ID",
                table: "Orarendek",
                column: "Otodik_Tanora_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Osztalyok_Ofo_ID",
                table: "Osztalyok",
                column: "Ofo_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Osztalyok_Szak_ID",
                table: "Osztalyok",
                column: "Szak_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tanorak_Tantargy_ID",
                table: "Tanorak",
                column: "Tantargy_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tantargyak_Osztaly_ID",
                table: "Tantargyak",
                column: "Osztaly_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tantargyak_Tanar_ID",
                table: "Tantargyak",
                column: "Tanar_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tanulok_Osztaly_ID",
                table: "Tanulok",
                column: "Osztaly_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jegyek");

            migrationBuilder.DropTable(
                name: "Orarendek");

            migrationBuilder.DropTable(
                name: "Tanulok");

            migrationBuilder.DropTable(
                name: "Tanorak");

            migrationBuilder.DropTable(
                name: "Tantargyak");

            migrationBuilder.DropTable(
                name: "Osztalyok");

            migrationBuilder.DropTable(
                name: "Szakok");

            migrationBuilder.DropTable(
                name: "Tanarok");
        }
    }
}
