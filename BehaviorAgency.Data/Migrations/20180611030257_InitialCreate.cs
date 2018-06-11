using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BehaviorAgency.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Address2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    CountryCode = table.Column<string>(maxLength: 3, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "CaseStatus",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStatus", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentCategory",
                columns: table => new
                {
                    DocCategoryId = table.Column<int>(nullable: false),
                    DocCategoryName = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentCategory", x => x.DocCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    AgencyId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    AgencyName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    AgencyLogo = table.Column<byte[]>(type: "image", nullable: true),
                    DropBoxClientId = table.Column<string>(unicode: false, nullable: true),
                    DropBoxClientSecret = table.Column<string>(unicode: false, nullable: true),
                    GoogleClientId = table.Column<string>(unicode: false, nullable: true),
                    GoogleClientSecret = table.Column<string>(unicode: false, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.AgencyId);
                    table.ForeignKey(
                        name: "FK_Agency_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInfo",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(maxLength: 50, nullable: false),
                    NaturalLanguage = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Multilingual = table.Column<bool>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfo", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CustomerInfo_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AspNetUserId = table.Column<string>(maxLength: 450, nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Sex = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    SecondaryPhone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserInfo_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    DocTypeId = table.Column<int>(nullable: false),
                    DocTypeName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DocTypeDesc = table.Column<string>(type: "text", nullable: true),
                    DocCategoryId = table.Column<int>(nullable: false),
                    AgencyId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.DocTypeId);
                    table.ForeignKey(
                        name: "FK_DocumentType_Agency",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "AgencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentType_DocumentCategory",
                        column: x => x.DocCategoryId,
                        principalTable: "DocumentCategory",
                        principalColumn: "DocCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgencyUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgencyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyUsers_Agency",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "AgencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgencyUsers_UserInfo",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    CaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    RbtId = table.Column<int>(nullable: true),
                    AnalystId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    CaseNumber = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PolicyNumber = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    SecondaryPolicyNumber = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Insurer = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    SecondInsurer = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MedicaidNumber = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    HoursApproved = table.Column<int>(nullable: true),
                    AdministeredLanguage = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.CaseId);
                    table.ForeignKey(
                        name: "FK_Case_UserInfo1",
                        column: x => x.AnalystId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_CustomerInfo",
                        column: x => x.CustomerId,
                        principalTable: "CustomerInfo",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_UserInfo",
                        column: x => x.RbtId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_CaseStatus",
                        column: x => x.StatusId,
                        principalTable: "CaseStatus",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    NotifyDocExpiration = table.Column<bool>(nullable: true),
                    SendReminders = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserNotifications_UserInfo",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocTypeId = table.Column<int>(nullable: false),
                    DocCategoryId = table.Column<int>(nullable: false),
                    AgencyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DocName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DocPath = table.Column<string>(unicode: false, nullable: false),
                    DocFormat = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReviewedBy = table.Column<int>(nullable: true),
                    ReviewedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    ApprovedBy = table.Column<int>(nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    RejectedBy = table.Column<int>(nullable: true),
                    RejectedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocId);
                    table.ForeignKey(
                        name: "FK_Document_Agency",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "AgencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_ApprovedByUser",
                        column: x => x.ApprovedBy,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_DocumentCategory",
                        column: x => x.DocCategoryId,
                        principalTable: "DocumentCategory",
                        principalColumn: "DocCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_DocumentType",
                        column: x => x.DocTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "DocTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_RejectedByUser",
                        column: x => x.RejectedBy,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_ReviewedByUser",
                        column: x => x.ReviewedBy,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_UserInfo",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agency_AddressId",
                table: "Agency",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyUsers_UserId",
                table: "AgencyUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyUsers",
                table: "AgencyUsers",
                columns: new[] { "AgencyId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Case_AnalystId",
                table: "Case",
                column: "AnalystId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_CustomerId",
                table: "Case",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_RbtId",
                table: "Case",
                column: "RbtId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_StatusId",
                table: "Case",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInfo_AddressId",
                table: "CustomerInfo",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_AgencyId",
                table: "Document",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_ApprovedBy",
                table: "Document",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocCategoryId",
                table: "Document",
                column: "DocCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocTypeId",
                table: "Document",
                column: "DocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_RejectedBy",
                table: "Document",
                column: "RejectedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Document_ReviewedBy",
                table: "Document",
                column: "ReviewedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Document_UserId",
                table: "Document",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocCategory",
                table: "DocumentCategory",
                column: "DocCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentType_AgencyId",
                table: "DocumentType",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentType_DocCategoryId",
                table: "DocumentType",
                column: "DocCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentType",
                table: "DocumentType",
                column: "DocTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_AddressId",
                table: "UserInfo",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgencyUsers");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "CustomerInfo");

            migrationBuilder.DropTable(
                name: "CaseStatus");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "DocumentCategory");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
