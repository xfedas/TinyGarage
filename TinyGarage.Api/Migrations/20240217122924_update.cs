using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyGarage.Api.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ModelCollections",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Manufacturers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Garages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "CarModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ModelCollections_CreatedById",
                table: "ModelCollections",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_CreatedById",
                table: "Manufacturers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_CreatedById",
                table: "Garages",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CreatedById",
                table: "Cars",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CreatedById",
                table: "CarModels",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_AspNetUsers_CreatedById",
                table: "CarModels",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_CreatedById",
                table: "Cars",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_AspNetUsers_CreatedById",
                table: "Garages",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_AspNetUsers_CreatedById",
                table: "Manufacturers",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelCollections_AspNetUsers_CreatedById",
                table: "ModelCollections",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_AspNetUsers_CreatedById",
                table: "CarModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_CreatedById",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Garages_AspNetUsers_CreatedById",
                table: "Garages");

            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_AspNetUsers_CreatedById",
                table: "Manufacturers");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelCollections_AspNetUsers_CreatedById",
                table: "ModelCollections");

            migrationBuilder.DropIndex(
                name: "IX_ModelCollections_CreatedById",
                table: "ModelCollections");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_CreatedById",
                table: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Garages_CreatedById",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CreatedById",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_CreatedById",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ModelCollections");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CarModels");
        }
    }
}
