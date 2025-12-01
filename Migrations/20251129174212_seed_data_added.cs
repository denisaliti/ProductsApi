using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Migrations
{
    /// <inheritdoc />
    public partial class seed_data_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 22, 102, 37, 148, 248, 75, 94, 168, 191, 25, 242, 223, 158, 156, 116, 133, 17, 36, 75, 57, 55, 153, 222, 2, 129, 151, 148, 234, 225, 60, 196, 211, 62, 109, 12, 192, 227, 3, 127, 170, 201, 194, 80, 215, 69, 39, 123, 187, 127, 121, 10, 131, 123, 228, 213, 86, 98, 164, 125, 137, 120, 235, 183, 121 }, new byte[] { 225, 217, 202, 23, 30, 136, 242, 127, 160, 142, 96, 70, 12, 17, 114, 137, 215, 173, 56, 166, 119, 141, 166, 127, 251, 67, 246, 88, 133, 72, 9, 9, 3, 75, 85, 141, 158, 147, 19, 62, 199, 210, 198, 154, 58, 208, 206, 153, 186, 187, 125, 69, 188, 212, 22, 37, 27, 241, 201, 193, 187, 64, 104, 69, 96, 17, 18, 16, 111, 21, 104, 40, 12, 110, 238, 8, 199, 120, 228, 127, 26, 133, 196, 232, 94, 204, 5, 193, 123, 229, 30, 77, 169, 242, 161, 172, 13, 19, 83, 37, 175, 107, 0, 201, 80, 223, 182, 37, 133, 215, 255, 14, 164, 71, 89, 118, 157, 80, 183, 162, 218, 45, 190, 59, 140, 44, 251, 103 }, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
