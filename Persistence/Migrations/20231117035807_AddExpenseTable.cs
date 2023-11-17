using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddExpenseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_LkpCategory_CategoryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LkpCategory",
                table: "LkpCategory");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "LkpCategory",
                newName: "LkpCategories");

            migrationBuilder.AddColumn<int>(
                name: "LkpCategory",
                table: "Expenses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryTypeId",
                table: "LkpCategories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LkpCategories",
                table: "LkpCategories",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LkpCategories",
                table: "LkpCategories");

            migrationBuilder.DropColumn(
                name: "LkpCategory",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CategoryTypeId",
                table: "LkpCategories");

            migrationBuilder.RenameTable(
                name: "LkpCategories",
                newName: "LkpCategory");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Expenses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LkpCategory",
                table: "LkpCategory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_LkpCategory_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                principalTable: "LkpCategory",
                principalColumn: "Id");
        }
    }
}
