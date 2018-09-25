using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mortgage.Domain.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lenders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Citizenship = table.Column<string>(nullable: false),
                    CriteriaUrl = table.Column<string>(nullable: true),
                    FirstTimeBuyer = table.Column<bool>(nullable: false),
                    LenderUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    NewProperty_AcceptBuyToLet = table.Column<bool>(nullable: false),
                    NewProperty_AcceptResidential = table.Column<bool>(nullable: false),
                    NewProperty_BuyToLetMaxLoanToValue = table.Column<decimal>(nullable: false),
                    NewProperty_MaxNumberOfFloors = table.Column<int>(nullable: false),
                    NewProperty_ResidentialMaxLoanToValue = table.Column<decimal>(nullable: false),
                    PrimaryContactInformation_DirectLine = table.Column<bool>(nullable: false),
                    PrimaryContactInformation_Name = table.Column<string>(nullable: true),
                    PrimaryContactInformation_PhoneNumber = table.Column<string>(nullable: true),
                    RatesUrl = table.Column<string>(nullable: true),
                    SecondaryContactInformation_DirectLine = table.Column<bool>(nullable: false),
                    SecondaryContactInformation_Name = table.Column<string>(nullable: true),
                    SecondaryContactInformation_PhoneNumber = table.Column<string>(nullable: true),
                    SelfEmployment_Accept = table.Column<bool>(nullable: false),
                    SelfEmployment_MinimumIncome = table.Column<decimal>(nullable: false),
                    SelfEmployment_YearsBooks = table.Column<int>(nullable: false),
                    UsedProperty_AcceptBuyToLet = table.Column<bool>(nullable: false),
                    UsedProperty_AcceptResidential = table.Column<bool>(nullable: false),
                    UsedProperty_BuyToLetMaxLoanToValue = table.Column<decimal>(nullable: false),
                    UsedProperty_MaxNumberOfFloors = table.Column<int>(nullable: false),
                    UsedProperty_ResidentialMaxLoanToValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LenderCountry",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Allowed = table.Column<bool>(nullable: false),
                    LenderId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LenderCountry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LenderCountry_Lenders_LenderId",
                        column: x => x.LenderId,
                        principalTable: "Lenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Afghanistan", "AF" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Netherlands Antilles", "AN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "New Caledonia", "NC" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "New Zealand", "NZ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Nicaragua", "NI" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Niger", "NE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Nigeria", "NG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Niue", "NU" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Norfolk Island", "NF" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Northern Mariana Islands", "MP" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Norway", "NO" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Oman", "OM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Pakistan", "PK" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Netherlands", "NL" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Palau", "PW" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Panama", "PA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Papua New Guinea", "PG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Paraguay", "PY" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Peru", "PE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Philippines", "PH" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Pitcairn", "PN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Poland", "PL" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Portugal", "PT" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Puerto Rico", "PR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Qatar", "QA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Reunion", "RE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Romania", "RO" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Palestinian Territory, Occupied", "PS" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Nepal", "NP" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Nauru", "NR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Namibia", "NA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Liberia", "LR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Libyan Arab Jamahiriya", "LY" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Liechtenstein", "LI" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Lithuania", "LT" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Luxembourg", "LU" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Macao", "MO" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Macedonia, The Former Yugoslav Republic of", "MK" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Madagascar", "MG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Malawi", "MW" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Malaysia", "MY" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Maldives", "MV" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Mali", "ML" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Malta", "MT" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Marshall Islands", "MH" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Martinique", "MQ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Mauritania", "MR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Mauritius", "MU" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Mayotte", "YT" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Mexico", "MX" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Micronesia, Federated States of", "FM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Moldova, Republic of", "MD" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Monaco", "MC" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Mongolia", "MN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Montserrat", "MS" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Morocco", "MA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Mozambique", "MZ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Myanmar", "MM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Russian Federation", "RU" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Lesotho", "LS" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "RWANDA", "RW" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Saint Kitts and Nevis", "KN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Timor-Leste", "TL" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Togo", "TG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Tokelau", "TK" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Tonga", "TO" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Trinidad and Tobago", "TT" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Tunisia", "TN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Turkey", "TR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Turkmenistan", "TM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Turks and Caicos Islands", "TC" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Tuvalu", "TV" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Uganda", "UG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Ukraine", "UA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Thailand", "TH" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "United Arab Emirates", "AE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "United States", "US" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "United States Minor Outlying Islands", "UM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Uruguay", "UY" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Uzbekistan", "UZ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Vanuatu", "VU" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Venezuela", "VE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Viet Nam", "VN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Virgin Islands, British", "VG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Virgin Islands, U.S.", "VI" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Wallis and Futuna", "WF" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Western Sahara", "EH" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Yemen", "YE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "United Kingdom", "GB" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Tanzania, United Republic of", "TZ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Tajikistan", "TJ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Taiwan, Province of China", "TW" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Saint Lucia", "LC" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Saint Pierre and Miquelon", "PM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Saint Vincent and the Grenadines", "VC" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Samoa", "WS" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "San Marino", "SM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Sao Tome and Principe", "ST" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Saudi Arabia", "SA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Senegal", "SN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Serbia and Montenegro", "CS" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Seychelles", "SC" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Sierra Leone", "SL" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Singapore", "SG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Slovakia", "SK" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Slovenia", "SI" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Solomon Islands", "SB" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Somalia", "SO" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "South Africa", "ZA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "South Georgia and the South Sandwich Islands", "GS" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Spain", "ES" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Sri Lanka", "LK" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Sudan", "SD" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Suriid", "SR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Svalbard and Jan Mayen", "SJ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Swaziland", "SZ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Sweden", "SE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Switzerland", "CH" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Syrian Arab Republic", "SY" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Saint Helena", "SH" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Zambia", "ZM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Lebanon", "LB" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Lao People'S Democratic Republic", "LA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Brunei Darussalam", "BN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Bulgaria", "BG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Burkina Faso", "BF" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Burundi", "BI" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Cambodia", "KH" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Cameroon", "CM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Canada", "CA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Cape Verde", "CV" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Cayman Islands", "KY" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Central African Republic", "CF" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Chad", "TD" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Chile", "CL" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "British Indian Ocean Territory", "IO" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "China", "CN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Cocos (Keeling) Islands", "CC" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Colombia", "CO" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Comoros", "KM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Congo", "CG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Congo, The Democratic Republic of the", "CD" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Cook Islands", "CK" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Costa Rica", "CR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Cote D'Ivoire", "CI" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Croatia", "HR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Cuba", "CU" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Cyprus", "CY" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Czech Republic", "CZ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Christmas Island", "CX" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Brazil", "BR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Bouvet Island", "BV" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Botswana", "BW" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Åland Islands", "AX" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Albania", "AL" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Algeria", "DZ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "American Samoa", "AS" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "AndorrA", "AD" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Angola", "AO" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Anguilla", "AI" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Antarctica", "AQ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Antigua and Barbuda", "AG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Argentina", "AR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Armenia", "AM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Aruba", "AW" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Australia", "AU" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Austria", "AT" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Azerbaijan", "AZ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Bahamas", "BS" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Bahrain", "BH" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Bangladesh", "BD" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Barbados", "BB" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Belarus", "BY" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Belgium", "BE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Belize", "BZ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Benin", "BJ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Bermuda", "BM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Bhutan", "BT" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Bolivia", "BO" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Bosnia and Herzegovina", "BA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Denmark", "DK" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Latvia", "LV" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Djibouti", "DJ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Dominican Republic", "DO" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Haiti", "HT" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Heard Island and Mcdonald Islands", "HM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Holy See (Vatican City State)", "VA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Honduras", "HN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Hong Kong", "HK" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Hungary", "HU" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Iceland", "IS" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "India", "IN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Indonesia", "ID" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Iran, Islamic Republic Of", "IR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Iraq", "IQ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Ireland", "IE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Guyana", "GY" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Isle of Man", "IM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Italy", "IT" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Jamaica", "JM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Japan", "JP" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Jersey", "JE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Jordan", "JO" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Kazakhstan", "KZ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Kenya", "KE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Kiribati", "KI" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Korea, Democratic People'S Republic of", "KP" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Korea, Republic of", "KR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Kuwait", "KW" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Kyrgyzstan", "KG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Israel", "IL" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Guinea-Bissau", "GW" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Guinea", "GN" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Guernsey", "GG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Ecuador", "EC" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Egypt", "EG" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "El Salvador", "SV" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Equatorial Guinea", "GQ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Eritrea", "ER" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Estonia", "EE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Ethiopia", "ET" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Falkland Islands (Malvinas)", "FK" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Faroe Islands", "FO" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Fiji", "FJ" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Finland", "FI" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "France", "FR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "French Guiana", "GF" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "French Polynesia", "PF" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "French Southern Territories", "TF" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Gabon", "GA" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Gambia", "GM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Georgia", "GE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Germany", "DE" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Ghana", "GH" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Gibraltar", "GI" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Greece", "GR" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Greenland", "GL" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Grenada", "GD" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Guadeloupe", "GP" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Guam", "GU" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Guatemala", "GT" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Dominica", "DM" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { "Zimbabwe", "ZW" });

            migrationBuilder.CreateIndex(
                name: "IX_LenderCountry_LenderId",
                table: "LenderCountry",
                column: "LenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "LenderCountry");

            migrationBuilder.DropTable(
                name: "Lenders");
        }
    }
}
