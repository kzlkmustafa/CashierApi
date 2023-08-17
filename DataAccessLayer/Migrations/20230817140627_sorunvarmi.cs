using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class sorunvarmi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_OpertaionClaims_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpertaionClaims",
                table: "OpertaionClaims");

            migrationBuilder.RenameTable(
                name: "OpertaionClaims",
                newName: "OperationClaims");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OperationClaims",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims",
                column: "OperationClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId",
                principalTable: "OperationClaims",
                principalColumn: "OperationClaimId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims");

            migrationBuilder.RenameTable(
                name: "OperationClaims",
                newName: "OpertaionClaims");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "OpertaionClaims",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpertaionClaims",
                table: "OpertaionClaims",
                column: "OperationClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_OpertaionClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId",
                principalTable: "OpertaionClaims",
                principalColumn: "OperationClaimId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
