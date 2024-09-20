using Microsoft.EntityFrameworkCore.Migrations;
using UsersCRUD.Domain.Users;

#nullable disable

namespace UsersCRUD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeDNIUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_DNI",
                table: "Users",
                columns: new[] { "DNI" },
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(name: "IX_Users_DNI", table: "Users");
        }
    }
}
