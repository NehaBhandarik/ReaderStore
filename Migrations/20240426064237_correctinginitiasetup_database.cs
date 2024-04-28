using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReaderStore.Migrations
{
    /// <inheritdoc />
    public partial class correctinginitiasetup_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookImage",
                table: "Books");

            migrationBuilder.AddColumn<byte[]>(
                name: "Bimage",
                table: "Books",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bimage",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "BookImage",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
