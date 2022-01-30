using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HttpMessengerApp.Server.Data.Migrations
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
                values: new object[] { new Guid("0fa6011c-3e1d-40c2-bf21-d64c794eedc8"), new DateTime(2022, 1, 29, 23, 17, 11, 824, DateTimeKind.Local).AddTicks(7848), "Best resource for learning C#", "C# Book", 15000L, new DateTime(2022, 1, 29, 23, 17, 11, 824, DateTimeKind.Local).AddTicks(7878) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("5692e0af-6770-4cd1-bed3-919c477656b8"), new DateTime(2022, 1, 29, 23, 17, 11, 824, DateTimeKind.Local).AddTicks(7967), "Best resource for learning about RESTful Api's", "RESTful Api Book", 20000L, new DateTime(2022, 1, 29, 23, 17, 11, 824, DateTimeKind.Local).AddTicks(7969) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("5a197706-6775-4156-9fd6-77ad2def8452"), new DateTime(2022, 1, 29, 23, 17, 11, 824, DateTimeKind.Local).AddTicks(7959), "Best resource for learning Entity Framework Core", "Entity Framework Core Book", 14000L, new DateTime(2022, 1, 29, 23, 17, 11, 824, DateTimeKind.Local).AddTicks(7961) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("5bc5b7df-05af-4050-a014-c029cf00ea5c"), new DateTime(2022, 1, 29, 23, 17, 11, 824, DateTimeKind.Local).AddTicks(7963), "Best resource for learning Blazor", "Blazor Book", 12000L, new DateTime(2022, 1, 29, 23, 17, 11, 824, DateTimeKind.Local).AddTicks(7965) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("7066ab64-92f0-4c7c-b9c5-bf633addc7e0"), new DateTime(2022, 1, 29, 23, 17, 11, 824, DateTimeKind.Local).AddTicks(7955), "Best resource for learning ASP.NET Core", "ASP.NET Core Book", 12000L, new DateTime(2022, 1, 29, 23, 17, 11, 824, DateTimeKind.Local).AddTicks(7957) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
