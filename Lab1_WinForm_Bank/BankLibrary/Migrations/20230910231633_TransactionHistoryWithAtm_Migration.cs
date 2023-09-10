using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankLibrary.Migrations
{
    /// <inheritdoc />
    public partial class TransactionHistoryWithAtm_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtmId",
                table: "TransactionHistory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_AtmId",
                table: "TransactionHistory",
                column: "AtmId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_ATMs_AtmId",
                table: "TransactionHistory",
                column: "AtmId",
                principalTable: "ATMs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_ATMs_AtmId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_AtmId",
                table: "TransactionHistory");

            migrationBuilder.DropColumn(
                name: "AtmId",
                table: "TransactionHistory");
        }
    }
}
