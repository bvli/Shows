﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DeckHub.Shows.Migrate.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Place = table.Column<string>(maxLength: 16, nullable: true),
                    Presenter = table.Column<string>(maxLength: 16, nullable: true),
                    Slug = table.Column<string>(maxLength: 16, nullable: true),
                    Title = table.Column<string>(maxLength: 256, nullable: true),
                    Time = table.Column<DateTimeOffset>(nullable: false),
                    HighestSlideShown = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shows_Presenter_Slug",
                table: "Shows",
                columns: new[] { "Presenter", "Slug" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shows");
        }
    }
}
