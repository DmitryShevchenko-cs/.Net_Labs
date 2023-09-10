using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ATM_MIgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_BankCards_BankCardId",
                table: "TransactionHistory");

            migrationBuilder.AlterColumn<int>(
                name: "BankCardId",
                table: "TransactionHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ATMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ATMNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATMs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_BankCards_BankCardId",
                table: "TransactionHistory",
                column: "BankCardId",
                principalTable: "BankCards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_BankCards_BankCardId",
                table: "TransactionHistory");

            migrationBuilder.DropTable(
                name: "ATMs");

            migrationBuilder.AlterColumn<int>(
                name: "BankCardId",
                table: "TransactionHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_BankCards_BankCardId",
                table: "TransactionHistory",
                column: "BankCardId",
                principalTable: "BankCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
