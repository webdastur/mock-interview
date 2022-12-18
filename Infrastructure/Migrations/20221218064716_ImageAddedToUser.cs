using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImageAddedToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageId", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, new byte[] { 52, 129, 80, 69, 126, 154, 117, 42, 71, 43, 46, 171, 98, 171, 220, 57, 228, 175, 228, 214, 236, 139, 50, 104, 177, 16, 219, 202, 172, 32, 137, 100, 190, 203, 23, 16, 39, 145, 132, 114, 74, 27, 165, 57, 193, 70, 132, 76, 204, 231, 130, 63, 123, 188, 129, 129, 231, 89, 210, 53, 237, 58, 34, 47 }, new byte[] { 1, 213, 116, 13, 240, 173, 101, 91, 195, 71, 227, 94, 212, 117, 182, 191, 188, 222, 188, 58, 20, 148, 201, 184, 149, 214, 227, 8, 172, 50, 67, 199, 212, 176, 72, 13, 243, 154, 228, 5, 202, 144, 154, 214, 244, 57, 219, 225, 169, 145, 31, 204, 247, 162, 51, 120, 192, 61, 186, 154, 128, 248, 204, 159, 120, 70, 131, 101, 251, 181, 224, 38, 161, 228, 231, 158, 20, 141, 65, 113, 166, 172, 224, 81, 64, 0, 251, 22, 242, 9, 63, 36, 151, 225, 69, 226, 43, 137, 99, 248, 75, 112, 147, 158, 230, 50, 88, 85, 231, 108, 10, 119, 232, 1, 223, 227, 241, 66, 41, 168, 6, 99, 112, 92, 155, 236, 228, 152 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ImageId",
                table: "Users",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Files_ImageId",
                table: "Users",
                column: "ImageId",
                principalTable: "Files",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Files_ImageId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ImageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 239, 177, 177, 74, 196, 152, 79, 48, 227, 175, 61, 23, 151, 130, 99, 154, 147, 11, 3, 61, 64, 41, 20, 215, 7, 161, 249, 230, 96, 188, 253, 103, 151, 19, 211, 149, 201, 63, 169, 182, 199, 42, 67, 83, 144, 31, 1, 35, 63, 79, 192, 87, 70, 105, 65, 94, 164, 51, 4, 120, 224, 4, 11, 137 }, new byte[] { 59, 147, 62, 21, 113, 32, 122, 95, 211, 135, 14, 21, 123, 163, 211, 23, 43, 74, 195, 163, 48, 172, 72, 0, 102, 85, 99, 75, 156, 92, 187, 32, 57, 5, 167, 80, 200, 33, 197, 168, 139, 180, 114, 6, 182, 237, 7, 24, 83, 254, 187, 13, 138, 221, 225, 44, 203, 224, 160, 6, 242, 213, 73, 120, 72, 12, 181, 211, 131, 217, 146, 147, 143, 48, 234, 43, 223, 7, 89, 248, 34, 16, 32, 88, 157, 74, 22, 126, 116, 253, 38, 66, 242, 242, 90, 114, 190, 124, 74, 197, 226, 33, 227, 230, 155, 235, 5, 214, 242, 73, 23, 51, 131, 182, 50, 83, 99, 42, 242, 223, 3, 124, 39, 253, 226, 150, 183, 0 } });
        }
    }
}
