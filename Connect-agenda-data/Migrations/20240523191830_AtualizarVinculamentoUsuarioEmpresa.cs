using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connect_agenda_data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarVinculamentoUsuarioEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompany_RoleUserCompany_RoleUserCompanyId",
                table: "UserCompany");

            migrationBuilder.DropIndex(
                name: "IX_UserCompany_RoleUserCompanyId",
                table: "UserCompany");

            migrationBuilder.DropColumn(
                name: "RoleUserCompanyId",
                table: "UserCompany");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleUserCompanyId",
                table: "UserCompany",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_RoleUserCompanyId",
                table: "UserCompany",
                column: "RoleUserCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompany_RoleUserCompany_RoleUserCompanyId",
                table: "UserCompany",
                column: "RoleUserCompanyId",
                principalTable: "RoleUserCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
