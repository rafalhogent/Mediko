using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedikoData.Migrations
{
    public partial class logbooksSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "573712a1-8697-4a15-8239-d1f193eb9c5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d67852a7-ce20-40c5-b741-37bb627938f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edeb2591-7ec4-49c4-b369-fa8fab2894b5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ea31a50f-0770-4762-bb7f-f6db9133caf2", "b6dcb5b7-5b8b-4ac4-837b-3404b9507ee4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea31a50f-0770-4762-bb7f-f6db9133caf2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6dcb5b7-5b8b-4ac4-837b-3404b9507ee4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40c952aa-b7ba-48c3-8dbd-8aa57d8c41e6", "555da7e6-2406-43d4-b1bb-a448b24ac203", "Editor", "Editor" },
                    { "9e34941c-2e2e-46d7-825f-abcff3f9cba1", "834d5cf8-18dd-4bc3-8b8c-7638ce2dbbc5", "Doktor", "Doktor" },
                    { "acc248e1-2ff7-45f0-bb95-782cf55dc309", "9fecf9b2-ea30-43b4-b213-bfbba30b8972", "Admin", "Administrator" },
                    { "f515dbfd-c2ba-4ae9-977e-ba13717596b7", "e3029452-2a31-4773-8962-ff5e0555ae52", "Patient", "Patient" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Language", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c7db1571-f6a6-4126-9b24-0a609cc15a29", 0, "def979dc-a7c0-492c-bae2-4d15aad78bd2", null, null, false, null, null, 1, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEL+zn48nEAiE4IC3cTONbVyNoB80Np9Cs8B5d2oNSP36kYMdBR7849hTEm8AvNE58A==", null, false, "6df89451-fca1-4e9f-9f4b-96992a9c701f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "LogBooks",
                columns: new[] { "LogBookId", "CreatorId", "Field1", "Field2", "Field3", "IconUrl", "Name", "Precision", "Unit1", "Unit2", "Unit3" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "Dagboek", 0, null, null, null },
                    { 2, null, "gewicht", null, null, null, "Gewicht", 1, "kg", null, null },
                    { 3, null, "systolic", "diastolic", "pulse", null, "Bloeddruk", 0, null, null, null },
                    { 4, null, "temperatuur", null, null, null, "Temperatuur", 1, "°C", null, null },
                    { 5, null, "drink", null, null, null, "Water", 1, "ml", null, null },
                    { 6, null, "glucose", null, null, null, "Glucose", 1, "mmol/L", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "acc248e1-2ff7-45f0-bb95-782cf55dc309", "c7db1571-f6a6-4126-9b24-0a609cc15a29" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40c952aa-b7ba-48c3-8dbd-8aa57d8c41e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e34941c-2e2e-46d7-825f-abcff3f9cba1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f515dbfd-c2ba-4ae9-977e-ba13717596b7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "acc248e1-2ff7-45f0-bb95-782cf55dc309", "c7db1571-f6a6-4126-9b24-0a609cc15a29" });

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "LogBookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "LogBookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "LogBookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "LogBookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "LogBookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LogBooks",
                keyColumn: "LogBookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acc248e1-2ff7-45f0-bb95-782cf55dc309");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7db1571-f6a6-4126-9b24-0a609cc15a29");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "573712a1-8697-4a15-8239-d1f193eb9c5b", "b109431b-f04e-46c2-b78a-1b03b01f5e88", "Editor", "Editor" },
                    { "d67852a7-ce20-40c5-b741-37bb627938f4", "e2238329-3efa-456b-b87e-eee2a04a8f6f", "Patient", "Patient" },
                    { "ea31a50f-0770-4762-bb7f-f6db9133caf2", "d41853e0-52d3-4f15-8a14-f75a4599d599", "Admin", "Administrator" },
                    { "edeb2591-7ec4-49c4-b369-fa8fab2894b5", "a96e825d-e82a-4351-a1ef-03cb207640bd", "Doktor", "Doktor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Language", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b6dcb5b7-5b8b-4ac4-837b-3404b9507ee4", 0, "5b53577d-a4ba-4886-a75a-e90646fb8f25", null, null, false, null, null, 1, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEDsKGu2lwNSZIjDPB4DBG9b5wtoKl3DdrdkNFrDfsSTQhvi3PoQV9SZCwedV5Tvd+A==", null, false, "30e906af-1bce-437a-8695-dbf418cb8f6d", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ea31a50f-0770-4762-bb7f-f6db9133caf2", "b6dcb5b7-5b8b-4ac4-837b-3404b9507ee4" });
        }
    }
}
