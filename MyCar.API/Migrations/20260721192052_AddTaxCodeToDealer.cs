using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCar.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTaxCodeToDealer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaxCode",
                table: "Dealers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxCode",
                table: "Dealers");
        }
    }
}
