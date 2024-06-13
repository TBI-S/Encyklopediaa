using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encyklopediaa.Migrations
{
    /// <inheritdoc />
    public partial class Encyklopedia200 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rodzina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodzina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siedlisko",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siedlisko", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Użytkownik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Użytkownik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gatunek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RodzinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gatunek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gatunek_Rodzina_RodzinaId",
                        column: x => x.RodzinaId,
                        principalTable: "Rodzina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artykul",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UżytkownikId = table.Column<int>(type: "int", nullable: false),
                    RodzinaID = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artykul", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artykul_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artykul_Rodzina_RodzinaID",
                        column: x => x.RodzinaID,
                        principalTable: "Rodzina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artykul_Użytkownik_UżytkownikId",
                        column: x => x.UżytkownikId,
                        principalTable: "Użytkownik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GatunekSiedlisko",
                columns: table => new
                {
                    GatuneksId = table.Column<int>(type: "int", nullable: false),
                    SiedliskosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GatunekSiedlisko", x => new { x.GatuneksId, x.SiedliskosId });
                    table.ForeignKey(
                        name: "FK_GatunekSiedlisko_Gatunek_GatuneksId",
                        column: x => x.GatuneksId,
                        principalTable: "Gatunek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GatunekSiedlisko_Siedlisko_SiedliskosId",
                        column: x => x.SiedliskosId,
                        principalTable: "Siedlisko",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artykul_AdminId",
                table: "Artykul",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Artykul_RodzinaID",
                table: "Artykul",
                column: "RodzinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Artykul_UżytkownikId",
                table: "Artykul",
                column: "UżytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Gatunek_RodzinaId",
                table: "Gatunek",
                column: "RodzinaId");

            migrationBuilder.CreateIndex(
                name: "IX_GatunekSiedlisko_SiedliskosId",
                table: "GatunekSiedlisko",
                column: "SiedliskosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artykul");

            migrationBuilder.DropTable(
                name: "GatunekSiedlisko");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Użytkownik");

            migrationBuilder.DropTable(
                name: "Gatunek");

            migrationBuilder.DropTable(
                name: "Siedlisko");

            migrationBuilder.DropTable(
                name: "Rodzina");
        }
    }
}
