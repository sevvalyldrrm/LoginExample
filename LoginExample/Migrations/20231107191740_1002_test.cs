using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginExample.Migrations
{
    /// <inheritdoc />
    public partial class _1002_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tanim2",
                table: "Bolum",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tanim2",
                table: "Bolum");
        }
    }
}
