using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connect_agenda_data.Migrations
{
    /// <inheritdoc />
    public partial class updateOrderdATA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Order",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CompanyId",
                table: "Order",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Company_CompanyId",
                table: "Order",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Company_CompanyId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CompanyId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Order");
        }
    }
}
