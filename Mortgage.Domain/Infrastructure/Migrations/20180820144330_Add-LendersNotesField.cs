using Microsoft.EntityFrameworkCore.Migrations;

namespace Mortgage.Domain.Infrastructure.Migrations
{
    public partial class AddLendersNotesField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AcceptInterestOnly",
                table: "Lenders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestOnlyMaxLoanToValue",
                table: "Lenders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MaximumAge",
                table: "Lenders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumIncome",
                table: "Lenders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Lenders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UsedProperty_HousingAndMultipleOccupancy",
                table: "Lenders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptInterestOnly",
                table: "Lenders");

            migrationBuilder.DropColumn(
                name: "InterestOnlyMaxLoanToValue",
                table: "Lenders");

            migrationBuilder.DropColumn(
                name: "MaximumAge",
                table: "Lenders");

            migrationBuilder.DropColumn(
                name: "MinimumIncome",
                table: "Lenders");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Lenders");

            migrationBuilder.DropColumn(
                name: "UsedProperty_HousingAndMultipleOccupancy",
                table: "Lenders");
        }
    }
}
