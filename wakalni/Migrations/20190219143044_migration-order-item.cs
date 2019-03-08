using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wakalni.Migrations
{
    public partial class migrationorderitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Adress_AdressId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adress",
                table: "Adress");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "fc7556ae-f740-46a7-9d59-48cf093af55f", "fdf78760-b7eb-4346-a8df-6bfdc7779278" });

            migrationBuilder.RenameTable(
                name: "Adress",
                newName: "Adresses");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SharingSpaceId",
                table: "Items",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FoodSharingSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CoverPath = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodSharingSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodSharingSpaces_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Principal = table.Column<bool>(nullable: false),
                    ImageOrder = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    NormalizedLabel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item_ItemType",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    ItemTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item_ItemType", x => new { x.ItemId, x.ItemTypeId });
                    table.ForeignKey(
                        name: "FK_Item_ItemType_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_ItemType_ItemTypes_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "655c13b8-10f2-49ac-85c4-bff659a33551", "7b9954c4-106d-43a7-ad04-c9e9a99952c5", "SuperAdmin", "SUPERADMIN" },
                    { "d133938d-d898-4cab-bfe6-0ef55d4b8537", "d13bc44c-643d-4b29-a4ed-e82fb4b1abe6", "Customer", "CUSTOMER" },
                    { "0b0f4e12-9987-482c-a70f-9c5ba3d83029", "8e7fe04c-100d-4922-9abd-b362ddee291c", "Chef", "CHEF" }
                });

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "Id", "Created", "Label", "Modified", "NormalizedLabel" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desert", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DESERT" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Starter", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "STARTER" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DISH" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Appetizer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "APPETIZER" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drinks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DRINKS" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ham", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HAM" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_SharingSpaceId",
                table: "Items",
                column: "SharingSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSharingSpaces_OwnerId",
                table: "FoodSharingSpaces",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ItemId",
                table: "Image",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Adresses_AdressId",
                table: "AspNetUsers",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_FoodSharingSpaces_SharingSpaceId",
                table: "Items",
                column: "SharingSpaceId",
                principalTable: "FoodSharingSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Adresses_AdressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_FoodSharingSpaces_SharingSpaceId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "FoodSharingSpaces");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Item_ItemType");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropIndex(
                name: "IX_Items_SharingSpaceId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0b0f4e12-9987-482c-a70f-9c5ba3d83029", "8e7fe04c-100d-4922-9abd-b362ddee291c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "655c13b8-10f2-49ac-85c4-bff659a33551", "7b9954c4-106d-43a7-ad04-c9e9a99952c5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d133938d-d898-4cab-bfe6-0ef55d4b8537", "d13bc44c-643d-4b29-a4ed-e82fb4b1abe6" });

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SharingSpaceId",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Adresses",
                newName: "Adress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adress",
                table: "Adress",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc7556ae-f740-46a7-9d59-48cf093af55f", "fdf78760-b7eb-4346-a8df-6bfdc7779278", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Adress_AdressId",
                table: "AspNetUsers",
                column: "AdressId",
                principalTable: "Adress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
