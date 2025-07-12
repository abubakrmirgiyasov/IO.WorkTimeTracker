using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkTimeTracker.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectTypeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTypes_Projects_ProjectId",
                table: "ProjectTypes");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTypes_ProjectId",
                table: "ProjectTypes");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectTypes");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "WorkTimeTrackings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WorkTimeTrackings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProjectTypes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectdWithProjectTypes",
                columns: table => new
                {
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectdWithProjectTypes", x => new { x.ProjectId, x.ProjectTypeId });
                    table.ForeignKey(
                        name: "FK_ProjectdWithProjectTypes_ProjectTypes_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "ProjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectdWithProjectTypes_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimeTrackings_Name",
                table: "WorkTimeTrackings",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimeTrackings_ShortDescription",
                table: "WorkTimeTrackings",
                column: "ShortDescription");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTypes_Name",
                table: "ProjectTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Link",
                table: "Projects",
                column: "Link",
                unique: true,
                filter: "[Link] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Name",
                table: "Projects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectdWithProjectTypes_ProjectTypeId",
                table: "ProjectdWithProjectTypes",
                column: "ProjectTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectdWithProjectTypes");

            migrationBuilder.DropIndex(
                name: "IX_WorkTimeTrackings_Name",
                table: "WorkTimeTrackings");

            migrationBuilder.DropIndex(
                name: "IX_WorkTimeTrackings_ShortDescription",
                table: "WorkTimeTrackings");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTypes_Name",
                table: "ProjectTypes");

            migrationBuilder.DropIndex(
                name: "IX_Projects_Link",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_Name",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "WorkTimeTrackings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WorkTimeTrackings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProjectTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<long>(
                name: "ProjectId",
                table: "ProjectTypes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTypes_ProjectId",
                table: "ProjectTypes",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTypes_Projects_ProjectId",
                table: "ProjectTypes",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
