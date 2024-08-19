using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixedTokenDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TokenCredentials",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "TokenCredentials",
                newName: "Name");
        }
    }
}
