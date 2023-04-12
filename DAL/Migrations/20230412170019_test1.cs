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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    ChartAlbumowID = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChartAlbumowID = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Piosenka",
                columns: table => new
                {
                    PiosenkaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumID = table.Column<int>(type: "int", nullable: false),
                    IleOdsluchan = table.Column<int>(type: "int", nullable: false),
                    IleOdsluchanTydzien = table.Column<int>(type: "int", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gatunek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChartPiosenekID = table.Column<int>(type: "int", nullable: true),
                    PlaylistaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piosenka", x => x.PiosenkaID);
                    table.ForeignKey(
                        name: "FK_Piosenka_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "AlbumID", "ChartAlbumowID", "Nazwa" },
                values: new object[,]
                {
                    { 1, null, "Her Loss" },
                    { 2, null, "beerbongs & bentleys" },
                    { 3, null, "Queen" },
                    { 4, null, "Chromatica" },
                    { 5, null, "thank u, next" }
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
                    { 7, "Ariana Grande", 78843849 }
                });

            migrationBuilder.InsertData(
                table: "Chart",
                columns: new[] { "ChartID", "Nazwa" },
                values: new object[,]
                {
                    { 1, "top 10 pop" },
                    { 2, "top" }
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
                    { 4, 6 },
                    { 5, 7 }
                });

            migrationBuilder.InsertData(
                table: "ChartAlbumow",
                columns: new[] { "ChartAlbumowID", "Nazwa" },
                values: new object[,]
                {
                    { 1, "top 10 miesiaca" },
                    { 2, "top pop" }
                });

            migrationBuilder.InsertData(
                table: "ChartPiosenek",
                columns: new[] { "ChartPiosenekID", "Nazwa" },
                values: new object[,]
                {
                    { 1, "top 10 miesiaca" },
                    { 2, "top 10 pop" }
                });

            migrationBuilder.InsertData(
                table: "Piosenka",
                columns: new[] { "PiosenkaID", "AlbumID", "ChartPiosenekID", "Gatunek", "IleOdsluchan", "IleOdsluchanTydzien", "Nazwa", "PlaylistaID" },
                values: new object[,]
                {
                    { 1, 1, null, "Rap", 430030716, 107507679, "Rich Flex", null },
                    { 2, 1, null, "Rap", 128496585, 32124146, "Major Distribution", null },
                    { 3, 1, null, "Rap", 128696575, 32174143, "On BS", null },
                    { 4, 1, null, "Rap", 762226574, 19055664, "BackOutsideBoyz", null },
                    { 5, 1, null, "Rap", 87005583, 19055664, "Privileged Rappers", null },
                    { 6, 2, null, "Rap", 873355833, 218338958, "rockstar", null },
                    { 7, 2, null, "Rap", 919573559, 229893389, "Candy Paint", null },
                    { 8, 2, null, "Rap", 944573559, 236143389, "Otherside", null },
                    { 9, 2, null, "Rap", 396452492, 99113123, "Ball For Me", null },
                    { 10, 2, null, "Rap", 356452492, 89113123, "Stay", null },
                    { 11, 3, null, "Rap", 155198494, 38799623, "Barbie Dreams", null },
                    { 12, 3, null, "Rap", 919573559, 229893389, "Chun-Li", null },
                    { 13, 3, null, "Rap", 934573559, 233643389, "Good Form", null },
                    { 14, 3, null, "Rap", 396452492, 99113123, "Miami", null },
                    { 15, 3, null, "Rap", 356452492, 89113123, "Run & Hide", null },
                    { 16, 4, null, "Pop", 356893192, 89223298, "Alice", null },
                    { 17, 4, null, "Pop", 354553192, 88638298, "Stupid Love", null },
                    { 18, 4, null, "Pop", 544553192, 136138298, "Rain On Me", null },
                    { 19, 4, null, "Pop", 234553192, 58638298, "Replay", null },
                    { 20, 4, null, "Pop", 22153192, 5538298, "Enigma", null },
                    { 21, 5, null, "Pop", 382870556, 95717639, "imagine", null },
                    { 22, 5, null, "Pop", 330118734, 82529683, "needy", null },
                    { 23, 5, null, "Pop", 289306849, 72326712, "NASA", null },
                    { 24, 5, null, "Pop", 260845535, 65211383, "bloodline", null },
                    { 25, 5, null, "Pop", 205119049, 51279762, "fake smile", null }
                });

            migrationBuilder.InsertData(
                table: "AlbumNaCharcie",
                columns: new[] { "AlbumID", "ChartAlbumowID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 4, 2 },
                    { 5, 1 },
                    { 5, 2 }
                });

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
                    { 6, 20 },
                    { 7, 21 },
                    { 7, 22 },
                    { 7, 23 },
                    { 7, 24 },
                    { 7, 25 }
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
                    { 2, 16, 0 },
                    { 1, 17, 0 },
                    { 2, 17, 0 },
                    { 1, 18, 0 },
                    { 2, 18, 0 },
                    { 1, 19, 0 },
                    { 2, 19, 0 },
                    { 1, 20, 0 },
                    { 2, 20, 0 },
                    { 1, 21, 0 },
                    { 2, 21, 0 },
                    { 1, 22, 0 },
                    { 2, 22, 0 },
                    { 1, 23, 0 },
                    { 2, 23, 0 },
                    { 1, 24, 0 },
                    { 2, 24, 0 },
                    { 1, 25, 0 },
                    { 2, 25, 0 }
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
                    { 20, 4 },
                    { 23, 4 },
                    { 25, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ChartAlbumowID",
                table: "Album",
                column: "ChartAlbumowID");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumNaCharcie_ChartAlbumowID",
                table: "AlbumNaCharcie",
                column: "ChartAlbumowID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtystaAlbum_ArtystaID",
                table: "ArtystaAlbum",
                column: "ArtystaID");

            migrationBuilder.CreateIndex(
                name: "IX_Piosenka_AlbumID",
                table: "Piosenka",
                column: "AlbumID");

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
                name: "Artysta");

            migrationBuilder.DropTable(
                name: "Piosenka");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "ChartPiosenek");

            migrationBuilder.DropTable(
                name: "Playlista");

            migrationBuilder.DropTable(
                name: "ChartAlbumow");

            migrationBuilder.DropTable(
                name: "Chart");
        }
    }
}
