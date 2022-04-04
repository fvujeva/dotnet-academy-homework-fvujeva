using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.FilipVujeva.Data.Db.Migrations
{
    /// <inheritdoc />
    public partial class RentRecords1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RentRecord",
                table: "RentRecord");

            migrationBuilder.DropIndex(
                name: "IX_RentRecord_BookId",
                table: "RentRecord");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RentRecord");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentRecord",
                table: "RentRecord",
                columns: new[] { "BookId", "PersonId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RentRecord",
                table: "RentRecord");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RentRecord",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentRecord",
                table: "RentRecord",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RentRecord_BookId",
                table: "RentRecord",
                column: "BookId");
        }
    }
}
