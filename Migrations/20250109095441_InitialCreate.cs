using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SajatOldal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Pn_max = table.Column<double>(type: "REAL", nullable: false),
                    n_pn_max = table.Column<double>(type: "REAL", nullable: false),
                    M_max = table.Column<double>(type: "REAL", nullable: false),
                    n_M_max = table.Column<double>(type: "REAL", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    Max_Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    Transmissions = table.Column<string>(type: "TEXT", nullable: false),
                    Transmisson_1 = table.Column<string>(type: "TEXT", nullable: true),
                    Transmisson_2 = table.Column<string>(type: "TEXT", nullable: true),
                    Transmisson_3 = table.Column<string>(type: "TEXT", nullable: true),
                    Transmisson_4 = table.Column<string>(type: "TEXT", nullable: true),
                    Transmisson_5 = table.Column<string>(type: "TEXT", nullable: true),
                    Transmisson_6 = table.Column<string>(type: "TEXT", nullable: true),
                    CarName = table.Column<string>(type: "TEXT", nullable: false),
                    Gear_ratio = table.Column<double>(type: "REAL", nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Hight = table.Column<int>(type: "INTEGER", nullable: false),
                    Wheelbase = table.Column<int>(type: "INTEGER", nullable: false),
                    Gauge = table.Column<int>(type: "INTEGER", nullable: false),
                    Tire = table.Column<string>(type: "TEXT", nullable: true),
                    Drag_coefficient = table.Column<double>(type: "REAL", nullable: false),
                    Rolling_Resistance_Factor = table.Column<double>(type: "REAL", nullable: false),
                    Transmission_efficiency = table.Column<double>(type: "REAL", nullable: false),
                    Reduction_constant_of_rotating_masses = table.Column<double>(type: "REAL", nullable: false),
                    Slope_of_rise = table.Column<double>(type: "REAL", nullable: false),
                    Adhesion_factor = table.Column<double>(type: "REAL", nullable: false),
                    Creep_factor = table.Column<double>(type: "REAL", nullable: false),
                    Wheel_radius = table.Column<double>(type: "REAL", nullable: false),
                    M_P_Max = table.Column<double>(type: "REAL", nullable: false),
                    Speed_of_the_Wheels_P = table.Column<string>(type: "TEXT", nullable: false),
                    Speed_of_the_Wheels_M = table.Column<string>(type: "TEXT", nullable: false),
                    Force_of_the_Wheels_P = table.Column<string>(type: "TEXT", nullable: false),
                    Force_of_the_Wheels_M = table.Column<string>(type: "TEXT", nullable: false),
                    Rolling_resistance = table.Column<double>(type: "REAL", nullable: false),
                    The_hill_on_degree = table.Column<double>(type: "REAL", nullable: false),
                    Rolling_resistance_on_a_hill = table.Column<double>(type: "REAL", nullable: false),
                    Ascent_resistance = table.Column<double>(type: "REAL", nullable: false),
                    AirResistances_P = table.Column<string>(type: "TEXT", nullable: false),
                    AirResistances_M = table.Column<string>(type: "TEXT", nullable: false),
                    AirDensity = table.Column<double>(type: "REAL", nullable: false),
                    Cross_Section = table.Column<double>(type: "REAL", nullable: false),
                    ForcesRequiredForAccelaration_P = table.Column<string>(type: "TEXT", nullable: false),
                    ForcesRequiredForAccelaration_M = table.Column<string>(type: "TEXT", nullable: false),
                    Accelarations_On_The_Hill_P = table.Column<string>(type: "TEXT", nullable: false),
                    Accelarations_On_The_Hill_M = table.Column<string>(type: "TEXT", nullable: false),
                    Dynamic_Factors = table.Column<string>(type: "TEXT", nullable: false),
                    ForceAgistTheCar_P = table.Column<string>(type: "TEXT", nullable: false),
                    ForceAgistTheCar_M = table.Column<string>(type: "TEXT", nullable: false),
                    Speed_In_Kmperh_P = table.Column<string>(type: "TEXT", nullable: false),
                    Speed_In_Kmperh_M = table.Column<string>(type: "TEXT", nullable: false),
                    P_M_Max = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
