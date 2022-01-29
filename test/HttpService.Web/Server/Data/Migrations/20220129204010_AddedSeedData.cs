using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HttpService.Web.Server.Data.Migrations
{
    public partial class AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("0e7af9da-fe60-4574-a2ba-007e8c08eb1c"), new DateTime(2022, 1, 29, 21, 40, 10, 817, DateTimeKind.Local).AddTicks(7647), "Best resource for learning about RESTful Api's", "RESTful Api Book", 20000L, new DateTime(2022, 1, 29, 21, 40, 10, 817, DateTimeKind.Local).AddTicks(7649) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("3987d581-8afa-42ba-a5c9-ee9c43456f01"), new DateTime(2022, 1, 29, 21, 40, 10, 817, DateTimeKind.Local).AddTicks(7639), "Best resource for learning Entity Framework Core", "Entity Framework Core Book", 14000L, new DateTime(2022, 1, 29, 21, 40, 10, 817, DateTimeKind.Local).AddTicks(7640) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("63a439fe-4b71-46ee-8763-e123442a5e1f"), new DateTime(2022, 1, 29, 21, 40, 10, 817, DateTimeKind.Local).AddTicks(7643), "Best resource for learning Blazor", "Blazor Book", 12000L, new DateTime(2022, 1, 29, 21, 40, 10, 817, DateTimeKind.Local).AddTicks(7645) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("8ab9e6ea-517c-4904-9fa7-46d1d5af277c"), new DateTime(2022, 1, 29, 21, 40, 10, 817, DateTimeKind.Local).AddTicks(7560), "Best resource for learning C#", "C# Book", 15000L, new DateTime(2022, 1, 29, 21, 40, 10, 817, DateTimeKind.Local).AddTicks(7589) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("f2f1f3f4-289d-4299-a082-ade06d8b6abd"), new DateTime(2022, 1, 29, 21, 40, 10, 817, DateTimeKind.Local).AddTicks(7619), "Best resource for learning ASP.NET Core", "ASP.NET Core Book", 12000L, new DateTime(2022, 1, 29, 21, 40, 10, 817, DateTimeKind.Local).AddTicks(7621) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0e7af9da-fe60-4574-a2ba-007e8c08eb1c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3987d581-8afa-42ba-a5c9-ee9c43456f01"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("63a439fe-4b71-46ee-8763-e123442a5e1f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8ab9e6ea-517c-4904-9fa7-46d1d5af277c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f2f1f3f4-289d-4299-a082-ade06d8b6abd"));
        }
    }
}
