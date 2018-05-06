using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bookshelf.Api.Migrations
{
    public partial class Trunk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
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
                    table.PrimaryKey("PK_Authors", x => x.IdAuthor);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    Ddcn = table.Column<string>(nullable: true),
                    Gid = table.Column<int>(nullable: false),
                    IdObject = table.Column<Guid>(nullable: false),
                    Isbn10 = table.Column<string>(nullable: true),
                    Isbn13 = table.Column<string>(nullable: true),
                    Pages = table.Column<short>(nullable: false),
                    Permission = table.Column<short>(nullable: false),
                    PublisherId = table.Column<Guid>(nullable: false),
                    Subtitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Uid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    IdAuthor = table.Column<Guid>(nullable: false),
                    IdBook = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.IdAuthor, x.IdBook });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_IdAuthor",
                        column: x => x.IdAuthor,
                        principalTable: "Authors",
                        principalColumn: "IdAuthor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BookId",
                table: "AuthorBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
