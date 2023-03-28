using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chart",
                columns: table => new
                {
                    ChartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChartAlbumowID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chart", x => x.ChartID);
                });

            migrationBuilder.CreateTable(
                name: "Piosenka",
                columns: table => new
                {
                    PiosenkaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piosenka", x => x.PiosenkaID);
                });

            migrationBuilder.CreateTable(
                name: "Playlista",
                columns: table => new
                {
                    PlaylistaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlista", x => x.PlaylistaID);
                });

            migrationBuilder.CreateTable(
                name: "ChartAlbumow",
                columns: table => new
                {
                    ChartID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartAlbumow", x => x.ChartID);
                    table.ForeignKey(
                        name: "FK_ChartAlbumow_Chart_ChartID",
                        column: x => x.ChartID,
                        principalTable: "Chart",
                        principalColumn: "ChartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChartPiosenek",
                columns: table => new
                {
                    ChartPiosenekID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChartID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartPiosenek", x => x.ChartPiosenekID);
                    table.ForeignKey(
                        name: "FK_ChartPiosenek_Chart_ChartID1",
                        column: x => x.ChartID1,
                        principalTable: "Chart",
                        principalColumn: "ChartID");
                });

            migrationBuilder.CreateTable(
                name: "PiosenkaNaPlayliscie",
                columns: table => new
                {
                    PiosenkaNaPlayliscieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PiosenkaID = table.Column<int>(type: "int", nullable: false),
                    PlaylistaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiosenkaNaPlayliscie", x => x.PiosenkaNaPlayliscieID);
                    table.ForeignKey(
                        name: "FK_PiosenkaNaPlayliscie_Piosenka_PiosenkaID",
                        column: x => x.PiosenkaID,
                        principalTable: "Piosenka",
                        principalColumn: "PiosenkaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PiosenkaNaPlayliscie_Playlista_PlaylistaID",
                        column: x => x.PlaylistaID,
                        principalTable: "Playlista",
                        principalColumn: "PlaylistaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PiosenkaNaCharcie",
                columns: table => new
                {
                    ChartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PiosenkaID = table.Column<int>(type: "int", nullable: false),
                    ChartPiosenekID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiosenkaNaCharcie", x => x.ChartID);
                    table.ForeignKey(
                        name: "FK_PiosenkaNaCharcie_ChartPiosenek_ChartPiosenekID",
                        column: x => x.ChartPiosenekID,
                        principalTable: "ChartPiosenek",
                        principalColumn: "ChartPiosenekID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PiosenkaNaCharcie_Piosenka_PiosenkaID",
                        column: x => x.PiosenkaID,
                        principalTable: "Piosenka",
                        principalColumn: "PiosenkaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PiosenkiPiosenkaID = table.Column<int>(type: "int", nullable: true),
                    ArtystaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.AlbumID);
                    table.ForeignKey(
                        name: "FK_Album_Piosenka_PiosenkiPiosenkaID",
                        column: x => x.PiosenkiPiosenkaID,
                        principalTable: "Piosenka",
                        principalColumn: "PiosenkaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumNaCharcie",
                columns: table => new
                {
                    AlbumNaCharcieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChartAlbumowID = table.Column<int>(type: "int", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumNaCharcie", x => x.AlbumNaCharcieID);
                    table.ForeignKey(
                        name: "FK_AlbumNaCharcie_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumNaCharcie_ChartAlbumow_ChartAlbumowID",
                        column: x => x.ChartAlbumowID,
                        principalTable: "ChartAlbumow",
                        principalColumn: "ChartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artysta",
                columns: table => new
                {
                    ArtystaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumID = table.Column<int>(type: "int", nullable: false),
                    ArtystaID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artysta", x => x.ArtystaID);
                    table.ForeignKey(
                        name: "FK_Artysta_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artysta_Artysta_ArtystaID1",
                        column: x => x.ArtystaID1,
                        principalTable: "Artysta",
                        principalColumn: "ArtystaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtystaID",
                table: "Album",
                column: "ArtystaID");

            migrationBuilder.CreateIndex(
                name: "IX_Album_PiosenkiPiosenkaID",
                table: "Album",
                column: "PiosenkiPiosenkaID");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumNaCharcie_AlbumID",
                table: "AlbumNaCharcie",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumNaCharcie_ChartAlbumowID",
                table: "AlbumNaCharcie",
                column: "ChartAlbumowID");

            migrationBuilder.CreateIndex(
                name: "IX_Artysta_AlbumID",
                table: "Artysta",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Artysta_ArtystaID1",
                table: "Artysta",
                column: "ArtystaID1");

            migrationBuilder.CreateIndex(
                name: "IX_ChartPiosenek_ChartID1",
                table: "ChartPiosenek",
                column: "ChartID1");

            migrationBuilder.CreateIndex(
                name: "IX_PiosenkaNaCharcie_ChartPiosenekID",
                table: "PiosenkaNaCharcie",
                column: "ChartPiosenekID");

            migrationBuilder.CreateIndex(
                name: "IX_PiosenkaNaCharcie_PiosenkaID",
                table: "PiosenkaNaCharcie",
                column: "PiosenkaID");

            migrationBuilder.CreateIndex(
                name: "IX_PiosenkaNaPlayliscie_PiosenkaID",
                table: "PiosenkaNaPlayliscie",
                column: "PiosenkaID");

            migrationBuilder.CreateIndex(
                name: "IX_PiosenkaNaPlayliscie_PlaylistaID",
                table: "PiosenkaNaPlayliscie",
                column: "PlaylistaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artysta_ArtystaID",
                table: "Album",
                column: "ArtystaID",
                principalTable: "Artysta",
                principalColumn: "ArtystaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artysta_ArtystaID",
                table: "Album");

            migrationBuilder.DropTable(
                name: "AlbumNaCharcie");

            migrationBuilder.DropTable(
                name: "PiosenkaNaCharcie");

            migrationBuilder.DropTable(
                name: "PiosenkaNaPlayliscie");

            migrationBuilder.DropTable(
                name: "ChartAlbumow");

            migrationBuilder.DropTable(
                name: "ChartPiosenek");

            migrationBuilder.DropTable(
                name: "Playlista");

            migrationBuilder.DropTable(
                name: "Chart");

            migrationBuilder.DropTable(
                name: "Artysta");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Piosenka");
        }
    }
}
