using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deletedTransactionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Transactions_TransactionId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Payments_TransactionId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 140, 235, 9, 129, 75, 220, 194, 250, 167, 98, 4, 47, 21, 143, 143, 124, 187, 176, 94, 66, 215, 183, 147, 219, 19, 64, 80, 39, 149, 72, 54, 199, 226, 154, 93, 237, 117, 226, 135, 144, 16, 41, 130, 222, 103, 123, 241, 196, 131, 157, 248, 18, 227, 233, 198, 243, 199, 209, 85, 84, 0, 187, 170, 198 }, new byte[] { 181, 96, 13, 186, 252, 54, 134, 86, 39, 221, 17, 200, 90, 18, 145, 121, 103, 16, 241, 26, 248, 30, 109, 231, 141, 89, 148, 184, 202, 38, 107, 155, 84, 115, 127, 254, 156, 134, 72, 60, 178, 47, 221, 180, 186, 171, 169, 138, 10, 230, 95, 19, 52, 50, 242, 173, 217, 186, 119, 122, 205, 188, 205, 167, 250, 115, 6, 8, 33, 40, 149, 145, 51, 9, 252, 71, 213, 156, 33, 80, 38, 202, 189, 63, 203, 170, 36, 233, 205, 164, 34, 241, 122, 145, 101, 71, 202, 55, 1, 152, 15, 73, 100, 101, 27, 56, 3, 103, 37, 235, 109, 64, 30, 115, 163, 205, 99, 193, 7, 128, 26, 146, 52, 5, 219, 19, 50, 10 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Payments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    CancelTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedUserId = table.Column<int>(type: "integer", nullable: false),
                    PerformTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedUserId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 52, 129, 80, 69, 126, 154, 117, 42, 71, 43, 46, 171, 98, 171, 220, 57, 228, 175, 228, 214, 236, 139, 50, 104, 177, 16, 219, 202, 172, 32, 137, 100, 190, 203, 23, 16, 39, 145, 132, 114, 74, 27, 165, 57, 193, 70, 132, 76, 204, 231, 130, 63, 123, 188, 129, 129, 231, 89, 210, 53, 237, 58, 34, 47 }, new byte[] { 1, 213, 116, 13, 240, 173, 101, 91, 195, 71, 227, 94, 212, 117, 182, 191, 188, 222, 188, 58, 20, 148, 201, 184, 149, 214, 227, 8, 172, 50, 67, 199, 212, 176, 72, 13, 243, 154, 228, 5, 202, 144, 154, 214, 244, 57, 219, 225, 169, 145, 31, 204, 247, 162, 51, 120, 192, 61, 186, 154, 128, 248, 204, 159, 120, 70, 131, 101, 251, 181, 224, 38, 161, 228, 231, 158, 20, 141, 65, 113, 166, 172, 224, 81, 64, 0, 251, 22, 242, 9, 63, 36, 151, 225, 69, 226, 43, 137, 99, 248, 75, 112, 147, 158, 230, 50, 88, 85, 231, 108, 10, 119, 232, 1, 223, 227, 241, 66, 41, 168, 6, 99, 112, 92, 155, 236, 228, 152 } });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TransactionId",
                table: "Payments",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Transactions_TransactionId",
                table: "Payments",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
