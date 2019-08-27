using Microsoft.EntityFrameworkCore.Migrations;

namespace Panda.Data.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_AspNetUsers_RecipientId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Package_PackageId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_AspNetUsers_RecipientId",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Package",
                table: "Package");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "Receipts");

            migrationBuilder.RenameTable(
                name: "Package",
                newName: "Packages");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_RecipientId",
                table: "Receipts",
                newName: "IX_Receipts_RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_PackageId",
                table: "Receipts",
                newName: "IX_Receipts_PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Package_RecipientId",
                table: "Packages",
                newName: "IX_Packages_RecipientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packages",
                table: "Packages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_AspNetUsers_RecipientId",
                table: "Packages",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Packages_PackageId",
                table: "Receipts",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_RecipientId",
                table: "Receipts",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_AspNetUsers_RecipientId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Packages_PackageId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_RecipientId",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packages",
                table: "Packages");

            migrationBuilder.RenameTable(
                name: "Receipts",
                newName: "Receipt");

            migrationBuilder.RenameTable(
                name: "Packages",
                newName: "Package");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_RecipientId",
                table: "Receipt",
                newName: "IX_Receipt_RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_PackageId",
                table: "Receipt",
                newName: "IX_Receipt_PackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_RecipientId",
                table: "Package",
                newName: "IX_Package_RecipientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Package",
                table: "Package",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_AspNetUsers_RecipientId",
                table: "Package",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Package_PackageId",
                table: "Receipt",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_AspNetUsers_RecipientId",
                table: "Receipt",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
