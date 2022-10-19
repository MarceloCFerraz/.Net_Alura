using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosAPI.Migrations
{
    public partial class roleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "17f160b2-65cc-4e44-967c-710af1281970");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "4736319f-1e2a-43f4-9bdb-dca58c61134a", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48a7ed4b-36e9-451a-8f07-88fac2356c04", "AQAAAAEAACcQAAAAEH/OXiLI2U4FFUfw+jLgCRaxMkVK0Zq/dePJVPHTmrowluGU/xrszULsC4ny7QBuiQ==", "dc983db1-05bc-4fcd-aa9e-ff0bf9c12a23" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "951d4c99-7012-4677-bf74-0d74b4070d18");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5685d766-0110-40b7-8b53-ffb9d059ae1f", "AQAAAAEAACcQAAAAECYZMgzGRAnedZ3wLm788Me+MJdmOG3KlP6S1bh8tv/bpOkOVmgf2HfNbsNlz9i7Bg==", "50e70fa1-c7c1-4ca4-9407-a11cc894d4e5" });
        }
    }
}
