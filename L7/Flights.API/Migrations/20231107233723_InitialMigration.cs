using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P02Travel.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Airlines = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    From = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    To = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Airlines", "DepartureTime", "From", "Price", "To" },
                values: new object[,]
                {
                    { 1, "Ryanair", new DateTime(2023, 11, 8, 13, 49, 36, 37, DateTimeKind.Local).AddTicks(2930), "XGG", 402, "GWZ" },
                    { 2, "Turkish Airlines", new DateTime(2023, 11, 8, 12, 16, 56, 591, DateTimeKind.Local).AddTicks(6729), "AJJ", 459, "PDH" },
                    { 3, "Lufthansa", new DateTime(2023, 11, 8, 15, 35, 39, 619, DateTimeKind.Local).AddTicks(2253), "SOB", 477, "PJS" },
                    { 4, "Lufthansa", new DateTime(2023, 11, 8, 10, 47, 30, 352, DateTimeKind.Local).AddTicks(8272), "DRP", 426, "GCF" },
                    { 5, "KLM", new DateTime(2023, 11, 8, 8, 47, 43, 347, DateTimeKind.Local).AddTicks(3497), "KHH", 422, "KHR" },
                    { 6, "KLM", new DateTime(2023, 11, 8, 2, 46, 42, 666, DateTimeKind.Local).AddTicks(5996), "ATU", 152, "EAG" },
                    { 7, "LOT", new DateTime(2023, 11, 8, 15, 4, 44, 249, DateTimeKind.Local).AddTicks(5297), "BGX", 402, "NIG" },
                    { 8, "Turkish Airlines", new DateTime(2023, 11, 8, 12, 14, 49, 105, DateTimeKind.Local).AddTicks(3480), "GTH", 438, "DUR" },
                    { 9, "Lufthansa", new DateTime(2023, 11, 8, 23, 9, 6, 875, DateTimeKind.Local).AddTicks(1709), "AIH", 245, "IUA" },
                    { 10, "Turkish Airlines", new DateTime(2023, 11, 8, 18, 37, 25, 445, DateTimeKind.Local).AddTicks(4994), "JZQ", 341, "ICZ" },
                    { 11, "Ryanair", new DateTime(2023, 11, 8, 13, 16, 26, 643, DateTimeKind.Local).AddTicks(924), "OWY", 441, "AQR" },
                    { 12, "LOT", new DateTime(2023, 11, 8, 3, 18, 36, 599, DateTimeKind.Local).AddTicks(136), "BWY", 129, "DIN" },
                    { 13, "Aeroflot", new DateTime(2023, 11, 8, 9, 51, 2, 3, DateTimeKind.Local).AddTicks(1990), "IRL", 257, "WEJ" },
                    { 14, "LOT", new DateTime(2023, 11, 8, 7, 17, 23, 831, DateTimeKind.Local).AddTicks(3891), "EYQ", 320, "HNB" },
                    { 15, "LOT", new DateTime(2023, 11, 8, 7, 54, 47, 257, DateTimeKind.Local).AddTicks(2834), "GZQ", 288, "PMH" },
                    { 16, "Ryanair", new DateTime(2023, 11, 8, 6, 50, 46, 546, DateTimeKind.Local).AddTicks(4714), "XFQ", 193, "DGA" },
                    { 17, "Ryanair", new DateTime(2023, 11, 8, 16, 58, 24, 259, DateTimeKind.Local).AddTicks(3826), "RRQ", 127, "OQH" },
                    { 18, "LOT", new DateTime(2023, 11, 8, 20, 31, 21, 270, DateTimeKind.Local).AddTicks(2311), "XSH", 467, "WOB" },
                    { 19, "Ryanair", new DateTime(2023, 11, 8, 12, 2, 30, 899, DateTimeKind.Local).AddTicks(9482), "DSF", 222, "DKX" },
                    { 20, "Ryanair", new DateTime(2023, 11, 8, 20, 43, 55, 212, DateTimeKind.Local).AddTicks(4729), "YAR", 111, "QBH" },
                    { 21, "LOT", new DateTime(2023, 11, 8, 14, 26, 22, 888, DateTimeKind.Local).AddTicks(2174), "YQI", 386, "INU" },
                    { 22, "LOT", new DateTime(2023, 11, 8, 3, 20, 38, 318, DateTimeKind.Local).AddTicks(2187), "TBQ", 448, "PFK" },
                    { 23, "LOT", new DateTime(2023, 11, 8, 3, 32, 9, 826, DateTimeKind.Local).AddTicks(3986), "UNH", 159, "TGE" },
                    { 24, "LOT", new DateTime(2023, 11, 9, 0, 1, 48, 74, DateTimeKind.Local).AddTicks(942), "XFR", 283, "AWS" },
                    { 25, "Ryanair", new DateTime(2023, 11, 8, 13, 13, 26, 335, DateTimeKind.Local).AddTicks(3337), "TTE", 233, "JLU" },
                    { 26, "KLM", new DateTime(2023, 11, 8, 5, 10, 40, 243, DateTimeKind.Local).AddTicks(2697), "MIU", 406, "GTY" },
                    { 27, "Lufthansa", new DateTime(2023, 11, 8, 20, 32, 36, 272, DateTimeKind.Local).AddTicks(6499), "HDK", 168, "EFK" },
                    { 28, "KLM", new DateTime(2023, 11, 8, 2, 17, 39, 3, DateTimeKind.Local).AddTicks(3369), "WTF", 210, "XEG" },
                    { 29, "KLM", new DateTime(2023, 11, 8, 16, 21, 27, 577, DateTimeKind.Local).AddTicks(4360), "ILC", 397, "LLS" },
                    { 30, "Aeroflot", new DateTime(2023, 11, 8, 4, 32, 41, 608, DateTimeKind.Local).AddTicks(2011), "WPK", 285, "SGQ" },
                    { 31, "Aeroflot", new DateTime(2023, 11, 8, 11, 52, 6, 643, DateTimeKind.Local).AddTicks(4429), "SPO", 292, "TFP" },
                    { 32, "Aeroflot", new DateTime(2023, 11, 8, 11, 9, 48, 534, DateTimeKind.Local).AddTicks(2967), "FOD", 346, "NZS" },
                    { 33, "Aeroflot", new DateTime(2023, 11, 8, 8, 23, 33, 221, DateTimeKind.Local).AddTicks(8738), "EUQ", 347, "RKN" },
                    { 34, "Lufthansa", new DateTime(2023, 11, 8, 13, 39, 13, 486, DateTimeKind.Local).AddTicks(8432), "XDM", 267, "NLA" },
                    { 35, "KLM", new DateTime(2023, 11, 8, 12, 59, 6, 902, DateTimeKind.Local).AddTicks(3105), "TNG", 490, "MZZ" },
                    { 36, "Ryanair", new DateTime(2023, 11, 8, 7, 45, 52, 978, DateTimeKind.Local).AddTicks(99), "QHP", 469, "RCU" },
                    { 37, "KLM", new DateTime(2023, 11, 8, 14, 13, 0, 930, DateTimeKind.Local).AddTicks(6883), "DBF", 258, "AEX" },
                    { 38, "KLM", new DateTime(2023, 11, 8, 20, 50, 14, 624, DateTimeKind.Local).AddTicks(8812), "GQD", 217, "DDL" },
                    { 39, "Turkish Airlines", new DateTime(2023, 11, 8, 23, 55, 4, 210, DateTimeKind.Local).AddTicks(2408), "MQW", 289, "QRX" },
                    { 40, "Ryanair", new DateTime(2023, 11, 8, 6, 53, 37, 289, DateTimeKind.Local).AddTicks(4483), "OFA", 368, "RPD" },
                    { 41, "KLM", new DateTime(2023, 11, 8, 17, 55, 39, 985, DateTimeKind.Local).AddTicks(8987), "FSJ", 366, "JCK" },
                    { 42, "Turkish Airlines", new DateTime(2023, 11, 8, 11, 13, 28, 240, DateTimeKind.Local).AddTicks(1760), "YMD", 468, "EKG" },
                    { 43, "LOT", new DateTime(2023, 11, 8, 19, 46, 37, 337, DateTimeKind.Local).AddTicks(8849), "MLI", 442, "HNE" },
                    { 44, "KLM", new DateTime(2023, 11, 8, 2, 24, 52, 747, DateTimeKind.Local).AddTicks(4944), "HNB", 484, "ZLW" },
                    { 45, "Ryanair", new DateTime(2023, 11, 8, 13, 34, 18, 937, DateTimeKind.Local).AddTicks(7778), "MCN", 126, "KAZ" },
                    { 46, "KLM", new DateTime(2023, 11, 8, 4, 56, 33, 181, DateTimeKind.Local).AddTicks(7846), "WKT", 305, "STE" },
                    { 47, "Aeroflot", new DateTime(2023, 11, 8, 9, 4, 41, 629, DateTimeKind.Local).AddTicks(3411), "DXE", 124, "EMH" },
                    { 48, "Ryanair", new DateTime(2023, 11, 8, 10, 22, 20, 825, DateTimeKind.Local).AddTicks(1548), "TYA", 171, "HFI" },
                    { 49, "Lufthansa", new DateTime(2023, 11, 9, 0, 11, 6, 144, DateTimeKind.Local).AddTicks(5630), "CBL", 388, "IGA" },
                    { 50, "KLM", new DateTime(2023, 11, 8, 19, 59, 42, 85, DateTimeKind.Local).AddTicks(1144), "OOT", 136, "WLH" },
                    { 51, "Ryanair", new DateTime(2023, 11, 8, 7, 9, 47, 420, DateTimeKind.Local).AddTicks(7094), "XIP", 429, "FJQ" },
                    { 52, "LOT", new DateTime(2023, 11, 8, 10, 52, 37, 888, DateTimeKind.Local).AddTicks(7699), "LOF", 444, "LOJ" },
                    { 53, "Ryanair", new DateTime(2023, 11, 8, 12, 35, 51, 89, DateTimeKind.Local).AddTicks(983), "ITQ", 478, "ELN" },
                    { 54, "Aeroflot", new DateTime(2023, 11, 8, 7, 20, 42, 180, DateTimeKind.Local).AddTicks(9915), "JYL", 169, "REK" },
                    { 55, "Ryanair", new DateTime(2023, 11, 8, 6, 58, 16, 163, DateTimeKind.Local).AddTicks(5090), "SWR", 266, "UNZ" },
                    { 56, "KLM", new DateTime(2023, 11, 8, 19, 8, 7, 974, DateTimeKind.Local).AddTicks(1204), "DCZ", 173, "KZB" },
                    { 57, "Ryanair", new DateTime(2023, 11, 8, 11, 1, 51, 590, DateTimeKind.Local).AddTicks(2580), "MRW", 449, "BHW" },
                    { 58, "KLM", new DateTime(2023, 11, 8, 3, 54, 46, 978, DateTimeKind.Local).AddTicks(3611), "DSK", 216, "UHH" },
                    { 59, "LOT", new DateTime(2023, 11, 8, 19, 42, 34, 97, DateTimeKind.Local).AddTicks(5788), "KMG", 155, "RTF" },
                    { 60, "KLM", new DateTime(2023, 11, 8, 16, 58, 23, 627, DateTimeKind.Local).AddTicks(5314), "TZY", 257, "KNK" },
                    { 61, "LOT", new DateTime(2023, 11, 8, 7, 27, 58, 914, DateTimeKind.Local).AddTicks(9034), "FQN", 353, "UYC" },
                    { 62, "LOT", new DateTime(2023, 11, 8, 19, 2, 42, 985, DateTimeKind.Local).AddTicks(9103), "ZIU", 287, "RCW" },
                    { 63, "Lufthansa", new DateTime(2023, 11, 8, 2, 21, 45, 369, DateTimeKind.Local).AddTicks(8969), "STY", 288, "QYM" },
                    { 64, "KLM", new DateTime(2023, 11, 8, 2, 10, 32, 700, DateTimeKind.Local).AddTicks(399), "KRF", 390, "ZKP" },
                    { 65, "KLM", new DateTime(2023, 11, 8, 4, 12, 17, 875, DateTimeKind.Local).AddTicks(5887), "AOO", 370, "EBM" },
                    { 66, "KLM", new DateTime(2023, 11, 8, 16, 11, 48, 431, DateTimeKind.Local).AddTicks(702), "OCW", 166, "BYT" },
                    { 67, "Turkish Airlines", new DateTime(2023, 11, 8, 6, 9, 22, 746, DateTimeKind.Local).AddTicks(8448), "POR", 359, "BJW" },
                    { 68, "LOT", new DateTime(2023, 11, 8, 11, 1, 57, 582, DateTimeKind.Local).AddTicks(1527), "IAX", 249, "FZB" },
                    { 69, "Lufthansa", new DateTime(2023, 11, 8, 21, 54, 30, 522, DateTimeKind.Local).AddTicks(875), "QOR", 113, "LZT" },
                    { 70, "Turkish Airlines", new DateTime(2023, 11, 8, 2, 55, 5, 269, DateTimeKind.Local).AddTicks(5381), "OIT", 386, "KUT" },
                    { 71, "KLM", new DateTime(2023, 11, 8, 8, 57, 57, 598, DateTimeKind.Local).AddTicks(6487), "TZF", 467, "SNW" },
                    { 72, "Ryanair", new DateTime(2023, 11, 8, 12, 41, 44, 230, DateTimeKind.Local).AddTicks(7980), "OJD", 333, "URM" },
                    { 73, "Ryanair", new DateTime(2023, 11, 8, 2, 8, 48, 701, DateTimeKind.Local).AddTicks(4980), "EEO", 455, "YAL" },
                    { 74, "Turkish Airlines", new DateTime(2023, 11, 8, 14, 55, 22, 646, DateTimeKind.Local).AddTicks(3740), "TXE", 324, "DMW" },
                    { 75, "KLM", new DateTime(2023, 11, 8, 11, 51, 45, 672, DateTimeKind.Local).AddTicks(5719), "ZYB", 358, "WNP" },
                    { 76, "LOT", new DateTime(2023, 11, 8, 13, 39, 5, 985, DateTimeKind.Local).AddTicks(5411), "WTP", 382, "GWH" },
                    { 77, "Turkish Airlines", new DateTime(2023, 11, 8, 3, 27, 21, 598, DateTimeKind.Local).AddTicks(6932), "XWZ", 475, "SWL" },
                    { 78, "KLM", new DateTime(2023, 11, 8, 15, 26, 27, 628, DateTimeKind.Local).AddTicks(9004), "YLW", 126, "GGC" },
                    { 79, "LOT", new DateTime(2023, 11, 8, 1, 38, 32, 324, DateTimeKind.Local).AddTicks(2703), "AHP", 485, "ZHN" },
                    { 80, "Lufthansa", new DateTime(2023, 11, 8, 16, 34, 22, 86, DateTimeKind.Local).AddTicks(4664), "HNB", 483, "WKY" },
                    { 81, "Aeroflot", new DateTime(2023, 11, 8, 17, 15, 44, 96, DateTimeKind.Local).AddTicks(9850), "LFC", 170, "OYK" },
                    { 82, "Ryanair", new DateTime(2023, 11, 8, 17, 5, 13, 750, DateTimeKind.Local).AddTicks(5355), "QOM", 397, "MEF" },
                    { 83, "Lufthansa", new DateTime(2023, 11, 8, 16, 19, 12, 302, DateTimeKind.Local).AddTicks(6690), "HYO", 164, "KTU" },
                    { 84, "LOT", new DateTime(2023, 11, 8, 14, 59, 7, 986, DateTimeKind.Local).AddTicks(4615), "KBA", 245, "YHO" },
                    { 85, "KLM", new DateTime(2023, 11, 8, 8, 20, 19, 217, DateTimeKind.Local).AddTicks(5901), "MKI", 308, "FTO" },
                    { 86, "KLM", new DateTime(2023, 11, 8, 16, 34, 41, 305, DateTimeKind.Local).AddTicks(5997), "TTI", 381, "UDS" },
                    { 87, "Aeroflot", new DateTime(2023, 11, 8, 19, 6, 44, 685, DateTimeKind.Local).AddTicks(7310), "EAL", 437, "HKH" },
                    { 88, "LOT", new DateTime(2023, 11, 8, 6, 41, 30, 650, DateTimeKind.Local).AddTicks(2703), "ZRH", 436, "XDO" },
                    { 89, "Lufthansa", new DateTime(2023, 11, 8, 9, 36, 35, 132, DateTimeKind.Local).AddTicks(7883), "XBD", 243, "ZXL" },
                    { 90, "Turkish Airlines", new DateTime(2023, 11, 8, 5, 11, 58, 863, DateTimeKind.Local).AddTicks(3937), "FOY", 442, "HFP" },
                    { 91, "LOT", new DateTime(2023, 11, 8, 13, 8, 11, 470, DateTimeKind.Local).AddTicks(4887), "YFZ", 487, "BJA" },
                    { 92, "LOT", new DateTime(2023, 11, 8, 19, 48, 50, 615, DateTimeKind.Local).AddTicks(2702), "DWP", 287, "SZX" },
                    { 93, "LOT", new DateTime(2023, 11, 8, 15, 18, 20, 814, DateTimeKind.Local).AddTicks(7817), "PED", 260, "ZYB" },
                    { 94, "Lufthansa", new DateTime(2023, 11, 8, 22, 0, 13, 729, DateTimeKind.Local).AddTicks(7897), "RRM", 112, "QBZ" },
                    { 95, "Ryanair", new DateTime(2023, 11, 8, 5, 42, 41, 557, DateTimeKind.Local).AddTicks(5319), "GWR", 443, "CAJ" },
                    { 96, "LOT", new DateTime(2023, 11, 8, 6, 43, 13, 778, DateTimeKind.Local).AddTicks(7907), "GLP", 116, "BUK" },
                    { 97, "Ryanair", new DateTime(2023, 11, 8, 7, 27, 28, 178, DateTimeKind.Local).AddTicks(8391), "LZH", 437, "YQS" },
                    { 98, "Aeroflot", new DateTime(2023, 11, 8, 5, 6, 55, 856, DateTimeKind.Local).AddTicks(2774), "CLU", 436, "QSC" },
                    { 99, "Turkish Airlines", new DateTime(2023, 11, 8, 3, 30, 46, 90, DateTimeKind.Local).AddTicks(8703), "WME", 323, "SDR" },
                    { 100, "Ryanair", new DateTime(2023, 11, 8, 14, 42, 16, 253, DateTimeKind.Local).AddTicks(7261), "OPW", 484, "CPU" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
