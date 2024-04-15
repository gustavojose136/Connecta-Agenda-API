using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connect_agenda_data.Migrations
{
    /// <inheritdoc />
    public partial class melhorias_banco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_UserUpdateId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Document",
                table: "User",
                newName: "Gender");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "User",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "User",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Company",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Address",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "Address",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPlanCard",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPlanCard = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdUser = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlanCardNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserUpdateId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserCreatedId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPlanCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPlanCard_PlanCard_IdPlanCard",
                        column: x => x.IdPlanCard,
                        principalTable: "PlanCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPlanCard_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPlanCard_User_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPlanCard_User_UserUpdateId",
                        column: x => x.UserUpdateId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlanCard_IdPlanCard",
                table: "UserPlanCard",
                column: "IdPlanCard");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlanCard_IdUser",
                table: "UserPlanCard",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlanCard_UserCreatedId",
                table: "UserPlanCard",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlanCard_UserUpdateId",
                table: "UserPlanCard",
                column: "UserUpdateId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_UserUpdateId",
                table: "User",
                column: "UserUpdateId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_UserUpdateId",
                table: "User");

            migrationBuilder.DropTable(
                name: "UserPlanCard");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Observation",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "User",
                newName: "Document");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_UserUpdateId",
                table: "User",
                column: "UserUpdateId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
