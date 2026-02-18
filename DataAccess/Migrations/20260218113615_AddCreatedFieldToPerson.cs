using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedFieldToPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Email_login",
                table: "Persons",
                column: "Email_login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Id_person",
                table: "Notes",
                column: "Id_person");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Persons_Id_person",
                table: "Notes",
                column: "Id_person",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Persons_Id_person",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Persons_Email_login",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Notes_Id_person",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Persons");
        }
    }
}
