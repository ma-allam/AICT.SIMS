using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AICT.SIMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "entities",
                columns: table => new
                {
                    entityid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entityname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    parententityid = table.Column<int>(type: "integer", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entities", x => x.entityid);
                    table.ForeignKey(
                        name: "FK_entities_entities_parententityid",
                        column: x => x.parententityid,
                        principalTable: "entities",
                        principalColumn: "entityid");
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    roleid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rolename = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.roleid);
                });

            migrationBuilder.CreateTable(
                name: "satellites",
                columns: table => new
                {
                    satelliteid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    satellitename = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    noradid = table.Column<int>(type: "integer", nullable: true),
                    swathwidthkm = table.Column<double>(type: "double precision", nullable: false),
                    tleline1 = table.Column<string>(type: "text", nullable: true),
                    tleline2 = table.Column<string>(type: "text", nullable: true),
                    lastupdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_satellites", x => x.satelliteid);
                });

            migrationBuilder.CreateTable(
                name: "SysParam",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParamName = table.Column<string>(type: "text", nullable: false),
                    ParamValue = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysParam", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    roleid = table.Column<int>(type: "integer", nullable: true),
                    isadmin = table.Column<bool>(type: "boolean", nullable: true),
                    parentuserid = table.Column<int>(type: "integer", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userid);
                    table.ForeignKey(
                        name: "FK_users_roles_roleid",
                        column: x => x.roleid,
                        principalTable: "roles",
                        principalColumn: "roleid");
                    table.ForeignKey(
                        name: "FK_users_users_parentuserid",
                        column: x => x.parentuserid,
                        principalTable: "users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateTable(
                name: "imagerequests",
                columns: table => new
                {
                    requestid = table.Column<Guid>(type: "uuid", nullable: false),
                    mainentityid = table.Column<int>(type: "integer", nullable: false),
                    subentityid = table.Column<int>(type: "integer", nullable: false),
                    createdbyuserid = table.Column<int>(type: "integer", nullable: false),
                    requestformimage = table.Column<byte[]>(type: "bytea", nullable: true),
                    requestformfilename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    priority = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    feasibilitydetails = table.Column<string>(type: "jsonb", nullable: true),
                    completionpercentage = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updatedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagerequests", x => x.requestid);
                    table.ForeignKey(
                        name: "FK_imagerequests_entities_mainentityid",
                        column: x => x.mainentityid,
                        principalTable: "entities",
                        principalColumn: "entityid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_imagerequests_entities_subentityid",
                        column: x => x.subentityid,
                        principalTable: "entities",
                        principalColumn: "entityid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_imagerequests_users_createdbyuserid",
                        column: x => x.createdbyuserid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "operationslog",
                columns: table => new
                {
                    logid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    requestid = table.Column<Guid>(type: "uuid", nullable: false),
                    actiontaken = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    performedbyuserid = table.Column<int>(type: "integer", nullable: true),
                    logtimestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    details = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operationslog", x => x.logid);
                    table.ForeignKey(
                        name: "FK_operationslog_imagerequests_requestid",
                        column: x => x.requestid,
                        principalTable: "imagerequests",
                        principalColumn: "requestid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_operationslog_users_performedbyuserid",
                        column: x => x.performedbyuserid,
                        principalTable: "users",
                        principalColumn: "userid");
                });

            migrationBuilder.CreateTable(
                name: "requestassignments",
                columns: table => new
                {
                    assignmentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    requestid = table.Column<Guid>(type: "uuid", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    assignedbyuserid = table.Column<int>(type: "integer", nullable: true),
                    assignedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestassignments", x => x.assignmentid);
                    table.ForeignKey(
                        name: "FK_requestassignments_imagerequests_requestid",
                        column: x => x.requestid,
                        principalTable: "imagerequests",
                        principalColumn: "requestid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requestassignments_users_assignedbyuserid",
                        column: x => x.assignedbyuserid,
                        principalTable: "users",
                        principalColumn: "userid");
                    table.ForeignKey(
                        name: "FK_requestassignments_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requesttargets",
                columns: table => new
                {
                    targetid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    requestid = table.Column<Guid>(type: "uuid", nullable: false),
                    targetlabel = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    targetgeometry = table.Column<Geometry>(type: "geometry(Geometry,4326)", nullable: false),
                    iscaptured = table.Column<bool>(type: "boolean", nullable: true),
                    capturedate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requesttargets", x => x.targetid);
                    table.ForeignKey(
                        name: "FK_requesttargets_imagerequests_requestid",
                        column: x => x.requestid,
                        principalTable: "imagerequests",
                        principalColumn: "requestid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_entities_parententityid",
                table: "entities",
                column: "parententityid");

            migrationBuilder.CreateIndex(
                name: "idx_req_status",
                table: "imagerequests",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_imagerequests_createdbyuserid",
                table: "imagerequests",
                column: "createdbyuserid");

            migrationBuilder.CreateIndex(
                name: "IX_imagerequests_mainentityid",
                table: "imagerequests",
                column: "mainentityid");

            migrationBuilder.CreateIndex(
                name: "IX_imagerequests_subentityid",
                table: "imagerequests",
                column: "subentityid");

            migrationBuilder.CreateIndex(
                name: "IX_operationslog_performedbyuserid",
                table: "operationslog",
                column: "performedbyuserid");

            migrationBuilder.CreateIndex(
                name: "IX_operationslog_requestid",
                table: "operationslog",
                column: "requestid");

            migrationBuilder.CreateIndex(
                name: "IX_requestassignments_assignedbyuserid",
                table: "requestassignments",
                column: "assignedbyuserid");

            migrationBuilder.CreateIndex(
                name: "IX_requestassignments_userid",
                table: "requestassignments",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "requestassignments_requestid_userid_key",
                table: "requestassignments",
                columns: new[] { "requestid", "userid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_requesttargets_requestid",
                table: "requesttargets",
                column: "requestid");

            migrationBuilder.CreateIndex(
                name: "roles_rolename_key",
                table: "roles",
                column: "rolename",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "satellites_noradid_key",
                table: "satellites",
                column: "noradid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_parentuserid",
                table: "users",
                column: "parentuserid");

            migrationBuilder.CreateIndex(
                name: "IX_users_roleid",
                table: "users",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "users_email_key",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operationslog");

            migrationBuilder.DropTable(
                name: "requestassignments");

            migrationBuilder.DropTable(
                name: "requesttargets");

            migrationBuilder.DropTable(
                name: "satellites");

            migrationBuilder.DropTable(
                name: "SysParam");

            migrationBuilder.DropTable(
                name: "imagerequests");

            migrationBuilder.DropTable(
                name: "entities");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
