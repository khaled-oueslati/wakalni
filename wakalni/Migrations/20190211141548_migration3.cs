using Microsoft.EntityFrameworkCore.Migrations;

namespace wakalni.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0b1c493b-e7cd-4756-82df-6b39fece0f4d", "afca8427-19c8-4bfe-9328-2fc478b68c1a" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc7556ae-f740-46a7-9d59-48cf093af55f", "fdf78760-b7eb-4346-a8df-6bfdc7779278", "SuperAdmin", "SUPERADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "fc7556ae-f740-46a7-9d59-48cf093af55f", "fdf78760-b7eb-4346-a8df-6bfdc7779278" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b1c493b-e7cd-4756-82df-6b39fece0f4d", "afca8427-19c8-4bfe-9328-2fc478b68c1a", "SuperAdmin", "SUPERADMIN" });
        }
    }
}
