using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankLibrary.Migrations
{
    /// <inheritdoc />
    public partial class TransactionHistoryWithBank_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_Users_UserId",
                table: "TransactionHistory");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TransactionHistory",
                newName: "BankCardId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionHistory_UserId",
                table: "TransactionHistory",
                newName: "IX_TransactionHistory_BankCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_BankCards_BankCardId",
                table: "TransactionHistory",
                column: "BankCardId",
                principalTable: "BankCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_BankCards_BankCardId",
                table: "TransactionHistory");

            migrationBuilder.RenameColumn(
                name: "BankCardId",
                table: "TransactionHistory",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionHistory_BankCardId",
                table: "TransactionHistory",
                newName: "IX_TransactionHistory_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_Users_UserId",
                table: "TransactionHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
