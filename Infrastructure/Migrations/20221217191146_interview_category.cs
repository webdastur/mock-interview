using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class interviewcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Interviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 239, 177, 177, 74, 196, 152, 79, 48, 227, 175, 61, 23, 151, 130, 99, 154, 147, 11, 3, 61, 64, 41, 20, 215, 7, 161, 249, 230, 96, 188, 253, 103, 151, 19, 211, 149, 201, 63, 169, 182, 199, 42, 67, 83, 144, 31, 1, 35, 63, 79, 192, 87, 70, 105, 65, 94, 164, 51, 4, 120, 224, 4, 11, 137 }, new byte[] { 59, 147, 62, 21, 113, 32, 122, 95, 211, 135, 14, 21, 123, 163, 211, 23, 43, 74, 195, 163, 48, 172, 72, 0, 102, 85, 99, 75, 156, 92, 187, 32, 57, 5, 167, 80, 200, 33, 197, 168, 139, 180, 114, 6, 182, 237, 7, 24, 83, 254, 187, 13, 138, 221, 225, 44, 203, 224, 160, 6, 242, 213, 73, 120, 72, 12, 181, 211, 131, 217, 146, 147, 143, 48, 234, 43, 223, 7, 89, 248, 34, 16, 32, 88, 157, 74, 22, 126, 116, 253, 38, 66, 242, 242, 90, 114, 190, 124, 74, 197, 226, 33, 227, 230, 155, 235, 5, 214, 242, 73, 23, 51, 131, 182, 50, 83, 99, 42, 242, 223, 3, 124, 39, 253, 226, 150, 183, 0 } });

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_CategoryId",
                table: "Interviews",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewCategories_CategoryId",
                table: "Interviews",
                column: "CategoryId",
                principalTable: "InterviewCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewCategories_CategoryId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_CategoryId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Interviews");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 227, 68, 44, 252, 124, 138, 184, 6, 246, 101, 244, 106, 153, 94, 165, 5, 10, 231, 249, 190, 175, 225, 184, 45, 24, 238, 42, 69, 184, 165, 183, 95, 66, 48, 68, 205, 38, 255, 48, 195, 248, 184, 70, 114, 25, 172, 108, 240, 149, 8, 8, 57, 141, 244, 141, 88, 19, 158, 26, 16, 59, 19, 196, 11 }, new byte[] { 149, 216, 97, 197, 7, 154, 191, 163, 42, 37, 186, 227, 116, 155, 229, 129, 139, 120, 216, 210, 65, 39, 113, 13, 171, 155, 254, 151, 87, 184, 201, 247, 92, 246, 49, 97, 203, 139, 106, 1, 165, 166, 244, 172, 45, 168, 206, 209, 6, 102, 241, 90, 4, 30, 93, 38, 12, 76, 48, 193, 139, 144, 150, 244, 76, 238, 198, 38, 179, 155, 214, 36, 51, 113, 7, 11, 194, 182, 223, 68, 109, 243, 132, 45, 38, 208, 131, 231, 28, 28, 195, 237, 182, 29, 68, 190, 90, 249, 207, 43, 215, 161, 25, 232, 185, 93, 126, 105, 91, 12, 14, 179, 242, 165, 171, 164, 215, 253, 0, 102, 16, 84, 219, 11, 45, 196, 247, 147 } });
        }
    }
}
