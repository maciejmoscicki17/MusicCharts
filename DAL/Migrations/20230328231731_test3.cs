using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
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
                name: "Playlista",
                columns: table => new
                {
                    PlaylistaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gatunek = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlista", x => x.PlaylistaID);
                });

            migrationBuilder.CreateTable(
                name: "ChartAlbumow",
                columns: table => new
                {
                    ChartAlbumowID = table.Column<int>(type: "int", nullable: false),
                    ChartID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartAlbumow", x => x.ChartAlbumowID);
                    table.ForeignKey(
                        name: "FK_ChartAlbumow_Chart_ChartAlbumowID",
                        column: x => x.ChartAlbumowID,
                        principalTable: "Chart",
                        principalColumn: "ChartID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChartPiosenek",
                columns: table => new
                {
                    ChartPiosenekID = table.Column<int>(type: "int", nullable: false),
                    ChartID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartPiosenek", x => x.ChartPiosenekID);
                    table.ForeignKey(
                        name: "FK_ChartPiosenek_Chart_ChartPiosenekID",
                        column: x => x.ChartPiosenekID,
                        principalTable: "Chart",
                        principalColumn: "ChartID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtystaID = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChartAlbumowID = table.Column<int>(type: "int", nullable: true),
                    PiosenkaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.AlbumID);
                    table.ForeignKey(
                        name: "FK_Album_ChartAlbumow_ChartAlbumowID",
                        column: x => x.ChartAlbumowID,
                        principalTable: "ChartAlbumow",
                        principalColumn: "ChartAlbumowID");
                });

            migrationBuilder.CreateTable(
                name: "AlbumNaCharcie",
                columns: table => new
                {
                    ChartAlbumowID = table.Column<int>(type: "int", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumNaCharcie", x => new { x.AlbumID, x.ChartAlbumowID });
                    table.ForeignKey(
                        name: "FK_AlbumNaCharcie_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlbumNaCharcie_ChartAlbumow_ChartAlbumowID",
                        column: x => x.ChartAlbumowID,
                        principalTable: "ChartAlbumow",
                        principalColumn: "ChartAlbumowID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artysta",
                columns: table => new
                {
                    ArtystaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SluchaczeWMiesiacu = table.Column<int>(type: "int", nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artysta", x => x.ArtystaID);
                    table.ForeignKey(
                        name: "FK_Artysta_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "AlbumID");
                });

            migrationBuilder.CreateTable(
                name: "Piosenka",
                columns: table => new
                {
                    PiosenkaID = table.Column<int>(type: "int", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: false),
                    ArtystaID = table.Column<int>(type: "int", nullable: false),
                    IleOdsluchan = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gatunek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChartPiosenekID = table.Column<int>(type: "int", nullable: true),
                    PlaylistaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piosenka", x => x.PiosenkaID);
                    table.ForeignKey(
                        name: "FK_Piosenka_Album_PiosenkaID",
                        column: x => x.PiosenkaID,
                        principalTable: "Album",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Piosenka_Artysta_ArtystaID",
                        column: x => x.ArtystaID,
                        principalTable: "Artysta",
                        principalColumn: "ArtystaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Piosenka_ChartPiosenek_ChartPiosenekID",
                        column: x => x.ChartPiosenekID,
                        principalTable: "ChartPiosenek",
                        principalColumn: "ChartPiosenekID");
                    table.ForeignKey(
                        name: "FK_Piosenka_Playlista_PlaylistaID",
                        column: x => x.PlaylistaID,
                        principalTable: "Playlista",
                        principalColumn: "PlaylistaID");
                });

            migrationBuilder.CreateTable(
                name: "PiosenkaNaCharcie",
                columns: table => new
                {
                    PiosenkaID = table.Column<int>(type: "int", nullable: false),
                    ChartPiosenekID = table.Column<int>(type: "int", nullable: false),
                    PozycjaPiosenki = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiosenkaNaCharcie", x => new { x.PiosenkaID, x.ChartPiosenekID });
                    table.ForeignKey(
                        name: "FK_PiosenkaNaCharcie_ChartPiosenek_ChartPiosenekID",
                        column: x => x.ChartPiosenekID,
                        principalTable: "ChartPiosenek",
                        principalColumn: "ChartPiosenekID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PiosenkaNaCharcie_Piosenka_PiosenkaID",
                        column: x => x.PiosenkaID,
                        principalTable: "Piosenka",
                        principalColumn: "PiosenkaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PiosenkaNaPlayliscie",
                columns: table => new
                {
                    PiosenkaID = table.Column<int>(type: "int", nullable: false),
                    PlaylistaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiosenkaNaPlayliscie", x => new { x.PiosenkaID, x.PlaylistaID });
                    table.ForeignKey(
                        name: "FK_PiosenkaNaPlayliscie_Piosenka_PiosenkaID",
                        column: x => x.PiosenkaID,
                        principalTable: "Piosenka",
                        principalColumn: "PiosenkaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PiosenkaNaPlayliscie_Playlista_PlaylistaID",
                        column: x => x.PlaylistaID,
                        principalTable: "Playlista",
                        principalColumn: "PlaylistaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Artysta",
                columns: new[] { "ArtystaID", "AlbumID", "Pseudonim", "SluchaczeWMiesiacu" },
                values: new object[,]
                {
                    { 1, null, "Artysta 1", 1000 },
                    { 2, null, "Artysta 2", 500 }
                });

            migrationBuilder.InsertData(
                table: "Chart",
                columns: new[] { "ChartID", "ChartAlbumowID" },
                values: new object[] { 1, 0 });

            migrationBuilder.InsertData(
                table: "Playlista",
                columns: new[] { "PlaylistaID", "Gatunek" },
                values: new object[] { 1, "Rock" });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "AlbumID", "ArtystaID", "ChartAlbumowID", "Nazwa", "PiosenkaID" },
                values: new object[,]
                {
                    { 1, 1, null, "Album 1", null },
                    { 2, 1, null, "Album 2", null },
                    { 3, 2, null, "Album 3", null }
                });

            migrationBuilder.InsertData(
                table: "ChartAlbumow",
                columns: new[] { "ChartAlbumowID", "ChartID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ChartPiosenek",
                columns: new[] { "ChartPiosenekID", "ChartID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Piosenka",
                columns: new[] { "PiosenkaID", "AlbumID", "ArtystaID", "ChartPiosenekID", "Gatunek", "IleOdsluchan", "Nazwa", "PlaylistaID" },
                values: new object[,]
                {
                    { 1, 1, 1, null, "Rock", 0, "Piosenka 1", null },
                    { 2, 1, 1, null, "Rock", 0, "Piosenka 2", null },
                    { 3, 3, 2, null, "Pop", 0, "Piosenka 3", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtystaID",
                table: "Album",
                column: "ArtystaID");

            migrationBuilder.CreateIndex(
                name: "IX_Album_ChartAlbumowID",
                table: "Album",
                column: "ChartAlbumowID");

            migrationBuilder.CreateIndex(
                name: "IX_Album_PiosenkaID",
                table: "Album",
                column: "PiosenkaID");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumNaCharcie_ChartAlbumowID",
                table: "AlbumNaCharcie",
                column: "ChartAlbumowID");

            migrationBuilder.CreateIndex(
                name: "IX_Artysta_AlbumID",
                table: "Artysta",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Piosenka_ArtystaID",
                table: "Piosenka",
                column: "ArtystaID");

            migrationBuilder.CreateIndex(
                name: "IX_Piosenka_ChartPiosenekID",
                table: "Piosenka",
                column: "ChartPiosenekID");

            migrationBuilder.CreateIndex(
                name: "IX_Piosenka_PlaylistaID",
                table: "Piosenka",
                column: "PlaylistaID");

            migrationBuilder.CreateIndex(
                name: "IX_PiosenkaNaCharcie_ChartPiosenekID",
                table: "PiosenkaNaCharcie",
                column: "ChartPiosenekID");

            migrationBuilder.CreateIndex(
                name: "IX_PiosenkaNaPlayliscie_PlaylistaID",
                table: "PiosenkaNaPlayliscie",
                column: "PlaylistaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artysta_ArtystaID",
                table: "Album",
                column: "ArtystaID",
                principalTable: "Artysta",
                principalColumn: "ArtystaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Piosenka_PiosenkaID",
                table: "Album",
                column: "PiosenkaID",
                principalTable: "Piosenka",
                principalColumn: "PiosenkaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artysta_ArtystaID",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Piosenka_Artysta_ArtystaID",
                table: "Piosenka");

            migrationBuilder.DropForeignKey(
                name: "FK_Album_ChartAlbumow_ChartAlbumowID",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Album_Piosenka_PiosenkaID",
                table: "Album");

            migrationBuilder.DropTable(
                name: "AlbumNaCharcie");

            migrationBuilder.DropTable(
                name: "PiosenkaNaCharcie");

            migrationBuilder.DropTable(
                name: "PiosenkaNaPlayliscie");

            migrationBuilder.DropTable(
                name: "Artysta");

            migrationBuilder.DropTable(
                name: "ChartAlbumow");

            migrationBuilder.DropTable(
                name: "Piosenka");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "ChartPiosenek");

            migrationBuilder.DropTable(
                name: "Playlista");

            migrationBuilder.DropTable(
                name: "Chart");
        }
    }
}
