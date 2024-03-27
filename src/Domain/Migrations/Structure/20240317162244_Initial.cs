﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Domain.Migrations.Structure
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    country = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    city = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    street = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    street2 = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    postal_code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    decription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    address = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "branches_ibfk_1",
                        column: x => x.address,
                        principalTable: "addresses",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "destinations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    address = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    availible = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "destinations_ibfk_1",
                        column: x => x.address,
                        principalTable: "addresses",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    password = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    surname = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    phone_num = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    addresses = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "users_ibfk_1",
                        column: x => x.addresses,
                        principalTable: "addresses",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "photos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    photo = table.Column<byte[]>(type: "blob", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "photos_ibfk_1",
                        column: x => x.id,
                        principalTable: "destinations",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    destination = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    beds = table.Column<string>(type: "json", nullable: false),
                    availible = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    amount_availible = table.Column<int>(type: "int", nullable: true),
                    cost_per_night = table.Column<decimal>(type: "decimal(15,2)", precision: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "rooms_ibfk_1",
                        column: x => x.destination,
                        principalTable: "destinations",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tags_destinations",
                columns: table => new
                {
                    tags_id = table.Column<int>(type: "int", nullable: false),
                    destinations_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.tags_id, x.destinations_id });
                    table.ForeignKey(
                        name: "tags_destinations_ibfk_1",
                        column: x => x.tags_id,
                        principalTable: "tags",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "tags_destinations_ibfk_2",
                        column: x => x.destinations_id,
                        principalTable: "destinations",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    branch = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "employees_ibfk_1",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "employees_ibfk_2",
                        column: x => x.branch,
                        principalTable: "branches",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "destinations_photos",
                columns: table => new
                {
                    destinations_id = table.Column<int>(type: "int", nullable: false),
                    photos_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.destinations_id, x.photos_id });
                    table.ForeignKey(
                        name: "destinations_photos_ibfk_1",
                        column: x => x.destinations_id,
                        principalTable: "destinations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "destinations_photos_ibfk_2",
                        column: x => x.photos_id,
                        principalTable: "photos",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rooms_photos",
                columns: table => new
                {
                    rooms_id = table.Column<int>(type: "int", nullable: false),
                    photos_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.rooms_id, x.photos_id });
                    table.ForeignKey(
                        name: "rooms_photos_ibfk_1",
                        column: x => x.rooms_id,
                        principalTable: "rooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "rooms_photos_ibfk_2",
                        column: x => x.photos_id,
                        principalTable: "photos",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tags_rooms",
                columns: table => new
                {
                    tags_id = table.Column<int>(type: "int", nullable: false),
                    rooms_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.tags_id, x.rooms_id });
                    table.ForeignKey(
                        name: "tags_rooms_ibfk_1",
                        column: x => x.tags_id,
                        principalTable: "tags",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "tags_rooms_ibfk_2",
                        column: x => x.rooms_id,
                        principalTable: "rooms",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    can_edit = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    can_delete = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "admin_ibfk_1",
                        column: x => x.id,
                        principalTable: "employees",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "packages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    room = table.Column<int>(type: "int", nullable: false),
                    availible = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    root_package_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "packages_ibfk_1",
                        column: x => x.room,
                        principalTable: "rooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "packages_ibfk_2",
                        column: x => x.created_by,
                        principalTable: "admin",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "packages_ibfk_3",
                        column: x => x.root_package_id,
                        principalTable: "packages",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    package_schedules = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    has_been_paid = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.package_schedules, x.userId });
                    table.ForeignKey(
                        name: "orders_ibfk_1",
                        column: x => x.package_schedules,
                        principalTable: "packages",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "orders_ibfk_2",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "package_schedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    package_id = table.Column<int>(type: "int", nullable: false),
                    date_start = table.Column<DateTime>(type: "date", nullable: false),
                    days = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "package_schedules_ibfk_1",
                        column: x => x.package_id,
                        principalTable: "packages",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tags_packages",
                columns: table => new
                {
                    tags_id = table.Column<int>(type: "int", nullable: false),
                    packages_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.tags_id, x.packages_id });
                    table.ForeignKey(
                        name: "tags_packages_ibfk_1",
                        column: x => x.tags_id,
                        principalTable: "tags",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "tags_packages_ibfk_2",
                        column: x => x.packages_id,
                        principalTable: "packages",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "address",
                table: "branches",
                column: "address");

            migrationBuilder.CreateIndex(
                name: "address1",
                table: "destinations",
                column: "address");

            migrationBuilder.CreateIndex(
                name: "photos_id",
                table: "destinations_photos",
                column: "photos_id");

            migrationBuilder.CreateIndex(
                name: "branch",
                table: "employees",
                column: "branch");

            migrationBuilder.CreateIndex(
                name: "userId",
                table: "orders",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "package_id",
                table: "package_schedules",
                column: "package_id");

            migrationBuilder.CreateIndex(
                name: "created_by",
                table: "packages",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "room",
                table: "packages",
                column: "room");

            migrationBuilder.CreateIndex(
                name: "root_package_id",
                table: "packages",
                column: "root_package_id");

            migrationBuilder.CreateIndex(
                name: "destination",
                table: "rooms",
                column: "destination");

            migrationBuilder.CreateIndex(
                name: "photos_id1",
                table: "rooms_photos",
                column: "photos_id");

            migrationBuilder.CreateIndex(
                name: "destinations_id",
                table: "tags_destinations",
                column: "destinations_id");

            migrationBuilder.CreateIndex(
                name: "packages_id",
                table: "tags_packages",
                column: "packages_id");

            migrationBuilder.CreateIndex(
                name: "rooms_id",
                table: "tags_rooms",
                column: "rooms_id");

            migrationBuilder.CreateIndex(
                name: "addresses",
                table: "users",
                column: "addresses");

            migrationBuilder.CreateIndex(
                name: "users_index_0",
                table: "users",
                column: "email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "destinations_photos");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "package_schedules");

            migrationBuilder.DropTable(
                name: "rooms_photos");

            migrationBuilder.DropTable(
                name: "tags_destinations");

            migrationBuilder.DropTable(
                name: "tags_packages");

            migrationBuilder.DropTable(
                name: "tags_rooms");

            migrationBuilder.DropTable(
                name: "photos");

            migrationBuilder.DropTable(
                name: "packages");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "destinations");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
