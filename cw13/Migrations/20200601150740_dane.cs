using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cw13.Migrations
{
    public partial class dane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Klienci",
                columns: new[] { "IdKlient", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "imie1", "nazwisko1" },
                    { 2, "imie2", "nazwisko2" },
                    { 3, "imie3", "nazwisko3" }
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "imie1", "nazwisko1" },
                    { 2, "imie2", "nazwisko2" },
                    { 3, "imie3", "nazwisko3" }
                });

            migrationBuilder.InsertData(
                table: "WyrobyCukiernicze",
                columns: new[] { "IdWyrobuCukierniczego", "CenaZaSzt", "Nazwa", "Typ" },
                values: new object[,]
                {
                    { 1, 1f, "nazwa1", "typ1" },
                    { 2, 2f, "nazwa2", "typ2" },
                    { 3, 3f, "nazwa3", "typ3" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienia",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 1, new DateTime(2020, 6, 1, 17, 7, 39, 802, DateTimeKind.Local).AddTicks(4356), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null });

            migrationBuilder.InsertData(
                table: "Zamowienia",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 2, new DateTime(2020, 6, 1, 17, 7, 39, 806, DateTimeKind.Local).AddTicks(9976), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, null });

            migrationBuilder.InsertData(
                table: "Zamowienia",
                columns: new[] { "IdZamowienia", "DataPrzyjecia", "DataRealizacji", "IdKlient", "IdPracownik", "Uwagi" },
                values: new object[] { 3, new DateTime(2020, 6, 1, 17, 7, 39, 807, DateTimeKind.Local).AddTicks(47), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, null });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobyCukiernicze",
                columns: new[] { "IdWyrobuCukierniczego", "IdZamowienia", "Ilosc", "Uwagi" },
                values: new object[] { 1, 1, 1, null });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobyCukiernicze",
                columns: new[] { "IdWyrobuCukierniczego", "IdZamowienia", "Ilosc", "Uwagi" },
                values: new object[] { 2, 2, 2, null });

            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobyCukiernicze",
                columns: new[] { "IdWyrobuCukierniczego", "IdZamowienia", "Ilosc", "Uwagi" },
                values: new object[] { 3, 3, 3, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobyCukiernicze",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobyCukiernicze",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobyCukiernicze",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "WyrobyCukiernicze",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WyrobyCukiernicze",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WyrobyCukiernicze",
                keyColumn: "IdWyrobuCukierniczego",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zamowienia",
                keyColumn: "IdZamowienia",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Klienci",
                keyColumn: "IdKlient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Klienci",
                keyColumn: "IdKlient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Klienci",
                keyColumn: "IdKlient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "IdPracownik",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "IdPracownik",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "IdPracownik",
                keyValue: 3);
        }
    }
}
