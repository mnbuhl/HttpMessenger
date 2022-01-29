using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HttpService.Web.Server.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("778a9780-ef52-4fc8-b136-13258afed44e"), new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8467), "Best resource for learning ASP.NET Core", "ASP.NET Core Book", 12000L, new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8469) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("b1558378-790b-48fa-8085-5f351836104f"), new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8396), "Best resource for learning C#", "C# Book", 15000L, new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8424) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("c85591c9-5b83-4cd6-8322-0e205a28ac52"), new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8476), "Best resource for learning Blazor", "Blazor Book", 12000L, new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8477) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("eca7fc27-91ba-4114-862e-f4ecf13900f1"), new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8472), "Best resource for learning Entity Framework Core", "Entity Framework Core Book", 14000L, new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8473) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("f6acaf24-5826-486b-bb40-b369b9a59e2e"), new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8480), "Best resource for learning about RESTful Api's", "RESTful Api Book", 20000L, new DateTime(2022, 1, 29, 21, 43, 38, 883, DateTimeKind.Local).AddTicks(8481) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
