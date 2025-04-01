using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    public partial class Booking5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTables_Tables_ID_table",
                table: "BookingTables");

            migrationBuilder.DropIndex(
                name: "IX_BookingTables_ID_table",
                table: "BookingTables");

            migrationBuilder.DropColumn(
                name: "ID_table",
                table: "BookingTables");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Bookings",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTables_TableId",
                table: "BookingTables",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTables_Tables_TableId",
                table: "BookingTables",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingTables_Tables_TableId",
                table: "BookingTables");

            migrationBuilder.DropIndex(
                name: "IX_BookingTables_TableId",
                table: "BookingTables");

            migrationBuilder.AddColumn<int>(
                name: "ID_table",
                table: "BookingTables",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Bookings",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTables_ID_table",
                table: "BookingTables",
                column: "ID_table");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingTables_Tables_ID_table",
                table: "BookingTables",
                column: "ID_table",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
