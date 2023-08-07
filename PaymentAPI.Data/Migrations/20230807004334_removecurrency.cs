using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaymentAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class removecurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("5212df22-9e2f-4b1b-a6bb-3b9e4a9f4372"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("d055f280-c4ca-40b9-a89f-536d55bfbfa9"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("61a7c9b7-1434-465b-b03c-a769e8949da5"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("6a98205b-3e34-4802-9499-230679f64546"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("c285f17d-e34b-495d-978b-68d57f6311cb"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "Id",
                keyValue: new Guid("2378a93e-5911-494f-8d7b-946e9409baf2"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "Id",
                keyValue: new Guid("ef6bacc7-332e-485b-91ae-07b387aff54e"));

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Cards");

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "BankName", "IsActive", "SortCode" },
                values: new object[,]
                {
                    { new Guid("9e9014b5-71ca-45ba-853b-0051564945b4"), "HSBC", true, "000111" },
                    { new Guid("e67a6c55-6e3f-4fb0-af61-5f9470fc4995"), "LLoyds", true, "333444" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("205a9b45-e29d-400d-853c-8b5bd8773955"), "NAR", "Naira" },
                    { new Guid("265534e9-a51e-4ed4-ba2e-8222b239f990"), "GBP", "Pounds Sterling" },
                    { new Guid("d802afc7-6805-4f84-ba55-749b6a539c44"), "USD", "Dollars" }
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("003f28db-059c-4e35-b7b3-fd12470b2e7d"), "CHK-1244O4I483", true, "Amazon" },
                    { new Guid("781a346b-eaed-4338-9b04-81a00e78772c"), "CHK-2934494944", true, "Samsung" },
                    { new Guid("d0cfa95f-746a-4ee1-9901-7e3e81d71c29"), "CHK-2939494944", true, "Apple" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("9e9014b5-71ca-45ba-853b-0051564945b4"));

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: new Guid("e67a6c55-6e3f-4fb0-af61-5f9470fc4995"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("205a9b45-e29d-400d-853c-8b5bd8773955"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("265534e9-a51e-4ed4-ba2e-8222b239f990"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("d802afc7-6805-4f84-ba55-749b6a539c44"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "Id",
                keyValue: new Guid("003f28db-059c-4e35-b7b3-fd12470b2e7d"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "Id",
                keyValue: new Guid("781a346b-eaed-4338-9b04-81a00e78772c"));

            migrationBuilder.DeleteData(
                table: "Merchants",
                keyColumn: "Id",
                keyValue: new Guid("d0cfa95f-746a-4ee1-9901-7e3e81d71c29"));

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "BankName", "IsActive", "SortCode" },
                values: new object[,]
                {
                    { new Guid("5212df22-9e2f-4b1b-a6bb-3b9e4a9f4372"), "HSBC", true, "000111" },
                    { new Guid("d055f280-c4ca-40b9-a89f-536d55bfbfa9"), "LLoyds", true, "333444" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("61a7c9b7-1434-465b-b03c-a769e8949da5"), "GBP", "Pounds Sterling" },
                    { new Guid("6a98205b-3e34-4802-9499-230679f64546"), "NAR", "Naira" },
                    { new Guid("c285f17d-e34b-495d-978b-68d57f6311cb"), "USD", "Dollars" }
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("2378a93e-5911-494f-8d7b-946e9409baf2"), "CHK-2939494944 ", true, "Apple" },
                    { new Guid("ef6bacc7-332e-485b-91ae-07b387aff54e"), "CHK-1244O4I483", true, "Amazon" }
                });
        }
    }
}
