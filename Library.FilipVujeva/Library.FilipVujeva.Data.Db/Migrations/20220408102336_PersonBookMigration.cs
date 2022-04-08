using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.FilipVujeva.Data.Db.Migrations
{
    /// <inheritdoc />
    public partial class PersonBookMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentRecord");

            migrationBuilder.CreateTable(
                name: "PersonBook",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    DateRented = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonBook", x => new { x.BookId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonBook_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonBook_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonBook_PersonId",
                table: "PersonBook",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonBook");

            migrationBuilder.CreateTable(
                name: "RentRecord",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentRecord", x => new { x.BookId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_RentRecord_AspNetUsers_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentRecord_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentRecord_PersonId",
                table: "RentRecord",
                column: "PersonId");
        }
    }
}
