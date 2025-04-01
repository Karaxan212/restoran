using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    public partial class Booking7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tables_TableId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TableId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ID_table",
                table: "Bookings",
                column: "ID_table");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tables_ID_table",
                table: "Bookings",
                column: "ID_table",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tables_ID_table",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ID_table",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Bookings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TableId",
                table: "Bookings",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tables_TableId",
                table: "Bookings",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id");
        }
    }
}
