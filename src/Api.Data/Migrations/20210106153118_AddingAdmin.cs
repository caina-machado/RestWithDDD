using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddingAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("b3cde265-da14-49fb-8760-33e80e7b4e8e"), new DateTime(2021, 1, 6, 12, 31, 17, 741, DateTimeKind.Local).AddTicks(3037), "admin@mail.com", "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b3cde265-da14-49fb-8760-33e80e7b4e8e"));
        }
    }
}
