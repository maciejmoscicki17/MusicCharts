using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artysta",
                columns: table => new
                {
                    ArtystaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SluchaczeWMiesiacu = table.Column<int>(type: "int", nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artysta", x => x.ArtystaID);
                });

            migrationBuilder.CreateTable(
                name: "Chart",
                columns: table => new
                {
                    ChartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
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
                    Gatunek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlista", x => x.PlaylistaID);
                });

            migrationBuilder.CreateTable(
                name: "ChartAlbumow",
                columns: table => new
                {
                    ChartAlbumowID = table.Column<int>(type: "int", nullable: false)
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
                    ChartPiosenekID = table.Column<int>(type: "int", nullable: false)
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
                name: "Piosenka",
                columns: table => new
                {
                    PiosenkaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Album",
                columns: table => new
                {
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.ForeignKey(
                        name: "FK_Album_Piosenka_PiosenkaID",
                        column: x => x.PiosenkaID,
                        principalTable: "Piosenka",
                        principalColumn: "PiosenkaID");
                });

            migrationBuilder.CreateTable(
                name: "PiosenkaArtysta",
                columns: table => new
                {
                    ArtystaID = table.Column<int>(type: "int", nullable: false),
                    PiosenkaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiosenkaArtysta", x => new { x.PiosenkaID, x.ArtystaID });
                    table.ForeignKey(
                        name: "FK_PiosenkaArtysta_Artysta_ArtystaID",
                        column: x => x.ArtystaID,
                        principalTable: "Artysta",
                        principalColumn: "ArtystaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PiosenkaArtysta_Piosenka_PiosenkaID",
                        column: x => x.PiosenkaID,
                        principalTable: "Piosenka",
                        principalColumn: "PiosenkaID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "ArtystaAlbum",
                columns: table => new
                {
                    ArtystaID = table.Column<int>(type: "int", nullable: false),
                    AlbumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtystaAlbum", x => new { x.AlbumID, x.ArtystaID });
                    table.ForeignKey(
                        name: "FK_ArtystaAlbum_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtystaAlbum_Artysta_ArtystaID",
                        column: x => x.ArtystaID,
                        principalTable: "Artysta",
                        principalColumn: "ArtystaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "AlbumID", "ChartAlbumowID", "Nazwa", "PiosenkaID" },
                values: new object[,]
                {
                    { 1, null, "Her Loss", null },
                    { 2, null, "beerbongs & bentleys", null },
                    { 3, null, "Queen", null },
                    { 4, null, "Chromatica", null }
                });

            migrationBuilder.InsertData(
                table: "Artysta",
                columns: new[] { "ArtystaID", "Pseudonim", "SluchaczeWMiesiacu" },
                values: new object[,]
                {
                    { 1, "Drake", 1000 },
                    { 2, "21 Savage", 500 },
                    { 3, "Post Malone", 579841 },
                    { 4, "Nicki Minaj", 676543 },
                    { 5, "Lil Wayne", 692834 },
                    { 6, "Lady Gaga", 44355321 },
                    { 7, "Ariana Grande", 44355321 }
                });

            migrationBuilder.InsertData(
                table: "Chart",
                column: "ChartID",
                value: 1);

            migrationBuilder.InsertData(
                table: "Piosenka",
                columns: new[] { "PiosenkaID", "ChartPiosenekID", "Gatunek", "IleOdsluchan", "Nazwa", "PlaylistaID" },
                values: new object[,]
                {
                    { 1, null, "Rap", 430030716, "Rich Flex", null },
                    { 2, null, "Rap", 128496585, "Major Distribution", null },
                    { 3, null, "Rap", 128496585, "On BS", null },
                    { 4, null, "Rap", 76222657, "BackOutsideBoyz", null },
                    { 5, null, "Rap", 87005583, "Privileged Rappers", null },
                    { 6, null, "Rap", 87005583, "rockstar", null },
                    { 7, null, "Rap", 919573559, "Candy Paint", null },
                    { 8, null, "Rap", 919573559, "Otherside", null },
                    { 9, null, "Rap", 396452492, "Ball For Me", null },
                    { 10, null, "Rap", 356452492, "Stay", null },
                    { 11, null, "Rap", 155198494, "Barbie Dreams", null },
                    { 12, null, "Rap", 919573559, "Chun-Li", null },
                    { 13, null, "Rap", 919573559, "Good Form", null },
                    { 14, null, "Rap", 396452492, "Miami", null },
                    { 15, null, "Rap", 356452492, "Run & Hide", null },
                    { 16, null, "Pop", 356453192, "Alice", null },
                    { 17, null, "Pop", 354553192, "Stupid Love", null },
                    { 18, null, "Pop", 544553192, "Rain On Me", null },
                    { 19, null, "Pop", 234553192, "Replay", null },
                    { 20, null, "Pop", 22153192, "Enigma", null }
                });

            migrationBuilder.InsertData(
                table: "Playlista",
                columns: new[] { "PlaylistaID", "Gatunek", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Rap", "Vibe" },
                    { 2, "Rap", "Relax" },
                    { 3, "Rap", "Sunday" },
                    { 4, "Pop", "Girls Night" }
                });

            migrationBuilder.InsertData(
                table: "ArtystaAlbum",
                columns: new[] { "AlbumID", "ArtystaID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 6 }
                });

            migrationBuilder.InsertData(
                table: "ChartAlbumow",
                column: "ChartAlbumowID",
                value: 1);

            migrationBuilder.InsertData(
                table: "ChartPiosenek",
                column: "ChartPiosenekID",
                value: 1);

            migrationBuilder.InsertData(
                table: "PiosenkaArtysta",
                columns: new[] { "ArtystaID", "PiosenkaID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 4, 9 },
                    { 3, 10 },
                    { 4, 11 },
                    { 4, 12 },
                    { 4, 13 },
                    { 5, 13 },
                    { 4, 14 },
                    { 4, 15 },
                    { 6, 16 },
                    { 6, 17 },
                    { 6, 18 },
                    { 7, 18 },
                    { 6, 19 },
                    { 6, 20 }
                });

            migrationBuilder.InsertData(
                table: "PiosenkaNaPlayliscie",
                columns: new[] { "PiosenkaID", "PlaylistaID" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 1 },
                    { 6, 3 },
                    { 8, 1 },
                    { 8, 2 },
                    { 9, 1 },
                    { 10, 2 },
                    { 12, 3 },
                    { 13, 2 },
                    { 14, 1 },
                    { 14, 4 },
                    { 15, 1 },
                    { 15, 4 },
                    { 18, 4 },
                    { 19, 4 },
                    { 20, 4 }
                });

            migrationBuilder.InsertData(
                table: "AlbumNaCharcie",
                columns: new[] { "AlbumID", "ChartAlbumowID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "PiosenkaNaCharcie",
                columns: new[] { "ChartPiosenekID", "PiosenkaID", "PozycjaPiosenki" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 1, 2, 0 },
                    { 1, 3, 0 },
                    { 1, 4, 0 },
                    { 1, 5, 0 },
                    { 1, 6, 0 },
                    { 1, 7, 0 },
                    { 1, 8, 0 },
                    { 1, 9, 0 },
                    { 1, 10, 0 },
                    { 1, 11, 0 },
                    { 1, 12, 0 },
                    { 1, 13, 0 },
                    { 1, 14, 0 },
                    { 1, 15, 0 },
                    { 1, 16, 0 },
                    { 1, 17, 0 },
                    { 1, 18, 0 },
                    { 1, 19, 0 },
                    { 1, 20, 0 }
                });

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
                name: "IX_ArtystaAlbum_ArtystaID",
                table: "ArtystaAlbum",
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
                name: "IX_PiosenkaArtysta_ArtystaID",
                table: "PiosenkaArtysta",
                column: "ArtystaID");

            migrationBuilder.CreateIndex(
                name: "IX_PiosenkaNaCharcie_ChartPiosenekID",
                table: "PiosenkaNaCharcie",
                column: "ChartPiosenekID");

            migrationBuilder.CreateIndex(
                name: "IX_PiosenkaNaPlayliscie_PlaylistaID",
                table: "PiosenkaNaPlayliscie",
                column: "PlaylistaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumNaCharcie");

            migrationBuilder.DropTable(
                name: "ArtystaAlbum");

            migrationBuilder.DropTable(
                name: "PiosenkaArtysta");

            migrationBuilder.DropTable(
                name: "PiosenkaNaCharcie");

            migrationBuilder.DropTable(
                name: "PiosenkaNaPlayliscie");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Artysta");

            migrationBuilder.DropTable(
                name: "ChartAlbumow");

            migrationBuilder.DropTable(
                name: "Piosenka");

            migrationBuilder.DropTable(
                name: "ChartPiosenek");

            migrationBuilder.DropTable(
                name: "Playlista");

            migrationBuilder.DropTable(
                name: "Chart");
        }
    }
}
