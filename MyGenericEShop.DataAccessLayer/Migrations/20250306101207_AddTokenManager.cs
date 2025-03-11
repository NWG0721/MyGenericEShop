using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGenericEShop.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddTokenManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelegramTokens",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModify = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramTokens", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelegramTokens");
        }
    }
}
