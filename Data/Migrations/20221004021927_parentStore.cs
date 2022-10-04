using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoupStorePracticeProject.Data.Migrations
{
    public partial class parentStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentStoreVmId",
                table: "Store",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentStoreVmId",
                table: "Cart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParentStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentStore", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Store_ParentStoreVmId",
                table: "Store",
                column: "ParentStoreVmId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ParentStoreVmId",
                table: "Cart",
                column: "ParentStoreVmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_ParentStore_ParentStoreVmId",
                table: "Cart",
                column: "ParentStoreVmId",
                principalTable: "ParentStore",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_ParentStore_ParentStoreVmId",
                table: "Store",
                column: "ParentStoreVmId",
                principalTable: "ParentStore",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_ParentStore_ParentStoreVmId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_ParentStore_ParentStoreVmId",
                table: "Store");

            migrationBuilder.DropTable(
                name: "ParentStore");

            migrationBuilder.DropIndex(
                name: "IX_Store_ParentStoreVmId",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ParentStoreVmId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ParentStoreVmId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "ParentStoreVmId",
                table: "Cart");
        }
    }
}
