using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXAMPLE.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BOOKS",
                columns: table => new
                {
                    ID_BOOK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMAGE_BOOK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AUTHOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POPULARITY = table.Column<int>(type: "int", nullable: false),
                    GENRE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TYPE_PRICE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COST = table.Column<float>(type: "real", nullable: false),
                    DATE_PUBLICATION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PATH_DOWNLOAD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKS", x => x.ID_BOOK);
                });

            migrationBuilder.CreateTable(
                name: "BUSKET",
                columns: table => new
                {
                    ID_BUSKET = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUSKET", x => x.ID_BUSKET);
                });

            migrationBuilder.CreateTable(
                name: "BUSKET_BOOKS",
                columns: table => new
                {
                    ID_RECORD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_BUSKET = table.Column<int>(type: "int", nullable: false),
                    ID_BOOK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUSKET_BOOKS", x => x.ID_RECORD);
                });

            migrationBuilder.CreateTable(
                name: "PAYMENT",
                columns: table => new
                {
                    ID_PAY = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USER = table.Column<int>(type: "int", nullable: false),
                    NUMBER_CARD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME_OWNER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_BOOK = table.Column<int>(type: "int", nullable: false),
                    STATE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAYMENT", x => x.ID_PAY);
                });

            migrationBuilder.CreateTable(
                name: "REVIEW_PROBLEM",
                columns: table => new
                {
                    ID_REVIEW = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOGIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    REVIEW_TEXT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REVIEW_PROBLEM", x => x.ID_REVIEW);
                });

            migrationBuilder.CreateTable(
                name: "REVIEWS",
                columns: table => new
                {
                    ID_REVIEW = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOGIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_BOOK = table.Column<int>(type: "int", nullable: false),
                    REVIEW_TEXT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REVIEWS", x => x.ID_REVIEW);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMAGE_PROFILE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LOGIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DATE_REGISTRATION = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ROLE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID_USER);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOOKS");

            migrationBuilder.DropTable(
                name: "BUSKET");

            migrationBuilder.DropTable(
                name: "BUSKET_BOOKS");

            migrationBuilder.DropTable(
                name: "PAYMENT");

            migrationBuilder.DropTable(
                name: "REVIEW_PROBLEM");

            migrationBuilder.DropTable(
                name: "REVIEWS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
