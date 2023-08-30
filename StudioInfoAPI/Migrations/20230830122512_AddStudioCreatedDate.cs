using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioInfoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddStudioCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedDate",
                table: "Studios",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Studios");
        }
    }
}
