﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderItems");
        }
    }
}
