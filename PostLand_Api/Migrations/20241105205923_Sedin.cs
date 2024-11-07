using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostLand_Api.Migrations
{
    /// <inheritdoc />
    public partial class Sedin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
             table: "AspNetRoles",
             columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
             values: new object[] {Guid.NewGuid().ToString(),"user","user".ToUpper(),Guid.NewGuid().ToString()
             });

            migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
            values: new object[] {Guid.NewGuid().ToString(),"Admin","Admin".ToUpper(),Guid.NewGuid().ToString()
            });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [AspNetRoles]");
        }
    }
}
