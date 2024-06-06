using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nutriapi.Migrations
{
    /// <inheritdoc />
    public partial class novaalteracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Basal",
                table: "BasalModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BasalModels",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Basal",
                table: "BasalModels");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BasalModels");
        }
    }
}
