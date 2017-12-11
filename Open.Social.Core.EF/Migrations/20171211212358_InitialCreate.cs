using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Open.Social.Core.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbo_User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    birth = table.Column<DateTime>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    expire = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 150, nullable: true),
                    password = table.Column<string>(nullable: true),
                    photo = table.Column<byte[]>(nullable: true),
                    salt = table.Column<Guid>(nullable: false),
                    update = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbo_User", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbo_User");
        }
    }
}
