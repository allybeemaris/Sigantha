using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sigantha.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timelines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timelines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimelineId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Start = table.Column<string>(nullable: true),
                    End = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eras_Timelines_TimelineId",
                        column: x => x.TimelineId,
                        principalTable: "Timelines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Legacies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimelineId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    SymbolPath = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legacies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Legacies_Timelines_TimelineId",
                        column: x => x.TimelineId,
                        principalTable: "Timelines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimelineId = table.Column<Guid>(nullable: false),
                    EraId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Start = table.Column<string>(nullable: true),
                    End = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Eras_EraId",
                        column: x => x.EraId,
                        principalTable: "Eras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_Timelines_TimelineId",
                        column: x => x.TimelineId,
                        principalTable: "Timelines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EraLegacies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EraId = table.Column<Guid>(nullable: false),
                    LegacyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EraLegacies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EraLegacies_Eras_EraId",
                        column: x => x.EraId,
                        principalTable: "Eras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EraLegacies_Legacies_LegacyId",
                        column: x => x.LegacyId,
                        principalTable: "Legacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventLegacies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false),
                    LegacyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLegacies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLegacies_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventLegacies_Legacies_LegacyId",
                        column: x => x.LegacyId,
                        principalTable: "Legacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimelineId = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Start = table.Column<string>(nullable: true),
                    End = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scenes_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scenes_Timelines_TimelineId",
                        column: x => x.TimelineId,
                        principalTable: "Timelines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SceneLegacies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SceneId = table.Column<Guid>(nullable: false),
                    LegacyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneLegacies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SceneLegacies_Legacies_LegacyId",
                        column: x => x.LegacyId,
                        principalTable: "Legacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SceneLegacies_Scenes_SceneId",
                        column: x => x.SceneId,
                        principalTable: "Scenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EraLegacies_EraId",
                table: "EraLegacies",
                column: "EraId");

            migrationBuilder.CreateIndex(
                name: "IX_EraLegacies_LegacyId",
                table: "EraLegacies",
                column: "LegacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Eras_Name",
                table: "Eras",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Eras_TimelineId",
                table: "Eras",
                column: "TimelineId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLegacies_EventId",
                table: "EventLegacies",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLegacies_LegacyId",
                table: "EventLegacies",
                column: "LegacyId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EraId",
                table: "Events",
                column: "EraId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Name",
                table: "Events",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TimelineId",
                table: "Events",
                column: "TimelineId");

            migrationBuilder.CreateIndex(
                name: "IX_Legacies_Name",
                table: "Legacies",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Legacies_TimelineId",
                table: "Legacies",
                column: "TimelineId");

            migrationBuilder.CreateIndex(
                name: "IX_SceneLegacies_LegacyId",
                table: "SceneLegacies",
                column: "LegacyId");

            migrationBuilder.CreateIndex(
                name: "IX_SceneLegacies_SceneId",
                table: "SceneLegacies",
                column: "SceneId");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_EventId",
                table: "Scenes",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_Name",
                table: "Scenes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_TimelineId",
                table: "Scenes",
                column: "TimelineId");

            migrationBuilder.CreateIndex(
                name: "IX_Timelines_Name",
                table: "Timelines",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EraLegacies");

            migrationBuilder.DropTable(
                name: "EventLegacies");

            migrationBuilder.DropTable(
                name: "SceneLegacies");

            migrationBuilder.DropTable(
                name: "Legacies");

            migrationBuilder.DropTable(
                name: "Scenes");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Eras");

            migrationBuilder.DropTable(
                name: "Timelines");
        }
    }
}
