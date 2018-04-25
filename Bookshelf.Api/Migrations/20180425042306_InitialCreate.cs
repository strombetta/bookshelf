using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bookshelf.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    IdAuthor = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Gid = table.Column<int>(nullable: false),
                    IdObject = table.Column<Guid>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Permission = table.Column<short>(nullable: false),
                    Uid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.IdAuthor);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    IdBook = table.Column<Guid>(nullable: false),
                    Ddcn = table.Column<string>(nullable: true),
                    Gid = table.Column<int>(nullable: false),
                    IdObject = table.Column<Guid>(nullable: false),
                    Isbn10 = table.Column<string>(nullable: true),
                    Isbn13 = table.Column<string>(nullable: true),
                    Pages = table.Column<short>(nullable: false),
                    Permission = table.Column<short>(nullable: false),
                    Publisher = table.Column<Guid>(nullable: false),
                    Subtitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Uid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.IdBook);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    IdPublisher = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.IdPublisher);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    IdAuthor = table.Column<Guid>(nullable: false),
                    IdBook = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.IdAuthor, x.IdBook });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Author_IdAuthor",
                        column: x => x.IdAuthor,
                        principalTable: "Author",
                        principalColumn: "IdAuthor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Books",
                        principalColumn: "IdBook",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_IdBook",
                table: "AuthorBook",
                column: "IdBook");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
