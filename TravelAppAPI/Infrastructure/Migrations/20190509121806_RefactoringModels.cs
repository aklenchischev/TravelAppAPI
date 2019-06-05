using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAppAPI.Infrastructure.Migrations
{
    public partial class RefactoringModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Places_PlaceId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Users_UserId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Users_UserId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesToPlaces_Places_PlaceId",
                table: "RoutesToPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesToPlaces_Routes_RouteId",
                table: "RoutesToPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_PlaceId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "PlaceOrder",
                table: "RoutesToPlaces");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Favourites");

            migrationBuilder.AlterColumn<int>(
                name: "RouteId",
                table: "RoutesToPlaces",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "RoutesToPlaces",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Routes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Favourites",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Favourites",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_RouteId",
                table: "Favourites",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Routes_RouteId",
                table: "Favourites",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Users_UserId",
                table: "Favourites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Users_UserId",
                table: "Routes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesToPlaces_Places_PlaceId",
                table: "RoutesToPlaces",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesToPlaces_Routes_RouteId",
                table: "RoutesToPlaces",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Routes_RouteId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Users_UserId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Users_UserId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesToPlaces_Places_PlaceId",
                table: "RoutesToPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesToPlaces_Routes_RouteId",
                table: "RoutesToPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_RouteId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Favourites");

            migrationBuilder.AlterColumn<int>(
                name: "RouteId",
                table: "RoutesToPlaces",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "RoutesToPlaces",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceOrder",
                table: "RoutesToPlaces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Routes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Favourites",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Favourites",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_PlaceId",
                table: "Favourites",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Places_PlaceId",
                table: "Favourites",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Users_UserId",
                table: "Favourites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Users_UserId",
                table: "Routes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesToPlaces_Places_PlaceId",
                table: "RoutesToPlaces",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesToPlaces_Routes_RouteId",
                table: "RoutesToPlaces",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
