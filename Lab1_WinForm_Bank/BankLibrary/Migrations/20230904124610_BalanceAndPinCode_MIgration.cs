﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankLibrary.Migrations
{
    /// <inheritdoc />
    public partial class BalanceAndPinCode_MIgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "BankCards",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PinCode",
                table: "BankCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "BankCards");

            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "BankCards");
        }
    }
}
