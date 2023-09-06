using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SomeIntFieldWithRange = table.Column<int>(type: "int", nullable: false),
                    SomeByteFieldWithRange = table.Column<byte>(type: "tinyint", nullable: false),
                    SomeFloatFieldWithRange = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.CheckConstraint("CK_Posts_SomeIntFieldWithRange_Range", "[SomeIntFieldWithRange] >= 0 AND [SomeIntFieldWithRange] <= 47");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
