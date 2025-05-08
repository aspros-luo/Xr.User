using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Xr.User.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password_salt = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    nick_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    real_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_no = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_real = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    sex = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime", nullable: false),
                    avatar = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(150)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creator = table.Column<long>(type: "bigint(20)", maxLength: 20, nullable: false),
                    gmt_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    modifier = table.Column<long>(type: "bigint(20)", maxLength: 20, nullable: false),
                    gmt_modified = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_deleted = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserOauth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(type: "bigint(20)", nullable: false),
                    Plateform = table.Column<int>(type: "int", nullable: false),
                    ValueId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creator = table.Column<long>(type: "bigint", nullable: false),
                    GmtCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Modifier = table.Column<long>(type: "bigint", nullable: false),
                    GmtModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOauth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOauth_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_follow",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT(20)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<long>(type: "BIGINT(20)", nullable: false),
                    type = table.Column<sbyte>(type: "TINYINT(4)", nullable: false),
                    value_id = table.Column<long>(type: "BIGINT(20)", nullable: false),
                    follow_time = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    creator = table.Column<long>(type: "BIGINT(20)", nullable: false),
                    gmt_created = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    modifier = table.Column<long>(type: "BIGINT(20)", nullable: false),
                    gmt_modified = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    is_deleted = table.Column<sbyte>(type: "TINYINT", nullable: false),
                    status = table.Column<sbyte>(type: "TINYINT(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_follow", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_follow_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_server",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(type: "bigint(20)", nullable: false),
                    is_audit = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    rate_point = table.Column<float>(type: "float(11,2)", nullable: false),
                    creator = table.Column<long>(type: "bigint(20)", maxLength: 20, nullable: false),
                    gmt_created = table.Column<DateTime>(type: "datetime", nullable: false),
                    modifier = table.Column<long>(type: "bigint(20)", maxLength: 20, nullable: false),
                    gmt_modified = table.Column<DateTime>(type: "datetime", nullable: false),
                    is_deleted = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    status = table.Column<sbyte>(type: "tinyint(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_server", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_server_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserOauth_UserId",
                table: "UserOauth",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_follow_user_id",
                table: "user_follow",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_server_UserId",
                table: "user_server",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOauth");

            migrationBuilder.DropTable(
                name: "user_follow");

            migrationBuilder.DropTable(
                name: "user_server");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
