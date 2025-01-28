using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace C4WX1.Database.Migrations
{
    /// <inheritdoc />
    public partial class InititalSchemaSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AMTQuestion",
                columns: table => new
                {
                    AMTQuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ordering = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AMTQuestion", x => x.AMTQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "APIMonitor",
                columns: table => new
                {
                    MonitorID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UUID = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    APIName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitorID", x => x.MonitorID);
                });

            migrationBuilder.CreateTable(
                name: "APIOrder",
                columns: table => new
                {
                    APIOrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderID = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    ResourceType = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PatientID = table.Column<int>(type: "integer", nullable: true),
                    PatientNRIC = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    PatientFirstName = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    PatientLastName = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    OrderedByID = table.Column<int>(type: "integer", nullable: true),
                    OrderedByName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OrderedByInstitution = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OrderedByInstitutionID = table.Column<int>(type: "integer", nullable: true),
                    DoctorMCR = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AcceptedBy = table.Column<int>(type: "integer", nullable: true),
                    AcceptedByName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AcceptedInstitutionName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AcceptedInstitutionID = table.Column<int>(type: "integer", nullable: true),
                    Clinicalsynopsis = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIOrder", x => x.APIOrderId);
                });

            migrationBuilder.CreateTable(
                name: "APNSNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotificationMessage = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    NotificationTitle = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    UserID = table.Column<int>(type: "integer", nullable: true),
                    SentStatus = table.Column<bool>(type: "boolean", nullable: true),
                    IsCritical = table.Column<bool>(type: "boolean", nullable: true),
                    TaskID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APNSNotification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audit_Activity",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ActivityID = table.Column<int>(type: "integer", nullable: false),
                    ProblemListID_FK = table.Column<int>(type: "integer", nullable: false),
                    ActivityDetail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    DiseaseSubInfoID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_AMTQuestion",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AMTQuestionId = table.Column<int>(type: "integer", nullable: false),
                    Question = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ordering = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_APIAccessKey",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    APIAccessKeyID = table.Column<int>(type: "integer", nullable: false),
                    TokenCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AccessKey = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserId_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_APIMonitor",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MonitorID = table.Column<int>(type: "integer", nullable: true),
                    UUID = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    APIName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_APIOrder",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    APIOrderId = table.Column<int>(type: "integer", nullable: false),
                    OrderID = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    ResourceType = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PatientID = table.Column<int>(type: "integer", nullable: true),
                    PatientNRIC = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    PatientFirstName = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    PatientLastName = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    OrderedByID = table.Column<int>(type: "integer", nullable: true),
                    OrderedByName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OrderedByInstitution = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OrderedByInstitutionID = table.Column<int>(type: "integer", nullable: true),
                    DoctorMCR = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AcceptedBy = table.Column<int>(type: "integer", nullable: true),
                    AcceptedByName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AcceptedInstitutionName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AcceptedInstitutionID = table.Column<int>(type: "integer", nullable: true),
                    Clinicalsynopsis = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_APIOrderAllergy",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    APIOrderAllergyID = table.Column<int>(type: "integer", nullable: false),
                    APIOrderID_FK = table.Column<int>(type: "integer", nullable: false),
                    AllergyAgentID = table.Column<int>(type: "integer", nullable: true),
                    AllergyAgent = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AllergyReactionID = table.Column<int>(type: "integer", nullable: true),
                    AllergyReaction = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_APIOrderDiagnosis",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    APIOrderDiagnosisID = table.Column<int>(type: "integer", nullable: false),
                    APIOrderID_FK = table.Column<int>(type: "integer", nullable: false),
                    DiagnosisType = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DiagnosisDesc = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_APIOrderMedication",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    APIOrderMedicationID = table.Column<int>(type: "integer", nullable: false),
                    APIOrderID_FK = table.Column<int>(type: "integer", nullable: false),
                    MedicationID = table.Column<int>(type: "integer", nullable: true),
                    MedicationName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MedicationStatus = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    MedicationQuantity = table.Column<int>(type: "integer", nullable: true),
                    MedicationQuantityUnit = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    MedicationFrequencyID = table.Column<int>(type: "integer", nullable: true),
                    MedicationFrequency = table.Column<int>(type: "integer", nullable: true),
                    MedicationPeriod = table.Column<int>(type: "integer", nullable: true),
                    MedicationPeriodUnit = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    MedicationAsNeeded = table.Column<bool>(type: "boolean", nullable: true),
                    MedicationDisplay = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DosageID_FK = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_APIOrderTask",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    APIOrderTaskID = table.Column<int>(type: "integer", nullable: false),
                    APIOrderID_FK = table.Column<int>(type: "integer", nullable: false),
                    TaskID = table.Column<int>(type: "integer", nullable: true),
                    TaskName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TaskTypeID = table.Column<int>(type: "integer", nullable: true),
                    TaskStartDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TaskEndDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TaskFrequencyID = table.Column<int>(type: "integer", nullable: true),
                    TaskFrequency = table.Column<int>(type: "integer", nullable: true),
                    TaskPeriod = table.Column<int>(type: "integer", nullable: true),
                    TaskPeriodUnit = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    TaskDisplay = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Remark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_APNSNotification",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    NotificationMessage = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    NotificationTitle = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    UserID = table.Column<int>(type: "integer", nullable: true),
                    SentStatus = table.Column<bool>(type: "boolean", nullable: true),
                    IsCritical = table.Column<bool>(type: "boolean", nullable: true),
                    TaskID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_BillingInvoice",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BillingInvoiceID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    InvoiceDueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CaseNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: true),
                    Consumable = table.Column<bool>(type: "boolean", nullable: true),
                    SendEmail = table.Column<bool>(type: "boolean", nullable: true),
                    EmailPatient = table.Column<bool>(type: "boolean", nullable: true),
                    EmailTo = table.Column<string>(type: "text", nullable: true),
                    EmailCC = table.Column<string>(type: "text", nullable: true),
                    EmailBCC = table.Column<string>(type: "text", nullable: true),
                    CurrencyID_FK = table.Column<int>(type: "integer", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    GroupNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Version = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_BillingInvoiceConsumable",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BillingInvoiceConsumableID = table.Column<int>(type: "integer", nullable: false),
                    BillingInvoiceID_FK = table.Column<int>(type: "integer", nullable: false),
                    ItemID_FK = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_BillingInvoiceService",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BillingInvoiceServiceID = table.Column<int>(type: "integer", nullable: false),
                    BillingInvoiceID_FK = table.Column<int>(type: "integer", nullable: false),
                    ProposalID_FK = table.Column<int>(type: "integer", nullable: true),
                    ServiceID_FK = table.Column<int>(type: "integer", nullable: false),
                    UnitCost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Session = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_BillingPackage",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ID = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Session = table.Column<int>(type: "integer", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Validity = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    BillingServiceID = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_BillingPackageInformation",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BillingPackageID = table.Column<int>(type: "integer", nullable: false),
                    BillingServiceID = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Session = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_BillingPackageRequest",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PackageRequestID = table.Column<int>(type: "integer", nullable: false),
                    PackageRequestNo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    PatientName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SendBillTo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Discount = table.Column<bool>(type: "boolean", nullable: false),
                    DiscountType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DiscountAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    BillingAddress1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingAddress2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingAddress3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingPostalCode = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    TotalPackageAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PackageList = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_BillingProposal",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BillingProposalID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    ProposalNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SendEmail = table.Column<bool>(type: "boolean", nullable: true),
                    EmailPatient = table.Column<bool>(type: "boolean", nullable: true),
                    EmailTo = table.Column<string>(type: "text", nullable: true),
                    EmailCC = table.Column<string>(type: "text", nullable: true),
                    EmailBCC = table.Column<string>(type: "text", nullable: true),
                    CurrencyID_FK = table.Column<int>(type: "integer", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    GroupNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Version = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ProposalType = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_BillingProposalService",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BillingProposalServiceID = table.Column<int>(type: "integer", nullable: false),
                    BillingProposalID_FK = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UnitCost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Duration1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Duration2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ServiceDescription = table.Column<string>(type: "text", nullable: true),
                    Visit = table.Column<int>(type: "integer", nullable: false),
                    Session = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    SessionUsed = table.Column<int>(type: "integer", nullable: false),
                    ServiceID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_BillingService",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ServiceID = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    CostPerSession = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Weekend = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Branch",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BranchID = table.Column<int>(type: "integer", nullable: false),
                    BranchName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Address1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Address2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Address3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Contact = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    IsSystemUsed = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CurrencyID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_C4WDeviceToken",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    C4WDeviceTokenId = table.Column<int>(type: "integer", nullable: false),
                    OldDeviceToken = table.Column<string>(type: "text", unicode: false, nullable: true),
                    NewDeviceToken = table.Column<string>(type: "text", unicode: false, nullable: true),
                    ClientEnvironment = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Device = table.Column<string>(type: "text", unicode: false, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CarePlan",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CarePlanID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    DiagnosisID_FK = table.Column<int>(type: "integer", nullable: true),
                    CarePlanStatusID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    CarePlanDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    CarePlanName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: true),
                    PersonInCharge = table.Column<int>(type: "integer", nullable: true),
                    CarePlanType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Remark = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CarePlanDetail",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CarePlanDetailID = table.Column<int>(type: "integer", nullable: false),
                    CarePlanSubID_FK = table.Column<int>(type: "integer", nullable: false),
                    SystemID_FK = table.Column<int>(type: "integer", nullable: false),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    DiseaseSubInfoID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CarePlanStatus",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CarePlanStatusID = table.Column<int>(type: "integer", nullable: false),
                    CarePlanStatus = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CareReviewFrequency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CarePlanSub",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CarePlanSubID = table.Column<int>(type: "integer", nullable: false),
                    CarePlanID_FK = table.Column<int>(type: "integer", nullable: false),
                    SubCarePlanName = table.Column<int>(type: "integer", nullable: false),
                    Goal = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PersonInCharge = table.Column<int>(type: "integer", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    GroupCode = table.Column<int>(type: "integer", nullable: true),
                    CarePlanGroupName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: true),
                    InterventionStatus = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    GoalStatus = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CarePlanSubActivity",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CarePlanSubID_FK = table.Column<int>(type: "integer", nullable: false),
                    ActivityID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CarePlanSubCPGoals",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CarePlanSubID_FK = table.Column<int>(type: "integer", nullable: false),
                    CPGoalsID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CarePlanSubGoal",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CarePlanSubGoalID = table.Column<int>(type: "integer", nullable: false),
                    CarePlanSubID_FK = table.Column<int>(type: "integer", nullable: false),
                    ScoreTypeID = table.Column<int>(type: "integer", nullable: true),
                    OperatorID = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Score2 = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    CarePlanSubGoalName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CarePlanSubIntervention",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CarePlanSubID_FK = table.Column<int>(type: "integer", nullable: false),
                    InterventionID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CarePlanSubProblemList",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CarePlanSubProblemListID = table.Column<int>(type: "integer", nullable: false),
                    CarePlanSubID_FK = table.Column<int>(type: "integer", nullable: false),
                    ProblemListID_FK = table.Column<int>(type: "integer", nullable: false),
                    PLReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PLStatus = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    PersonInChargeID_FK = table.Column<int>(type: "integer", nullable: true),
                    TypeOfGoal = table.Column<int>(type: "integer", nullable: true),
                    Goal = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CarePlanSubProblemListGoal",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CarePlanSubProblemListGoalID = table.Column<int>(type: "integer", nullable: false),
                    CarePlanSubProblemListID_FK = table.Column<int>(type: "integer", nullable: false),
                    Goal = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Action = table.Column<int>(type: "integer", nullable: true),
                    ScoreTypeID = table.Column<int>(type: "integer", nullable: true),
                    OperatorID = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Score2 = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    ProblemListGoalID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CareReport",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CareReportID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    CareReportType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Status = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    SectionStatus = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    Memo1 = table.Column<string>(type: "text", nullable: true),
                    Memo2 = table.Column<string>(type: "text", nullable: true),
                    Memo3 = table.Column<string>(type: "text", nullable: true),
                    Memo4 = table.Column<string>(type: "text", nullable: true),
                    Memo5 = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    CarePlanID_FK = table.Column<int>(type: "integer", nullable: true),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: true),
                    VisitStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VisitEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VisitedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    Subject = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    VitalSignID_FK = table.Column<int>(type: "integer", nullable: true),
                    Pain = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    PainScaleType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    PainLevel = table.Column<int>(type: "integer", nullable: true),
                    PainDescriptionID_FK = table.Column<int>(type: "integer", nullable: true),
                    SiteOfPain = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TypeOfPain = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    AggravatingFactor = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RelievingFactor = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Frequency = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    PainRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    NeuroOrMental = table.Column<int>(type: "integer", nullable: true),
                    Eyes = table.Column<int>(type: "integer", nullable: true),
                    VerbalResponse = table.Column<int>(type: "integer", nullable: true),
                    MotorResponse = table.Column<int>(type: "integer", nullable: true),
                    LeftEyeSize = table.Column<int>(type: "integer", nullable: true),
                    LeftEyeReaction = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    RightEyeSize = table.Column<int>(type: "integer", nullable: true),
                    RightEyeReaction = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    NeuroRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SectionRequired = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    PsychoEmotionalSpiritual = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PsychoRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AirwayBreathingID_FK = table.Column<int>(type: "integer", nullable: true),
                    CoughID_FK = table.Column<int>(type: "integer", nullable: true),
                    O2AidID_FK = table.Column<int>(type: "integer", nullable: true),
                    O2LitresPercent = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    O2Litres = table.Column<decimal>(type: "numeric(4,1)", nullable: true),
                    Sunction = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CoughAmount = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Color = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ColorOthers = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Consistency = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Nebuliser = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    AirwayBreathingRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CirculationID_FK = table.Column<int>(type: "integer", nullable: true),
                    LowerEyelidsID_FK = table.Column<int>(type: "integer", nullable: true),
                    LipsID_FK = table.Column<int>(type: "integer", nullable: true),
                    CapillaryRefillID_FK = table.Column<int>(type: "integer", nullable: true),
                    PeripheralPulsesRadialID_FK = table.Column<int>(type: "integer", nullable: true),
                    PeripheralPulsesPedalID_FK = table.Column<int>(type: "integer", nullable: true),
                    CirculationRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SleepRestID_FK = table.Column<int>(type: "integer", nullable: true),
                    DayNightReversal = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    SleepRestRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TemperatureID_FK = table.Column<int>(type: "integer", nullable: true),
                    TemperatureInterventions = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TemperatureRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    BowelCareID_FK = table.Column<int>(type: "integer", nullable: true),
                    NoOfBowelTimes = table.Column<int>(type: "integer", nullable: true),
                    BowelType = table.Column<int>(type: "integer", nullable: true),
                    HowManyDaysBNO = table.Column<int>(type: "integer", nullable: true),
                    BowelInterventions = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Stoma = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    StomaCreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    StomaSizeLength = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    StomaSizeBreath = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    StomaColour = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StomaAppearance = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StomaProtrusion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StomaPeristomalSkin = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StomaEffluent = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StomaAmountOfOutput = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StomaOstomyProductUsed = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    StomaReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    BowelRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    BladderCareID_FK = table.Column<int>(type: "integer", nullable: true),
                    BladderCareTimes = table.Column<int>(type: "integer", nullable: true),
                    BladderCareNPU = table.Column<int>(type: "integer", nullable: true),
                    DiapersID_FK = table.Column<int>(type: "integer", nullable: true),
                    TypeOfUrine = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    CharacteristicOfUrine = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Dysuria = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    BladderCareRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PersonalHygieneRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CareReportRehabilitationID_FK = table.Column<int>(type: "integer", nullable: true),
                    EnvironmentRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ACP = table.Column<bool>(type: "boolean", nullable: true),
                    ACP_DoneDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ACP_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    OtherTreatment = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    OtherTreatmentOther = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OtherTreatmentRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CareReportSystemInfoID_FK = table.Column<int>(type: "integer", nullable: true),
                    SectionRequireInput = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    PatientNutritionID_FK = table.Column<int>(type: "integer", nullable: true),
                    SkinAndWoundCare = table.Column<string>(type: "character varying(2000)", unicode: false, maxLength: 2000, nullable: true),
                    PersonalHygiene = table.Column<string>(type: "character varying(2000)", unicode: false, maxLength: 2000, nullable: true),
                    Environment = table.Column<string>(type: "character varying(2000)", unicode: false, maxLength: 2000, nullable: true),
                    BreathSounds = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BowelSounds = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    HeartSounds = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CareReportConfig",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CareReportConfigID = table.Column<int>(type: "integer", nullable: false),
                    UserTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    SectionAccess = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CareReportRehabilitation",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CareReportRehabilitationID = table.Column<int>(type: "integer", nullable: false),
                    IsADLAssistance = table.Column<bool>(type: "boolean", nullable: true),
                    ADLAssistanceType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Bounded = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    NoOfTimesTurned = table.Column<int>(type: "integer", nullable: true),
                    NoOfSatOutOfBed = table.Column<int>(type: "integer", nullable: true),
                    IsDVTPrevention = table.Column<bool>(type: "boolean", nullable: true),
                    DVTType = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    RequirePhysioTherapist = table.Column<bool>(type: "boolean", nullable: true),
                    VisitForPhysioTherapist = table.Column<int>(type: "integer", nullable: true),
                    RequireOccupationTherapist = table.Column<bool>(type: "boolean", nullable: true),
                    VisitForOccupationTherapist = table.Column<int>(type: "integer", nullable: true),
                    RequireSpeechTherapist = table.Column<bool>(type: "boolean", nullable: true),
                    VisitForSpeechTherapist = table.Column<int>(type: "integer", nullable: true),
                    RequireWalkingAid = table.Column<bool>(type: "boolean", nullable: true),
                    WalkingAidType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    IsUpperLimbStrengthLeft = table.Column<bool>(type: "boolean", nullable: true),
                    IsUpperLimbStrengthRight = table.Column<bool>(type: "boolean", nullable: true),
                    UpperLimbStrengthLeft = table.Column<int>(type: "integer", nullable: true),
                    UpperLimbStrengthRight = table.Column<int>(type: "integer", nullable: true),
                    IsLowerLimbStrengthLeft = table.Column<bool>(type: "boolean", nullable: true),
                    IsLowerLimbStrengthRight = table.Column<bool>(type: "boolean", nullable: true),
                    LowerLimbStrengthLeft = table.Column<int>(type: "integer", nullable: true),
                    LowerLimbStrengthRight = table.Column<int>(type: "integer", nullable: true),
                    RehabilitationRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CareReportSocialSupport",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CareReportSocialSupportID = table.Column<int>(type: "integer", nullable: false),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: false),
                    PatientSocialSupportID_FK = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CareReportSystemInfo",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CareReportSystemInfoID = table.Column<int>(type: "integer", nullable: false),
                    IsUpdatePrimaryDoctor = table.Column<bool>(type: "boolean", nullable: true),
                    PrimaryDoctorUserID_FK = table.Column<int>(type: "integer", nullable: true),
                    PrimaryDoctorName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsUpdateSecondaryDoctor = table.Column<bool>(type: "boolean", nullable: true),
                    SecondaryDoctorUserID_FK = table.Column<int>(type: "integer", nullable: true),
                    SecondaryDoctorName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsUpdateKeyPerson1 = table.Column<bool>(type: "boolean", nullable: true),
                    KeyPerson1UserID_FK = table.Column<int>(type: "integer", nullable: true),
                    IsUpdateKeyPerson2 = table.Column<bool>(type: "boolean", nullable: true),
                    KeyPerson2UserID_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsUpdateFamily = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Chat",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ChatID = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Attachment = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Attachment_Physical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    ParentID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Family = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Code",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CodeId = table.Column<int>(type: "integer", nullable: false),
                    CodeTypeId_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ordering = table.Column<int>(type: "integer", nullable: true),
                    IsSystemUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    Indication_Acute = table.Column<bool>(type: "boolean", nullable: true),
                    Indication_PRN = table.Column<bool>(type: "boolean", nullable: true),
                    Referral_Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    AllergyReaction_Drug = table.Column<bool>(type: "boolean", nullable: true),
                    AllergyReaction_Others = table.Column<bool>(type: "boolean", nullable: true),
                    MedicationGroupID_FK = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    CurrencyCodeA = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    CurrencyCodeN = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    CurrencyInvoiceFooter = table.Column<string>(type: "text", nullable: true),
                    Critical = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CodeType",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CodeTypeId = table.Column<int>(type: "integer", nullable: false),
                    CodeTypeName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsSystemUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_CPGoals",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CPGoalsID = table.Column<int>(type: "integer", nullable: false),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    CPGoalsInfo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Diagnosis",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DiagnosisID = table.Column<int>(type: "integer", nullable: false),
                    Diagnosis = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_DischargeSummaryReport",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DischargeSummaryReportId = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VisitDateStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VisitDateEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VisitedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    SummaryCaseNote = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_DischargeSummaryReportAttachment",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DischargeSummaryReportAttachmentID = table.Column<int>(type: "integer", nullable: false),
                    DischargeSummaryReportID_FK = table.Column<int>(type: "integer", nullable: false),
                    Filename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Physical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Disease",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DiseaseID = table.Column<int>(type: "integer", nullable: false),
                    DiseaseName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SystemID_FK = table.Column<int>(type: "integer", nullable: false),
                    IsAdditionalInfo = table.Column<bool>(type: "boolean", nullable: false),
                    IsSuggestPalliativeCare = table.Column<bool>(type: "boolean", nullable: false),
                    IsSystemUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true),
                    DiseaseCode = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_DiseaseInfo",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DiseaseInfoID = table.Column<int>(type: "integer", nullable: false),
                    DiseaseInfo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_DiseaseSubInfo",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DiseaseSubInfoID = table.Column<int>(type: "integer", nullable: false),
                    DiseaseSubInfo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_DiseaseVitalSignType",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DiseaseVitalSignTypeID = table.Column<int>(type: "integer", nullable: false),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    VitalSignTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_EBASDEPQuestion",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EBASDEPQuestionId = table.Column<int>(type: "integer", nullable: false),
                    Question = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ordering = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Enquiry",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EnquiryID = table.Column<int>(type: "integer", nullable: false),
                    CareManagerAssignedID_FK = table.Column<int>(type: "integer", nullable: true),
                    EnquirySourceID_FK = table.Column<int>(type: "integer", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RaceID_FK = table.Column<int>(type: "integer", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PreferredLanguageID_FK = table.Column<int>(type: "integer", nullable: true),
                    GenderID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientAddress1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PatientAddress2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PatientAddress3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    NameOfCaller = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ContactNumberOfCaller = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EmailOfCaller = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PreferredAppointmentDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    MedicalHistory = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CaregiverAtHomeID_FK = table.Column<int>(type: "integer", nullable: true),
                    ServicesRequiredID_FK = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    OtherRace = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OtherPreferredLanguage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UserOrganizationID_FK = table.Column<int>(type: "integer", nullable: true),
                    CaseNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OrderID = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_EnquiryAttachment",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EnquiryAttachmentID = table.Column<int>(type: "integer", nullable: false),
                    EnquiryID_FK = table.Column<int>(type: "integer", nullable: false),
                    Filename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Physical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_EnquiryConfig",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EnquiryConfigID = table.Column<int>(type: "integer", nullable: false),
                    SCMID_FK = table.Column<int>(type: "integer", nullable: true),
                    EmailContent = table.Column<string>(type: "text", nullable: true),
                    EscalatingPersonID_FK = table.Column<int>(type: "integer", nullable: true),
                    EscalationPeriod = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    EscalationEmail = table.Column<string>(type: "text", nullable: true),
                    EmailtoCMContent = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_EnquiryEscPerson",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EnquiryConfigID = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_EnquiryLanguage",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EnquiryID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_EnquirySCM",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EnquiryConfigID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_EnquiryServicesRequired",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EnquiryID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Event",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EventID = table.Column<int>(type: "integer", nullable: false),
                    EventName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EventTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    PeriodTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    FromDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ToDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserCategory_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_EventUser",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EventUserID = table.Column<int>(type: "integer", nullable: false),
                    EventID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_EventUserLog",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EventUserLogID = table.Column<int>(type: "integer", nullable: false),
                    EventID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_ExternalDoctor",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExternalDoctorID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ClinicianTypeID_FK = table.Column<int>(type: "integer", nullable: true),
                    Contact = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    AccessHospitalID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_GeoFencing",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    GeoFencingId = table.Column<int>(type: "integer", nullable: false),
                    IP = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsWhitelisted = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Group",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    GroupName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_GroupRole",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    GroupId_FK = table.Column<int>(type: "integer", nullable: false),
                    RoleId_FK = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_ICAWoundCare",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_InitialCareAssessment",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InitialCareAssessmentID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    GeneralCondition = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Physique = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ConsciousLevel = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    EmotionalState = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    OtherEmotionalState = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Breathing = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    OtherBreathing = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    O2Litres = table.Column<decimal>(type: "numeric(3,1)", nullable: true),
                    O2LitresVia = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    TracheostomyDateInserted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TracheostomySize = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    TracheostomyType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsTracheostomyInnerCannula = table.Column<bool>(type: "boolean", nullable: true),
                    TracheostomyNextReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Cough = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Vision = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    VisionImpairedLeft = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedRight = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    VisionImpairedGlaucoma = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedCataract = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedGlaucomaLeft = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedGlaucomaRight = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedGlaucomaRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    VisionImpairedCataractLeft = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedCataractRight = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedCataractRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Hearing = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    HearingImpairedLeft = table.Column<bool>(type: "boolean", nullable: true),
                    HearingImpairedRight = table.Column<bool>(type: "boolean", nullable: true),
                    HearingImpairedRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    HearingImpairedWithHearingAidLeft = table.Column<bool>(type: "boolean", nullable: true),
                    HearingImpairedWithHearingAidRight = table.Column<bool>(type: "boolean", nullable: true),
                    HearingImpairedWithHearingAidRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    BowelHabitsTimes = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    BowelHabitsDays = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    BowelType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Stoma = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    StomaCreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    StomaSizeLength = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    StomaSizeBreath = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    StomaColour = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StomaAppearance = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StomaProtrusion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StomaPeristomalSkin = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StomaEffluent = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StomaAmountOfOutput = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StomaOstomyProductUsed = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    StomaReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UrinaryFrequencyTimes = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    UrinaryFrequencyDay = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    UrinaryTypes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Catheter = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CatheterDateInserted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CatheterType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CatheterSize = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CatheterNextReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LMP = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UseOfDrug = table.Column<bool>(type: "boolean", nullable: true),
                    UseOfDrugExplain = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    MedicalHistory = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    OralCavityAssessmentScore1 = table.Column<int>(type: "integer", nullable: true),
                    OralCavityAssessmentScore2 = table.Column<int>(type: "integer", nullable: true),
                    OralCavityAssessmentScore3 = table.Column<int>(type: "integer", nullable: true),
                    OralCavityAssessmentScore4 = table.Column<int>(type: "integer", nullable: true),
                    OralCavityAssessmentScore5 = table.Column<int>(type: "integer", nullable: true),
                    OralCavityAssessmentScore6 = table.Column<int>(type: "integer", nullable: true),
                    MilkFeedRx = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    EmotionalYesNo = table.Column<bool>(type: "boolean", nullable: true),
                    EmotionalYes = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    HowCanIHelp = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LostInterest = table.Column<bool>(type: "boolean", nullable: true),
                    LostInterestYes = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    HowDoYouScope = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DifficultyCoping = table.Column<bool>(type: "boolean", nullable: true),
                    DifficultyCopingYes = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Depressed = table.Column<bool>(type: "boolean", nullable: true),
                    GetSupport = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ReferCounsellor = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    PatientProfileID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientReferralID_FK = table.Column<int>(type: "integer", nullable: true),
                    SectionStatus = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    PatientAdditionalInfoID_FK = table.Column<int>(type: "integer", nullable: true),
                    VitalSignID_FK = table.Column<int>(type: "integer", nullable: true),
                    WoundAssessmentScore1 = table.Column<int>(type: "integer", nullable: true),
                    WoundAssessmentScore2 = table.Column<int>(type: "integer", nullable: true),
                    WoundAssessmentScore3 = table.Column<int>(type: "integer", nullable: true),
                    WoundAssessmentScore4 = table.Column<int>(type: "integer", nullable: true),
                    WoundAssessmentScore5 = table.Column<int>(type: "integer", nullable: true),
                    WoundAssessmentScore6 = table.Column<int>(type: "integer", nullable: true),
                    PatientMedicationID_FK = table.Column<int>(type: "integer", nullable: true),
                    HomeFacilityVentilation = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityCooking = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityRefrigeration = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityToileting = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityStairs = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityCommunication = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityAffectCaregiver = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityAffectCareManager = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsRequirePalliativeCare = table.Column<bool>(type: "boolean", nullable: true),
                    PainLevel = table.Column<int>(type: "integer", nullable: true),
                    TirednessLevel = table.Column<int>(type: "integer", nullable: true),
                    DrowsinessLevel = table.Column<int>(type: "integer", nullable: true),
                    NauseaLevel = table.Column<int>(type: "integer", nullable: true),
                    LackOfAppetiteLevel = table.Column<int>(type: "integer", nullable: true),
                    ShortnessOfBreath = table.Column<int>(type: "integer", nullable: true),
                    DepressionLevel = table.Column<int>(type: "integer", nullable: true),
                    AnxietyLevel = table.Column<int>(type: "integer", nullable: true),
                    BestWellbeing = table.Column<int>(type: "integer", nullable: true),
                    Faith = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsReligious = table.Column<bool>(type: "boolean", nullable: true),
                    GiveMeaningToLife = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MakeSense = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsBeliefImportant = table.Column<bool>(type: "boolean", nullable: true),
                    InfluenceTakeCare = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BeliefInfluenced = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RoleOfBeliefForInfluence = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsPartOfCommunity = table.Column<bool>(type: "boolean", nullable: true),
                    SupportTo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RoleOfBeliefForCommunity = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PersonalConcern = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AddressIssue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Concern = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TalkToSomeone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OralCavityAssessmentScore7 = table.Column<int>(type: "integer", nullable: true),
                    OralCavityAssessmentScore8 = table.Column<int>(type: "integer", nullable: true),
                    PatientNutritionID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientRAFID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientMBIID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientMFSID_FK = table.Column<int>(type: "integer", nullable: true),
                    VisitDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VSOnSetDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    painOnSetDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VSQuality = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    VSPainFrequency = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    VSIntermittent = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    VSLocation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    VSPrecipitatingFactors = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    VSRelievingFactors = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    VSPainFrequencyIntermittentNumber = table.Column<int>(type: "integer", nullable: true),
                    CAAlertness = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CACommunication = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CADementia = table.Column<bool>(type: "boolean", nullable: true),
                    CAdateAndTime = table.Column<bool>(type: "boolean", nullable: true),
                    CAPerson = table.Column<bool>(type: "boolean", nullable: true),
                    CAPlace = table.Column<bool>(type: "boolean", nullable: true),
                    CASituation = table.Column<bool>(type: "boolean", nullable: true),
                    HearingAid = table.Column<bool>(type: "boolean", nullable: true),
                    ChestSymmetry = table.Column<bool>(type: "boolean", nullable: true),
                    AbdomenSymmetry = table.Column<bool>(type: "boolean", nullable: true),
                    AnySkinIssue = table.Column<bool>(type: "boolean", nullable: true),
                    PressureInjuries = table.Column<bool>(type: "boolean", nullable: true),
                    ApicalPulse = table.Column<int>(type: "integer", nullable: true),
                    SkinType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SkinIssue = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SkinTurgor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BreathSounds = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BowelSounds = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Percussion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Palpation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TenderNGuarding = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Remark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LeftUpperLimbStrength = table.Column<int>(type: "integer", nullable: true),
                    RightUpperLimbStrength = table.Column<int>(type: "integer", nullable: true),
                    LeftLowerLimbStrength = table.Column<int>(type: "integer", nullable: true),
                    RightLowerLimbStrength = table.Column<int>(type: "integer", nullable: true),
                    MobilityStatus = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AssistiveAids = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Incontinence = table.Column<bool>(type: "boolean", nullable: true),
                    IncontinenceType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UrineConsistency = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UrineColour = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StoolsType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    VisionSpectacles = table.Column<bool>(type: "boolean", nullable: true),
                    OxygenRequired = table.Column<bool>(type: "boolean", nullable: true),
                    Sputum = table.Column<bool>(type: "boolean", nullable: true),
                    SuctioningRequired = table.Column<bool>(type: "boolean", nullable: true),
                    OxygenLMin = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    OxygenType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    OxygenRemark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Oralhealth = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Teeth = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AblePassUrine = table.Column<bool>(type: "boolean", nullable: true),
                    NutritionalImbalance = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_InitialCareAssessmentAttachment",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InitialCareAssessmentAttachmentID = table.Column<int>(type: "integer", nullable: false),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: false),
                    Filename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Physical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsReferralAssessment = table.Column<bool>(type: "boolean", nullable: false),
                    IsDischargeAssessment = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_InitialCareAssessmentSpecialInstruction",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InitialCareAssessmentSpecialInstructionID = table.Column<int>(type: "integer", nullable: false),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Instructions = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_InitialCareAssessmentVitalSign",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: false),
                    VitalSignID_FK = table.Column<int>(type: "integer", nullable: false),
                    TimeOfRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Intervention",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InterventionID = table.Column<int>(type: "integer", nullable: false),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    InterventionInfo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Item",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ItemID = table.Column<int>(type: "integer", nullable: false),
                    ItemName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    ItemUnitID_FK = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    AvailableInBilling = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_ItemStock",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ItemStockID = table.Column<int>(type: "integer", nullable: false),
                    ItemID_FK = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_LoginDevice",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LoginDeviceId = table.Column<int>(type: "integer", nullable: false),
                    UserId_FK = table.Column<int>(type: "integer", nullable: false),
                    DeviceType = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    DeviceID = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_MailSettings",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    msgBCC = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    msgCC = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    msgTo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    msgSubj = table.Column<string>(type: "text", nullable: true),
                    msgBody = table.Column<string>(type: "text", nullable: true),
                    displayMsgTo = table.Column<bool>(type: "boolean", nullable: true),
                    displayMsgCC = table.Column<bool>(type: "boolean", nullable: true),
                    displayMsgBCC = table.Column<bool>(type: "boolean", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_MedicationVitalSignType",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MedicationVitalSignTypeID = table.Column<int>(type: "integer", nullable: false),
                    MedicationID_FK = table.Column<int>(type: "integer", nullable: false),
                    VitalSignTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_MobileAppVersioning",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MobileVersionId = table.Column<int>(type: "integer", nullable: false),
                    AppName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeviceType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Version = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_MultiDisciplinaryMeeting",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MultiDisciplinaryMeetingID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    IssuesOverall = table.Column<string>(type: "text", nullable: false),
                    AssignedToFollowUp = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_MultiDisciplinaryMeetingDetail",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MultiDisciplinaryMeetingDetailID = table.Column<int>(type: "integer", nullable: false),
                    MultiDisciplinaryMeetingID_FK = table.Column<int>(type: "integer", nullable: false),
                    IssueCatID = table.Column<int>(type: "integer", nullable: false),
                    IssueTitle = table.Column<string>(type: "text", nullable: false),
                    IssueContent = table.Column<string>(type: "text", nullable: false),
                    ActionPlan = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_NotificationChat",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NotificationChatID = table.Column<int>(type: "integer", nullable: false),
                    NotificationId_FK = table.Column<int>(type: "integer", nullable: false),
                    ChatID_FK = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_NotificationEvent",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NotificationEventID = table.Column<int>(type: "integer", nullable: false),
                    NotificationId_FK = table.Column<int>(type: "integer", nullable: false),
                    EventID_FK = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_NotificationMessageTemplates",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    notificationgroupCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    notificationSubject = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    notificationMessage = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Notifications",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    notificationTypeCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    isRead = table.Column<bool>(type: "boolean", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FacilityID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_NotificationTask",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NotificationTaskID = table.Column<int>(type: "integer", nullable: true),
                    NotificationId_FK = table.Column<int>(type: "integer", nullable: false),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_NotificationVitalSignDetails",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    notificationId = table.Column<int>(type: "integer", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VitalSignDetailId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_NutritionTask",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NutritionTaskID = table.Column<int>(type: "integer", nullable: false),
                    ActionTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    Food = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Liquid = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Method = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BeforeImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    AfterImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TypeReferenceID_FK = table.Column<int>(type: "integer", nullable: true),
                    AmountReferenceID_FK = table.Column<int>(type: "integer", nullable: true),
                    ColorReferenceID_FK = table.Column<int>(type: "integer", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    GivenAmount = table.Column<int>(type: "integer", nullable: true),
                    TakenAmount = table.Column<int>(type: "integer", nullable: true),
                    Unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_NutritionTaskReference",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReferenceID = table.Column<int>(type: "integer", nullable: false),
                    CodeId_FK = table.Column<int>(type: "integer", nullable: false),
                    ReferenceImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Otp",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OtpId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Package",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PackageID = table.Column<int>(type: "integer", nullable: false),
                    PackageName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PackageDetails = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Patient",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientID = table.Column<int>(type: "integer", nullable: false),
                    Firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NRIC = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Photo = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CareManagerAssignedID = table.Column<int>(type: "integer", nullable: true),
                    CaseID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DrugAllergy = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    DischargeNoticePeriodInMonths = table.Column<int>(type: "integer", nullable: true),
                    AdmittedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ReasonOfAdmission = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AMD = table.Column<bool>(type: "boolean", nullable: true),
                    ACP = table.Column<bool>(type: "boolean", nullable: true),
                    PACEMAKER = table.Column<bool>(type: "boolean", nullable: true),
                    ACID = table.Column<bool>(type: "boolean", nullable: true),
                    MobilePhone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    HomePhone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    GenogramPicture = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    ReferringDiagnosis = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    MailForVitalAlert1 = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    MailForVitalAlert2 = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    MailForVitalAlert3 = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    MailForFamilyNotification1 = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    MailForFamilyNotification2 = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    VisitingFrequency = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    NumberOfChildren = table.Column<int>(type: "integer", nullable: true),
                    Occupation = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: true),
                    UpfrontPayment = table.Column<bool>(type: "boolean", nullable: true),
                    CareReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientTypeID_FK = table.Column<int>(type: "integer", nullable: true),
                    MailingAddress1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MailingAddress2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MailingAddress3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    GenderID_FK = table.Column<int>(type: "integer", nullable: true),
                    BloodTypeID_FK = table.Column<int>(type: "integer", nullable: true),
                    ResidentTypeID_FK = table.Column<int>(type: "integer", nullable: true),
                    MaritalStatusID_FK = table.Column<int>(type: "integer", nullable: true),
                    ReligionID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientProfileID_FK = table.Column<int>(type: "integer", nullable: true),
                    RaceID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientAdditionalInfoID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientReferralID_FK = table.Column<int>(type: "integer", nullable: true),
                    MedicalHistoryRemarks = table.Column<string>(type: "text", nullable: true),
                    PatientMedicationID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientReferralByID_FK = table.Column<int>(type: "integer", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IdentificationAttachmentFilename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IdentificationAttachmentPhysical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    OtherRace = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OtherLanguage = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PaymentMode = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true),
                    InvoiceModeID_FK = table.Column<int>(type: "integer", nullable: true),
                    DisplayName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OrderID = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    Accepted = table.Column<bool>(type: "boolean", nullable: true),
                    NursingStation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AccessHospitalID_FK = table.Column<int>(type: "integer", nullable: true),
                    ActionDescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IntegrationSourceID = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientAccessLine",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientAccessLineID = table.Column<int>(type: "integer", nullable: false),
                    AccessLine = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: false),
                    DateOfInsertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Patent = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    PatentReSited = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    PatentReSitedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PatentSite = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    DateDueForChange = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AccessLineRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientAdditionalInfo",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientAdditionalInfoID = table.Column<int>(type: "integer", nullable: false),
                    AICD = table.Column<bool>(type: "boolean", nullable: true),
                    AICD_InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AICD_InsertedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AICD_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ACP = table.Column<bool>(type: "boolean", nullable: true),
                    ACP_DoneDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ACP_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DNR = table.Column<bool>(type: "boolean", nullable: true),
                    Pacemaker = table.Column<bool>(type: "boolean", nullable: true),
                    Pacemaker_InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Pacemaker_InsertedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Pacemaker_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    DNR_DateInitiated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DNR_InitiatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DNR_DateTerminated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DNR_TerminatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CVCLine = table.Column<bool>(type: "boolean", nullable: true),
                    CVCLine_InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CVCLine_InsertedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CVCLine_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PICCLine = table.Column<bool>(type: "boolean", nullable: true),
                    PICCLine_InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PICCLine_InsertedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PICCLine_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IVLine = table.Column<bool>(type: "boolean", nullable: true),
                    IVLine_InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IVLine_InsertedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IVLine_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientAMT",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientAMTID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    Alertness = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: true),
                    VitalSignDetailId_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientAMTAnswer",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientAMTID_FK = table.Column<int>(type: "integer", nullable: false),
                    AMTQuestionID_FK = table.Column<int>(type: "integer", nullable: false),
                    Answer = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientAttachment",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientAttachmentID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    Filename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Physical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    FileTypeID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientBradenScale",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientBradenScaleID = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    VitalSignDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<int>(type: "integer", nullable: true),
                    Score2 = table.Column<int>(type: "integer", nullable: true),
                    Score3 = table.Column<int>(type: "integer", nullable: true),
                    Score4 = table.Column<int>(type: "integer", nullable: true),
                    Score5 = table.Column<int>(type: "integer", nullable: true),
                    Score6 = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientClinician",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientClinicianID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    UserID_FK = table.Column<int>(type: "integer", nullable: true),
                    ExternalDoctorID_FK = table.Column<int>(type: "integer", nullable: true),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: true),
                    DiseaseSubInfoID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientDrugAllergy",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DrugAllergyID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ReactionID_FK = table.Column<int>(type: "integer", nullable: true),
                    MedicationID_FK = table.Column<int>(type: "integer", nullable: true),
                    ReferID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientEBASDEP",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientEBASDEPID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    Alertness = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: true),
                    VitalSignDetailId_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientEBASDEPAnswer",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientEBASDEPID_FK = table.Column<int>(type: "integer", nullable: false),
                    EBASDEPQuestionID_FK = table.Column<int>(type: "integer", nullable: false),
                    Answer = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientFamilyHistory",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientFamilyHistoryID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    DiseaseSubInfoID_FK = table.Column<int>(type: "integer", nullable: true),
                    YearDiagnose = table.Column<int>(type: "integer", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Relationship = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientGCS",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientGCSID = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    VitalSignDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<int>(type: "integer", nullable: true),
                    Score2 = table.Column<int>(type: "integer", nullable: true),
                    Score3 = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientImmunisation",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ImmunisationID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Place = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    NextDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientLanguage",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientMBI",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientMBIID = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    VitalSignDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<int>(type: "integer", nullable: true),
                    Score2 = table.Column<int>(type: "integer", nullable: true),
                    Score3 = table.Column<int>(type: "integer", nullable: true),
                    Score4 = table.Column<int>(type: "integer", nullable: true),
                    Score5 = table.Column<int>(type: "integer", nullable: true),
                    Score6 = table.Column<int>(type: "integer", nullable: true),
                    Score7 = table.Column<int>(type: "integer", nullable: true),
                    Score8 = table.Column<int>(type: "integer", nullable: true),
                    Score9 = table.Column<int>(type: "integer", nullable: true),
                    Score10 = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientMedicalHistory",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientMedicalHistoryID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    ClinicianID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MedicalStatusID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientMedication",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientMedicationID = table.Column<int>(type: "integer", nullable: false),
                    Allergies = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    SelfAdminister = table.Column<bool>(type: "boolean", nullable: true),
                    Compliant = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientMedicationConsume",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientMedicationConsumeID = table.Column<int>(type: "integer", nullable: false),
                    PatientMedicationID_FK = table.Column<int>(type: "integer", nullable: false),
                    MedicationID_FK = table.Column<int>(type: "integer", nullable: true),
                    RouteID_FK = table.Column<int>(type: "integer", nullable: true),
                    DosageID_FK = table.Column<int>(type: "integer", nullable: true),
                    FrequencyID_FK = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Indication = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ReasonOfDiscontinue = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ChronicDiseaseID_FK = table.Column<int>(type: "integer", nullable: true),
                    ChronicDiseaseSubInfoID_FK = table.Column<int>(type: "integer", nullable: true),
                    AcutePRNIndicationID_FK = table.Column<int>(type: "integer", nullable: true),
                    ReferID_FK = table.Column<int>(type: "integer", nullable: true),
                    InstructedByID_FK = table.Column<int>(type: "integer", nullable: true),
                    DrName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DrContact = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MCRNo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ClinicHosp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    InstructedBy2ID_FK = table.Column<int>(type: "integer", nullable: true),
                    DrNameED = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DrContactED = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MCRNoED = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ClinicHospED = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientMedicationConsumeAttachment",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientMedicationConsumeAttachmentID = table.Column<int>(type: "integer", nullable: false),
                    PatientMedicationConsumeID_FK = table.Column<int>(type: "integer", nullable: false),
                    Filename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Physical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsEndDate = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientMedicationSupply",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientMedicationID_FK = table.Column<int>(type: "integer", nullable: false),
                    SupplyID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientMFS",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientMFSID = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    VitalSignDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<int>(type: "integer", nullable: true),
                    Score2 = table.Column<int>(type: "integer", nullable: true),
                    Score3 = table.Column<int>(type: "integer", nullable: true),
                    Score4 = table.Column<int>(type: "integer", nullable: true),
                    Score5 = table.Column<int>(type: "integer", nullable: true),
                    Score6 = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientMMSE",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientMMSEID = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    VitalSignDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<int>(type: "integer", nullable: true),
                    Score2 = table.Column<int>(type: "integer", nullable: true),
                    Score3 = table.Column<int>(type: "integer", nullable: true),
                    Score4 = table.Column<int>(type: "integer", nullable: true),
                    Score5 = table.Column<int>(type: "integer", nullable: true),
                    Score6 = table.Column<int>(type: "integer", nullable: true),
                    Score7 = table.Column<int>(type: "integer", nullable: true),
                    Score8 = table.Column<int>(type: "integer", nullable: true),
                    Score9 = table.Column<int>(type: "integer", nullable: true),
                    Score10 = table.Column<int>(type: "integer", nullable: true),
                    Score11 = table.Column<int>(type: "integer", nullable: true),
                    Score12 = table.Column<int>(type: "integer", nullable: true),
                    Score13 = table.Column<int>(type: "integer", nullable: true),
                    Score14 = table.Column<int>(type: "integer", nullable: true),
                    Score15 = table.Column<int>(type: "integer", nullable: true),
                    Score16 = table.Column<int>(type: "integer", nullable: true),
                    Score17 = table.Column<int>(type: "integer", nullable: true),
                    Score18 = table.Column<int>(type: "integer", nullable: true),
                    Score19 = table.Column<int>(type: "integer", nullable: true),
                    Score20 = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientNutrition",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientNutritionID = table.Column<int>(type: "integer", nullable: false),
                    EatingAndSwallowing = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EatingAndSwallowingTypeOfTubeFeeding = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EatingAndSwallowingTypeOfTube = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EatingAndSwallowingSize = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EatingAndSwallowingDateInserted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EatingAndSwallowingDateDue = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Diet = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Appetite = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    FluidConsistency = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    FluidRestrictionMLSPerDay = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    ReviewedBySpeechTherapist = table.Column<bool>(type: "boolean", nullable: true),
                    ReferralToSpeechTherapist = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    Enteralfeeding = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    SizeofPEGJtube = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IVtherapyStateType = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    SwallowingIssues = table.Column<bool>(type: "boolean", nullable: true),
                    DiagnosedDysphasia = table.Column<bool>(type: "boolean", nullable: true),
                    IsFIsluidRestriction = table.Column<bool>(type: "boolean", nullable: true),
                    IVtherapy = table.Column<bool>(type: "boolean", nullable: true),
                    IVtherapyMLSPerDay = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    MilkFeedAmt = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    WaterPerDay = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    DiagnosedDysphasiaLastReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientOtherAllergy",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    OtherAllergyID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    ReactionID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DescriptionID_FK = table.Column<int>(type: "integer", nullable: true),
                    OtherDescription = table.Column<string>(type: "text", nullable: true),
                    ReferID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientPackage",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    PackageID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientProfile",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientProfileID = table.Column<int>(type: "integer", nullable: false),
                    BloodTypeID_FK = table.Column<int>(type: "integer", nullable: true),
                    ReligionID_FK = table.Column<int>(type: "integer", nullable: true),
                    MobilePhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    HomePhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingAddress1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingAddress2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingAddress3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingPostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    OtherReligion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Organization = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Ward = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Bed = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PatientOrganizationID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientRAF",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientRAFID = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    VitalSignDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<int>(type: "integer", nullable: true),
                    Score2 = table.Column<int>(type: "integer", nullable: true),
                    Score3 = table.Column<int>(type: "integer", nullable: true),
                    Score4 = table.Column<int>(type: "integer", nullable: true),
                    Score5a = table.Column<int>(type: "integer", nullable: true),
                    Score5b = table.Column<int>(type: "integer", nullable: true),
                    Score5c = table.Column<int>(type: "integer", nullable: true),
                    Score5d = table.Column<int>(type: "integer", nullable: true),
                    Score6 = table.Column<int>(type: "integer", nullable: true),
                    Score7 = table.Column<int>(type: "integer", nullable: true),
                    Score8 = table.Column<int>(type: "integer", nullable: true),
                    Score9 = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientReferral",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientReferralID = table.Column<int>(type: "integer", nullable: false),
                    PrimaryClinicianID_FK = table.Column<int>(type: "integer", nullable: true),
                    SecondaryClinicianID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientAwareDiagnose = table.Column<bool>(type: "boolean", nullable: true),
                    FamilyAwareDiagnose = table.Column<bool>(type: "boolean", nullable: true),
                    PatientAwarePrognosis = table.Column<bool>(type: "boolean", nullable: true),
                    FamilyAwarePrognosis = table.Column<bool>(type: "boolean", nullable: true),
                    PatientAwareDiagnoseReason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    FamilyAwareDiagnoseReason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PatientAwarePrognosisReason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    FamilyAwarePrognosisReason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    PrimaryNurseID_FK = table.Column<int>(type: "integer", nullable: true),
                    SecondaryNurseID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientReferralService",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientReferralID_FK = table.Column<int>(type: "integer", nullable: false),
                    ServiceID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientSocialSupport",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientSocialSupportID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    Firstname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Lastname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    GenderID_FK = table.Column<int>(type: "integer", nullable: true),
                    MaritalStatusID_FK = table.Column<int>(type: "integer", nullable: true),
                    RelationshipID_FK = table.Column<int>(type: "integer", nullable: true),
                    NationalityID_FK = table.Column<int>(type: "integer", nullable: true),
                    Contact = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    NotifyEmail = table.Column<bool>(type: "boolean", nullable: true),
                    NotifySMS = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    NotifyPhoneCall = table.Column<bool>(type: "boolean", nullable: true),
                    Spokeperson = table.Column<bool>(type: "boolean", nullable: true),
                    CanLogin = table.Column<bool>(type: "boolean", nullable: true),
                    BillTo = table.Column<bool>(type: "boolean", nullable: true),
                    UserType = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientSpecialIndicator",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientWound",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientWoundID = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    OccurDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SeenDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Site = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    LocationOfWound = table.Column<string>(type: "text", nullable: true),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: true),
                    ActionDescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Stage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    WoundStatusID_FK = table.Column<int>(type: "integer", nullable: true),
                    Comments = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    StatusRemark = table.Column<string>(type: "text", nullable: true),
                    LocationRemark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientWoundDraft",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientWoundDraftID = table.Column<int>(type: "integer", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    OccurDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SeenDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LocationOfWound = table.Column<string>(type: "text", nullable: true),
                    Site = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Stage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    WoundStatusID_FK = table.Column<int>(type: "integer", nullable: true),
                    Comments = table.Column<string>(type: "text", unicode: false, nullable: true),
                    SizeLength = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeWidth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Size = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SurfaceArea = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Perimeter = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    AverageDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    MaximumDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    MinimumDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Volume = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Granulation = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Slough = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Necrosis = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Epithelizing = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Others = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Exudate = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ExudateNature = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ExudatedConsistency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Edges = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PeriWound = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Suffering = table.Column<int>(type: "integer", nullable: true),
                    IsRedness = table.Column<bool>(type: "boolean", nullable: true),
                    IsSwelling = table.Column<bool>(type: "boolean", nullable: true),
                    IsWarmToTouch = table.Column<bool>(type: "boolean", nullable: true),
                    IsSmell = table.Column<bool>(type: "boolean", nullable: true),
                    IsAccept = table.Column<bool>(type: "boolean", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    ImageUpload = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    OriginalImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    WoundBedImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    AnnotatedImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    PatientWoundID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: true),
                    AssignDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    DepthImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    DepthMax = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthEighty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthSixty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthForty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthTwenty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthNegative = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthNans = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    UnderMining = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    Rotation = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    OriginalImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    WoundBedImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    DepthImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    AnnotatedImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    SizeLength_Auto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeDepth_Auto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeWidth_Auto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    MeasurementUpdateRemark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TCUpdateRemark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    isTCModified = table.Column<bool>(type: "boolean", nullable: true),
                    isWMModified = table.Column<bool>(type: "boolean", nullable: true),
                    isUploadImageModified = table.Column<bool>(type: "boolean", nullable: true),
                    woundOverlaysImageDistance = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    woundOverlaysImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    TO_Comments = table.Column<string>(type: "text", unicode: false, nullable: true),
                    NextReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    NextTreatmentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TreatmentRemarks = table.Column<string>(type: "text", nullable: true),
                    LocationRemark = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientWoundReviewBy",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientWoundReviewById = table.Column<int>(type: "integer", nullable: false),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: true),
                    UserId_FK = table.Column<int>(type: "integer", nullable: true),
                    ReviewComments = table.Column<string>(type: "text", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientWoundVisit",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientWoundVisitID = table.Column<int>(type: "integer", nullable: false),
                    PatientWoundID_FK = table.Column<int>(type: "integer", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    WoundType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WoundSubType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    WoundTypeOther = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SizeLength = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeWidth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Edges = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Appearance = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Smell = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UnderMining = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Exudate = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Suffering = table.Column<int>(type: "integer", nullable: true),
                    ImageUpload = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    SurfaceArea = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    UnderMiningDepth = table.Column<decimal>(type: "numeric(4,1)", nullable: true),
                    ExudateSubInfo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    VitalSignID_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    ReferID_FK = table.Column<int>(type: "integer", nullable: true),
                    NextReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TreatmentRemarks = table.Column<string>(type: "text", nullable: true),
                    AssignedToID_FK = table.Column<int>(type: "integer", nullable: true),
                    DESIGN_R_Depth = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DESIGN_R_Exudate = table.Column<int>(type: "integer", nullable: true),
                    DESIGN_R_Size = table.Column<int>(type: "integer", nullable: true),
                    DESIGN_R_Inflammation = table.Column<int>(type: "integer", nullable: true),
                    DESIGN_R_Granulation = table.Column<int>(type: "integer", nullable: true),
                    DESIGN_R_Necrotic = table.Column<int>(type: "integer", nullable: true),
                    DESIGN_R_Pocket = table.Column<int>(type: "integer", nullable: true),
                    DESIGN_R_Score = table.Column<int>(type: "integer", nullable: true),
                    IsDESIGN_R = table.Column<bool>(type: "boolean", nullable: true),
                    ExudateSubInfo2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PeriWound = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Debridement = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CleansingSolutionUsed = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Model_jpg = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Model_mtl = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Model_obj = table.Column<string>(type: "text", unicode: false, nullable: true),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    Volume = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    WoundInfection = table.Column<bool>(type: "boolean", nullable: true),
                    fever = table.Column<bool>(type: "boolean", nullable: true),
                    temperature = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    abscessPuss = table.Column<bool>(type: "boolean", nullable: true),
                    increasedPain = table.Column<bool>(type: "boolean", nullable: true),
                    erythema = table.Column<bool>(type: "boolean", nullable: true),
                    oedema = table.Column<bool>(type: "boolean", nullable: true),
                    localWarmth = table.Column<bool>(type: "boolean", nullable: true),
                    increasedExcudate = table.Column<bool>(type: "boolean", nullable: true),
                    delayedHealing = table.Column<bool>(type: "boolean", nullable: true),
                    maladour = table.Column<bool>(type: "boolean", nullable: true),
                    pocketing = table.Column<bool>(type: "boolean", nullable: true),
                    suspectedInfection = table.Column<bool>(type: "boolean", nullable: true),
                    TC_Granulation = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    TC_Slough = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    TC_Necrosis = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    TC_Epithelizing = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    TC_Others = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    TC_OriginalImage = table.Column<string>(type: "text", unicode: false, nullable: true),
                    TC_WoundBedImage = table.Column<string>(type: "text", unicode: false, nullable: true),
                    TC_AnnotatedImage = table.Column<string>(type: "text", unicode: false, nullable: true),
                    TC_IsAccept = table.Column<bool>(type: "boolean", nullable: true),
                    TC_Reason = table.Column<string>(type: "text", nullable: true),
                    Perimeter = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    AverageDepth = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    MaximumDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    MinimumDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    IsRedness = table.Column<bool>(type: "boolean", nullable: true),
                    IsSwelling = table.Column<bool>(type: "boolean", nullable: true),
                    IsWarmToTouch = table.Column<bool>(type: "boolean", nullable: true),
                    IsSmell = table.Column<bool>(type: "boolean", nullable: true),
                    Size = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    TC_Auto_Granulation = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    TC_Auto_Slough = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    TC_Auto_Necrosis = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    TC_Auto_Epithelizing = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    TC_Auto_Others = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    NextTreatmentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    InfectionRemarks = table.Column<string>(type: "text", nullable: true),
                    TO_Comments = table.Column<string>(type: "text", unicode: false, nullable: true),
                    DepthImage = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    StatusRemark = table.Column<string>(type: "text", nullable: true),
                    woundOverlaysImageDistance = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    woundOverlaysImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    otherTissueName = table.Column<string>(type: "text", unicode: false, nullable: true),
                    isTCAndImageModified = table.Column<bool>(type: "boolean", nullable: true),
                    isTCModified = table.Column<bool>(type: "boolean", nullable: true),
                    isWMModified = table.Column<bool>(type: "boolean", nullable: true),
                    isUploadImageModified = table.Column<bool>(type: "boolean", nullable: true),
                    ProgressiveWoundStage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    OriginalImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    WoundBedImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    DepthImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    AnnotatedImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    SizeLength_Auto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeDepth_Auto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeWidth_Auto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    MeasurementUpdateRemark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TCUpdateRemark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DepthMax = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthEighty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthSixty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthForty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthTwenty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthNegative = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthNans = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Rotation = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ReasonForChangeMeasurement = table.Column<string>(type: "text", nullable: true),
                    ReasonForChangeClassification = table.Column<string>(type: "text", nullable: true),
                    OrigWoundId = table.Column<int>(type: "integer", nullable: true),
                    SmallWound = table.Column<bool>(type: "boolean", nullable: true),
                    FrequencyOfVisit = table.Column<int>(type: "integer", nullable: true),
                    WoundCaptureMode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientWoundVisitAppearance",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientWoundVisitCleansingItem",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientWoundVisitClinician",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientWoundVisitClinicianID = table.Column<int>(type: "integer", nullable: false),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: true),
                    UserID_FK = table.Column<int>(type: "integer", nullable: true),
                    ExternalDoctorID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientWoundVisitTreatment",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientWoundVisitTreatmentID = table.Column<int>(type: "integer", nullable: false),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: false),
                    ItemID_FK = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    IsChargeable = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientWoundVisitTreatmentList",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientWoundVisitTListID = table.Column<int>(type: "integer", nullable: false),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: false),
                    TListItemID_FK = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_PatientWoundVisitTreatmentObjectives",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: false),
                    ObjectiveID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_ProblemList",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProblemListID = table.Column<int>(type: "integer", nullable: false),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    ProblemInfo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    TypeOfGoal = table.Column<int>(type: "integer", nullable: true),
                    DiseaseSubInfoID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_ProblemListGoal",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProblemListGoalID = table.Column<int>(type: "integer", nullable: false),
                    ProblemListID_FK = table.Column<int>(type: "integer", nullable: false),
                    Goal = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Action = table.Column<int>(type: "integer", nullable: true),
                    ScoreTypeID = table.Column<int>(type: "integer", nullable: true),
                    OperatorID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Receipt",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReceiptID = table.Column<int>(type: "integer", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    PaymentModeID_FK = table.Column<int>(type: "integer", nullable: false),
                    TotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ReceivedFrom = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    SendEmail = table.Column<bool>(type: "boolean", nullable: true),
                    EmailPatient = table.Column<bool>(type: "boolean", nullable: true),
                    EmailTo = table.Column<string>(type: "text", nullable: true),
                    EmailCC = table.Column<string>(type: "text", nullable: true),
                    EmailBCC = table.Column<string>(type: "text", nullable: true),
                    CurrencyID_FK = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GroupNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_ReceiptForInvoice",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReceiptForInvoiceID = table.Column<int>(type: "integer", nullable: false),
                    ReceiptID_FK = table.Column<int>(type: "integer", nullable: false),
                    BillingInvoiceID_FK = table.Column<int>(type: "integer", nullable: false),
                    Amt = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_RegisteredDevice",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeviceID = table.Column<int>(type: "integer", nullable: false),
                    DeviceType = table.Column<int>(type: "integer", nullable: true),
                    DeviceToken = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    UserID = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_RegisteredDeviceV2",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RegisteredDeviceID = table.Column<int>(type: "integer", nullable: false),
                    UserId_FK = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    DeviceType = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    DeviceToken = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    FirstRegisterIpAddress = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    AppName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Version = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_ResidentAssessmentCategory",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ResidentAssessmentCategoryID = table.Column<int>(type: "integer", nullable: false),
                    Category1Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category1Recommendation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category2Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category2Recommendation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category3Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category3Recommendation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category4Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category4Recommendation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Role",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    RoleDescription = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    OptionText = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    OptionValue = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    OptionType = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    Ordering = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_ScheduledTasks",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ScheduleId = table.Column<int>(type: "integer", nullable: false),
                    ScheduleDescription = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PerformTask = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    Everyday = table.Column<bool>(type: "boolean", nullable: false),
                    Weekday = table.Column<bool>(type: "boolean", nullable: false),
                    NDays = table.Column<int>(type: "integer", nullable: false),
                    WeekDays = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    TimeStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TimeEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Interval = table.Column<int>(type: "integer", nullable: false),
                    IntervalType = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    NextRun = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastRun = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_ServiceForBilling",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ServiceForBillingID = table.Column<int>(type: "integer", nullable: false),
                    CategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Duration1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Duration2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_ServiceForBillingCost",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ServiceForBillingCostID = table.Column<int>(type: "integer", nullable: false),
                    ServiceForBillingID_FK = table.Column<int>(type: "integer", nullable: false),
                    CurrencyID_FK = table.Column<int>(type: "integer", nullable: false),
                    UnitCost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_ServiceSkillset",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ServiceID_FK = table.Column<int>(type: "integer", nullable: false),
                    SkillsetID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_SyncPatientLog",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SyncLogId = table.Column<int>(type: "integer", nullable: false),
                    SyncBatchTs = table.Column<int>(type: "integer", nullable: false),
                    PatientID = table.Column<int>(type: "integer", nullable: false),
                    OffPatientID = table.Column<int>(type: "integer", nullable: false),
                    ServerPatientID = table.Column<int>(type: "integer", nullable: true),
                    SyncResult = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_SyncWoundLog",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SyncLogId = table.Column<int>(type: "integer", nullable: false),
                    SyncBatchTs = table.Column<int>(type: "integer", nullable: false),
                    WoundID = table.Column<int>(type: "integer", nullable: false),
                    OffWoundID = table.Column<int>(type: "integer", nullable: false),
                    ServerPatientID = table.Column<int>(type: "integer", nullable: false),
                    ServerWoundID = table.Column<int>(type: "integer", nullable: false),
                    SyncResult = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_SyncWoundVisitLog",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SyncLogId = table.Column<int>(type: "integer", nullable: false),
                    SyncBatchTs = table.Column<int>(type: "integer", nullable: false),
                    OffWoundVisitID = table.Column<int>(type: "integer", nullable: false),
                    ServerWoundID = table.Column<int>(type: "integer", nullable: false),
                    ServerWoundVisitID = table.Column<int>(type: "integer", nullable: false),
                    SyncResult = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_SysConfig",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ConfigName = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    ConfigValue = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsConfigurable = table.Column<bool>(type: "boolean", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_SystemForDisease",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SystemID = table.Column<int>(type: "integer", nullable: false),
                    System = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsSystemUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    GroupCode = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Task",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TaskID = table.Column<int>(type: "integer", nullable: false),
                    ActionTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Location = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: true),
                    OtherLocation = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: true),
                    FrequencyID_FK = table.Column<int>(type: "integer", nullable: true),
                    DosageID_FK = table.Column<int>(type: "integer", nullable: true),
                    MilkFeedVolumeMLS = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    Supplement = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    H2OFlushingMLS = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    ReferenceType = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    ReferenceID = table.Column<int>(type: "integer", nullable: true),
                    Pending = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MedicationID_FK = table.Column<int>(type: "integer", nullable: true),
                    Recurrence_Frequency = table.Column<int>(type: "integer", nullable: true),
                    Recurrence_Days = table.Column<int>(type: "integer", nullable: true),
                    Recurrence_Interval = table.Column<int>(type: "integer", nullable: true),
                    Recurrence_IntervalFlag = table.Column<int>(type: "integer", nullable: true),
                    MedicationInstructions = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    recurrenceDailyHourly = table.Column<int>(type: "integer", nullable: true),
                    UserCategory_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_TaskFileAttachment",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FileAttachmentID = table.Column<int>(type: "integer", nullable: false),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_TaskServicesRequired",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_TaskSpecificDate",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TaskSpecificDateID = table.Column<int>(type: "integer", nullable: false),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    TaskDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_TaskUser",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TaskUserID = table.Column<int>(type: "integer", nullable: false),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserType = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_TaskUserLog",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TaskUserLogID = table.Column<int>(type: "integer", nullable: false),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    FailReason = table.Column<string>(type: "text", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    HideDashboard = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_TaskUserLogAttachment",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FileAttachmentID = table.Column<int>(type: "integer", nullable: false),
                    TaskUserLogID_FK = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_TD_WoundAssessmentFactor",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TD_WoundAssessmentID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_TeleconsultationRecording",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RecordingID = table.Column<int>(type: "integer", nullable: false),
                    RecordingType = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    Sid = table.Column<string>(type: "character(36)", unicode: false, fixedLength: true, maxLength: 36, nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_TeleconsultationReport",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TeleReportID = table.Column<int>(type: "integer", nullable: false),
                    MediaType = table.Column<int>(type: "integer", nullable: false),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    Memo = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Thresholds",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    minValue = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    maxValue = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createdBy = table.Column<int>(type: "integer", nullable: true),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedBy = table.Column<int>(type: "integer", nullable: true),
                    updatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ews_min_1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_3 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_3 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_4 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_4 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_5 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_5 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_6 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_6 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_7 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_7 = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_TreatmentListItem",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TListItemID = table.Column<int>(type: "integer", nullable: false),
                    ItemName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TListTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    IsSystemUsed = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ItemBrand = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Cost = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_TreatmentTOL",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TreatmentTOLID = table.Column<int>(type: "integer", nullable: false),
                    TListItemID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Types",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    codeValue = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    parentCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ordering = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_UploadFile",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UploadFileId = table.Column<int>(type: "integer", nullable: false),
                    FileType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ByteData = table.Column<byte[]>(type: "bytea", nullable: true),
                    FileName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_UserAddress",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserLocationID = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    Address1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Address2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Address3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_UserBranch",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    BranchID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_UserCategory",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserCategoryID = table.Column<int>(type: "integer", nullable: false),
                    UserCategory = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserCategoryOrganizationID_FK = table.Column<int>(type: "integer", nullable: true),
                    EnableGeoFencing = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_UserCategoryRole",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserCategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    RoleID_FK = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_UserLanguage",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    LanguageID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_UserOrganization",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_UserRole",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId_FK = table.Column<int>(type: "integer", nullable: false),
                    RoleId_FK = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_Users",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Photo = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Contact = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Designation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastLogoutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastActivityDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastLockoutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastPasswordChangedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PreviousPasswords = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    SessionKey = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ResetPassword = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LocationNow1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LocationNow2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LocationNow3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PostalCodeNow = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    LocationNowModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    IsExternal = table.Column<bool>(type: "boolean", nullable: true),
                    UserOrganizationID_FK = table.Column<int>(type: "integer", nullable: true),
                    IsTCAccepted = table.Column<bool>(type: "boolean", nullable: true),
                    UserName = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    PreferredLanguage = table.Column<int>(type: "integer", nullable: true),
                    AccessLevelID_FK = table.Column<int>(type: "integer", nullable: true),
                    HasValidEmail = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    TokenID = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    PreviousPasswords2 = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    SharePdf = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_UserSkillset",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_UserType",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserTypeID = table.Column<int>(type: "integer", nullable: false),
                    UserType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserCategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ManpowerRate = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_UserUserType",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserTypeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_VitalSignDetails",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    vitalSignTypeId = table.Column<int>(type: "integer", nullable: false),
                    vitalSignId = table.Column<int>(type: "integer", nullable: false),
                    detailValue = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_VitalSignRelationships",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    vitalSignTypeId = table.Column<int>(type: "integer", nullable: false),
                    patientId = table.Column<int>(type: "integer", nullable: false),
                    thresholdId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_VitalSigns",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    patientId = table.Column<int>(type: "integer", nullable: false),
                    source = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    icaId = table.Column<int>(type: "integer", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createdBy = table.Column<int>(type: "integer", nullable: true),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedBy = table.Column<int>(type: "integer", nullable: true),
                    updatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_VitalSignTypes",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createdBy = table.Column<int>(type: "integer", nullable: true),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedBy = table.Column<int>(type: "integer", nullable: true),
                    updatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_VitalSignTypeThreshold",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    VitalSignTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    ews_min_1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_3 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_3 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_4 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_4 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_5 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_5 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_6 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_6 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_7 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_7 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Audit_WoundConsolidatedEmail",
                columns: table => new
                {
                    AuditAction = table.Column<string>(type: "character varying(5)", unicode: false, maxLength: 5, nullable: false),
                    ActionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WoundConsolidatedEmailID = table.Column<int>(type: "integer", nullable: false),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: false),
                    MailSettingsID_FK = table.Column<int>(type: "integer", nullable: false),
                    PDFContent = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "BillingPackageInformation",
                columns: table => new
                {
                    BillingPackageID = table.Column<int>(type: "integer", nullable: false),
                    BillingServiceID = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Session = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingPackageInformation", x => new { x.BillingPackageID, x.BillingServiceID });
                });

            migrationBuilder.CreateTable(
                name: "BillingPackageRequest",
                columns: table => new
                {
                    PackageRequestID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PackageRequestNo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    PatientName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SendBillTo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Discount = table.Column<bool>(type: "boolean", nullable: false),
                    DiscountType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DiscountAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    BillingAddress1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingAddress2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingAddress3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingPostalCode = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    TotalPackageAmount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PackageList = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageRequestID", x => x.PackageRequestID);
                });

            migrationBuilder.CreateTable(
                name: "C4WDeviceToken",
                columns: table => new
                {
                    C4WDeviceTokenId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OldDeviceToken = table.Column<string>(type: "text", unicode: false, nullable: true),
                    NewDeviceToken = table.Column<string>(type: "text", unicode: false, nullable: true),
                    ClientEnvironment = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Device = table.Column<string>(type: "text", unicode: false, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C4WDeviceToken", x => x.C4WDeviceTokenId);
                });

            migrationBuilder.CreateTable(
                name: "C4WImage",
                columns: table => new
                {
                    C4WImageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WoundImageName = table.Column<string>(type: "text", unicode: false, nullable: true),
                    WoundImageData = table.Column<string>(type: "text", unicode: false, nullable: true),
                    WoundBedImageName = table.Column<string>(type: "text", unicode: false, nullable: true),
                    WoundBedImageData = table.Column<string>(type: "text", unicode: false, nullable: true),
                    TissueImageName = table.Column<string>(type: "text", unicode: false, nullable: true),
                    TissueImageData = table.Column<string>(type: "text", unicode: false, nullable: true),
                    DepthImageName = table.Column<string>(type: "text", unicode: false, nullable: true),
                    DepthImageData = table.Column<string>(type: "text", unicode: false, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C4WImage", x => x.C4WImageId);
                });

            migrationBuilder.CreateTable(
                name: "CarePlanStatus",
                columns: table => new
                {
                    CarePlanStatusID = table.Column<int>(type: "integer", nullable: false),
                    CarePlanStatus = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CareReviewFrequency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanStatus", x => x.CarePlanStatusID);
                });

            migrationBuilder.CreateTable(
                name: "CareReportRehabilitation",
                columns: table => new
                {
                    CareReportRehabilitationID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsADLAssistance = table.Column<bool>(type: "boolean", nullable: true),
                    ADLAssistanceType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Bounded = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    NoOfTimesTurned = table.Column<int>(type: "integer", nullable: true),
                    NoOfSatOutOfBed = table.Column<int>(type: "integer", nullable: true),
                    IsDVTPrevention = table.Column<bool>(type: "boolean", nullable: true),
                    DVTType = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    RequirePhysioTherapist = table.Column<bool>(type: "boolean", nullable: true),
                    VisitForPhysioTherapist = table.Column<int>(type: "integer", nullable: true),
                    RequireOccupationTherapist = table.Column<bool>(type: "boolean", nullable: true),
                    VisitForOccupationTherapist = table.Column<int>(type: "integer", nullable: true),
                    RequireSpeechTherapist = table.Column<bool>(type: "boolean", nullable: true),
                    VisitForSpeechTherapist = table.Column<int>(type: "integer", nullable: true),
                    RequireWalkingAid = table.Column<bool>(type: "boolean", nullable: true),
                    WalkingAidType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    IsUpperLimbStrengthLeft = table.Column<bool>(type: "boolean", nullable: true),
                    IsUpperLimbStrengthRight = table.Column<bool>(type: "boolean", nullable: true),
                    UpperLimbStrengthLeft = table.Column<int>(type: "integer", nullable: true),
                    UpperLimbStrengthRight = table.Column<int>(type: "integer", nullable: true),
                    IsLowerLimbStrengthLeft = table.Column<bool>(type: "boolean", nullable: true),
                    IsLowerLimbStrengthRight = table.Column<bool>(type: "boolean", nullable: true),
                    LowerLimbStrengthLeft = table.Column<int>(type: "integer", nullable: true),
                    LowerLimbStrengthRight = table.Column<int>(type: "integer", nullable: true),
                    RehabilitationRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareReportRehabilitation", x => x.CareReportRehabilitationID);
                });

            migrationBuilder.CreateTable(
                name: "CodeType",
                columns: table => new
                {
                    CodeTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodeTypeName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsSystemUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeType", x => x.CodeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    DiagnosisID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Diagnosis = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.DiagnosisID);
                });

            migrationBuilder.CreateTable(
                name: "DischargeSummaryReport",
                columns: table => new
                {
                    DischargeSummaryReportId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VisitDateStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VisitDateEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VisitedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    SummaryCaseNote = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DischargeSummaryReport", x => x.DischargeSummaryReportId);
                });

            migrationBuilder.CreateTable(
                name: "EBASDEPQuestion",
                columns: table => new
                {
                    EBASDEPQuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ordering = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EBASDEPQuestion", x => x.EBASDEPQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "EmailLog",
                columns: table => new
                {
                    EmailLogId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    msgBCC = table.Column<string>(type: "text", nullable: true),
                    msgCC = table.Column<string>(type: "text", nullable: true),
                    msgTo = table.Column<string>(type: "text", nullable: true),
                    msgSubj = table.Column<string>(type: "text", nullable: true),
                    msgBody = table.Column<string>(type: "text", nullable: true),
                    msgFromName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    msgFrom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    isHtml = table.Column<bool>(type: "boolean", nullable: true),
                    attachmentName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    isSent = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    smtpServerAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    smtpLogin = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    smtpPassword = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    smtpPort = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailLog", x => x.EmailLogId);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    ErrorLogId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ErrorDetails = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.ErrorLogId);
                });

            migrationBuilder.CreateTable(
                name: "GeoFencing",
                columns: table => new
                {
                    GeoFencingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IP = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsWhitelisted = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoFencing", x => x.GeoFencingId);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "InitialCareAssessmentVitalSign",
                columns: table => new
                {
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: false),
                    VitalSignID_FK = table.Column<int>(type: "integer", nullable: false),
                    TimeOfRecord = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialCareAssessmentVitalSign", x => new { x.InitialCareAssessmentID_FK, x.VitalSignID_FK });
                });

            migrationBuilder.CreateTable(
                name: "IntegrationApiRequestLog",
                columns: table => new
                {
                    IntegrationApiRequestLogID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IntegrationSource = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FacilityId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ResidentId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedByID_FK = table.Column<int>(type: "integer", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "(now())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Integrat__5749CA7CC431EC3C", x => x.IntegrationApiRequestLogID);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: true),
                    FullName = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "LoginDevice",
                columns: table => new
                {
                    LoginDeviceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId_FK = table.Column<int>(type: "integer", nullable: false),
                    DeviceType = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    DeviceID = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDevice", x => x.LoginDeviceId);
                });

            migrationBuilder.CreateTable(
                name: "MailSettings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    msgBCC = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    msgCC = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    msgTo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    msgSubj = table.Column<string>(type: "text", nullable: true),
                    msgBody = table.Column<string>(type: "text", nullable: true),
                    displayMsgTo = table.Column<bool>(type: "boolean", nullable: true),
                    displayMsgCC = table.Column<bool>(type: "boolean", nullable: true),
                    displayMsgBCC = table.Column<bool>(type: "boolean", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailSettings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Otp",
                columns: table => new
                {
                    OtpId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otp", x => x.OtpId);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    PackageID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PackageName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PackageDetails = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.PackageID);
                });

            migrationBuilder.CreateTable(
                name: "PatientAdditionalInfo",
                columns: table => new
                {
                    PatientAdditionalInfoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AICD = table.Column<bool>(type: "boolean", nullable: true),
                    AICD_InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AICD_InsertedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AICD_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ACP = table.Column<bool>(type: "boolean", nullable: true),
                    ACP_DoneDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ACP_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DNR = table.Column<bool>(type: "boolean", nullable: true),
                    Pacemaker = table.Column<bool>(type: "boolean", nullable: true),
                    Pacemaker_InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Pacemaker_InsertedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Pacemaker_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    DNR_DateInitiated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DNR_InitiatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DNR_DateTerminated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DNR_TerminatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CVCLine = table.Column<bool>(type: "boolean", nullable: true),
                    CVCLine_InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CVCLine_InsertedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CVCLine_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PICCLine = table.Column<bool>(type: "boolean", nullable: true),
                    PICCLine_InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PICCLine_InsertedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PICCLine_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IVLine = table.Column<bool>(type: "boolean", nullable: true),
                    IVLine_InsertDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IVLine_InsertedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IVLine_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAdditionalInfo", x => x.PatientAdditionalInfoID);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedication",
                columns: table => new
                {
                    PatientMedicationID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Allergies = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    SelfAdminister = table.Column<bool>(type: "boolean", nullable: true),
                    Compliant = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedication_1", x => x.PatientMedicationID);
                });

            migrationBuilder.CreateTable(
                name: "PatientNutrition",
                columns: table => new
                {
                    PatientNutritionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EatingAndSwallowing = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EatingAndSwallowingTypeOfTubeFeeding = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EatingAndSwallowingTypeOfTube = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EatingAndSwallowingSize = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EatingAndSwallowingDateInserted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EatingAndSwallowingDateDue = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Diet = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Appetite = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    FluidConsistency = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    FluidRestrictionMLSPerDay = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    ReviewedBySpeechTherapist = table.Column<bool>(type: "boolean", nullable: true),
                    ReferralToSpeechTherapist = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    Enteralfeeding = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    SizeofPEGJtube = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    IVtherapyStateType = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    SwallowingIssues = table.Column<bool>(type: "boolean", nullable: true),
                    DiagnosedDysphasia = table.Column<bool>(type: "boolean", nullable: true),
                    IsFIsluidRestriction = table.Column<bool>(type: "boolean", nullable: true),
                    IVtherapy = table.Column<bool>(type: "boolean", nullable: true),
                    IVtherapyMLSPerDay = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    MilkFeedAmt = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    WaterPerDay = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    DiagnosedDysphasiaLastReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientNutrition", x => x.PatientNutritionID);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredDevice",
                columns: table => new
                {
                    DeviceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceType = table.Column<int>(type: "integer", nullable: true),
                    DeviceToken = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    UserID = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "RegisteredDeviceV2",
                columns: table => new
                {
                    RegisteredDeviceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId_FK = table.Column<int>(type: "integer", nullable: true),
                    DeviceId = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    DeviceType = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    DeviceToken = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    FirstRegisterIpAddress = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    AppName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Version = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredDeviceV2", x => x.RegisteredDeviceID);
                });

            migrationBuilder.CreateTable(
                name: "ResidentAssessmentCategory",
                columns: table => new
                {
                    ResidentAssessmentCategoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Category1Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category1Recommendation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category2Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category2Recommendation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category3Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category3Recommendation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category4Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Category4Recommendation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentAssessmentCategory", x => x.ResidentAssessmentCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    RoleDescription = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    OptionText = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    OptionValue = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    OptionType = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, defaultValue: ""),
                    Ordering = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    Active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledTasks",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "integer", nullable: false),
                    ScheduleDescription = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, defaultValue: ""),
                    PerformTask = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, defaultValue: "D"),
                    Everyday = table.Column<bool>(type: "boolean", nullable: false),
                    Weekday = table.Column<bool>(type: "boolean", nullable: false),
                    NDays = table.Column<int>(type: "integer", nullable: false),
                    WeekDays = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    TimeStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TimeEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Interval = table.Column<int>(type: "integer", nullable: false),
                    IntervalType = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    NextRun = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastRun = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledTasks", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "SyncPatientLog",
                columns: table => new
                {
                    SyncLogId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SyncBatchTs = table.Column<int>(type: "integer", nullable: false),
                    PatientID = table.Column<int>(type: "integer", nullable: false),
                    OffPatientID = table.Column<int>(type: "integer", nullable: false),
                    ServerPatientID = table.Column<int>(type: "integer", nullable: true),
                    SyncResult = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncPatientLog", x => x.SyncLogId);
                });

            migrationBuilder.CreateTable(
                name: "SyncWoundLog",
                columns: table => new
                {
                    SyncLogId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SyncBatchTs = table.Column<int>(type: "integer", nullable: false),
                    WoundID = table.Column<int>(type: "integer", nullable: false),
                    OffWoundID = table.Column<int>(type: "integer", nullable: false),
                    ServerPatientID = table.Column<int>(type: "integer", nullable: false),
                    ServerWoundID = table.Column<int>(type: "integer", nullable: false),
                    SyncResult = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncWoundLog", x => x.SyncLogId);
                });

            migrationBuilder.CreateTable(
                name: "SyncWoundVisitLog",
                columns: table => new
                {
                    SyncLogId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SyncBatchTs = table.Column<int>(type: "integer", nullable: false),
                    OffWoundVisitID = table.Column<int>(type: "integer", nullable: false),
                    ServerWoundID = table.Column<int>(type: "integer", nullable: false),
                    ServerWoundVisitID = table.Column<int>(type: "integer", nullable: false),
                    SyncResult = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncWoundVisitLog", x => x.SyncLogId);
                });

            migrationBuilder.CreateTable(
                name: "SysConfig",
                columns: table => new
                {
                    ConfigName = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    ConfigValue = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsConfigurable = table.Column<bool>(type: "boolean", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysConfig", x => x.ConfigName);
                });

            migrationBuilder.CreateTable(
                name: "SystemForDisease",
                columns: table => new
                {
                    SystemID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    System = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsSystemUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    GroupCode = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemForDisease", x => x.SystemID);
                });

            migrationBuilder.CreateTable(
                name: "TeleconsultationReport",
                columns: table => new
                {
                    TeleReportID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MediaType = table.Column<int>(type: "integer", nullable: false),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    Memo = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeleconsultationReport", x => x.TeleReportID);
                });

            migrationBuilder.CreateTable(
                name: "Thresholds",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    minValue = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    maxValue = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createdBy = table.Column<int>(type: "integer", nullable: true),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedBy = table.Column<int>(type: "integer", nullable: true),
                    updatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ews_min_1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_3 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_3 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_4 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_4 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_5 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_5 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_6 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_6 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_7 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_7 = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Threshol__3213E83F6D225C2D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    codeValue = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    parentCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ordering = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Types__357D4CF8F524A549", x => x.code);
                    table.ForeignKey(
                        name: "fk_Types_parentCode",
                        column: x => x.parentCode,
                        principalTable: "Types",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "UploadFile",
                columns: table => new
                {
                    UploadFileId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ByteData = table.Column<byte[]>(type: "bytea", nullable: true),
                    FileName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadFile", x => x.UploadFileId);
                });

            migrationBuilder.CreateTable(
                name: "UUIDLog",
                columns: table => new
                {
                    UUIDLogID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UUID = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    IsUpdated = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientWoundVisitID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UUIDLog", x => x.UUIDLogID);
                });

            migrationBuilder.CreateTable(
                name: "VitalSignTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createdBy = table.Column<int>(type: "integer", nullable: true),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedBy = table.Column<int>(type: "integer", nullable: true),
                    updatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VitalSig__3213E83F6F00CA79", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WoundUserCategoryParentChild",
                columns: table => new
                {
                    ParentUserCategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    ChildUserCategoryID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WoundUserCategoryParentChild", x => new { x.ParentUserCategoryID_FK, x.ChildUserCategoryID_FK });
                });

            migrationBuilder.CreateTable(
                name: "APIOrderAllergy",
                columns: table => new
                {
                    APIOrderAllergyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    APIOrderID_FK = table.Column<int>(type: "integer", nullable: false),
                    AllergyAgentID = table.Column<int>(type: "integer", nullable: true),
                    AllergyAgent = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AllergyReactionID = table.Column<int>(type: "integer", nullable: true),
                    AllergyReaction = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIOrderAllergy", x => x.APIOrderAllergyID);
                    table.ForeignKey(
                        name: "FK_APIOrderAllergy_APIOrder",
                        column: x => x.APIOrderID_FK,
                        principalTable: "APIOrder",
                        principalColumn: "APIOrderId");
                });

            migrationBuilder.CreateTable(
                name: "APIOrderDiagnosis",
                columns: table => new
                {
                    APIOrderDiagnosisID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    APIOrderID_FK = table.Column<int>(type: "integer", nullable: false),
                    DiagnosisType = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DiagnosisDesc = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIOrderDiagnosis", x => x.APIOrderDiagnosisID);
                    table.ForeignKey(
                        name: "FK_APIOrderDiagnosis_APIOrder",
                        column: x => x.APIOrderID_FK,
                        principalTable: "APIOrder",
                        principalColumn: "APIOrderId");
                });

            migrationBuilder.CreateTable(
                name: "APIOrderMedication",
                columns: table => new
                {
                    APIOrderMedicationID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    APIOrderID_FK = table.Column<int>(type: "integer", nullable: false),
                    MedicationID = table.Column<int>(type: "integer", nullable: true),
                    MedicationName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MedicationStatus = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    MedicationQuantity = table.Column<int>(type: "integer", nullable: true),
                    MedicationQuantityUnit = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    MedicationFrequencyID = table.Column<int>(type: "integer", nullable: true),
                    MedicationFrequency = table.Column<int>(type: "integer", nullable: true),
                    MedicationPeriod = table.Column<int>(type: "integer", nullable: true),
                    MedicationPeriodUnit = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    MedicationAsNeeded = table.Column<bool>(type: "boolean", nullable: true),
                    MedicationDisplay = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DosageID_FK = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIOrderMedication", x => x.APIOrderMedicationID);
                    table.ForeignKey(
                        name: "FK_APIOrderMedication_APIOrder",
                        column: x => x.APIOrderID_FK,
                        principalTable: "APIOrder",
                        principalColumn: "APIOrderId");
                });

            migrationBuilder.CreateTable(
                name: "APIOrderTask",
                columns: table => new
                {
                    APIOrderTaskID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    APIOrderID_FK = table.Column<int>(type: "integer", nullable: false),
                    TaskID = table.Column<int>(type: "integer", nullable: true),
                    TaskName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TaskTypeID = table.Column<int>(type: "integer", nullable: true),
                    TaskStartDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TaskEndDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TaskFrequencyID = table.Column<int>(type: "integer", nullable: true),
                    TaskFrequency = table.Column<int>(type: "integer", nullable: true),
                    TaskPeriod = table.Column<int>(type: "integer", nullable: true),
                    TaskPeriodUnit = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    TaskDisplay = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Remark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIOrderTask", x => x.APIOrderTaskID);
                    table.ForeignKey(
                        name: "FK_APIOrderTask_APIOrder",
                        column: x => x.APIOrderID_FK,
                        principalTable: "APIOrder",
                        principalColumn: "APIOrderId");
                });

            migrationBuilder.CreateTable(
                name: "Code",
                columns: table => new
                {
                    CodeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodeTypeId_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ordering = table.Column<int>(type: "integer", nullable: true),
                    IsSystemUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    Indication_Acute = table.Column<bool>(type: "boolean", nullable: true),
                    Indication_PRN = table.Column<bool>(type: "boolean", nullable: true),
                    Referral_Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    AllergyReaction_Drug = table.Column<bool>(type: "boolean", nullable: true),
                    AllergyReaction_Others = table.Column<bool>(type: "boolean", nullable: true),
                    MedicationGroupID_FK = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    CurrencyCodeA = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    CurrencyCodeN = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: true),
                    CurrencyInvoiceFooter = table.Column<string>(type: "text", nullable: true),
                    Critical = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Code", x => x.CodeId);
                    table.ForeignKey(
                        name: "FK_Code_Code",
                        column: x => x.MedicationGroupID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Code_CodeType",
                        column: x => x.CodeTypeId_FK,
                        principalTable: "CodeType",
                        principalColumn: "CodeTypeId");
                });

            migrationBuilder.CreateTable(
                name: "DischargeSummaryReportAttachment",
                columns: table => new
                {
                    DischargeSummaryReportAttachmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DischargeSummaryReportID_FK = table.Column<int>(type: "integer", nullable: false),
                    Filename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Physical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DischargeSummaryReportAttachment", x => x.DischargeSummaryReportAttachmentID);
                    table.ForeignKey(
                        name: "FK_DischargeSummaryReportAttachment_DischargeSummaryReport",
                        column: x => x.DischargeSummaryReportID_FK,
                        principalTable: "DischargeSummaryReport",
                        principalColumn: "DischargeSummaryReportId");
                });

            migrationBuilder.CreateTable(
                name: "GroupRole",
                columns: table => new
                {
                    GroupId_FK = table.Column<int>(type: "integer", nullable: false),
                    RoleId_FK = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRole", x => new { x.GroupId_FK, x.RoleId_FK });
                    table.ForeignKey(
                        name: "FK_GroupRole_Group",
                        column: x => x.GroupId_FK,
                        principalTable: "Group",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_GroupRole_Role",
                        column: x => x.RoleId_FK,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Disease",
                columns: table => new
                {
                    DiseaseID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiseaseName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SystemID_FK = table.Column<int>(type: "integer", nullable: false),
                    IsAdditionalInfo = table.Column<bool>(type: "boolean", nullable: false),
                    IsSuggestPalliativeCare = table.Column<bool>(type: "boolean", nullable: false),
                    IsSystemUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true),
                    DiseaseCode = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease", x => x.DiseaseID);
                    table.ForeignKey(
                        name: "FK_Disease_SystemForDisease",
                        column: x => x.SystemID_FK,
                        principalTable: "SystemForDisease",
                        principalColumn: "SystemID");
                });

            migrationBuilder.CreateTable(
                name: "APIAccessKey",
                columns: table => new
                {
                    APIAccessKeyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TokenCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AccessKey = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserId_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__APIAcces__79CAEB20D6CC8EEA", x => x.APIAccessKeyID);
                    table.ForeignKey(
                        name: "FK_APIAccessKey_TokenCode",
                        column: x => x.TokenCode,
                        principalTable: "Types",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "NotificationMessageTemplates",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    notificationgroupCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    notificationSubject = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    notificationMessage = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3213E83FC46BAAC6", x => x.id);
                    table.ForeignKey(
                        name: "fk_NotificationMessageTemplates_notificationgroupCode",
                        column: x => x.notificationgroupCode,
                        principalTable: "Types",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "VitalSignTypeThreshold",
                columns: table => new
                {
                    VitalSignTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    ews_min_1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_1 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_2 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_3 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_3 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_4 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_4 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_5 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_5 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_6 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_6 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_min_7 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    ews_max_7 = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalSignTypeThreshold", x => x.VitalSignTypeID_FK);
                    table.ForeignKey(
                        name: "FK_VitalSignTypeThreshold_VitalSignTypes",
                        column: x => x.VitalSignTypeID_FK,
                        principalTable: "VitalSignTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "BillingService",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    CostPerSession = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Weekend = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceID", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_BillingService_Code",
                        column: x => x.CategoryID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Address1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Address2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Address3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Contact = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: false),
                    IsSystemUsed = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CurrencyID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchID);
                    table.ForeignKey(
                        name: "FK_Branch_Code",
                        column: x => x.CurrencyID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    FacilityID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FacilityName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    OrganizationID_FK = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    _id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IntegrationSource = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.FacilityID);
                    table.ForeignKey(
                        name: "FK_Facility_Code",
                        column: x => x.OrganizationID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    ItemUnitID_FK = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    AvailableInBilling = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Item_Code",
                        column: x => x.CategoryID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Item_Code1",
                        column: x => x.ItemUnitID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "MedicationVitalSignType",
                columns: table => new
                {
                    MedicationVitalSignTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicationID_FK = table.Column<int>(type: "integer", nullable: false),
                    VitalSignTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationVitalSignType", x => x.MedicationVitalSignTypeID);
                    table.ForeignKey(
                        name: "FK_MedicationVitalSignType_Code",
                        column: x => x.MedicationID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_MedicationVitalSignType_VitalSignTypes",
                        column: x => x.VitalSignTypeID_FK,
                        principalTable: "VitalSignTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "NutritionTaskReference",
                columns: table => new
                {
                    ReferenceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodeId_FK = table.Column<int>(type: "integer", nullable: false),
                    ReferenceImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionTaskReference", x => x.ReferenceID);
                    table.ForeignKey(
                        name: "FK_NutritionTaskReference_Code",
                        column: x => x.CodeId_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicationSupply",
                columns: table => new
                {
                    PatientMedicationID_FK = table.Column<int>(type: "integer", nullable: false),
                    SupplyID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicationSupply", x => new { x.PatientMedicationID_FK, x.SupplyID_FK });
                    table.ForeignKey(
                        name: "FK_PatientMedicationSupply_Code",
                        column: x => x.SupplyID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientMedicationSupply_PatientMedication",
                        column: x => x.PatientMedicationID_FK,
                        principalTable: "PatientMedication",
                        principalColumn: "PatientMedicationID");
                });

            migrationBuilder.CreateTable(
                name: "PatientProfile",
                columns: table => new
                {
                    PatientProfileID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodTypeID_FK = table.Column<int>(type: "integer", nullable: true),
                    ReligionID_FK = table.Column<int>(type: "integer", nullable: true),
                    MobilePhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    HomePhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingAddress1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingAddress2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingAddress3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BillingPostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    OtherReligion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Organization = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Ward = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Bed = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Note = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PatientOrganizationID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProfile", x => x.PatientProfileID);
                    table.ForeignKey(
                        name: "FK_PatientProfile_Code",
                        column: x => x.BloodTypeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientProfile_Code1",
                        column: x => x.ReligionID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientProfile_PatientOrganizationID_FK",
                        column: x => x.PatientOrganizationID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodeId = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    CodeValue = table.Column<string>(type: "text", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_Resource_Code",
                        column: x => x.CodeId,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Resource_Language",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "LanguageId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceForBilling",
                columns: table => new
                {
                    ServiceForBillingID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Duration1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Duration2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceForBilling", x => x.ServiceForBillingID);
                    table.ForeignKey(
                        name: "FK_ServiceForBilling_Code",
                        column: x => x.CategoryID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceSkillset",
                columns: table => new
                {
                    ServiceID_FK = table.Column<int>(type: "integer", nullable: false),
                    SkillsetID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSkillset", x => new { x.ServiceID_FK, x.SkillsetID_FK });
                    table.ForeignKey(
                        name: "FK_ServiceSkillset_Code",
                        column: x => x.SkillsetID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_ServiceSkillset_Code1",
                        column: x => x.ServiceID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "TD_WoundAssessmentFactor",
                columns: table => new
                {
                    TD_WoundAssessmentID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TD_WoundAssessmentFactor", x => new { x.TD_WoundAssessmentID_FK, x.CodeID_FK });
                    table.ForeignKey(
                        name: "FK_TD_WoundAssessmentFactor_Code",
                        column: x => x.CodeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "TreatmentListItem",
                columns: table => new
                {
                    TListItemID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TListTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    IsSystemUsed = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ItemBrand = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Cost = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentListItem", x => x.TListItemID);
                    table.ForeignKey(
                        name: "FK_TreatmentListItem_Code",
                        column: x => x.TListTypeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "UserCategory",
                columns: table => new
                {
                    UserCategoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserCategory = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserCategoryOrganizationID_FK = table.Column<int>(type: "integer", nullable: true),
                    EnableGeoFencing = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategory", x => x.UserCategoryID);
                    table.ForeignKey(
                        name: "FK_UserCategory_UserCategoryOrganizationID_FK",
                        column: x => x.UserCategoryOrganizationID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "CPGoals",
                columns: table => new
                {
                    CPGoalsID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    CPGoalsInfo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPGoals", x => x.CPGoalsID);
                    table.ForeignKey(
                        name: "FK_CPGoals_Disease",
                        column: x => x.DiseaseID_FK,
                        principalTable: "Disease",
                        principalColumn: "DiseaseID");
                });

            migrationBuilder.CreateTable(
                name: "DiseaseInfo",
                columns: table => new
                {
                    DiseaseInfoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiseaseInfo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseInfo", x => x.DiseaseInfoID);
                    table.ForeignKey(
                        name: "FK_DiseaseInfo_Disease",
                        column: x => x.DiseaseID_FK,
                        principalTable: "Disease",
                        principalColumn: "DiseaseID");
                });

            migrationBuilder.CreateTable(
                name: "DiseaseSubInfo",
                columns: table => new
                {
                    DiseaseSubInfoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiseaseSubInfo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseSubInfo", x => x.DiseaseSubInfoID);
                    table.ForeignKey(
                        name: "FK_DiseaseSubInfo_Disease",
                        column: x => x.DiseaseID_FK,
                        principalTable: "Disease",
                        principalColumn: "DiseaseID");
                });

            migrationBuilder.CreateTable(
                name: "DiseaseVitalSignType",
                columns: table => new
                {
                    DiseaseVitalSignTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    VitalSignTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseVitalSignType", x => x.DiseaseVitalSignTypeID);
                    table.ForeignKey(
                        name: "FK_DiseaseVitalSignType_Disease",
                        column: x => x.DiseaseID_FK,
                        principalTable: "Disease",
                        principalColumn: "DiseaseID");
                    table.ForeignKey(
                        name: "FK_DiseaseVitalSignType_VitalSignTypes",
                        column: x => x.VitalSignTypeID_FK,
                        principalTable: "VitalSignTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Intervention",
                columns: table => new
                {
                    InterventionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    InterventionInfo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervention", x => x.InterventionID);
                    table.ForeignKey(
                        name: "FK_Intervention_Disease",
                        column: x => x.DiseaseID_FK,
                        principalTable: "Disease",
                        principalColumn: "DiseaseID");
                });

            migrationBuilder.CreateTable(
                name: "ProblemList",
                columns: table => new
                {
                    ProblemListID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    ProblemInfo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    TypeOfGoal = table.Column<int>(type: "integer", nullable: true),
                    DiseaseSubInfoID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemList", x => x.ProblemListID);
                    table.ForeignKey(
                        name: "FK_ProblemList_Disease",
                        column: x => x.DiseaseID_FK,
                        principalTable: "Disease",
                        principalColumn: "DiseaseID");
                });

            migrationBuilder.CreateTable(
                name: "BillingPackage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Session = table.Column<int>(type: "integer", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Validity = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    BillingServiceID = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingPackage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BillingPackage_BillingService",
                        column: x => x.BillingServiceID,
                        principalTable: "BillingService",
                        principalColumn: "ServiceID");
                });

            migrationBuilder.CreateTable(
                name: "ItemStock",
                columns: table => new
                {
                    ItemStockID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemID_FK = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStock", x => x.ItemStockID);
                    table.ForeignKey(
                        name: "FK_ItemStock_Item",
                        column: x => x.ItemID_FK,
                        principalTable: "Item",
                        principalColumn: "ItemID");
                });

            migrationBuilder.CreateTable(
                name: "ServiceForBillingCost",
                columns: table => new
                {
                    ServiceForBillingCostID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceForBillingID_FK = table.Column<int>(type: "integer", nullable: false),
                    CurrencyID_FK = table.Column<int>(type: "integer", nullable: false),
                    UnitCost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceForBillingCost", x => x.ServiceForBillingCostID);
                    table.ForeignKey(
                        name: "FK_ServiceForBillingCost_Code",
                        column: x => x.CurrencyID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_ServiceForBillingCost_ServiceForBilling",
                        column: x => x.ServiceForBillingID_FK,
                        principalTable: "ServiceForBilling",
                        principalColumn: "ServiceForBillingID");
                });

            migrationBuilder.CreateTable(
                name: "TreatmentTOL",
                columns: table => new
                {
                    TreatmentTOLID = table.Column<int>(type: "integer", nullable: false),
                    TListItemID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentTOL", x => new { x.TreatmentTOLID, x.TListItemID_FK });
                    table.ForeignKey(
                        name: "FK_TreatmentTOL_TreatmentListItem",
                        column: x => x.TListItemID_FK,
                        principalTable: "TreatmentListItem",
                        principalColumn: "TListItemID");
                });

            migrationBuilder.CreateTable(
                name: "UserCategoryFacility",
                columns: table => new
                {
                    UserCategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    FacilityID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategoryFacility", x => new { x.UserCategoryID_FK, x.FacilityID_FK });
                    table.ForeignKey(
                        name: "FK_UserCategoryFacility_Facility",
                        column: x => x.FacilityID_FK,
                        principalTable: "Facility",
                        principalColumn: "FacilityID");
                    table.ForeignKey(
                        name: "FK_UserCategoryFacility_UserCategory",
                        column: x => x.UserCategoryID_FK,
                        principalTable: "UserCategory",
                        principalColumn: "UserCategoryID");
                });

            migrationBuilder.CreateTable(
                name: "UserCategoryParentChild",
                columns: table => new
                {
                    ParentUserCategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    ChildUserCategoryID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategoryParentChild", x => new { x.ParentUserCategoryID_FK, x.ChildUserCategoryID_FK });
                    table.ForeignKey(
                        name: "FK_UserCategoryParentChild_Child",
                        column: x => x.ChildUserCategoryID_FK,
                        principalTable: "UserCategory",
                        principalColumn: "UserCategoryID");
                    table.ForeignKey(
                        name: "FK_UserCategoryParentChild_Parent",
                        column: x => x.ParentUserCategoryID_FK,
                        principalTable: "UserCategory",
                        principalColumn: "UserCategoryID");
                });

            migrationBuilder.CreateTable(
                name: "UserCategoryRole",
                columns: table => new
                {
                    UserCategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    RoleID_FK = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategoryRole", x => new { x.UserCategoryID_FK, x.RoleID_FK });
                    table.ForeignKey(
                        name: "FK_UserCategoryRole_Role",
                        column: x => x.RoleID_FK,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_UserCategoryRole_UserCategory",
                        column: x => x.UserCategoryID_FK,
                        principalTable: "UserCategory",
                        principalColumn: "UserCategoryID");
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserCategoryID_FK = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ManpowerRate = table.Column<decimal>(type: "numeric(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                    table.ForeignKey(
                        name: "FK_UserType_UserCategory",
                        column: x => x.UserCategoryID_FK,
                        principalTable: "UserCategory",
                        principalColumn: "UserCategoryID");
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicationConsume",
                columns: table => new
                {
                    PatientMedicationConsumeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientMedicationID_FK = table.Column<int>(type: "integer", nullable: false),
                    MedicationID_FK = table.Column<int>(type: "integer", nullable: true),
                    RouteID_FK = table.Column<int>(type: "integer", nullable: true),
                    DosageID_FK = table.Column<int>(type: "integer", nullable: true),
                    FrequencyID_FK = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Indication = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ReasonOfDiscontinue = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ChronicDiseaseID_FK = table.Column<int>(type: "integer", nullable: true),
                    ChronicDiseaseSubInfoID_FK = table.Column<int>(type: "integer", nullable: true),
                    AcutePRNIndicationID_FK = table.Column<int>(type: "integer", nullable: true),
                    ReferID_FK = table.Column<int>(type: "integer", nullable: true),
                    InstructedByID_FK = table.Column<int>(type: "integer", nullable: true),
                    DrName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DrContact = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MCRNo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ClinicHosp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    InstructedBy2ID_FK = table.Column<int>(type: "integer", nullable: true),
                    DrNameED = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DrContactED = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MCRNoED = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ClinicHospED = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicationConsume", x => x.PatientMedicationConsumeID);
                    table.ForeignKey(
                        name: "FK_PatientMedicationConsume_Code",
                        column: x => x.RouteID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientMedicationConsume_Code1",
                        column: x => x.DosageID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientMedicationConsume_Code2",
                        column: x => x.FrequencyID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientMedicationConsume_Code3",
                        column: x => x.AcutePRNIndicationID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientMedicationConsume_Code4",
                        column: x => x.MedicationID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientMedicationConsume_Disease",
                        column: x => x.ChronicDiseaseID_FK,
                        principalTable: "Disease",
                        principalColumn: "DiseaseID");
                    table.ForeignKey(
                        name: "FK_PatientMedicationConsume_DiseaseSubInfo",
                        column: x => x.ChronicDiseaseSubInfoID_FK,
                        principalTable: "DiseaseSubInfo",
                        principalColumn: "DiseaseSubInfoID");
                    table.ForeignKey(
                        name: "FK_PatientMedicationConsume_InstructedBy2ID_FK",
                        column: x => x.InstructedBy2ID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientMedicationConsume_InstructedByID_FK",
                        column: x => x.InstructedByID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientMedicationConsume_PatientMedication",
                        column: x => x.PatientMedicationID_FK,
                        principalTable: "PatientMedication",
                        principalColumn: "PatientMedicationID");
                    table.ForeignKey(
                        name: "FK_PatientMedicationConsume_PatientMedicationConsume",
                        column: x => x.ReferID_FK,
                        principalTable: "PatientMedicationConsume",
                        principalColumn: "PatientMedicationConsumeID");
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProblemListID_FK = table.Column<int>(type: "integer", nullable: false),
                    ActivityDetail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    DiseaseSubInfoID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK_Activity_Disease",
                        column: x => x.DiseaseID_FK,
                        principalTable: "Disease",
                        principalColumn: "DiseaseID");
                    table.ForeignKey(
                        name: "FK_Activity_ProblemList",
                        column: x => x.ProblemListID_FK,
                        principalTable: "ProblemList",
                        principalColumn: "ProblemListID");
                });

            migrationBuilder.CreateTable(
                name: "ProblemListGoal",
                columns: table => new
                {
                    ProblemListGoalID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProblemListID_FK = table.Column<int>(type: "integer", nullable: false),
                    Goal = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Action = table.Column<int>(type: "integer", nullable: true),
                    ScoreTypeID = table.Column<int>(type: "integer", nullable: true),
                    OperatorID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemListGoal", x => x.ProblemListGoalID);
                    table.ForeignKey(
                        name: "FK_ProblemListGoal_Operator",
                        column: x => x.OperatorID,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_ProblemListGoal_ProblemList",
                        column: x => x.ProblemListID_FK,
                        principalTable: "ProblemList",
                        principalColumn: "ProblemListID");
                    table.ForeignKey(
                        name: "FK_ProblemListGoal_ScoreType",
                        column: x => x.ScoreTypeID,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "CareReportConfig",
                columns: table => new
                {
                    CareReportConfigID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    SectionAccess = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareReportConfig", x => x.CareReportConfigID);
                    table.ForeignKey(
                        name: "FK_CareReportConfig_UserType",
                        column: x => x.UserTypeID_FK,
                        principalTable: "UserType",
                        principalColumn: "UserTypeID");
                });

            migrationBuilder.CreateTable(
                name: "ExternalDoctor",
                columns: table => new
                {
                    ExternalDoctorID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ClinicianTypeID_FK = table.Column<int>(type: "integer", nullable: true),
                    Contact = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    AccessHospitalID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalDoctor", x => x.ExternalDoctorID);
                    table.ForeignKey(
                        name: "FK_ExternalDoctor_UserType",
                        column: x => x.ClinicianTypeID_FK,
                        principalTable: "UserType",
                        principalColumn: "UserTypeID");
                });

            migrationBuilder.CreateTable(
                name: "MailSettingsMsgToUserType",
                columns: table => new
                {
                    MailSetting_FK = table.Column<int>(type: "integer", nullable: false),
                    UserTypeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailSettingsMsgToUserType", x => new { x.MailSetting_FK, x.UserTypeID_FK });
                    table.ForeignKey(
                        name: "FK_MailSettingsMsgToUserType_UserType",
                        column: x => x.UserTypeID_FK,
                        principalTable: "UserType",
                        principalColumn: "UserTypeID");
                    table.ForeignKey(
                        name: "FK_MailSettingsMsgToUserType_id",
                        column: x => x.MailSetting_FK,
                        principalTable: "MailSettings",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicationConsumeAttachment",
                columns: table => new
                {
                    PatientMedicationConsumeAttachmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientMedicationConsumeID_FK = table.Column<int>(type: "integer", nullable: false),
                    Filename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Physical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsEndDate = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicationConsumeAttachment", x => x.PatientMedicationConsumeAttachmentID);
                    table.ForeignKey(
                        name: "FK_PatientMedicationConsumeAttachment_PatientMedicationConsume",
                        column: x => x.PatientMedicationConsumeID_FK,
                        principalTable: "PatientMedicationConsume",
                        principalColumn: "PatientMedicationConsumeID");
                });

            migrationBuilder.CreateTable(
                name: "AuditTrail",
                columns: table => new
                {
                    AuditTrailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuditAction = table.Column<string>(type: "text", nullable: false, defaultValue: ""),
                    Module = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Event = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IPAddress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    APIRequest = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrail", x => x.AuditTrailId);
                });

            migrationBuilder.CreateTable(
                name: "BillingInvoice",
                columns: table => new
                {
                    BillingInvoiceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    InvoiceDueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CaseNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: true),
                    Consumable = table.Column<bool>(type: "boolean", nullable: true),
                    SendEmail = table.Column<bool>(type: "boolean", nullable: true),
                    EmailPatient = table.Column<bool>(type: "boolean", nullable: true),
                    EmailTo = table.Column<string>(type: "text", nullable: true),
                    EmailCC = table.Column<string>(type: "text", nullable: true),
                    EmailBCC = table.Column<string>(type: "text", nullable: true),
                    CurrencyID_FK = table.Column<int>(type: "integer", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    GroupNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Version = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingInvoice", x => x.BillingInvoiceID);
                    table.ForeignKey(
                        name: "FK_BillingInvoice_Code",
                        column: x => x.CurrencyID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "BillingInvoiceConsumable",
                columns: table => new
                {
                    BillingInvoiceConsumableID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BillingInvoiceID_FK = table.Column<int>(type: "integer", nullable: false),
                    ItemID_FK = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingInvoiceConsumable", x => x.BillingInvoiceConsumableID);
                    table.ForeignKey(
                        name: "FK_BillingInvoiceConsumable_BillingInvoice",
                        column: x => x.BillingInvoiceID_FK,
                        principalTable: "BillingInvoice",
                        principalColumn: "BillingInvoiceID");
                    table.ForeignKey(
                        name: "FK_BillingInvoiceConsumable_Item",
                        column: x => x.ItemID_FK,
                        principalTable: "Item",
                        principalColumn: "ItemID");
                });

            migrationBuilder.CreateTable(
                name: "BillingInvoiceService",
                columns: table => new
                {
                    BillingInvoiceServiceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BillingInvoiceID_FK = table.Column<int>(type: "integer", nullable: false),
                    ProposalID_FK = table.Column<int>(type: "integer", nullable: true),
                    ServiceID_FK = table.Column<int>(type: "integer", nullable: false),
                    UnitCost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Session = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingInvoiceService", x => x.BillingInvoiceServiceID);
                    table.ForeignKey(
                        name: "FK_BillingInvoiceService_BillingInvoice",
                        column: x => x.BillingInvoiceID_FK,
                        principalTable: "BillingInvoice",
                        principalColumn: "BillingInvoiceID");
                    table.ForeignKey(
                        name: "FK_BillingInvoiceService_ServiceForBilling",
                        column: x => x.ServiceID_FK,
                        principalTable: "ServiceForBilling",
                        principalColumn: "ServiceForBillingID");
                });

            migrationBuilder.CreateTable(
                name: "BillingProposal",
                columns: table => new
                {
                    BillingProposalID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    ProposalNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SendEmail = table.Column<bool>(type: "boolean", nullable: true),
                    EmailPatient = table.Column<bool>(type: "boolean", nullable: true),
                    EmailTo = table.Column<string>(type: "text", nullable: true),
                    EmailCC = table.Column<string>(type: "text", nullable: true),
                    EmailBCC = table.Column<string>(type: "text", nullable: true),
                    CurrencyID_FK = table.Column<int>(type: "integer", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    GroupNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Version = table.Column<short>(type: "smallint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ProposalType = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingProposal", x => x.BillingProposalID);
                    table.ForeignKey(
                        name: "FK_BillingProposal_Code",
                        column: x => x.CurrencyID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "BillingProposalService",
                columns: table => new
                {
                    BillingProposalServiceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BillingProposalID_FK = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UnitCost = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Duration1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Duration2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ServiceDescription = table.Column<string>(type: "text", nullable: true),
                    Visit = table.Column<int>(type: "integer", nullable: false),
                    Session = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    SessionUsed = table.Column<int>(type: "integer", nullable: false),
                    ServiceID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingProposalService", x => x.BillingProposalServiceID);
                    table.ForeignKey(
                        name: "FK_BillingProposalService_BillingProposal",
                        column: x => x.BillingProposalID_FK,
                        principalTable: "BillingProposal",
                        principalColumn: "BillingProposalID");
                    table.ForeignKey(
                        name: "FK_BillingProposalService_ServiceForBilling",
                        column: x => x.ServiceID_FK,
                        principalTable: "ServiceForBilling",
                        principalColumn: "ServiceForBillingID");
                });

            migrationBuilder.CreateTable(
                name: "CarePlan",
                columns: table => new
                {
                    CarePlanID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    DiagnosisID_FK = table.Column<int>(type: "integer", nullable: true),
                    CarePlanStatusID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    CarePlanDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    CarePlanName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: true),
                    PersonInCharge = table.Column<int>(type: "integer", nullable: true),
                    CarePlanType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Remark = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlan", x => x.CarePlanID);
                    table.ForeignKey(
                        name: "FK_CarePlan_CarePlanStatus",
                        column: x => x.CarePlanStatusID_FK,
                        principalTable: "CarePlanStatus",
                        principalColumn: "CarePlanStatusID");
                    table.ForeignKey(
                        name: "FK_CarePlan_Diagnosis",
                        column: x => x.DiagnosisID_FK,
                        principalTable: "Diagnosis",
                        principalColumn: "DiagnosisID");
                });

            migrationBuilder.CreateTable(
                name: "CarePlanSub",
                columns: table => new
                {
                    CarePlanSubID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarePlanID_FK = table.Column<int>(type: "integer", nullable: false),
                    SubCarePlanName = table.Column<int>(type: "integer", nullable: false),
                    Goal = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PersonInCharge = table.Column<int>(type: "integer", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    GroupCode = table.Column<int>(type: "integer", nullable: true),
                    CarePlanGroupName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: true),
                    InterventionStatus = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    GoalStatus = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanDetail", x => x.CarePlanSubID);
                    table.ForeignKey(
                        name: "FK_CarePlanSub_CarePlan",
                        column: x => x.CarePlanID_FK,
                        principalTable: "CarePlan",
                        principalColumn: "CarePlanID");
                });

            migrationBuilder.CreateTable(
                name: "CarePlanDetail",
                columns: table => new
                {
                    CarePlanDetailID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarePlanSubID_FK = table.Column<int>(type: "integer", nullable: false),
                    SystemID_FK = table.Column<int>(type: "integer", nullable: false),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    DiseaseSubInfoID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanDetail_", x => x.CarePlanDetailID);
                    table.ForeignKey(
                        name: "FK_CarePlanDetail_CarePlanSub",
                        column: x => x.CarePlanSubID_FK,
                        principalTable: "CarePlanSub",
                        principalColumn: "CarePlanSubID");
                    table.ForeignKey(
                        name: "FK_CarePlanDetail_DiseaseForDisease",
                        column: x => x.DiseaseID_FK,
                        principalTable: "Disease",
                        principalColumn: "DiseaseID");
                    table.ForeignKey(
                        name: "FK_CarePlanDetail_SystemForDisease",
                        column: x => x.SystemID_FK,
                        principalTable: "SystemForDisease",
                        principalColumn: "SystemID");
                });

            migrationBuilder.CreateTable(
                name: "CarePlanSubActivity",
                columns: table => new
                {
                    CarePlanSubID_FK = table.Column<int>(type: "integer", nullable: false),
                    ActivityID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanSubActivity", x => new { x.CarePlanSubID_FK, x.ActivityID_FK });
                    table.ForeignKey(
                        name: "FK_CarePlanSubActivity_Activity",
                        column: x => x.ActivityID_FK,
                        principalTable: "Activity",
                        principalColumn: "ActivityID");
                    table.ForeignKey(
                        name: "FK_CarePlanSubActivity_CarePlanSub",
                        column: x => x.CarePlanSubID_FK,
                        principalTable: "CarePlanSub",
                        principalColumn: "CarePlanSubID");
                });

            migrationBuilder.CreateTable(
                name: "CarePlanSubCPGoals",
                columns: table => new
                {
                    CarePlanSubID_FK = table.Column<int>(type: "integer", nullable: false),
                    CPGoalsID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanSubCPGoals", x => new { x.CarePlanSubID_FK, x.CPGoalsID_FK });
                    table.ForeignKey(
                        name: "FK_CarePlanSubCPGoals_CPGoals",
                        column: x => x.CPGoalsID_FK,
                        principalTable: "CPGoals",
                        principalColumn: "CPGoalsID");
                    table.ForeignKey(
                        name: "FK_CarePlanSubCPGoals_CarePlanSub",
                        column: x => x.CarePlanSubID_FK,
                        principalTable: "CarePlanSub",
                        principalColumn: "CarePlanSubID");
                });

            migrationBuilder.CreateTable(
                name: "CarePlanSubGoal",
                columns: table => new
                {
                    CarePlanSubGoalID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarePlanSubID_FK = table.Column<int>(type: "integer", nullable: false),
                    ScoreTypeID = table.Column<int>(type: "integer", nullable: true),
                    OperatorID = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    Score2 = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    CarePlanSubGoalName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanSubGoal", x => x.CarePlanSubGoalID);
                    table.ForeignKey(
                        name: "FK_CarePlanSubGoal_CarePlanSub",
                        column: x => x.CarePlanSubID_FK,
                        principalTable: "CarePlanSub",
                        principalColumn: "CarePlanSubID");
                    table.ForeignKey(
                        name: "FK_CarePlanSubGoal_Disease",
                        column: x => x.DiseaseID_FK,
                        principalTable: "Disease",
                        principalColumn: "DiseaseID");
                });

            migrationBuilder.CreateTable(
                name: "CarePlanSubIntervention",
                columns: table => new
                {
                    CarePlanSubID_FK = table.Column<int>(type: "integer", nullable: false),
                    InterventionID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanSubIntervention", x => new { x.CarePlanSubID_FK, x.InterventionID_FK });
                    table.ForeignKey(
                        name: "FK_CarePlanSubIntervention_CarePlanSub",
                        column: x => x.CarePlanSubID_FK,
                        principalTable: "CarePlanSub",
                        principalColumn: "CarePlanSubID");
                    table.ForeignKey(
                        name: "FK_CarePlanSubIntervention_Intervention",
                        column: x => x.InterventionID_FK,
                        principalTable: "Intervention",
                        principalColumn: "InterventionID");
                });

            migrationBuilder.CreateTable(
                name: "CarePlanSubProblemList",
                columns: table => new
                {
                    CarePlanSubProblemListID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarePlanSubID_FK = table.Column<int>(type: "integer", nullable: false),
                    ProblemListID_FK = table.Column<int>(type: "integer", nullable: false),
                    PLReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PLStatus = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    PersonInChargeID_FK = table.Column<int>(type: "integer", nullable: true),
                    TypeOfGoal = table.Column<int>(type: "integer", nullable: true),
                    Goal = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanSubProblemList", x => x.CarePlanSubProblemListID);
                    table.ForeignKey(
                        name: "FK_CarePlanSubProblemList_CarePlanSub",
                        column: x => x.CarePlanSubID_FK,
                        principalTable: "CarePlanSub",
                        principalColumn: "CarePlanSubID");
                    table.ForeignKey(
                        name: "FK_CarePlanSubProblemList_ProblemList",
                        column: x => x.ProblemListID_FK,
                        principalTable: "ProblemList",
                        principalColumn: "ProblemListID");
                });

            migrationBuilder.CreateTable(
                name: "CarePlanSubProblemListGoal",
                columns: table => new
                {
                    CarePlanSubProblemListGoalID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarePlanSubProblemListID_FK = table.Column<int>(type: "integer", nullable: false),
                    Goal = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Action = table.Column<int>(type: "integer", nullable: true),
                    ScoreTypeID = table.Column<int>(type: "integer", nullable: true),
                    OperatorID = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    Score2 = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    ProblemListGoalID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanSubProblemListGoal", x => x.CarePlanSubProblemListGoalID);
                    table.ForeignKey(
                        name: "FK_CarePlanSubProblemListGoal_CarePlanSubProblemList",
                        column: x => x.CarePlanSubProblemListID_FK,
                        principalTable: "CarePlanSubProblemList",
                        principalColumn: "CarePlanSubProblemListID");
                    table.ForeignKey(
                        name: "FK_CarePlanSubProblemListGoal_Operator",
                        column: x => x.OperatorID,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CarePlanSubProblemListGoal_ProblemListGoal",
                        column: x => x.ProblemListGoalID_FK,
                        principalTable: "ProblemListGoal",
                        principalColumn: "ProblemListGoalID");
                    table.ForeignKey(
                        name: "FK_CarePlanSubProblemListGoal_ScoreType",
                        column: x => x.ScoreTypeID,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "CareReport",
                columns: table => new
                {
                    CareReportID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    CareReportType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Status = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    SectionStatus = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    Memo1 = table.Column<string>(type: "text", nullable: true),
                    Memo2 = table.Column<string>(type: "text", nullable: true),
                    Memo3 = table.Column<string>(type: "text", nullable: true),
                    Memo4 = table.Column<string>(type: "text", nullable: true),
                    Memo5 = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    CarePlanID_FK = table.Column<int>(type: "integer", nullable: true),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: true),
                    VisitStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VisitEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VisitedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    Subject = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    VitalSignID_FK = table.Column<int>(type: "integer", nullable: true),
                    Pain = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    PainScaleType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    PainLevel = table.Column<int>(type: "integer", nullable: true),
                    PainDescriptionID_FK = table.Column<int>(type: "integer", nullable: true),
                    SiteOfPain = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TypeOfPain = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    AggravatingFactor = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RelievingFactor = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Frequency = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    PainRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    NeuroOrMental = table.Column<int>(type: "integer", nullable: true),
                    Eyes = table.Column<int>(type: "integer", nullable: true),
                    VerbalResponse = table.Column<int>(type: "integer", nullable: true),
                    MotorResponse = table.Column<int>(type: "integer", nullable: true),
                    LeftEyeSize = table.Column<int>(type: "integer", nullable: true),
                    LeftEyeReaction = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    RightEyeSize = table.Column<int>(type: "integer", nullable: true),
                    RightEyeReaction = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    NeuroRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SectionRequired = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    PsychoEmotionalSpiritual = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PsychoRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AirwayBreathingID_FK = table.Column<int>(type: "integer", nullable: true),
                    CoughID_FK = table.Column<int>(type: "integer", nullable: true),
                    O2AidID_FK = table.Column<int>(type: "integer", nullable: true),
                    O2LitresPercent = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    O2Litres = table.Column<decimal>(type: "numeric(4,1)", nullable: true),
                    Sunction = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CoughAmount = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Color = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ColorOthers = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Consistency = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Nebuliser = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    AirwayBreathingRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CirculationID_FK = table.Column<int>(type: "integer", nullable: true),
                    LowerEyelidsID_FK = table.Column<int>(type: "integer", nullable: true),
                    LipsID_FK = table.Column<int>(type: "integer", nullable: true),
                    CapillaryRefillID_FK = table.Column<int>(type: "integer", nullable: true),
                    PeripheralPulsesRadialID_FK = table.Column<int>(type: "integer", nullable: true),
                    PeripheralPulsesPedalID_FK = table.Column<int>(type: "integer", nullable: true),
                    CirculationRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SleepRestID_FK = table.Column<int>(type: "integer", nullable: true),
                    DayNightReversal = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    SleepRestRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TemperatureID_FK = table.Column<int>(type: "integer", nullable: true),
                    TemperatureInterventions = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TemperatureRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    BowelCareID_FK = table.Column<int>(type: "integer", nullable: true),
                    NoOfBowelTimes = table.Column<int>(type: "integer", nullable: true),
                    BowelType = table.Column<int>(type: "integer", nullable: true),
                    HowManyDaysBNO = table.Column<int>(type: "integer", nullable: true),
                    BowelInterventions = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Stoma = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    StomaCreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    StomaSizeLength = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    StomaSizeBreath = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    StomaColour = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StomaAppearance = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StomaProtrusion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StomaPeristomalSkin = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StomaEffluent = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StomaAmountOfOutput = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StomaOstomyProductUsed = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    StomaReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    BowelRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    BladderCareID_FK = table.Column<int>(type: "integer", nullable: true),
                    BladderCareTimes = table.Column<int>(type: "integer", nullable: true),
                    BladderCareNPU = table.Column<int>(type: "integer", nullable: true),
                    DiapersID_FK = table.Column<int>(type: "integer", nullable: true),
                    TypeOfUrine = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    CharacteristicOfUrine = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Dysuria = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    BladderCareRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PersonalHygieneRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CareReportRehabilitationID_FK = table.Column<int>(type: "integer", nullable: true),
                    EnvironmentRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ACP = table.Column<bool>(type: "boolean", nullable: true),
                    ACP_DoneDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ACP_ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    OtherTreatment = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    OtherTreatmentOther = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OtherTreatmentRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CareReportSystemInfoID_FK = table.Column<int>(type: "integer", nullable: true),
                    SectionRequireInput = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    PatientNutritionID_FK = table.Column<int>(type: "integer", nullable: true),
                    SkinAndWoundCare = table.Column<string>(type: "character varying(2000)", unicode: false, maxLength: 2000, nullable: true),
                    PersonalHygiene = table.Column<string>(type: "character varying(2000)", unicode: false, maxLength: 2000, nullable: true),
                    Environment = table.Column<string>(type: "character varying(2000)", unicode: false, maxLength: 2000, nullable: true),
                    BreathSounds = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BowelSounds = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    HeartSounds = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareReport", x => x.CareReportID);
                    table.ForeignKey(
                        name: "FK_CareReport_CarePlan",
                        column: x => x.CarePlanID_FK,
                        principalTable: "CarePlan",
                        principalColumn: "CarePlanID");
                    table.ForeignKey(
                        name: "FK_CareReport_CareReport",
                        column: x => x.CareReportID_FK,
                        principalTable: "CareReport",
                        principalColumn: "CareReportID");
                    table.ForeignKey(
                        name: "FK_CareReport_CareReportRehabilitation",
                        column: x => x.CareReportRehabilitationID_FK,
                        principalTable: "CareReportRehabilitation",
                        principalColumn: "CareReportRehabilitationID");
                    table.ForeignKey(
                        name: "FK_CareReport_Code",
                        column: x => x.PainDescriptionID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code1",
                        column: x => x.AirwayBreathingID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code10",
                        column: x => x.SleepRestID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code11",
                        column: x => x.TemperatureID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code14",
                        column: x => x.BowelCareID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code15",
                        column: x => x.BladderCareID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code16",
                        column: x => x.DiapersID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code2",
                        column: x => x.CoughID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code3",
                        column: x => x.O2AidID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code4",
                        column: x => x.CirculationID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code5",
                        column: x => x.LowerEyelidsID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code6",
                        column: x => x.LipsID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code7",
                        column: x => x.CapillaryRefillID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code8",
                        column: x => x.PeripheralPulsesRadialID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_Code9",
                        column: x => x.PeripheralPulsesPedalID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_CareReport_PatientNutrition",
                        column: x => x.PatientNutritionID_FK,
                        principalTable: "PatientNutrition",
                        principalColumn: "PatientNutritionID");
                });

            migrationBuilder.CreateTable(
                name: "PatientAccessLine",
                columns: table => new
                {
                    PatientAccessLineID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessLine = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: false),
                    DateOfInsertion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Patent = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    PatentReSited = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    PatentReSitedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PatentSite = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    DateDueForChange = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AccessLineRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAccessLine", x => x.PatientAccessLineID);
                    table.ForeignKey(
                        name: "FK_PatientAccessLine_CareReport",
                        column: x => x.CareReportID_FK,
                        principalTable: "CareReport",
                        principalColumn: "CareReportID");
                });

            migrationBuilder.CreateTable(
                name: "CareReportSocialSupport",
                columns: table => new
                {
                    CareReportSocialSupportID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: false),
                    PatientSocialSupportID_FK = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareReportSocialSupport", x => x.CareReportSocialSupportID);
                    table.ForeignKey(
                        name: "FK_CareReportSocialSupport_CareReport",
                        column: x => x.CareReportID_FK,
                        principalTable: "CareReport",
                        principalColumn: "CareReportID");
                });

            migrationBuilder.CreateTable(
                name: "CareReportSystemInfo",
                columns: table => new
                {
                    CareReportSystemInfoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsUpdatePrimaryDoctor = table.Column<bool>(type: "boolean", nullable: true),
                    PrimaryDoctorUserID_FK = table.Column<int>(type: "integer", nullable: true),
                    PrimaryDoctorName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsUpdateSecondaryDoctor = table.Column<bool>(type: "boolean", nullable: true),
                    SecondaryDoctorUserID_FK = table.Column<int>(type: "integer", nullable: true),
                    SecondaryDoctorName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsUpdateKeyPerson1 = table.Column<bool>(type: "boolean", nullable: true),
                    KeyPerson1UserID_FK = table.Column<int>(type: "integer", nullable: true),
                    IsUpdateKeyPerson2 = table.Column<bool>(type: "boolean", nullable: true),
                    KeyPerson2UserID_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsUpdateFamily = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareReportSystemInfo", x => x.CareReportSystemInfoID);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    ChatID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Attachment = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Attachment_Physical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    ParentID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Family = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ChatID);
                    table.ForeignKey(
                        name: "FK_Chat_Chat1",
                        column: x => x.ParentID_FK,
                        principalTable: "Chat",
                        principalColumn: "ChatID");
                });

            migrationBuilder.CreateTable(
                name: "Enquiry",
                columns: table => new
                {
                    EnquiryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CareManagerAssignedID_FK = table.Column<int>(type: "integer", nullable: true),
                    EnquirySourceID_FK = table.Column<int>(type: "integer", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RaceID_FK = table.Column<int>(type: "integer", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PreferredLanguageID_FK = table.Column<int>(type: "integer", nullable: true),
                    GenderID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientAddress1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PatientAddress2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PatientAddress3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    NameOfCaller = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ContactNumberOfCaller = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EmailOfCaller = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    PreferredAppointmentDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    MedicalHistory = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CaregiverAtHomeID_FK = table.Column<int>(type: "integer", nullable: true),
                    ServicesRequiredID_FK = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    OtherRace = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OtherPreferredLanguage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UserOrganizationID_FK = table.Column<int>(type: "integer", nullable: true),
                    CaseNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OrderID = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiry", x => x.EnquiryID);
                    table.ForeignKey(
                        name: "FK_Enquiry_CaregiverAtHome",
                        column: x => x.CaregiverAtHomeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Enquiry_Gender",
                        column: x => x.GenderID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Enquiry_Organization",
                        column: x => x.UserOrganizationID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Enquiry_PreferredLanguage",
                        column: x => x.PreferredLanguageID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Enquiry_Race",
                        column: x => x.RaceID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Enquiry_ServicesRequired",
                        column: x => x.ServicesRequiredID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Enquiry_Source",
                        column: x => x.EnquirySourceID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "EnquiryAttachment",
                columns: table => new
                {
                    EnquiryAttachmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnquiryID_FK = table.Column<int>(type: "integer", nullable: false),
                    Filename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Physical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryAttachment", x => x.EnquiryAttachmentID);
                    table.ForeignKey(
                        name: "FK_EnquiryAttachment_Enquiry",
                        column: x => x.EnquiryID_FK,
                        principalTable: "Enquiry",
                        principalColumn: "EnquiryID");
                });

            migrationBuilder.CreateTable(
                name: "EnquiryLanguage",
                columns: table => new
                {
                    EnquiryID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryLanguage", x => new { x.EnquiryID_FK, x.CodeID_FK });
                    table.ForeignKey(
                        name: "FK_EnquiryLanguage_Code",
                        column: x => x.CodeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_EnquiryLanguage_Enquiry",
                        column: x => x.EnquiryID_FK,
                        principalTable: "Enquiry",
                        principalColumn: "EnquiryID");
                });

            migrationBuilder.CreateTable(
                name: "EnquiryServicesRequired",
                columns: table => new
                {
                    EnquiryID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryServicesRequired", x => new { x.EnquiryID_FK, x.CodeID_FK });
                    table.ForeignKey(
                        name: "FK_EnquiryServicesRequired_Code",
                        column: x => x.CodeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_EnquiryServicesRequired_Enquiry",
                        column: x => x.EnquiryID_FK,
                        principalTable: "Enquiry",
                        principalColumn: "EnquiryID");
                });

            migrationBuilder.CreateTable(
                name: "EnquiryConfig",
                columns: table => new
                {
                    EnquiryConfigID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SCMID_FK = table.Column<int>(type: "integer", nullable: true),
                    EmailContent = table.Column<string>(type: "text", nullable: true),
                    EscalatingPersonID_FK = table.Column<int>(type: "integer", nullable: true),
                    EscalationPeriod = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    EscalationEmail = table.Column<string>(type: "text", nullable: true),
                    EmailtoCMContent = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryConfig", x => x.EnquiryConfigID);
                });

            migrationBuilder.CreateTable(
                name: "EnquiryEscPerson",
                columns: table => new
                {
                    EnquiryConfigID = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryEscPerson", x => new { x.EnquiryConfigID, x.UserID_FK });
                    table.ForeignKey(
                        name: "FK_EnquiryEscPerson_EnquiryConfig",
                        column: x => x.EnquiryConfigID,
                        principalTable: "EnquiryConfig",
                        principalColumn: "EnquiryConfigID");
                });

            migrationBuilder.CreateTable(
                name: "EnquirySCM",
                columns: table => new
                {
                    EnquiryConfigID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquirySCM", x => new { x.EnquiryConfigID_FK, x.UserID_FK });
                    table.ForeignKey(
                        name: "FK_EnquirySCM_EnquiryConfig",
                        column: x => x.EnquiryConfigID_FK,
                        principalTable: "EnquiryConfig",
                        principalColumn: "EnquiryConfigID");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EventTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    PeriodTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    FromDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ToDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserCategory_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Event_Code1",
                        column: x => x.EventTypeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Event_Code2",
                        column: x => x.PeriodTypeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Event_UserCategory",
                        column: x => x.UserCategory_FK,
                        principalTable: "UserCategory",
                        principalColumn: "UserCategoryID");
                });

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    EventUserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => x.EventUserID);
                    table.ForeignKey(
                        name: "FK_EventUser_Event",
                        column: x => x.EventID_FK,
                        principalTable: "Event",
                        principalColumn: "EventID");
                });

            migrationBuilder.CreateTable(
                name: "EventUserLog",
                columns: table => new
                {
                    EventUserLogID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUserLog", x => x.EventUserLogID);
                    table.ForeignKey(
                        name: "FK_EventUserLog_Event",
                        column: x => x.EventID_FK,
                        principalTable: "Event",
                        principalColumn: "EventID");
                });

            migrationBuilder.CreateTable(
                name: "ICAWoundCare",
                columns: table => new
                {
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICAWoundCare", x => new { x.InitialCareAssessmentID_FK, x.CodeID_FK });
                    table.ForeignKey(
                        name: "FK_ICAWoundCare_Code",
                        column: x => x.CodeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "InitialCareAssessment",
                columns: table => new
                {
                    InitialCareAssessmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    GeneralCondition = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Physique = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ConsciousLevel = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    EmotionalState = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    OtherEmotionalState = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Breathing = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    OtherBreathing = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    O2Litres = table.Column<decimal>(type: "numeric(3,1)", nullable: true),
                    O2LitresVia = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    TracheostomyDateInserted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TracheostomySize = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    TracheostomyType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsTracheostomyInnerCannula = table.Column<bool>(type: "boolean", nullable: true),
                    TracheostomyNextReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Cough = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Vision = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    VisionImpairedLeft = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedRight = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    VisionImpairedGlaucoma = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedCataract = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedGlaucomaLeft = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedGlaucomaRight = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedGlaucomaRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    VisionImpairedCataractLeft = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedCataractRight = table.Column<bool>(type: "boolean", nullable: true),
                    VisionImpairedCataractRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Hearing = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    HearingImpairedLeft = table.Column<bool>(type: "boolean", nullable: true),
                    HearingImpairedRight = table.Column<bool>(type: "boolean", nullable: true),
                    HearingImpairedRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    HearingImpairedWithHearingAidLeft = table.Column<bool>(type: "boolean", nullable: true),
                    HearingImpairedWithHearingAidRight = table.Column<bool>(type: "boolean", nullable: true),
                    HearingImpairedWithHearingAidRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    BowelHabitsTimes = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    BowelHabitsDays = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    BowelType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Stoma = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    StomaCreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    StomaSizeLength = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    StomaSizeBreath = table.Column<decimal>(type: "numeric(4,2)", nullable: true),
                    StomaColour = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StomaAppearance = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StomaProtrusion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StomaPeristomalSkin = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StomaEffluent = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StomaAmountOfOutput = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StomaOstomyProductUsed = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    StomaReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UrinaryFrequencyTimes = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    UrinaryFrequencyDay = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    UrinaryTypes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Catheter = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CatheterDateInserted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CatheterType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CatheterSize = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CatheterNextReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LMP = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UseOfDrug = table.Column<bool>(type: "boolean", nullable: true),
                    UseOfDrugExplain = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    MedicalHistory = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    OralCavityAssessmentScore1 = table.Column<int>(type: "integer", nullable: true),
                    OralCavityAssessmentScore2 = table.Column<int>(type: "integer", nullable: true),
                    OralCavityAssessmentScore3 = table.Column<int>(type: "integer", nullable: true),
                    OralCavityAssessmentScore4 = table.Column<int>(type: "integer", nullable: true),
                    OralCavityAssessmentScore5 = table.Column<int>(type: "integer", nullable: true),
                    OralCavityAssessmentScore6 = table.Column<int>(type: "integer", nullable: true),
                    MilkFeedRx = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    EmotionalYesNo = table.Column<bool>(type: "boolean", nullable: true),
                    EmotionalYes = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    HowCanIHelp = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LostInterest = table.Column<bool>(type: "boolean", nullable: true),
                    LostInterestYes = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    HowDoYouScope = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DifficultyCoping = table.Column<bool>(type: "boolean", nullable: true),
                    DifficultyCopingYes = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Depressed = table.Column<bool>(type: "boolean", nullable: true),
                    GetSupport = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ReferCounsellor = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    PatientProfileID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientReferralID_FK = table.Column<int>(type: "integer", nullable: true),
                    SectionStatus = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    PatientAdditionalInfoID_FK = table.Column<int>(type: "integer", nullable: true),
                    VitalSignID_FK = table.Column<int>(type: "integer", nullable: true),
                    WoundAssessmentScore1 = table.Column<int>(type: "integer", nullable: true),
                    WoundAssessmentScore2 = table.Column<int>(type: "integer", nullable: true),
                    WoundAssessmentScore3 = table.Column<int>(type: "integer", nullable: true),
                    WoundAssessmentScore4 = table.Column<int>(type: "integer", nullable: true),
                    WoundAssessmentScore5 = table.Column<int>(type: "integer", nullable: true),
                    WoundAssessmentScore6 = table.Column<int>(type: "integer", nullable: true),
                    PatientMedicationID_FK = table.Column<int>(type: "integer", nullable: true),
                    HomeFacilityVentilation = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityCooking = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityRefrigeration = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityToileting = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityStairs = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityCommunication = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityAffectCaregiver = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityAffectCareManager = table.Column<bool>(type: "boolean", nullable: true),
                    HomeFacilityRemarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsRequirePalliativeCare = table.Column<bool>(type: "boolean", nullable: true),
                    PainLevel = table.Column<int>(type: "integer", nullable: true),
                    TirednessLevel = table.Column<int>(type: "integer", nullable: true),
                    DrowsinessLevel = table.Column<int>(type: "integer", nullable: true),
                    NauseaLevel = table.Column<int>(type: "integer", nullable: true),
                    LackOfAppetiteLevel = table.Column<int>(type: "integer", nullable: true),
                    ShortnessOfBreath = table.Column<int>(type: "integer", nullable: true),
                    DepressionLevel = table.Column<int>(type: "integer", nullable: true),
                    AnxietyLevel = table.Column<int>(type: "integer", nullable: true),
                    BestWellbeing = table.Column<int>(type: "integer", nullable: true),
                    Faith = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsReligious = table.Column<bool>(type: "boolean", nullable: true),
                    GiveMeaningToLife = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MakeSense = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsBeliefImportant = table.Column<bool>(type: "boolean", nullable: true),
                    InfluenceTakeCare = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BeliefInfluenced = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RoleOfBeliefForInfluence = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsPartOfCommunity = table.Column<bool>(type: "boolean", nullable: true),
                    SupportTo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RoleOfBeliefForCommunity = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PersonalConcern = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AddressIssue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Concern = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TalkToSomeone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OralCavityAssessmentScore7 = table.Column<int>(type: "integer", nullable: true),
                    OralCavityAssessmentScore8 = table.Column<int>(type: "integer", nullable: true),
                    PatientNutritionID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientRAFID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientMBIID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientMFSID_FK = table.Column<int>(type: "integer", nullable: true),
                    VisitDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VSOnSetDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    painOnSetDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VSQuality = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    VSPainFrequency = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    VSIntermittent = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    VSLocation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    VSPrecipitatingFactors = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    VSRelievingFactors = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    VSPainFrequencyIntermittentNumber = table.Column<int>(type: "integer", nullable: true),
                    CAAlertness = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CACommunication = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CADementia = table.Column<bool>(type: "boolean", nullable: true),
                    CAdateAndTime = table.Column<bool>(type: "boolean", nullable: true),
                    CAPerson = table.Column<bool>(type: "boolean", nullable: true),
                    CAPlace = table.Column<bool>(type: "boolean", nullable: true),
                    CASituation = table.Column<bool>(type: "boolean", nullable: true),
                    HearingAid = table.Column<bool>(type: "boolean", nullable: true),
                    ChestSymmetry = table.Column<bool>(type: "boolean", nullable: true),
                    AbdomenSymmetry = table.Column<bool>(type: "boolean", nullable: true),
                    AnySkinIssue = table.Column<bool>(type: "boolean", nullable: true),
                    PressureInjuries = table.Column<bool>(type: "boolean", nullable: true),
                    ApicalPulse = table.Column<int>(type: "integer", nullable: true),
                    SkinType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SkinIssue = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SkinTurgor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BreathSounds = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BowelSounds = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Percussion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Palpation = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TenderNGuarding = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Remark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LeftUpperLimbStrength = table.Column<int>(type: "integer", nullable: true),
                    RightUpperLimbStrength = table.Column<int>(type: "integer", nullable: true),
                    LeftLowerLimbStrength = table.Column<int>(type: "integer", nullable: true),
                    RightLowerLimbStrength = table.Column<int>(type: "integer", nullable: true),
                    MobilityStatus = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AssistiveAids = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Incontinence = table.Column<bool>(type: "boolean", nullable: true),
                    IncontinenceType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UrineConsistency = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UrineColour = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    StoolsType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    VisionSpectacles = table.Column<bool>(type: "boolean", nullable: true),
                    OxygenRequired = table.Column<bool>(type: "boolean", nullable: true),
                    Sputum = table.Column<bool>(type: "boolean", nullable: true),
                    SuctioningRequired = table.Column<bool>(type: "boolean", nullable: true),
                    OxygenLMin = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    OxygenType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    OxygenRemark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Oralhealth = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Teeth = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    AblePassUrine = table.Column<bool>(type: "boolean", nullable: true),
                    NutritionalImbalance = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialCareAssessment", x => x.InitialCareAssessmentID);
                    table.ForeignKey(
                        name: "FK_InitialCareAssessment_PatientAdditionalInfo",
                        column: x => x.PatientAdditionalInfoID_FK,
                        principalTable: "PatientAdditionalInfo",
                        principalColumn: "PatientAdditionalInfoID");
                    table.ForeignKey(
                        name: "FK_InitialCareAssessment_PatientMedication",
                        column: x => x.PatientMedicationID_FK,
                        principalTable: "PatientMedication",
                        principalColumn: "PatientMedicationID");
                    table.ForeignKey(
                        name: "FK_InitialCareAssessment_PatientNutrition",
                        column: x => x.PatientNutritionID_FK,
                        principalTable: "PatientNutrition",
                        principalColumn: "PatientNutritionID");
                    table.ForeignKey(
                        name: "FK_InitialCareAssessment_PatientProfile",
                        column: x => x.PatientProfileID_FK,
                        principalTable: "PatientProfile",
                        principalColumn: "PatientProfileID");
                });

            migrationBuilder.CreateTable(
                name: "InitialCareAssessmentAttachment",
                columns: table => new
                {
                    InitialCareAssessmentAttachmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: false),
                    Filename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Physical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsReferralAssessment = table.Column<bool>(type: "boolean", nullable: false),
                    IsDischargeAssessment = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialCareAssessmentAttachment", x => x.InitialCareAssessmentAttachmentID);
                    table.ForeignKey(
                        name: "FK_InitialCareAssessmentAttachment_InitialCareAssessment",
                        column: x => x.InitialCareAssessmentID_FK,
                        principalTable: "InitialCareAssessment",
                        principalColumn: "InitialCareAssessmentID");
                });

            migrationBuilder.CreateTable(
                name: "InitialCareAssessmentSpecialInstruction",
                columns: table => new
                {
                    InitialCareAssessmentSpecialInstructionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Instructions = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialCareAssessmentSpecialInstruction", x => x.InitialCareAssessmentSpecialInstructionID);
                    table.ForeignKey(
                        name: "FK_InitialCareAssessmentSpecialInstruction_InitialCareAssessment",
                        column: x => x.InitialCareAssessmentID_FK,
                        principalTable: "InitialCareAssessment",
                        principalColumn: "InitialCareAssessmentID");
                });

            migrationBuilder.CreateTable(
                name: "MobileAppVersioning",
                columns: table => new
                {
                    MobileVersionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeviceType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Version = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileAppVersioning", x => x.MobileVersionId);
                });

            migrationBuilder.CreateTable(
                name: "MultiDisciplinaryMeeting",
                columns: table => new
                {
                    MultiDisciplinaryMeetingID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    IssuesOverall = table.Column<string>(type: "text", nullable: false),
                    AssignedToFollowUp = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiDisciplinaryMeeting", x => x.MultiDisciplinaryMeetingID);
                });

            migrationBuilder.CreateTable(
                name: "MultiDisciplinaryMeetingDetail",
                columns: table => new
                {
                    MultiDisciplinaryMeetingDetailID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MultiDisciplinaryMeetingID_FK = table.Column<int>(type: "integer", nullable: false),
                    IssueCatID = table.Column<int>(type: "integer", nullable: false),
                    IssueTitle = table.Column<string>(type: "text", nullable: false),
                    IssueContent = table.Column<string>(type: "text", nullable: false),
                    ActionPlan = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiDisciplinaryMeetingDetail", x => x.MultiDisciplinaryMeetingDetailID);
                    table.ForeignKey(
                        name: "FK_MultiDisciplinaryMeetingDetail_MultiDisciplinaryMeeting",
                        column: x => x.MultiDisciplinaryMeetingID_FK,
                        principalTable: "MultiDisciplinaryMeeting",
                        principalColumn: "MultiDisciplinaryMeetingID");
                });

            migrationBuilder.CreateTable(
                name: "NotificationChat",
                columns: table => new
                {
                    NotificationChatID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotificationId_FK = table.Column<int>(type: "integer", nullable: false),
                    ChatID_FK = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationChat", x => x.NotificationChatID);
                    table.ForeignKey(
                        name: "FK_NotificationChat_Chat",
                        column: x => x.ChatID_FK,
                        principalTable: "Chat",
                        principalColumn: "ChatID");
                });

            migrationBuilder.CreateTable(
                name: "NotificationEvent",
                columns: table => new
                {
                    NotificationEventID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotificationId_FK = table.Column<int>(type: "integer", nullable: false),
                    EventID_FK = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationEvent", x => x.NotificationEventID);
                    table.ForeignKey(
                        name: "FK_NotificationEvent_Event",
                        column: x => x.EventID_FK,
                        principalTable: "Event",
                        principalColumn: "EventID");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    notificationTypeCode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    isRead = table.Column<bool>(type: "boolean", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FacilityID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3213E83F5EF36BEC", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notifications_Facility",
                        column: x => x.FacilityID_FK,
                        principalTable: "Facility",
                        principalColumn: "FacilityID");
                    table.ForeignKey(
                        name: "fk_Notifications_notificationTypeCode",
                        column: x => x.notificationTypeCode,
                        principalTable: "Types",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "NotificationTask",
                columns: table => new
                {
                    NotificationTaskID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotificationId_FK = table.Column<int>(type: "integer", nullable: false),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTask", x => x.NotificationTaskID);
                    table.ForeignKey(
                        name: "FK_NotificationTask_Notifications",
                        column: x => x.NotificationId_FK,
                        principalTable: "Notifications",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationVitalSignDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    notificationId = table.Column<int>(type: "integer", nullable: false),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VitalSignDetailId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__3213E83F3CF99FFF", x => x.id);
                    table.ForeignKey(
                        name: "fk_NotificationVitalSignDetails_notificationId",
                        column: x => x.notificationId,
                        principalTable: "Notifications",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "NutritionTask",
                columns: table => new
                {
                    NutritionTaskID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActionTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    Food = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Liquid = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Method = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BeforeImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    AfterImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TypeReferenceID_FK = table.Column<int>(type: "integer", nullable: true),
                    AmountReferenceID_FK = table.Column<int>(type: "integer", nullable: true),
                    ColorReferenceID_FK = table.Column<int>(type: "integer", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    GivenAmount = table.Column<int>(type: "integer", nullable: true),
                    TakenAmount = table.Column<int>(type: "integer", nullable: true),
                    Unit = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionTask", x => x.NutritionTaskID);
                    table.ForeignKey(
                        name: "FK_NutritionTask_Code",
                        column: x => x.ActionTypeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_NutritionTask_NutritionTaskReference1",
                        column: x => x.TypeReferenceID_FK,
                        principalTable: "NutritionTaskReference",
                        principalColumn: "ReferenceID");
                    table.ForeignKey(
                        name: "FK_NutritionTask_NutritionTaskReference2",
                        column: x => x.AmountReferenceID_FK,
                        principalTable: "NutritionTaskReference",
                        principalColumn: "ReferenceID");
                    table.ForeignKey(
                        name: "FK_NutritionTask_NutritionTaskReference3",
                        column: x => x.ColorReferenceID_FK,
                        principalTable: "NutritionTaskReference",
                        principalColumn: "ReferenceID");
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NRIC = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Photo = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CareManagerAssignedID = table.Column<int>(type: "integer", nullable: true),
                    CaseID = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DrugAllergy = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    DischargeNoticePeriodInMonths = table.Column<int>(type: "integer", nullable: true),
                    AdmittedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ReasonOfAdmission = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AMD = table.Column<bool>(type: "boolean", nullable: true),
                    ACP = table.Column<bool>(type: "boolean", nullable: true),
                    PACEMAKER = table.Column<bool>(type: "boolean", nullable: true),
                    ACID = table.Column<bool>(type: "boolean", nullable: true),
                    MobilePhone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    HomePhone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    GenogramPicture = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    ReferringDiagnosis = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    MailForVitalAlert1 = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    MailForVitalAlert2 = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    MailForVitalAlert3 = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    MailForFamilyNotification1 = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    MailForFamilyNotification2 = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    VisitingFrequency = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    NumberOfChildren = table.Column<int>(type: "integer", nullable: true),
                    Occupation = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: true),
                    UpfrontPayment = table.Column<bool>(type: "boolean", nullable: true),
                    CareReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientTypeID_FK = table.Column<int>(type: "integer", nullable: true),
                    MailingAddress1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MailingAddress2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MailingAddress3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    GenderID_FK = table.Column<int>(type: "integer", nullable: true),
                    BloodTypeID_FK = table.Column<int>(type: "integer", nullable: true),
                    ResidentTypeID_FK = table.Column<int>(type: "integer", nullable: true),
                    MaritalStatusID_FK = table.Column<int>(type: "integer", nullable: true),
                    ReligionID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientProfileID_FK = table.Column<int>(type: "integer", nullable: true),
                    RaceID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientAdditionalInfoID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientReferralID_FK = table.Column<int>(type: "integer", nullable: true),
                    MedicalHistoryRemarks = table.Column<string>(type: "text", nullable: true),
                    PatientMedicationID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientReferralByID_FK = table.Column<int>(type: "integer", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IdentificationAttachmentFilename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IdentificationAttachmentPhysical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    OtherRace = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OtherLanguage = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PaymentMode = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true),
                    InvoiceModeID_FK = table.Column<int>(type: "integer", nullable: true),
                    DisplayName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OrderID = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    Accepted = table.Column<bool>(type: "boolean", nullable: true),
                    NursingStation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    AccessHospitalID_FK = table.Column<int>(type: "integer", nullable: true),
                    ActionDescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IntegrationSourceID = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patient_Code",
                        column: x => x.PatientTypeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Patient_Code1",
                        column: x => x.GenderID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Patient_Code2",
                        column: x => x.BloodTypeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Patient_Code3",
                        column: x => x.ResidentTypeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Patient_Code4",
                        column: x => x.MaritalStatusID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Patient_Code5",
                        column: x => x.ReligionID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Patient_Code6",
                        column: x => x.RaceID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Patient_Code7",
                        column: x => x.PatientReferralByID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Patient_Code_InvoiceModeID_FK",
                        column: x => x.InvoiceModeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Patient_PatientAdditionalInfo",
                        column: x => x.PatientAdditionalInfoID_FK,
                        principalTable: "PatientAdditionalInfo",
                        principalColumn: "PatientAdditionalInfoID");
                    table.ForeignKey(
                        name: "FK_Patient_PatientMedication",
                        column: x => x.PatientMedicationID_FK,
                        principalTable: "PatientMedication",
                        principalColumn: "PatientMedicationID");
                    table.ForeignKey(
                        name: "FK_Patient_PatientProfile",
                        column: x => x.PatientProfileID_FK,
                        principalTable: "PatientProfile",
                        principalColumn: "PatientProfileID");
                });

            migrationBuilder.CreateTable(
                name: "PatientAttachment",
                columns: table => new
                {
                    PatientAttachmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    Filename = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Physical = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    FileTypeID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAttachment", x => x.PatientAttachmentID);
                    table.ForeignKey(
                        name: "FK_PatientAttachment_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "PatientDrugAllergy",
                columns: table => new
                {
                    DrugAllergyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ReactionID_FK = table.Column<int>(type: "integer", nullable: true),
                    MedicationID_FK = table.Column<int>(type: "integer", nullable: true),
                    ReferID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDrugAllery", x => x.DrugAllergyID);
                    table.ForeignKey(
                        name: "FK_PatientDrugAllergy_Code",
                        column: x => x.ReactionID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientDrugAllergy_Code1",
                        column: x => x.MedicationID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientDrugAllergy_PatientDrugAllergy",
                        column: x => x.ReferID_FK,
                        principalTable: "PatientDrugAllergy",
                        principalColumn: "DrugAllergyID");
                    table.ForeignKey(
                        name: "FK_PatientDrugAllery_InitialCareAssessment",
                        column: x => x.InitialCareAssessmentID_FK,
                        principalTable: "InitialCareAssessment",
                        principalColumn: "InitialCareAssessmentID");
                    table.ForeignKey(
                        name: "FK_PatientDrugAllery_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "PatientFacility",
                columns: table => new
                {
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    FacilityID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFacility", x => new { x.PatientID_FK, x.FacilityID_FK });
                    table.ForeignKey(
                        name: "FK_PatientFacility_Facility",
                        column: x => x.FacilityID_FK,
                        principalTable: "Facility",
                        principalColumn: "FacilityID");
                    table.ForeignKey(
                        name: "FK_PatientFacility_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "PatientFamilyHistory",
                columns: table => new
                {
                    PatientFamilyHistoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: false),
                    DiseaseSubInfoID_FK = table.Column<int>(type: "integer", nullable: true),
                    YearDiagnose = table.Column<int>(type: "integer", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Relationship = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFamilyHistory", x => x.PatientFamilyHistoryID);
                    table.ForeignKey(
                        name: "FK_PatientFamilyHistory_Disease",
                        column: x => x.DiseaseID_FK,
                        principalTable: "Disease",
                        principalColumn: "DiseaseID");
                    table.ForeignKey(
                        name: "FK_PatientFamilyHistory_DiseaseSubInfo",
                        column: x => x.DiseaseSubInfoID_FK,
                        principalTable: "DiseaseSubInfo",
                        principalColumn: "DiseaseSubInfoID");
                    table.ForeignKey(
                        name: "FK_PatientFamilyHistory_InitialCareAssessment",
                        column: x => x.InitialCareAssessmentID_FK,
                        principalTable: "InitialCareAssessment",
                        principalColumn: "InitialCareAssessmentID");
                    table.ForeignKey(
                        name: "FK_PatientFamilyHistory_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "PatientImmunisation",
                columns: table => new
                {
                    ImmunisationID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Place = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    NextDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientImmunisation", x => x.ImmunisationID);
                    table.ForeignKey(
                        name: "FK_PatientImmunisation_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "PatientLanguage",
                columns: table => new
                {
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientLanguage", x => new { x.PatientID_FK, x.CodeID_FK });
                    table.ForeignKey(
                        name: "FK_PatientLanguage_Code",
                        column: x => x.CodeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientLanguage_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "PatientOtherAllergy",
                columns: table => new
                {
                    OtherAllergyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    ReactionID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DescriptionID_FK = table.Column<int>(type: "integer", nullable: true),
                    OtherDescription = table.Column<string>(type: "text", nullable: true),
                    ReferID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientOtherAllergy", x => x.OtherAllergyID);
                    table.ForeignKey(
                        name: "FK_PatientOtherAllergy_Code",
                        column: x => x.ReactionID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientOtherAllergy_Code1",
                        column: x => x.DescriptionID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientOtherAllergy_InitialCareAssessment",
                        column: x => x.InitialCareAssessmentID_FK,
                        principalTable: "InitialCareAssessment",
                        principalColumn: "InitialCareAssessmentID");
                    table.ForeignKey(
                        name: "FK_PatientOtherAllergy_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_PatientOtherAllergy_PatientDrugAllergy",
                        column: x => x.ReferID_FK,
                        principalTable: "PatientOtherAllergy",
                        principalColumn: "OtherAllergyID");
                });

            migrationBuilder.CreateTable(
                name: "PatientPackage",
                columns: table => new
                {
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    PackageID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPackage", x => new { x.PackageID_FK, x.PatientID_FK });
                    table.ForeignKey(
                        name: "FK_PatientPackage_Package",
                        column: x => x.PackageID_FK,
                        principalTable: "Package",
                        principalColumn: "PackageID");
                    table.ForeignKey(
                        name: "FK_PatientPackage_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "PatientSocialSupport",
                columns: table => new
                {
                    PatientSocialSupportID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    Firstname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Lastname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    GenderID_FK = table.Column<int>(type: "integer", nullable: true),
                    MaritalStatusID_FK = table.Column<int>(type: "integer", nullable: true),
                    RelationshipID_FK = table.Column<int>(type: "integer", nullable: true),
                    NationalityID_FK = table.Column<int>(type: "integer", nullable: true),
                    Contact = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    NotifyEmail = table.Column<bool>(type: "boolean", nullable: true),
                    NotifySMS = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    NotifyPhoneCall = table.Column<bool>(type: "boolean", nullable: true),
                    Spokeperson = table.Column<bool>(type: "boolean", nullable: true),
                    CanLogin = table.Column<bool>(type: "boolean", nullable: true),
                    BillTo = table.Column<bool>(type: "boolean", nullable: true),
                    UserType = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSocialSupport", x => x.PatientSocialSupportID);
                    table.ForeignKey(
                        name: "FK_PatientSocialSupport_Code",
                        column: x => x.MaritalStatusID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientSocialSupport_Code1",
                        column: x => x.RelationshipID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientSocialSupport_Code2",
                        column: x => x.NationalityID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientSocialSupport_Code3",
                        column: x => x.GenderID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientSocialSupport_InitialCareAssessment",
                        column: x => x.InitialCareAssessmentID_FK,
                        principalTable: "InitialCareAssessment",
                        principalColumn: "InitialCareAssessmentID");
                    table.ForeignKey(
                        name: "FK_PatientSocialSupport_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "PatientSpecialIndicator",
                columns: table => new
                {
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSpecialIndicator", x => new { x.PatientID_FK, x.CodeID_FK });
                    table.ForeignKey(
                        name: "FK_PatientSpecialIndicator_Code",
                        column: x => x.CodeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientSpecialIndicator_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "PatientWound",
                columns: table => new
                {
                    PatientWoundID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    OccurDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SeenDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Site = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    LocationOfWound = table.Column<string>(type: "text", nullable: true),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: true),
                    ActionDescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Remarks = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Stage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    WoundStatusID_FK = table.Column<int>(type: "integer", nullable: true),
                    Comments = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    StatusRemark = table.Column<string>(type: "text", nullable: true),
                    LocationRemark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientWound", x => x.PatientWoundID);
                    table.ForeignKey(
                        name: "FK_PatientWound_CareReport",
                        column: x => x.CareReportID_FK,
                        principalTable: "CareReport",
                        principalColumn: "CareReportID");
                    table.ForeignKey(
                        name: "FK_PatientWound_Code",
                        column: x => x.WoundStatusID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientWound_InitialCareAssessment",
                        column: x => x.InitialCareAssessmentID_FK,
                        principalTable: "InitialCareAssessment",
                        principalColumn: "InitialCareAssessmentID");
                    table.ForeignKey(
                        name: "FK_PatientWound_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "TeleconsultationRecording",
                columns: table => new
                {
                    RecordingID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecordingType_FK = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    Sid = table.Column<string>(type: "character(36)", unicode: false, fixedLength: true, maxLength: 36, nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeleconsultationRecording", x => x.RecordingID);
                    table.ForeignKey(
                        name: "FK_TeleconsultationRecording_Code",
                        column: x => x.RecordingType_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_TeleconsultationRecording_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Photo = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Contact = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Designation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastLogoutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastActivityDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastLockoutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastPasswordChangedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PreviousPasswords = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    SessionKey = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ResetPassword = table.Column<bool>(type: "boolean", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LocationNow1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LocationNow2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LocationNow3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PostalCodeNow = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    LocationNowModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    IsExternal = table.Column<bool>(type: "boolean", nullable: false),
                    UserOrganizationID_FK = table.Column<int>(type: "integer", nullable: true),
                    IsTCAccepted = table.Column<bool>(type: "boolean", nullable: true),
                    UserName = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    PreferredLanguage = table.Column<int>(type: "integer", nullable: true),
                    AccessLevelID_FK = table.Column<int>(type: "integer", nullable: true),
                    HasValidEmail = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    TokenID = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    PreviousPasswords2 = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    SharePdf = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "VitalSignRelationships",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vitalSignTypeId = table.Column<int>(type: "integer", nullable: false),
                    patientId = table.Column<int>(type: "integer", nullable: false),
                    thresholdId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalSignRelationships", x => x.id);
                    table.ForeignKey(
                        name: "fk_VitalSignRelationship_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "fk_VitalSignRelationship_thresholdId",
                        column: x => x.thresholdId,
                        principalTable: "Thresholds",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_VitalSignRelationship_vitalSignTypeId",
                        column: x => x.vitalSignTypeId,
                        principalTable: "VitalSignTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "VitalSigns",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patientId = table.Column<int>(type: "integer", nullable: false),
                    source = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    icaId = table.Column<int>(type: "integer", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    createdBy = table.Column<int>(type: "integer", nullable: true),
                    createdDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updatedBy = table.Column<int>(type: "integer", nullable: true),
                    updatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VitalSig__3213E83F2E0950CF", x => x.id);
                    table.ForeignKey(
                        name: "fk_VitalSigns_patientId",
                        column: x => x.patientId,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "PatientClinician",
                columns: table => new
                {
                    PatientClinicianID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    UserID_FK = table.Column<int>(type: "integer", nullable: true),
                    ExternalDoctorID_FK = table.Column<int>(type: "integer", nullable: true),
                    DiseaseID_FK = table.Column<int>(type: "integer", nullable: true),
                    DiseaseSubInfoID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientClinician", x => x.PatientClinicianID);
                    table.ForeignKey(
                        name: "FK_PatientClinician_Disease",
                        column: x => x.DiseaseID_FK,
                        principalTable: "Disease",
                        principalColumn: "DiseaseID");
                    table.ForeignKey(
                        name: "FK_PatientClinician_DiseaseSubInfo",
                        column: x => x.DiseaseSubInfoID_FK,
                        principalTable: "DiseaseSubInfo",
                        principalColumn: "DiseaseSubInfoID");
                    table.ForeignKey(
                        name: "FK_PatientClinician_ExternalDoctor",
                        column: x => x.ExternalDoctorID_FK,
                        principalTable: "ExternalDoctor",
                        principalColumn: "ExternalDoctorID");
                    table.ForeignKey(
                        name: "FK_PatientClinician_InitialCareAssessment",
                        column: x => x.InitialCareAssessmentID_FK,
                        principalTable: "InitialCareAssessment",
                        principalColumn: "InitialCareAssessmentID");
                    table.ForeignKey(
                        name: "FK_PatientClinician_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_PatientClinician_Users",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    ReceiptID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReceiptNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    PaymentModeID_FK = table.Column<int>(type: "integer", nullable: false),
                    TotalAmt = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ReceivedFrom = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    SendEmail = table.Column<bool>(type: "boolean", nullable: true),
                    EmailPatient = table.Column<bool>(type: "boolean", nullable: true),
                    EmailTo = table.Column<string>(type: "text", nullable: true),
                    EmailCC = table.Column<string>(type: "text", nullable: true),
                    EmailBCC = table.Column<string>(type: "text", nullable: true),
                    CurrencyID_FK = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    GroupNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Receipt__CC08C400E8522DFD", x => x.ReceiptID);
                    table.ForeignKey(
                        name: "FK_Receipt_Code",
                        column: x => x.PaymentModeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Receipt_Code1",
                        column: x => x.CurrencyID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Receipt_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_Receipt_Users",
                        column: x => x.CreatedBy_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Receipt_Users1",
                        column: x => x.ModifiedBy_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "RecentView",
                columns: table => new
                {
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: false),
                    DateView = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentView", x => new { x.UserID_FK, x.PatientID_FK });
                    table.ForeignKey(
                        name: "FK_RecentView_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_RecentView_Users",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActionTypeID_FK = table.Column<int>(type: "integer", nullable: false),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Location = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: true),
                    OtherLocation = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: true),
                    FrequencyID_FK = table.Column<int>(type: "integer", nullable: true),
                    DosageID_FK = table.Column<int>(type: "integer", nullable: true),
                    MilkFeedVolumeMLS = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    Supplement = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    H2OFlushingMLS = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    ReferenceType = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: true),
                    ReferenceID = table.Column<int>(type: "integer", nullable: true),
                    Pending = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MedicationID_FK = table.Column<int>(type: "integer", nullable: true),
                    Recurrence_Frequency = table.Column<int>(type: "integer", nullable: true),
                    Recurrence_Days = table.Column<int>(type: "integer", nullable: true),
                    Recurrence_Interval = table.Column<int>(type: "integer", nullable: true),
                    Recurrence_IntervalFlag = table.Column<int>(type: "integer", nullable: true),
                    MedicationInstructions = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    recurrenceDailyHourly = table.Column<int>(type: "integer", nullable: true),
                    UserCategory_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Task_Code",
                        column: x => x.ActionTypeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Task_Code1",
                        column: x => x.FrequencyID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Task_Code2",
                        column: x => x.DosageID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Task_Code3",
                        column: x => x.MedicationID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_Task_InitialCareAssessment",
                        column: x => x.InitialCareAssessmentID_FK,
                        principalTable: "InitialCareAssessment",
                        principalColumn: "InitialCareAssessmentID");
                    table.ForeignKey(
                        name: "FK_Task_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_Task_UserCategory",
                        column: x => x.UserCategory_FK,
                        principalTable: "UserCategory",
                        principalColumn: "UserCategoryID");
                    table.ForeignKey(
                        name: "FK_Task_Users",
                        column: x => x.CreatedBy_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    UserLocationID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    Address1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Address2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Address3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.UserLocationID);
                    table.ForeignKey(
                        name: "FK_UserAddress_Users",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserBranch",
                columns: table => new
                {
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    BranchID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBranch", x => new { x.UserID_FK, x.BranchID_FK });
                    table.ForeignKey(
                        name: "FK_UserBranch_Branch",
                        column: x => x.BranchID_FK,
                        principalTable: "Branch",
                        principalColumn: "BranchID");
                    table.ForeignKey(
                        name: "FK_UserBranch_Users",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserLanguage",
                columns: table => new
                {
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    LanguageID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguage", x => new { x.UserID_FK, x.LanguageID_FK });
                    table.ForeignKey(
                        name: "FK_UserLanguage_Code",
                        column: x => x.LanguageID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_UserLanguage_Users",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserOrganization",
                columns: table => new
                {
                    UserId_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrganization", x => new { x.UserId_FK, x.CodeID_FK });
                    table.ForeignKey(
                        name: "FK_UserOrganization_Code",
                        column: x => x.CodeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_UserOrganization_Users",
                        column: x => x.UserId_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId_FK = table.Column<int>(type: "integer", nullable: false),
                    RoleId_FK = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId_FK, x.RoleId_FK });
                    table.ForeignKey(
                        name: "FK_UserRole_Role",
                        column: x => x.RoleId_FK,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_UserRole_Users",
                        column: x => x.UserId_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserSkillset",
                columns: table => new
                {
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkillset", x => new { x.UserID_FK, x.CodeID_FK });
                    table.ForeignKey(
                        name: "FK_UserSkillset_Code",
                        column: x => x.CodeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_UserSkillset_Users",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserUserType",
                columns: table => new
                {
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserTypeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserType", x => new { x.UserID_FK, x.UserTypeID_FK });
                    table.ForeignKey(
                        name: "FK_UserUserType_UserType",
                        column: x => x.UserTypeID_FK,
                        principalTable: "UserType",
                        principalColumn: "UserTypeID");
                    table.ForeignKey(
                        name: "FK_UserUserType_Users",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "PatientWoundVisit",
                columns: table => new
                {
                    PatientWoundVisitID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientWoundID_FK = table.Column<int>(type: "integer", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    WoundType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WoundSubType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    WoundTypeOther = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SizeLength = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    SizeDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    SizeWidth = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    Edges = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Appearance = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Smell = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UnderMining = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Exudate = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Suffering = table.Column<int>(type: "integer", nullable: true, defaultValue: 0),
                    ImageUpload = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    SurfaceArea = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    UnderMiningDepth = table.Column<decimal>(type: "numeric(4,1)", nullable: true, defaultValue: 0m),
                    ExudateSubInfo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    VitalSignID_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    ReferID_FK = table.Column<int>(type: "integer", nullable: true),
                    NextReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TreatmentRemarks = table.Column<string>(type: "text", nullable: true),
                    AssignedToID_FK = table.Column<int>(type: "integer", nullable: true),
                    DESIGN_R_Depth = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DESIGN_R_Exudate = table.Column<int>(type: "integer", nullable: false),
                    DESIGN_R_Size = table.Column<int>(type: "integer", nullable: false),
                    DESIGN_R_Inflammation = table.Column<int>(type: "integer", nullable: false),
                    DESIGN_R_Granulation = table.Column<int>(type: "integer", nullable: false),
                    DESIGN_R_Necrotic = table.Column<int>(type: "integer", nullable: false),
                    DESIGN_R_Pocket = table.Column<int>(type: "integer", nullable: false),
                    DESIGN_R_Score = table.Column<int>(type: "integer", nullable: false),
                    IsDESIGN_R = table.Column<bool>(type: "boolean", nullable: false),
                    ExudateSubInfo2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PeriWound = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Debridement = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CleansingSolutionUsed = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Model_jpg = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Model_mtl = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Model_obj = table.Column<string>(type: "text", unicode: false, nullable: true),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    Volume = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    WoundInfection = table.Column<bool>(type: "boolean", nullable: true),
                    fever = table.Column<bool>(type: "boolean", nullable: true),
                    temperature = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    abscessPuss = table.Column<bool>(type: "boolean", nullable: true),
                    increasedPain = table.Column<bool>(type: "boolean", nullable: true),
                    erythema = table.Column<bool>(type: "boolean", nullable: true),
                    oedema = table.Column<bool>(type: "boolean", nullable: true),
                    localWarmth = table.Column<bool>(type: "boolean", nullable: true),
                    increasedExcudate = table.Column<bool>(type: "boolean", nullable: true),
                    delayedHealing = table.Column<bool>(type: "boolean", nullable: true),
                    maladour = table.Column<bool>(type: "boolean", nullable: true),
                    pocketing = table.Column<bool>(type: "boolean", nullable: true),
                    suspectedInfection = table.Column<bool>(type: "boolean", nullable: true),
                    TC_Granulation = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    TC_Slough = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    TC_Necrosis = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    TC_Epithelizing = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    TC_Others = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    TC_OriginalImage = table.Column<string>(type: "text", unicode: false, nullable: true),
                    TC_WoundBedImage = table.Column<string>(type: "text", unicode: false, nullable: true),
                    TC_AnnotatedImage = table.Column<string>(type: "text", unicode: false, nullable: true),
                    TC_IsAccept = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    TC_Reason = table.Column<string>(type: "text", nullable: true),
                    Perimeter = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    AverageDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    MaximumDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    MinimumDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    IsRedness = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    IsSwelling = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    IsWarmToTouch = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    IsSmell = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    Size = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    TC_Auto_Granulation = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    TC_Auto_Slough = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    TC_Auto_Necrosis = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    TC_Auto_Epithelizing = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    TC_Auto_Others = table.Column<decimal>(type: "numeric(5,2)", nullable: true, defaultValue: 0m),
                    NextTreatmentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    InfectionRemarks = table.Column<string>(type: "text", nullable: true),
                    TO_Comments = table.Column<string>(type: "text", unicode: false, nullable: true),
                    DepthImage = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "character varying(15)", unicode: false, maxLength: 15, nullable: true),
                    StatusRemark = table.Column<string>(type: "text", nullable: true),
                    woundOverlaysImageDistance = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    woundOverlaysImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    otherTissueName = table.Column<string>(type: "text", unicode: false, nullable: true),
                    isTCAndImageModified = table.Column<bool>(type: "boolean", nullable: true),
                    isTCModified = table.Column<bool>(type: "boolean", nullable: true),
                    isWMModified = table.Column<bool>(type: "boolean", nullable: true),
                    isUploadImageModified = table.Column<bool>(type: "boolean", nullable: true),
                    ProgressiveWoundStage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    OriginalImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    WoundBedImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    DepthImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    AnnotatedImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    SizeLength_Auto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeDepth_Auto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeWidth_Auto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    MeasurementUpdateRemark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TCUpdateRemark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DepthMax = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthEighty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthSixty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthForty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthTwenty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthNegative = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthNans = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Rotation = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ReasonForChangeMeasurement = table.Column<string>(type: "text", nullable: true),
                    ReasonForChangeClassification = table.Column<string>(type: "text", nullable: true),
                    OrigWoundId = table.Column<int>(type: "integer", nullable: true),
                    SmallWound = table.Column<bool>(type: "boolean", nullable: true),
                    FrequencyOfVisit = table.Column<int>(type: "integer", nullable: true),
                    WoundCaptureMode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientWoundVisit", x => x.PatientWoundVisitID);
                    table.ForeignKey(
                        name: "FK_PatientWoundVisit_CareReport",
                        column: x => x.CareReportID_FK,
                        principalTable: "CareReport",
                        principalColumn: "CareReportID");
                    table.ForeignKey(
                        name: "FK_PatientWoundVisit_InitialCareAssessment",
                        column: x => x.InitialCareAssessmentID_FK,
                        principalTable: "InitialCareAssessment",
                        principalColumn: "InitialCareAssessmentID");
                    table.ForeignKey(
                        name: "FK_PatientWoundVisit_PatientWound",
                        column: x => x.PatientWoundID_FK,
                        principalTable: "PatientWound",
                        principalColumn: "PatientWoundID");
                    table.ForeignKey(
                        name: "FK_PatientWoundVisit_PatientWoundVisit",
                        column: x => x.ReferID_FK,
                        principalTable: "PatientWoundVisit",
                        principalColumn: "PatientWoundVisitID");
                    table.ForeignKey(
                        name: "FK_PatientWoundVisit_Users",
                        column: x => x.AssignedToID_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_PatientWoundVisit_VitalSigns",
                        column: x => x.VitalSignID_FK,
                        principalTable: "VitalSigns",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "VitalSignDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vitalSignTypeId = table.Column<int>(type: "integer", nullable: false),
                    vitalSignId = table.Column<int>(type: "integer", nullable: false),
                    detailValue = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VitalSig__3213E83FE42362D2", x => x.id);
                    table.ForeignKey(
                        name: "fk_VitalSignDetails_vitalSignId",
                        column: x => x.vitalSignId,
                        principalTable: "VitalSigns",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_VitalSignDetails_vitalSignTypeId",
                        column: x => x.vitalSignTypeId,
                        principalTable: "VitalSignTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicalHistory",
                columns: table => new
                {
                    PatientMedicalHistoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    ClinicianID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MedicalStatusID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicalHistory", x => x.PatientMedicalHistoryID);
                    table.ForeignKey(
                        name: "FK_PatientMedicalHistory_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_PatientMedicalHistory_PatientClinician",
                        column: x => x.ClinicianID_FK,
                        principalTable: "PatientClinician",
                        principalColumn: "PatientClinicianID");
                    table.ForeignKey(
                        name: "FK_PatientMedicalHistory_Status",
                        column: x => x.MedicalStatusID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                });

            migrationBuilder.CreateTable(
                name: "PatientReferral",
                columns: table => new
                {
                    PatientReferralID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrimaryClinicianID_FK = table.Column<int>(type: "integer", nullable: true),
                    SecondaryClinicianID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientAwareDiagnose = table.Column<bool>(type: "boolean", nullable: true),
                    FamilyAwareDiagnose = table.Column<bool>(type: "boolean", nullable: true),
                    PatientAwarePrognosis = table.Column<bool>(type: "boolean", nullable: true),
                    FamilyAwarePrognosis = table.Column<bool>(type: "boolean", nullable: true),
                    PatientAwareDiagnoseReason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    FamilyAwareDiagnoseReason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PatientAwarePrognosisReason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    FamilyAwarePrognosisReason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    PrimaryNurseID_FK = table.Column<int>(type: "integer", nullable: true),
                    SecondaryNurseID_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientReferral", x => x.PatientReferralID);
                    table.ForeignKey(
                        name: "FK_PatientReferral_PatientClinician2",
                        column: x => x.PrimaryClinicianID_FK,
                        principalTable: "PatientClinician",
                        principalColumn: "PatientClinicianID");
                    table.ForeignKey(
                        name: "FK_PatientReferral_PatientClinician3",
                        column: x => x.SecondaryClinicianID_FK,
                        principalTable: "PatientClinician",
                        principalColumn: "PatientClinicianID");
                    table.ForeignKey(
                        name: "FK_PatientReferral_PatientClinician4",
                        column: x => x.PrimaryNurseID_FK,
                        principalTable: "PatientClinician",
                        principalColumn: "PatientClinicianID");
                    table.ForeignKey(
                        name: "FK_PatientReferral_PatientClinician5",
                        column: x => x.SecondaryNurseID_FK,
                        principalTable: "PatientClinician",
                        principalColumn: "PatientClinicianID");
                });

            migrationBuilder.CreateTable(
                name: "ReceiptForInvoice",
                columns: table => new
                {
                    ReceiptForInvoiceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReceiptID_FK = table.Column<int>(type: "integer", nullable: false),
                    BillingInvoiceID_FK = table.Column<int>(type: "integer", nullable: false),
                    Amt = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ReceiptF__AAA44B1B702F8EEB", x => x.ReceiptForInvoiceID);
                    table.ForeignKey(
                        name: "FK_ReceiptForInv_Inv",
                        column: x => x.BillingInvoiceID_FK,
                        principalTable: "BillingInvoice",
                        principalColumn: "BillingInvoiceID");
                    table.ForeignKey(
                        name: "FK_ReceiptForInv_Receipt",
                        column: x => x.ReceiptID_FK,
                        principalTable: "Receipt",
                        principalColumn: "ReceiptID");
                });

            migrationBuilder.CreateTable(
                name: "TaskFileAttachment",
                columns: table => new
                {
                    FileAttachmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFileAttachment", x => x.FileAttachmentID);
                    table.ForeignKey(
                        name: "FK_TaskFileAttachment_Task",
                        column: x => x.TaskID_FK,
                        principalTable: "Task",
                        principalColumn: "TaskID");
                });

            migrationBuilder.CreateTable(
                name: "TaskServicesRequired",
                columns: table => new
                {
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskServicesRequired", x => new { x.TaskID_FK, x.CodeID_FK });
                    table.ForeignKey(
                        name: "FK_TaskServicesRequired_Code",
                        column: x => x.CodeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_TaskServicesRequired_Task",
                        column: x => x.TaskID_FK,
                        principalTable: "Task",
                        principalColumn: "TaskID");
                });

            migrationBuilder.CreateTable(
                name: "TaskSpecificDate",
                columns: table => new
                {
                    TaskSpecificDateID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    TaskDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSpecificDate", x => x.TaskSpecificDateID);
                    table.ForeignKey(
                        name: "FK_TaskSpecificDate_Task",
                        column: x => x.TaskID_FK,
                        principalTable: "Task",
                        principalColumn: "TaskID");
                });

            migrationBuilder.CreateTable(
                name: "TaskUser",
                columns: table => new
                {
                    TaskUserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserType = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUser", x => x.TaskUserID);
                    table.ForeignKey(
                        name: "FK_TaskUser_Task",
                        column: x => x.TaskID_FK,
                        principalTable: "Task",
                        principalColumn: "TaskID");
                    table.ForeignKey(
                        name: "FK_TaskUser_Users",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TaskUserLog",
                columns: table => new
                {
                    TaskUserLogID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskID_FK = table.Column<int>(type: "integer", nullable: false),
                    UserID_FK = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    FailReason = table.Column<string>(type: "text", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    HideDashboard = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUserLog", x => x.TaskUserLogID);
                    table.ForeignKey(
                        name: "FK_TaskUserLog_Task",
                        column: x => x.TaskID_FK,
                        principalTable: "Task",
                        principalColumn: "TaskID");
                    table.ForeignKey(
                        name: "FK_TaskUserLog_Users",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "PatientWoundDraft",
                columns: table => new
                {
                    PatientWoundDraftID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VisitDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    OccurDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SeenDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LocationOfWound = table.Column<string>(type: "text", nullable: true),
                    Site = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Category = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Stage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    WoundStatusID_FK = table.Column<int>(type: "integer", nullable: true),
                    Comments = table.Column<string>(type: "text", unicode: false, nullable: true),
                    SizeLength = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeWidth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Size = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SurfaceArea = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Perimeter = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    AverageDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    MaximumDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    MinimumDepth = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Volume = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Granulation = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Slough = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Necrosis = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Epithelizing = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Others = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Exudate = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ExudateNature = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ExudatedConsistency = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Edges = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PeriWound = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Suffering = table.Column<int>(type: "integer", nullable: true),
                    IsRedness = table.Column<bool>(type: "boolean", nullable: true),
                    IsSwelling = table.Column<bool>(type: "boolean", nullable: true),
                    IsWarmToTouch = table.Column<bool>(type: "boolean", nullable: true),
                    IsSmell = table.Column<bool>(type: "boolean", nullable: true),
                    IsAccept = table.Column<bool>(type: "boolean", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    ImageUpload = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    OriginalImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    WoundBedImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    AnnotatedImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    PatientWoundID_FK = table.Column<int>(type: "integer", nullable: true),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: true),
                    AssignDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    DepthImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    DepthMax = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthEighty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthSixty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthForty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthTwenty = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthNegative = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    DepthNans = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    UnderMining = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    Rotation = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    OriginalImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    WoundBedImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    DepthImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    AnnotatedImageMeasurement = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    SizeLength_Auto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeDepth_Auto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    SizeWidth_Auto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    MeasurementUpdateRemark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TCUpdateRemark = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    isTCModified = table.Column<bool>(type: "boolean", nullable: true),
                    isWMModified = table.Column<bool>(type: "boolean", nullable: true),
                    isUploadImageModified = table.Column<bool>(type: "boolean", nullable: true),
                    woundOverlaysImageDistance = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    woundOverlaysImage = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    TO_Comments = table.Column<string>(type: "text", unicode: false, nullable: true),
                    NextReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    NextTreatmentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TreatmentRemarks = table.Column<string>(type: "text", nullable: true),
                    LocationRemark = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientWoundDraft", x => x.PatientWoundDraftID);
                    table.ForeignKey(
                        name: "FK_PatientWoundDraft_Code",
                        column: x => x.WoundStatusID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientWoundDraft_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_PatientWoundDraft_PatientWound",
                        column: x => x.PatientWoundID_FK,
                        principalTable: "PatientWound",
                        principalColumn: "PatientWoundID");
                    table.ForeignKey(
                        name: "FK_PatientWoundDraft_PatientWoundVisit",
                        column: x => x.PatientWoundVisitID_FK,
                        principalTable: "PatientWoundVisit",
                        principalColumn: "PatientWoundVisitID");
                });

            migrationBuilder.CreateTable(
                name: "PatientWoundReviewBy",
                columns: table => new
                {
                    PatientWoundReviewById = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: true),
                    UserId_FK = table.Column<int>(type: "integer", nullable: true),
                    ReviewComments = table.Column<string>(type: "text", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THK_ICP_InputFrom", x => x.PatientWoundReviewById);
                    table.ForeignKey(
                        name: "FK_PatientWoundReviewBy_PatientWoundVisit",
                        column: x => x.PatientWoundVisitID_FK,
                        principalTable: "PatientWoundVisit",
                        principalColumn: "PatientWoundVisitID");
                    table.ForeignKey(
                        name: "FK_PatientWoundReviewBy_Users",
                        column: x => x.UserId_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "PatientWoundVisitAppearance",
                columns: table => new
                {
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientWoundVisitAppearance", x => new { x.PatientWoundVisitID_FK, x.CodeID_FK });
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitAppearance_Code",
                        column: x => x.CodeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitAppearance_PatientWoundVisit",
                        column: x => x.PatientWoundVisitID_FK,
                        principalTable: "PatientWoundVisit",
                        principalColumn: "PatientWoundVisitID");
                });

            migrationBuilder.CreateTable(
                name: "PatientWoundVisitCleansingItem",
                columns: table => new
                {
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: false),
                    CodeID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientWoundVisitCleansingItem", x => new { x.PatientWoundVisitID_FK, x.CodeID_FK });
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitCleansingItem_Code",
                        column: x => x.CodeID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitCleansingItem_PatientWoundVisit",
                        column: x => x.PatientWoundVisitID_FK,
                        principalTable: "PatientWoundVisit",
                        principalColumn: "PatientWoundVisitID");
                });

            migrationBuilder.CreateTable(
                name: "PatientWoundVisitClinician",
                columns: table => new
                {
                    PatientWoundVisitClinicianID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: true),
                    UserID_FK = table.Column<int>(type: "integer", nullable: true),
                    ExternalDoctorID_FK = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientWoundVisitClinician", x => x.PatientWoundVisitClinicianID);
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitClinician_ExternalDoctor",
                        column: x => x.ExternalDoctorID_FK,
                        principalTable: "ExternalDoctor",
                        principalColumn: "ExternalDoctorID");
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitClinician_PatientWoundVisit",
                        column: x => x.PatientWoundVisitID_FK,
                        principalTable: "PatientWoundVisit",
                        principalColumn: "PatientWoundVisitID");
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitClinician_Users",
                        column: x => x.UserID_FK,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "PatientWoundVisitTreatment",
                columns: table => new
                {
                    PatientWoundVisitTreatmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: false),
                    ItemID_FK = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    IsChargeable = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientWoundVisitTreatment", x => x.PatientWoundVisitTreatmentID);
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitTreatment_Item",
                        column: x => x.ItemID_FK,
                        principalTable: "Item",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitTreatment_PatientWoundVisit",
                        column: x => x.PatientWoundVisitID_FK,
                        principalTable: "PatientWoundVisit",
                        principalColumn: "PatientWoundVisitID");
                });

            migrationBuilder.CreateTable(
                name: "PatientWoundVisitTreatmentList",
                columns: table => new
                {
                    PatientWoundVisitTListID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: false),
                    TListItemID_FK = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientWoundVisitTreatmentList", x => x.PatientWoundVisitTListID);
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitTreatmentList_PatientWoundVisit",
                        column: x => x.PatientWoundVisitID_FK,
                        principalTable: "PatientWoundVisit",
                        principalColumn: "PatientWoundVisitID");
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitTreatmentList_TreatmentListItem",
                        column: x => x.TListItemID_FK,
                        principalTable: "TreatmentListItem",
                        principalColumn: "TListItemID");
                });

            migrationBuilder.CreateTable(
                name: "PatientWoundVisitTreatmentObjectives",
                columns: table => new
                {
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: false),
                    ObjectiveID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientWoundVisitTreatmentObjectives", x => new { x.PatientWoundVisitID_FK, x.ObjectiveID_FK });
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitTreatmentObjectives_Code",
                        column: x => x.ObjectiveID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientWoundVisitTreatmentObjectives_PatientWoundVisit",
                        column: x => x.PatientWoundVisitID_FK,
                        principalTable: "PatientWoundVisit",
                        principalColumn: "PatientWoundVisitID");
                });

            migrationBuilder.CreateTable(
                name: "WoundConsolidatedEmail",
                columns: table => new
                {
                    WoundConsolidatedEmailID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientWoundVisitID_FK = table.Column<int>(type: "integer", nullable: false),
                    MailSettingsID_FK = table.Column<int>(type: "integer", nullable: false),
                    PDFContent = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WoundConsolidatedEmail", x => x.WoundConsolidatedEmailID);
                    table.ForeignKey(
                        name: "FK_WoundConsolidatedEmail_MailSettings",
                        column: x => x.MailSettingsID_FK,
                        principalTable: "MailSettings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_WoundConsolidatedEmail_PatientWoundVisit",
                        column: x => x.PatientWoundVisitID_FK,
                        principalTable: "PatientWoundVisit",
                        principalColumn: "PatientWoundVisitID");
                });

            migrationBuilder.CreateTable(
                name: "PatientAMT",
                columns: table => new
                {
                    PatientAMTID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    Alertness = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: true),
                    VitalSignDetailId_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAMT", x => x.PatientAMTID);
                    table.ForeignKey(
                        name: "FK_PatientAMT_CareReport",
                        column: x => x.CareReportID_FK,
                        principalTable: "CareReport",
                        principalColumn: "CareReportID");
                    table.ForeignKey(
                        name: "FK_PatientAMT_InitialCareAssessment",
                        column: x => x.InitialCareAssessmentID_FK,
                        principalTable: "InitialCareAssessment",
                        principalColumn: "InitialCareAssessmentID");
                    table.ForeignKey(
                        name: "FK_PatientAMT_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_PatientAMT_VitalSignDetails",
                        column: x => x.VitalSignDetailId_FK,
                        principalTable: "VitalSignDetails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PatientBradenScale",
                columns: table => new
                {
                    PatientBradenScaleID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    VitalSignDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<int>(type: "integer", nullable: true),
                    Score2 = table.Column<int>(type: "integer", nullable: true),
                    Score3 = table.Column<int>(type: "integer", nullable: true),
                    Score4 = table.Column<int>(type: "integer", nullable: true),
                    Score5 = table.Column<int>(type: "integer", nullable: true),
                    Score6 = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientBradenScale", x => x.PatientBradenScaleID);
                    table.ForeignKey(
                        name: "FK_PatientBradenScale_VitalSignDetails",
                        column: x => x.VitalSignDetailID_FK,
                        principalTable: "VitalSignDetails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PatientEBASDEP",
                columns: table => new
                {
                    PatientEBASDEPID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID_FK = table.Column<int>(type: "integer", nullable: true),
                    InitialCareAssessmentID_FK = table.Column<int>(type: "integer", nullable: true),
                    Alertness = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Score = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CareReportID_FK = table.Column<int>(type: "integer", nullable: true),
                    VitalSignDetailId_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientEBASDEP", x => x.PatientEBASDEPID);
                    table.ForeignKey(
                        name: "FK_PatientEBASDEP_CareReport",
                        column: x => x.CareReportID_FK,
                        principalTable: "CareReport",
                        principalColumn: "CareReportID");
                    table.ForeignKey(
                        name: "FK_PatientEBASDEP_InitialCareAssessment",
                        column: x => x.InitialCareAssessmentID_FK,
                        principalTable: "InitialCareAssessment",
                        principalColumn: "InitialCareAssessmentID");
                    table.ForeignKey(
                        name: "FK_PatientEBASDEP_Patient",
                        column: x => x.PatientID_FK,
                        principalTable: "Patient",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_PatientEBASDEP_VitalSignDetails",
                        column: x => x.VitalSignDetailId_FK,
                        principalTable: "VitalSignDetails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PatientGCS",
                columns: table => new
                {
                    PatientGCSID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    VitalSignDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<int>(type: "integer", nullable: true),
                    Score2 = table.Column<int>(type: "integer", nullable: true),
                    Score3 = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientGCS", x => x.PatientGCSID);
                    table.ForeignKey(
                        name: "FK_PatientGCS_VitalSignDetails",
                        column: x => x.VitalSignDetailID_FK,
                        principalTable: "VitalSignDetails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PatientMBI",
                columns: table => new
                {
                    PatientMBIID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    VitalSignDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<int>(type: "integer", nullable: true),
                    Score2 = table.Column<int>(type: "integer", nullable: true),
                    Score3 = table.Column<int>(type: "integer", nullable: true),
                    Score4 = table.Column<int>(type: "integer", nullable: true),
                    Score5 = table.Column<int>(type: "integer", nullable: true),
                    Score6 = table.Column<int>(type: "integer", nullable: true),
                    Score7 = table.Column<int>(type: "integer", nullable: true),
                    Score8 = table.Column<int>(type: "integer", nullable: true),
                    Score9 = table.Column<int>(type: "integer", nullable: true),
                    Score10 = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMBI", x => x.PatientMBIID);
                    table.ForeignKey(
                        name: "FK_PatientMBI_VitalSignDetails",
                        column: x => x.VitalSignDetailID_FK,
                        principalTable: "VitalSignDetails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PatientMFS",
                columns: table => new
                {
                    PatientMFSID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    VitalSignDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<int>(type: "integer", nullable: true),
                    Score2 = table.Column<int>(type: "integer", nullable: true),
                    Score3 = table.Column<int>(type: "integer", nullable: true),
                    Score4 = table.Column<int>(type: "integer", nullable: true),
                    Score5 = table.Column<int>(type: "integer", nullable: true),
                    Score6 = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMFS", x => x.PatientMFSID);
                    table.ForeignKey(
                        name: "FK_PatientMFS_VitalSignDetails",
                        column: x => x.VitalSignDetailID_FK,
                        principalTable: "VitalSignDetails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PatientMMSE",
                columns: table => new
                {
                    PatientMMSEID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    VitalSignDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<int>(type: "integer", nullable: true),
                    Score2 = table.Column<int>(type: "integer", nullable: true),
                    Score3 = table.Column<int>(type: "integer", nullable: true),
                    Score4 = table.Column<int>(type: "integer", nullable: true),
                    Score5 = table.Column<int>(type: "integer", nullable: true),
                    Score6 = table.Column<int>(type: "integer", nullable: true),
                    Score7 = table.Column<int>(type: "integer", nullable: true),
                    Score8 = table.Column<int>(type: "integer", nullable: true),
                    Score9 = table.Column<int>(type: "integer", nullable: true),
                    Score10 = table.Column<int>(type: "integer", nullable: true),
                    Score11 = table.Column<int>(type: "integer", nullable: true),
                    Score12 = table.Column<int>(type: "integer", nullable: true),
                    Score13 = table.Column<int>(type: "integer", nullable: true),
                    Score14 = table.Column<int>(type: "integer", nullable: true),
                    Score15 = table.Column<int>(type: "integer", nullable: true),
                    Score16 = table.Column<int>(type: "integer", nullable: true),
                    Score17 = table.Column<int>(type: "integer", nullable: true),
                    Score18 = table.Column<int>(type: "integer", nullable: true),
                    Score19 = table.Column<int>(type: "integer", nullable: true),
                    Score20 = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMMSE", x => x.PatientMMSEID);
                    table.ForeignKey(
                        name: "FK_PatientMMSE_VitalSignDetails",
                        column: x => x.VitalSignDetailID_FK,
                        principalTable: "VitalSignDetails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PatientRAF",
                columns: table => new
                {
                    PatientRAFID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    VitalSignDetailID_FK = table.Column<int>(type: "integer", nullable: true),
                    Score1 = table.Column<int>(type: "integer", nullable: true),
                    Score2 = table.Column<int>(type: "integer", nullable: true),
                    Score3 = table.Column<int>(type: "integer", nullable: true),
                    Score4 = table.Column<int>(type: "integer", nullable: true),
                    Score5a = table.Column<int>(type: "integer", nullable: true),
                    Score5b = table.Column<int>(type: "integer", nullable: true),
                    Score5c = table.Column<int>(type: "integer", nullable: true),
                    Score5d = table.Column<int>(type: "integer", nullable: true),
                    Score6 = table.Column<int>(type: "integer", nullable: true),
                    Score7 = table.Column<int>(type: "integer", nullable: true),
                    Score8 = table.Column<int>(type: "integer", nullable: true),
                    Score9 = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRAF", x => x.PatientRAFID);
                    table.ForeignKey(
                        name: "FK_PatientRAF_VitalSignDetails",
                        column: x => x.VitalSignDetailID_FK,
                        principalTable: "VitalSignDetails",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PatientReferralService",
                columns: table => new
                {
                    PatientReferralID_FK = table.Column<int>(type: "integer", nullable: false),
                    ServiceID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientReferralService", x => new { x.PatientReferralID_FK, x.ServiceID_FK });
                    table.ForeignKey(
                        name: "FK_PatientReferralService_Code",
                        column: x => x.ServiceID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientReferralService_PatientReferral",
                        column: x => x.PatientReferralID_FK,
                        principalTable: "PatientReferral",
                        principalColumn: "PatientReferralID");
                });

            migrationBuilder.CreateTable(
                name: "TaskUserLogAttachment",
                columns: table => new
                {
                    FileAttachmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskUserLogID_FK = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUserLogAttachment", x => x.FileAttachmentID);
                    table.ForeignKey(
                        name: "FK_TaskUserLogAttachment_TaskUserLog",
                        column: x => x.TaskUserLogID_FK,
                        principalTable: "TaskUserLog",
                        principalColumn: "TaskUserLogID");
                });

            migrationBuilder.CreateTable(
                name: "PatientWoundDraftTreatmentList",
                columns: table => new
                {
                    PatientWoundDraftTListID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientWoundDraftID_FK = table.Column<int>(type: "integer", nullable: false),
                    TListItemID_FK = table.Column<int>(type: "integer", nullable: false),
                    Remarks = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy_FK = table.Column<int>(type: "integer", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedBy_FK = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientWoundDraftTreatmentList", x => x.PatientWoundDraftTListID);
                    table.ForeignKey(
                        name: "FK_PatientWoundDraftTreatmentList_PatientWoundDraft",
                        column: x => x.PatientWoundDraftID_FK,
                        principalTable: "PatientWoundDraft",
                        principalColumn: "PatientWoundDraftID");
                    table.ForeignKey(
                        name: "FK_PatientWoundDraftTreatmentList_TreatmentListItem",
                        column: x => x.TListItemID_FK,
                        principalTable: "TreatmentListItem",
                        principalColumn: "TListItemID");
                });

            migrationBuilder.CreateTable(
                name: "PatientWoundDraftTreatmentObjectives",
                columns: table => new
                {
                    PatientWoundDraftID_FK = table.Column<int>(type: "integer", nullable: false),
                    ObjectiveID_FK = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientWoundDraftTreatmentObjectives", x => new { x.PatientWoundDraftID_FK, x.ObjectiveID_FK });
                    table.ForeignKey(
                        name: "FK_PatientWoundDraftTreatmentObjectives_Code",
                        column: x => x.ObjectiveID_FK,
                        principalTable: "Code",
                        principalColumn: "CodeId");
                    table.ForeignKey(
                        name: "FK_PatientWoundDraftTreatmentObjectives_PatientWoundDraft",
                        column: x => x.PatientWoundDraftID_FK,
                        principalTable: "PatientWoundDraft",
                        principalColumn: "PatientWoundDraftID");
                });

            migrationBuilder.CreateTable(
                name: "PatientAMTAnswer",
                columns: table => new
                {
                    PatientAMTID_FK = table.Column<int>(type: "integer", nullable: false),
                    AMTQuestionID_FK = table.Column<int>(type: "integer", nullable: false),
                    Answer = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAMTAnswer", x => new { x.PatientAMTID_FK, x.AMTQuestionID_FK });
                    table.ForeignKey(
                        name: "FK_PatientAMTAnswer_AMTQuestion",
                        column: x => x.AMTQuestionID_FK,
                        principalTable: "AMTQuestion",
                        principalColumn: "AMTQuestionId");
                    table.ForeignKey(
                        name: "FK_PatientAMTAnswer_PatientAMT",
                        column: x => x.PatientAMTID_FK,
                        principalTable: "PatientAMT",
                        principalColumn: "PatientAMTID");
                });

            migrationBuilder.CreateTable(
                name: "PatientEBASDEPAnswer",
                columns: table => new
                {
                    PatientEBASDEPID_FK = table.Column<int>(type: "integer", nullable: false),
                    EBASDEPQuestionID_FK = table.Column<int>(type: "integer", nullable: false),
                    Answer = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientEBASDEPAnswer", x => new { x.PatientEBASDEPID_FK, x.EBASDEPQuestionID_FK });
                    table.ForeignKey(
                        name: "FK_PatientEBASDEPAnswer_EBASDEPQuestion",
                        column: x => x.EBASDEPQuestionID_FK,
                        principalTable: "EBASDEPQuestion",
                        principalColumn: "EBASDEPQuestionId");
                    table.ForeignKey(
                        name: "FK_PatientEBASDEPAnswer_PatientEBASDEP",
                        column: x => x.PatientEBASDEPID_FK,
                        principalTable: "PatientEBASDEP",
                        principalColumn: "PatientEBASDEPID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_DiseaseID_FK",
                table: "Activity",
                column: "DiseaseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ProblemListID_FK",
                table: "Activity",
                column: "ProblemListID_FK");

            migrationBuilder.CreateIndex(
                name: "idx_APIAccessKey1",
                table: "APIAccessKey",
                columns: new[] { "TokenCode", "ExpiryDate" });

            migrationBuilder.CreateIndex(
                name: "idx_APIAccessKey2",
                table: "APIAccessKey",
                column: "TokenCode");

            migrationBuilder.CreateIndex(
                name: "idx_APIAccessKey3",
                table: "APIAccessKey",
                columns: new[] { "TokenCode", "ExpiryDate", "CreatedDate" });

            migrationBuilder.CreateIndex(
                name: "IX_APIOrderAllergy_APIOrderID_FK",
                table: "APIOrderAllergy",
                column: "APIOrderID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_APIOrderDiagnosis_APIOrderID_FK",
                table: "APIOrderDiagnosis",
                column: "APIOrderID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_APIOrderMedication_APIOrderID_FK",
                table: "APIOrderMedication",
                column: "APIOrderID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_APIOrderTask_APIOrderID_FK",
                table: "APIOrderTask",
                column: "APIOrderID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrail_CreatedBy_FK",
                table: "AuditTrail",
                column: "CreatedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInvoice_CareReportID_FK",
                table: "BillingInvoice",
                column: "CareReportID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInvoice_CreatedBy_FK",
                table: "BillingInvoice",
                column: "CreatedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInvoice_CurrencyID_FK",
                table: "BillingInvoice",
                column: "CurrencyID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInvoice_ModifiedBy_FK",
                table: "BillingInvoice",
                column: "ModifiedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInvoice_PatientID_FK",
                table: "BillingInvoice",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInvoiceConsumable_BillingInvoiceID_FK",
                table: "BillingInvoiceConsumable",
                column: "BillingInvoiceID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInvoiceConsumable_ItemID_FK",
                table: "BillingInvoiceConsumable",
                column: "ItemID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInvoiceService_BillingInvoiceID_FK",
                table: "BillingInvoiceService",
                column: "BillingInvoiceID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInvoiceService_ProposalID_FK",
                table: "BillingInvoiceService",
                column: "ProposalID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInvoiceService_ServiceID_FK",
                table: "BillingInvoiceService",
                column: "ServiceID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingPackage_BillingServiceID",
                table: "BillingPackage",
                column: "BillingServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_BillingProposal_CreatedBy_FK",
                table: "BillingProposal",
                column: "CreatedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingProposal_CurrencyID_FK",
                table: "BillingProposal",
                column: "CurrencyID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingProposal_ModifiedBy_FK",
                table: "BillingProposal",
                column: "ModifiedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingProposal_PatientID_FK",
                table: "BillingProposal",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingProposalService_BillingProposalID_FK",
                table: "BillingProposalService",
                column: "BillingProposalID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingProposalService_ServiceID_FK",
                table: "BillingProposalService",
                column: "ServiceID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BillingService_CategoryID_FK",
                table: "BillingService",
                column: "CategoryID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CurrencyID_FK",
                table: "Branch",
                column: "CurrencyID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlan_CarePlanStatusID_FK",
                table: "CarePlan",
                column: "CarePlanStatusID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlan_DiagnosisID_FK",
                table: "CarePlan",
                column: "DiagnosisID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlan_PatientID_FK",
                table: "CarePlan",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanDetail_CarePlanSubID_FK",
                table: "CarePlanDetail",
                column: "CarePlanSubID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanDetail_DiseaseID_FK",
                table: "CarePlanDetail",
                column: "DiseaseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanDetail_SystemID_FK",
                table: "CarePlanDetail",
                column: "SystemID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanSub_CarePlanID_FK",
                table: "CarePlanSub",
                column: "CarePlanID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanSubActivity_ActivityID_FK",
                table: "CarePlanSubActivity",
                column: "ActivityID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanSubCPGoals_CPGoalsID_FK",
                table: "CarePlanSubCPGoals",
                column: "CPGoalsID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanSubGoal_CarePlanSubID_FK",
                table: "CarePlanSubGoal",
                column: "CarePlanSubID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanSubGoal_DiseaseID_FK",
                table: "CarePlanSubGoal",
                column: "DiseaseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanSubIntervention_InterventionID_FK",
                table: "CarePlanSubIntervention",
                column: "InterventionID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanSubProblemList_CarePlanSubID_FK",
                table: "CarePlanSubProblemList",
                column: "CarePlanSubID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanSubProblemList_ProblemListID_FK",
                table: "CarePlanSubProblemList",
                column: "ProblemListID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanSubProblemListGoal_CarePlanSubProblemListID_FK",
                table: "CarePlanSubProblemListGoal",
                column: "CarePlanSubProblemListID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanSubProblemListGoal_OperatorID",
                table: "CarePlanSubProblemListGoal",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanSubProblemListGoal_ProblemListGoalID_FK",
                table: "CarePlanSubProblemListGoal",
                column: "ProblemListGoalID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanSubProblemListGoal_ScoreTypeID",
                table: "CarePlanSubProblemListGoal",
                column: "ScoreTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_AirwayBreathingID_FK",
                table: "CareReport",
                column: "AirwayBreathingID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_BladderCareID_FK",
                table: "CareReport",
                column: "BladderCareID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_BowelCareID_FK",
                table: "CareReport",
                column: "BowelCareID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_CapillaryRefillID_FK",
                table: "CareReport",
                column: "CapillaryRefillID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_CarePlanID_FK",
                table: "CareReport",
                column: "CarePlanID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_CareReportID_FK",
                table: "CareReport",
                column: "CareReportID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_CareReportRehabilitationID_FK",
                table: "CareReport",
                column: "CareReportRehabilitationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_CareReportSystemInfoID_FK",
                table: "CareReport",
                column: "CareReportSystemInfoID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_CirculationID_FK",
                table: "CareReport",
                column: "CirculationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_CoughID_FK",
                table: "CareReport",
                column: "CoughID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_DiapersID_FK",
                table: "CareReport",
                column: "DiapersID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_LipsID_FK",
                table: "CareReport",
                column: "LipsID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_LowerEyelidsID_FK",
                table: "CareReport",
                column: "LowerEyelidsID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_O2AidID_FK",
                table: "CareReport",
                column: "O2AidID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_PainDescriptionID_FK",
                table: "CareReport",
                column: "PainDescriptionID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_PatientID_FK",
                table: "CareReport",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_PatientNutritionID_FK",
                table: "CareReport",
                column: "PatientNutritionID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_PeripheralPulsesPedalID_FK",
                table: "CareReport",
                column: "PeripheralPulsesPedalID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_PeripheralPulsesRadialID_FK",
                table: "CareReport",
                column: "PeripheralPulsesRadialID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_SleepRestID_FK",
                table: "CareReport",
                column: "SleepRestID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_TemperatureID_FK",
                table: "CareReport",
                column: "TemperatureID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_VisitedBy_FK",
                table: "CareReport",
                column: "VisitedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReport_VitalSignID_FK",
                table: "CareReport",
                column: "VitalSignID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReportConfig_UserTypeID_FK",
                table: "CareReportConfig",
                column: "UserTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReportSocialSupport_CareReportID_FK",
                table: "CareReportSocialSupport",
                column: "CareReportID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReportSocialSupport_PatientSocialSupportID_FK",
                table: "CareReportSocialSupport",
                column: "PatientSocialSupportID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReportSystemInfo_KeyPerson1UserID_FK",
                table: "CareReportSystemInfo",
                column: "KeyPerson1UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReportSystemInfo_KeyPerson2UserID_FK",
                table: "CareReportSystemInfo",
                column: "KeyPerson2UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReportSystemInfo_PrimaryDoctorUserID_FK",
                table: "CareReportSystemInfo",
                column: "PrimaryDoctorUserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CareReportSystemInfo_SecondaryDoctorUserID_FK",
                table: "CareReportSystemInfo",
                column: "SecondaryDoctorUserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_CreatedBy_FK",
                table: "Chat",
                column: "CreatedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_ParentID_FK",
                table: "Chat",
                column: "ParentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_PatientID_FK",
                table: "Chat",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Code_CodeTypeId_FK",
                table: "Code",
                column: "CodeTypeId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Code_MedicationGroupID_FK",
                table: "Code",
                column: "MedicationGroupID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CPGoals_DiseaseID_FK",
                table: "CPGoals",
                column: "DiseaseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_DischargeSummaryReportAttachment_DischargeSummaryReportID_FK",
                table: "DischargeSummaryReportAttachment",
                column: "DischargeSummaryReportID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Disease_SystemID_FK",
                table: "Disease",
                column: "SystemID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseInfo_DiseaseID_FK",
                table: "DiseaseInfo",
                column: "DiseaseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseSubInfo_DiseaseID_FK",
                table: "DiseaseSubInfo",
                column: "DiseaseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseVitalSignType_DiseaseID_FK",
                table: "DiseaseVitalSignType",
                column: "DiseaseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseVitalSignType_VitalSignTypeID_FK",
                table: "DiseaseVitalSignType",
                column: "VitalSignTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_CaregiverAtHomeID_FK",
                table: "Enquiry",
                column: "CaregiverAtHomeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_CareManagerAssignedID_FK",
                table: "Enquiry",
                column: "CareManagerAssignedID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_EnquirySourceID_FK",
                table: "Enquiry",
                column: "EnquirySourceID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_GenderID_FK",
                table: "Enquiry",
                column: "GenderID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_PreferredLanguageID_FK",
                table: "Enquiry",
                column: "PreferredLanguageID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_RaceID_FK",
                table: "Enquiry",
                column: "RaceID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_ServicesRequiredID_FK",
                table: "Enquiry",
                column: "ServicesRequiredID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_UserOrganizationID_FK",
                table: "Enquiry",
                column: "UserOrganizationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryAttachment_EnquiryID_FK",
                table: "EnquiryAttachment",
                column: "EnquiryID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryConfig_EscalatingPersonID_FK",
                table: "EnquiryConfig",
                column: "EscalatingPersonID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryConfig_SCMID_FK",
                table: "EnquiryConfig",
                column: "SCMID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryEscPerson_UserID_FK",
                table: "EnquiryEscPerson",
                column: "UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryLanguage_CodeID_FK",
                table: "EnquiryLanguage",
                column: "CodeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EnquirySCM_UserID_FK",
                table: "EnquirySCM",
                column: "UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EnquiryServicesRequired_CodeID_FK",
                table: "EnquiryServicesRequired",
                column: "CodeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CreatedBy_FK",
                table: "Event",
                column: "CreatedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTypeID_FK",
                table: "Event",
                column: "EventTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Event_PeriodTypeID_FK",
                table: "Event",
                column: "PeriodTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Event_UserCategory_FK",
                table: "Event",
                column: "UserCategory_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventID_FK",
                table: "EventUser",
                column: "EventID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_UserID_FK",
                table: "EventUser",
                column: "UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EventUserLog_EventID_FK",
                table: "EventUserLog",
                column: "EventID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EventUserLog_UserID_FK",
                table: "EventUserLog",
                column: "UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalDoctor_ClinicianTypeID_FK",
                table: "ExternalDoctor",
                column: "ClinicianTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_OrganizationID_FK",
                table: "Facility",
                column: "OrganizationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRole_RoleId_FK",
                table: "GroupRole",
                column: "RoleId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ICAWoundCare_CodeID_FK",
                table: "ICAWoundCare",
                column: "CodeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InitialCareAssessment_PatientAdditionalInfoID_FK",
                table: "InitialCareAssessment",
                column: "PatientAdditionalInfoID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InitialCareAssessment_PatientMBIID_FK",
                table: "InitialCareAssessment",
                column: "PatientMBIID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InitialCareAssessment_PatientMedicationID_FK",
                table: "InitialCareAssessment",
                column: "PatientMedicationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InitialCareAssessment_PatientMFSID_FK",
                table: "InitialCareAssessment",
                column: "PatientMFSID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InitialCareAssessment_PatientNutritionID_FK",
                table: "InitialCareAssessment",
                column: "PatientNutritionID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InitialCareAssessment_PatientProfileID_FK",
                table: "InitialCareAssessment",
                column: "PatientProfileID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InitialCareAssessment_PatientRAFID_FK",
                table: "InitialCareAssessment",
                column: "PatientRAFID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InitialCareAssessment_PatientReferralID_FK",
                table: "InitialCareAssessment",
                column: "PatientReferralID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InitialCareAssessment_VitalSignID_FK",
                table: "InitialCareAssessment",
                column: "VitalSignID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InitialCareAssessmentAttachment_InitialCareAssessmentID_FK",
                table: "InitialCareAssessmentAttachment",
                column: "InitialCareAssessmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_InitialCareAssessmentSpecialInstruction_InitialCareAssessme~",
                table: "InitialCareAssessmentSpecialInstruction",
                column: "InitialCareAssessmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Intervention_DiseaseID_FK",
                table: "Intervention",
                column: "DiseaseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryID_FK",
                table: "Item",
                column: "CategoryID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemUnitID_FK",
                table: "Item",
                column: "ItemUnitID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStock_ItemID_FK",
                table: "ItemStock",
                column: "ItemID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_MailSettingsMsgToUserType_UserTypeID_FK",
                table: "MailSettingsMsgToUserType",
                column: "UserTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationVitalSignType_MedicationID_FK",
                table: "MedicationVitalSignType",
                column: "MedicationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationVitalSignType_VitalSignTypeID_FK",
                table: "MedicationVitalSignType",
                column: "VitalSignTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_MobileAppVersioning_CreatedBy_FK",
                table: "MobileAppVersioning",
                column: "CreatedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_MobileAppVersioning_ModifiedBy_FK",
                table: "MobileAppVersioning",
                column: "ModifiedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_MultiDisciplinaryMeeting_PatientID_FK",
                table: "MultiDisciplinaryMeeting",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_MultiDisciplinaryMeetingDetail_MultiDisciplinaryMeetingID_FK",
                table: "MultiDisciplinaryMeetingDetail",
                column: "MultiDisciplinaryMeetingID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationChat_ChatID_FK",
                table: "NotificationChat",
                column: "ChatID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationChat_NotificationId_FK",
                table: "NotificationChat",
                column: "NotificationId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationEvent_EventID_FK",
                table: "NotificationEvent",
                column: "EventID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationEvent_NotificationId_FK",
                table: "NotificationEvent",
                column: "NotificationId_FK");

            migrationBuilder.CreateIndex(
                name: "idx_NotificationMessageTemplates1",
                table: "NotificationMessageTemplates",
                column: "notificationgroupCode");

            migrationBuilder.CreateIndex(
                name: "idx_Notifications1",
                table: "Notifications",
                columns: new[] { "userId", "isRead" });

            migrationBuilder.CreateIndex(
                name: "idx_Notifications2",
                table: "Notifications",
                column: "isRead");

            migrationBuilder.CreateIndex(
                name: "idx_Notifications3",
                table: "Notifications",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FacilityID_FK",
                table: "Notifications",
                column: "FacilityID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_notificationTypeCode",
                table: "Notifications",
                column: "notificationTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTask_NotificationId_FK",
                table: "NotificationTask",
                column: "NotificationId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTask_TaskID_FK",
                table: "NotificationTask",
                column: "TaskID_FK");

            migrationBuilder.CreateIndex(
                name: "idx_NotificationVitalSignDetails1",
                table: "NotificationVitalSignDetails",
                columns: new[] { "notificationId", "VitalSignDetailId" });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationVitalSignDetails_VitalSignDetailId",
                table: "NotificationVitalSignDetails",
                column: "VitalSignDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionTask_ActionTypeID_FK",
                table: "NutritionTask",
                column: "ActionTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionTask_AmountReferenceID_FK",
                table: "NutritionTask",
                column: "AmountReferenceID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionTask_ColorReferenceID_FK",
                table: "NutritionTask",
                column: "ColorReferenceID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionTask_PatientID_FK",
                table: "NutritionTask",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionTask_TypeReferenceID_FK",
                table: "NutritionTask",
                column: "TypeReferenceID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionTaskReference_CodeId_FK",
                table: "NutritionTaskReference",
                column: "CodeId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_BloodTypeID_FK",
                table: "Patient",
                column: "BloodTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_GenderID_FK",
                table: "Patient",
                column: "GenderID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_InvoiceModeID_FK",
                table: "Patient",
                column: "InvoiceModeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_MaritalStatusID_FK",
                table: "Patient",
                column: "MaritalStatusID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatientAdditionalInfoID_FK",
                table: "Patient",
                column: "PatientAdditionalInfoID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatientMedicationID_FK",
                table: "Patient",
                column: "PatientMedicationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatientProfileID_FK",
                table: "Patient",
                column: "PatientProfileID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatientReferralByID_FK",
                table: "Patient",
                column: "PatientReferralByID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatientReferralID_FK",
                table: "Patient",
                column: "PatientReferralID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatientTypeID_FK",
                table: "Patient",
                column: "PatientTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_RaceID_FK",
                table: "Patient",
                column: "RaceID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ReligionID_FK",
                table: "Patient",
                column: "ReligionID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ResidentTypeID_FK",
                table: "Patient",
                column: "ResidentTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAccessLine_CareReportID_FK",
                table: "PatientAccessLine",
                column: "CareReportID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAMT_CareReportID_FK",
                table: "PatientAMT",
                column: "CareReportID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAMT_InitialCareAssessmentID_FK",
                table: "PatientAMT",
                column: "InitialCareAssessmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAMT_PatientID_FK",
                table: "PatientAMT",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAMT_VitalSignDetailId_FK",
                table: "PatientAMT",
                column: "VitalSignDetailId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAMTAnswer_AMTQuestionID_FK",
                table: "PatientAMTAnswer",
                column: "AMTQuestionID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAttachment_PatientID_FK",
                table: "PatientAttachment",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientBradenScale_VitalSignDetailID_FK",
                table: "PatientBradenScale",
                column: "VitalSignDetailID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientClinician_DiseaseID_FK",
                table: "PatientClinician",
                column: "DiseaseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientClinician_DiseaseSubInfoID_FK",
                table: "PatientClinician",
                column: "DiseaseSubInfoID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientClinician_ExternalDoctorID_FK",
                table: "PatientClinician",
                column: "ExternalDoctorID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientClinician_InitialCareAssessmentID_FK",
                table: "PatientClinician",
                column: "InitialCareAssessmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientClinician_PatientID_FK",
                table: "PatientClinician",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientClinician_UserID_FK",
                table: "PatientClinician",
                column: "UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDrugAllergy_InitialCareAssessmentID_FK",
                table: "PatientDrugAllergy",
                column: "InitialCareAssessmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDrugAllergy_MedicationID_FK",
                table: "PatientDrugAllergy",
                column: "MedicationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDrugAllergy_PatientID_FK",
                table: "PatientDrugAllergy",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDrugAllergy_ReactionID_FK",
                table: "PatientDrugAllergy",
                column: "ReactionID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDrugAllergy_ReferID_FK",
                table: "PatientDrugAllergy",
                column: "ReferID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientEBASDEP_CareReportID_FK",
                table: "PatientEBASDEP",
                column: "CareReportID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientEBASDEP_InitialCareAssessmentID_FK",
                table: "PatientEBASDEP",
                column: "InitialCareAssessmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientEBASDEP_PatientID_FK",
                table: "PatientEBASDEP",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientEBASDEP_VitalSignDetailId_FK",
                table: "PatientEBASDEP",
                column: "VitalSignDetailId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientEBASDEPAnswer_EBASDEPQuestionID_FK",
                table: "PatientEBASDEPAnswer",
                column: "EBASDEPQuestionID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFacility_FacilityID_FK",
                table: "PatientFacility",
                column: "FacilityID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFamilyHistory_DiseaseID_FK",
                table: "PatientFamilyHistory",
                column: "DiseaseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFamilyHistory_DiseaseSubInfoID_FK",
                table: "PatientFamilyHistory",
                column: "DiseaseSubInfoID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFamilyHistory_InitialCareAssessmentID_FK",
                table: "PatientFamilyHistory",
                column: "InitialCareAssessmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFamilyHistory_PatientID_FK",
                table: "PatientFamilyHistory",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientGCS_VitalSignDetailID_FK",
                table: "PatientGCS",
                column: "VitalSignDetailID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientImmunisation_PatientID_FK",
                table: "PatientImmunisation",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLanguage_CodeID_FK",
                table: "PatientLanguage",
                column: "CodeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMBI_VitalSignDetailID_FK",
                table: "PatientMBI",
                column: "VitalSignDetailID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalHistory_ClinicianID_FK",
                table: "PatientMedicalHistory",
                column: "ClinicianID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalHistory_MedicalStatusID_FK",
                table: "PatientMedicalHistory",
                column: "MedicalStatusID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalHistory_PatientID_FK",
                table: "PatientMedicalHistory",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationConsume_AcutePRNIndicationID_FK",
                table: "PatientMedicationConsume",
                column: "AcutePRNIndicationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationConsume_ChronicDiseaseID_FK",
                table: "PatientMedicationConsume",
                column: "ChronicDiseaseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationConsume_ChronicDiseaseSubInfoID_FK",
                table: "PatientMedicationConsume",
                column: "ChronicDiseaseSubInfoID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationConsume_DosageID_FK",
                table: "PatientMedicationConsume",
                column: "DosageID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationConsume_FrequencyID_FK",
                table: "PatientMedicationConsume",
                column: "FrequencyID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationConsume_InstructedBy2ID_FK",
                table: "PatientMedicationConsume",
                column: "InstructedBy2ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationConsume_InstructedByID_FK",
                table: "PatientMedicationConsume",
                column: "InstructedByID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationConsume_MedicationID_FK",
                table: "PatientMedicationConsume",
                column: "MedicationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationConsume_PatientMedicationID_FK",
                table: "PatientMedicationConsume",
                column: "PatientMedicationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationConsume_ReferID_FK",
                table: "PatientMedicationConsume",
                column: "ReferID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationConsume_RouteID_FK",
                table: "PatientMedicationConsume",
                column: "RouteID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationConsumeAttachment_PatientMedicationConsume~",
                table: "PatientMedicationConsumeAttachment",
                column: "PatientMedicationConsumeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationSupply_SupplyID_FK",
                table: "PatientMedicationSupply",
                column: "SupplyID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMFS_VitalSignDetailID_FK",
                table: "PatientMFS",
                column: "VitalSignDetailID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMMSE_VitalSignDetailID_FK",
                table: "PatientMMSE",
                column: "VitalSignDetailID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOtherAllergy_DescriptionID_FK",
                table: "PatientOtherAllergy",
                column: "DescriptionID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOtherAllergy_InitialCareAssessmentID_FK",
                table: "PatientOtherAllergy",
                column: "InitialCareAssessmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOtherAllergy_PatientID_FK",
                table: "PatientOtherAllergy",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOtherAllergy_ReactionID_FK",
                table: "PatientOtherAllergy",
                column: "ReactionID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOtherAllergy_ReferID_FK",
                table: "PatientOtherAllergy",
                column: "ReferID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPackage_PatientID_FK",
                table: "PatientPackage",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProfile_BloodTypeID_FK",
                table: "PatientProfile",
                column: "BloodTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProfile_PatientOrganizationID_FK",
                table: "PatientProfile",
                column: "PatientOrganizationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProfile_ReligionID_FK",
                table: "PatientProfile",
                column: "ReligionID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRAF_VitalSignDetailID_FK",
                table: "PatientRAF",
                column: "VitalSignDetailID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReferral_PrimaryClinicianID_FK",
                table: "PatientReferral",
                column: "PrimaryClinicianID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReferral_PrimaryNurseID_FK",
                table: "PatientReferral",
                column: "PrimaryNurseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReferral_SecondaryClinicianID_FK",
                table: "PatientReferral",
                column: "SecondaryClinicianID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReferral_SecondaryNurseID_FK",
                table: "PatientReferral",
                column: "SecondaryNurseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReferralService_ServiceID_FK",
                table: "PatientReferralService",
                column: "ServiceID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSocialSupport_GenderID_FK",
                table: "PatientSocialSupport",
                column: "GenderID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSocialSupport_InitialCareAssessmentID_FK",
                table: "PatientSocialSupport",
                column: "InitialCareAssessmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSocialSupport_MaritalStatusID_FK",
                table: "PatientSocialSupport",
                column: "MaritalStatusID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSocialSupport_NationalityID_FK",
                table: "PatientSocialSupport",
                column: "NationalityID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSocialSupport_PatientID_FK",
                table: "PatientSocialSupport",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSocialSupport_RelationshipID_FK",
                table: "PatientSocialSupport",
                column: "RelationshipID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSpecialIndicator_CodeID_FK",
                table: "PatientSpecialIndicator",
                column: "CodeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWound_CareReportID_FK",
                table: "PatientWound",
                column: "CareReportID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWound_InitialCareAssessmentID_FK",
                table: "PatientWound",
                column: "InitialCareAssessmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWound_PatientID_FK",
                table: "PatientWound",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWound_WoundStatusID_FK",
                table: "PatientWound",
                column: "WoundStatusID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundDraft_PatientID_FK",
                table: "PatientWoundDraft",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundDraft_PatientWoundID_FK",
                table: "PatientWoundDraft",
                column: "PatientWoundID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundDraft_PatientWoundVisitID_FK",
                table: "PatientWoundDraft",
                column: "PatientWoundVisitID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundDraft_WoundStatusID_FK",
                table: "PatientWoundDraft",
                column: "WoundStatusID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundDraftTreatmentList_PatientWoundDraftID_FK",
                table: "PatientWoundDraftTreatmentList",
                column: "PatientWoundDraftID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundDraftTreatmentList_TListItemID_FK",
                table: "PatientWoundDraftTreatmentList",
                column: "TListItemID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundDraftTreatmentObjectives_ObjectiveID_FK",
                table: "PatientWoundDraftTreatmentObjectives",
                column: "ObjectiveID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundReviewBy_PatientWoundVisitID_FK",
                table: "PatientWoundReviewBy",
                column: "PatientWoundVisitID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundReviewBy_UserId_FK",
                table: "PatientWoundReviewBy",
                column: "UserId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisit_AssignedToID_FK",
                table: "PatientWoundVisit",
                column: "AssignedToID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisit_CareReportID_FK",
                table: "PatientWoundVisit",
                column: "CareReportID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisit_InitialCareAssessmentID_FK",
                table: "PatientWoundVisit",
                column: "InitialCareAssessmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisit_PatientWoundID_FK",
                table: "PatientWoundVisit",
                column: "PatientWoundID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisit_ReferID_FK",
                table: "PatientWoundVisit",
                column: "ReferID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisit_VitalSignID_FK",
                table: "PatientWoundVisit",
                column: "VitalSignID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisitAppearance_CodeID_FK",
                table: "PatientWoundVisitAppearance",
                column: "CodeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisitCleansingItem_CodeID_FK",
                table: "PatientWoundVisitCleansingItem",
                column: "CodeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisitClinician_ExternalDoctorID_FK",
                table: "PatientWoundVisitClinician",
                column: "ExternalDoctorID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisitClinician_PatientWoundVisitID_FK",
                table: "PatientWoundVisitClinician",
                column: "PatientWoundVisitID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisitClinician_UserID_FK",
                table: "PatientWoundVisitClinician",
                column: "UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisitTreatment_ItemID_FK",
                table: "PatientWoundVisitTreatment",
                column: "ItemID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisitTreatment_PatientWoundVisitID_FK",
                table: "PatientWoundVisitTreatment",
                column: "PatientWoundVisitID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisitTreatmentList_PatientWoundVisitID_FK",
                table: "PatientWoundVisitTreatmentList",
                column: "PatientWoundVisitID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisitTreatmentList_TListItemID_FK",
                table: "PatientWoundVisitTreatmentList",
                column: "TListItemID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PatientWoundVisitTreatmentObjectives_ObjectiveID_FK",
                table: "PatientWoundVisitTreatmentObjectives",
                column: "ObjectiveID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemList_DiseaseID_FK",
                table: "ProblemList",
                column: "DiseaseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemListGoal_OperatorID",
                table: "ProblemListGoal",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemListGoal_ProblemListID_FK",
                table: "ProblemListGoal",
                column: "ProblemListID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemListGoal_ScoreTypeID",
                table: "ProblemListGoal",
                column: "ScoreTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_CreatedBy_FK",
                table: "Receipt",
                column: "CreatedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_CurrencyID_FK",
                table: "Receipt",
                column: "CurrencyID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_ModifiedBy_FK",
                table: "Receipt",
                column: "ModifiedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_PatientID_FK",
                table: "Receipt",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_PaymentModeID_FK",
                table: "Receipt",
                column: "PaymentModeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptForInvoice_BillingInvoiceID_FK",
                table: "ReceiptForInvoice",
                column: "BillingInvoiceID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptForInvoice_ReceiptID_FK",
                table: "ReceiptForInvoice",
                column: "ReceiptID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_RecentView_PatientID_FK",
                table: "RecentView",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_CodeId",
                table: "Resource",
                column: "CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_LanguageId",
                table: "Resource",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceForBilling_CategoryID_FK",
                table: "ServiceForBilling",
                column: "CategoryID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceForBillingCost_CurrencyID_FK",
                table: "ServiceForBillingCost",
                column: "CurrencyID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceForBillingCost_ServiceForBillingID_FK",
                table: "ServiceForBillingCost",
                column: "ServiceForBillingID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSkillset_SkillsetID_FK",
                table: "ServiceSkillset",
                column: "SkillsetID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ActionTypeID_FK",
                table: "Task",
                column: "ActionTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Task_CreatedBy_FK",
                table: "Task",
                column: "CreatedBy_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Task_DosageID_FK",
                table: "Task",
                column: "DosageID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Task_FrequencyID_FK",
                table: "Task",
                column: "FrequencyID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Task_InitialCareAssessmentID_FK",
                table: "Task",
                column: "InitialCareAssessmentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Task_MedicationID_FK",
                table: "Task",
                column: "MedicationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Task_PatientID_FK",
                table: "Task",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Reference",
                table: "Task",
                columns: new[] { "ReferenceType", "ReferenceID" });

            migrationBuilder.CreateIndex(
                name: "IX_Task_UserCategory_FK",
                table: "Task",
                column: "UserCategory_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TaskFileAttachment_TaskID_FK",
                table: "TaskFileAttachment",
                column: "TaskID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TaskServicesRequired_CodeID_FK",
                table: "TaskServicesRequired",
                column: "CodeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TaskSpecificDate_TaskID_FK",
                table: "TaskSpecificDate",
                column: "TaskID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUser_TaskID_FK",
                table: "TaskUser",
                column: "TaskID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUser_UserID_FK",
                table: "TaskUser",
                column: "UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUserLog",
                table: "TaskUserLog",
                columns: new[] { "StartDate", "EndDate", "TaskID_FK" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskUserLog_1",
                table: "TaskUserLog",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUserLog_2",
                table: "TaskUserLog",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUserLog_3",
                table: "TaskUserLog",
                column: "TaskID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUserLog_UserID_FK",
                table: "TaskUserLog",
                column: "UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUserLogAttachment_TaskUserLogID_FK",
                table: "TaskUserLogAttachment",
                column: "TaskUserLogID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TD_WoundAssessmentFactor_CodeID_FK",
                table: "TD_WoundAssessmentFactor",
                column: "CodeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TeleconsultationRecording_PatientID_FK",
                table: "TeleconsultationRecording",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TeleconsultationRecording_RecordingType_FK",
                table: "TeleconsultationRecording",
                column: "RecordingType_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentListItem_TListTypeID_FK",
                table: "TreatmentListItem",
                column: "TListTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentTOL_TListItemID_FK",
                table: "TreatmentTOL",
                column: "TListItemID_FK");

            migrationBuilder.CreateIndex(
                name: "idx_Types1",
                table: "Types",
                columns: new[] { "code", "parentCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Types_parentCode",
                table: "Types",
                column: "parentCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserID_FK",
                table: "UserAddress",
                column: "UserID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserBranch_BranchID_FK",
                table: "UserBranch",
                column: "BranchID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategory_UserCategoryOrganizationID_FK",
                table: "UserCategory",
                column: "UserCategoryOrganizationID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategoryFacility_FacilityID_FK",
                table: "UserCategoryFacility",
                column: "FacilityID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategoryParentChild_ChildUserCategoryID_FK",
                table: "UserCategoryParentChild",
                column: "ChildUserCategoryID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategoryRole_RoleID_FK",
                table: "UserCategoryRole",
                column: "RoleID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguage_LanguageID_FK",
                table: "UserLanguage",
                column: "LanguageID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganization_CodeID_FK",
                table: "UserOrganization",
                column: "CodeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId_FK",
                table: "UserRole",
                column: "RoleId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PatientID_FK",
                table: "Users",
                column: "PatientID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkillset_CodeID_FK",
                table: "UserSkillset",
                column: "CodeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserType_UserCategoryID_FK",
                table: "UserType",
                column: "UserCategoryID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserType_UserTypeID_FK",
                table: "UserUserType",
                column: "UserTypeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSignDetails_vitalSignId",
                table: "VitalSignDetails",
                column: "vitalSignId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSignDetails_vitalSignTypeId",
                table: "VitalSignDetails",
                column: "vitalSignTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSignRelationships_patientId",
                table: "VitalSignRelationships",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSignRelationships_thresholdId",
                table: "VitalSignRelationships",
                column: "thresholdId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSignRelationships_vitalSignTypeId",
                table: "VitalSignRelationships",
                column: "vitalSignTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSigns_patientId",
                table: "VitalSigns",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "idx_VitalSignTypes1",
                table: "VitalSignTypes",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSignTypeThreshold",
                table: "VitalSignTypeThreshold",
                column: "VitalSignTypeID_FK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WoundConsolidatedEmail_MailSettingsID_FK",
                table: "WoundConsolidatedEmail",
                column: "MailSettingsID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_WoundConsolidatedEmail_PatientWoundVisitID_FK",
                table: "WoundConsolidatedEmail",
                column: "PatientWoundVisitID_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditTrail_Users",
                table: "AuditTrail",
                column: "CreatedBy_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingInvoice_CareReport",
                table: "BillingInvoice",
                column: "CareReportID_FK",
                principalTable: "CareReport",
                principalColumn: "CareReportID");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingInvoice_Patient",
                table: "BillingInvoice",
                column: "PatientID_FK",
                principalTable: "Patient",
                principalColumn: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingInvoice_Users",
                table: "BillingInvoice",
                column: "CreatedBy_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingInvoice_Users1",
                table: "BillingInvoice",
                column: "ModifiedBy_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingInvoiceService_BillingProposal",
                table: "BillingInvoiceService",
                column: "ProposalID_FK",
                principalTable: "BillingProposal",
                principalColumn: "BillingProposalID");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingProposal_Patient",
                table: "BillingProposal",
                column: "PatientID_FK",
                principalTable: "Patient",
                principalColumn: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingProposal_Users",
                table: "BillingProposal",
                column: "CreatedBy_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingProposal_Users1",
                table: "BillingProposal",
                column: "ModifiedBy_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarePlan_Patient",
                table: "CarePlan",
                column: "PatientID_FK",
                principalTable: "Patient",
                principalColumn: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_CareReport_CareReportSystemInfo",
                table: "CareReport",
                column: "CareReportSystemInfoID_FK",
                principalTable: "CareReportSystemInfo",
                principalColumn: "CareReportSystemInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_CareReport_Patient",
                table: "CareReport",
                column: "PatientID_FK",
                principalTable: "Patient",
                principalColumn: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_CareReport_Users",
                table: "CareReport",
                column: "VisitedBy_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareReport_VitalSigns",
                table: "CareReport",
                column: "VitalSignID_FK",
                principalTable: "VitalSigns",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CareReportSocialSupport_PatientSocialSupport",
                table: "CareReportSocialSupport",
                column: "PatientSocialSupportID_FK",
                principalTable: "PatientSocialSupport",
                principalColumn: "PatientSocialSupportID");

            migrationBuilder.AddForeignKey(
                name: "FK_CareReportSystemInfo_PatientClinician1",
                table: "CareReportSystemInfo",
                column: "PrimaryDoctorUserID_FK",
                principalTable: "PatientClinician",
                principalColumn: "PatientClinicianID");

            migrationBuilder.AddForeignKey(
                name: "FK_CareReportSystemInfo_PatientClinician2",
                table: "CareReportSystemInfo",
                column: "SecondaryDoctorUserID_FK",
                principalTable: "PatientClinician",
                principalColumn: "PatientClinicianID");

            migrationBuilder.AddForeignKey(
                name: "FK_CareReportSystemInfo_Users1",
                table: "CareReportSystemInfo",
                column: "KeyPerson1UserID_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareReportSystemInfo_Users2",
                table: "CareReportSystemInfo",
                column: "KeyPerson2UserID_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Patient1",
                table: "Chat",
                column: "PatientID_FK",
                principalTable: "Patient",
                principalColumn: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Users",
                table: "Chat",
                column: "CreatedBy_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enquiry_Users",
                table: "Enquiry",
                column: "CareManagerAssignedID_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnquiryConfig_Users_EscPersonID",
                table: "EnquiryConfig",
                column: "EscalatingPersonID_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnquiryConfig_Users_SCMID",
                table: "EnquiryConfig",
                column: "SCMID_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnquiryEscPerson_Users",
                table: "EnquiryEscPerson",
                column: "UserID_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnquirySCM_Users",
                table: "EnquirySCM",
                column: "UserID_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Users",
                table: "Event",
                column: "CreatedBy_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Users",
                table: "EventUser",
                column: "UserID_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUserLog_Users",
                table: "EventUserLog",
                column: "UserID_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ICAWoundCare_InitialCareAssessment",
                table: "ICAWoundCare",
                column: "InitialCareAssessmentID_FK",
                principalTable: "InitialCareAssessment",
                principalColumn: "InitialCareAssessmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialCareAssessment_PatientMBI",
                table: "InitialCareAssessment",
                column: "PatientMBIID_FK",
                principalTable: "PatientMBI",
                principalColumn: "PatientMBIID");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialCareAssessment_PatientMFS",
                table: "InitialCareAssessment",
                column: "PatientMFSID_FK",
                principalTable: "PatientMFS",
                principalColumn: "PatientMFSID");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialCareAssessment_PatientRAF",
                table: "InitialCareAssessment",
                column: "PatientRAFID_FK",
                principalTable: "PatientRAF",
                principalColumn: "PatientRAFID");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialCareAssessment_PatientReferral",
                table: "InitialCareAssessment",
                column: "PatientReferralID_FK",
                principalTable: "PatientReferral",
                principalColumn: "PatientReferralID");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialCareAssessment_VitalSigns",
                table: "InitialCareAssessment",
                column: "VitalSignID_FK",
                principalTable: "VitalSigns",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MobileAppVersioning_User_CreatedBy",
                table: "MobileAppVersioning",
                column: "CreatedBy_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MobileAppVersioning_User_ModifiedBy",
                table: "MobileAppVersioning",
                column: "ModifiedBy_FK",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MultiDisciplinaryMeeting_Patient",
                table: "MultiDisciplinaryMeeting",
                column: "PatientID_FK",
                principalTable: "Patient",
                principalColumn: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationChat_Notifications",
                table: "NotificationChat",
                column: "NotificationId_FK",
                principalTable: "Notifications",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationEvent_Notifications",
                table: "NotificationEvent",
                column: "NotificationId_FK",
                principalTable: "Notifications",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_Notifications_userId",
                table: "Notifications",
                column: "userId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationTask_Task",
                table: "NotificationTask",
                column: "TaskID_FK",
                principalTable: "Task",
                principalColumn: "TaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationVitalSignDetails_VitalSignDetails",
                table: "NotificationVitalSignDetails",
                column: "VitalSignDetailId",
                principalTable: "VitalSignDetails",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionTask_Patient",
                table: "NutritionTask",
                column: "PatientID_FK",
                principalTable: "Patient",
                principalColumn: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_PatientReferral",
                table: "Patient",
                column: "PatientReferralID_FK",
                principalTable: "PatientReferral",
                principalColumn: "PatientReferralID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiseaseSubInfo_Disease",
                table: "DiseaseSubInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientClinician_Disease",
                table: "PatientClinician");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientClinician_Users",
                table: "PatientClinician");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Code",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Code1",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Code2",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Code3",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Code4",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Code5",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Code6",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Code7",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Code_InvoiceModeID_FK",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientProfile_Code",
                table: "PatientProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientProfile_Code1",
                table: "PatientProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientProfile_PatientOrganizationID_FK",
                table: "PatientProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCategory_UserCategoryOrganizationID_FK",
                table: "UserCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientClinician_Patient",
                table: "PatientClinician");

            migrationBuilder.DropForeignKey(
                name: "fk_VitalSigns_patientId",
                table: "VitalSigns");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialCareAssessment_PatientNutrition",
                table: "InitialCareAssessment");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialCareAssessment_VitalSigns",
                table: "InitialCareAssessment");

            migrationBuilder.DropForeignKey(
                name: "fk_VitalSignDetails_vitalSignId",
                table: "VitalSignDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ExternalDoctor_UserType",
                table: "ExternalDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReferral_PatientClinician2",
                table: "PatientReferral");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReferral_PatientClinician3",
                table: "PatientReferral");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReferral_PatientClinician4",
                table: "PatientReferral");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReferral_PatientClinician5",
                table: "PatientReferral");

            migrationBuilder.DropTable(
                name: "APIAccessKey");

            migrationBuilder.DropTable(
                name: "APIMonitor");

            migrationBuilder.DropTable(
                name: "APIOrderAllergy");

            migrationBuilder.DropTable(
                name: "APIOrderDiagnosis");

            migrationBuilder.DropTable(
                name: "APIOrderMedication");

            migrationBuilder.DropTable(
                name: "APIOrderTask");

            migrationBuilder.DropTable(
                name: "APNSNotification");

            migrationBuilder.DropTable(
                name: "Audit_Activity");

            migrationBuilder.DropTable(
                name: "Audit_AMTQuestion");

            migrationBuilder.DropTable(
                name: "Audit_APIAccessKey");

            migrationBuilder.DropTable(
                name: "Audit_APIMonitor");

            migrationBuilder.DropTable(
                name: "Audit_APIOrder");

            migrationBuilder.DropTable(
                name: "Audit_APIOrderAllergy");

            migrationBuilder.DropTable(
                name: "Audit_APIOrderDiagnosis");

            migrationBuilder.DropTable(
                name: "Audit_APIOrderMedication");

            migrationBuilder.DropTable(
                name: "Audit_APIOrderTask");

            migrationBuilder.DropTable(
                name: "Audit_APNSNotification");

            migrationBuilder.DropTable(
                name: "Audit_BillingInvoice");

            migrationBuilder.DropTable(
                name: "Audit_BillingInvoiceConsumable");

            migrationBuilder.DropTable(
                name: "Audit_BillingInvoiceService");

            migrationBuilder.DropTable(
                name: "Audit_BillingPackage");

            migrationBuilder.DropTable(
                name: "Audit_BillingPackageInformation");

            migrationBuilder.DropTable(
                name: "Audit_BillingPackageRequest");

            migrationBuilder.DropTable(
                name: "Audit_BillingProposal");

            migrationBuilder.DropTable(
                name: "Audit_BillingProposalService");

            migrationBuilder.DropTable(
                name: "Audit_BillingService");

            migrationBuilder.DropTable(
                name: "Audit_Branch");

            migrationBuilder.DropTable(
                name: "Audit_C4WDeviceToken");

            migrationBuilder.DropTable(
                name: "Audit_CarePlan");

            migrationBuilder.DropTable(
                name: "Audit_CarePlanDetail");

            migrationBuilder.DropTable(
                name: "Audit_CarePlanStatus");

            migrationBuilder.DropTable(
                name: "Audit_CarePlanSub");

            migrationBuilder.DropTable(
                name: "Audit_CarePlanSubActivity");

            migrationBuilder.DropTable(
                name: "Audit_CarePlanSubCPGoals");

            migrationBuilder.DropTable(
                name: "Audit_CarePlanSubGoal");

            migrationBuilder.DropTable(
                name: "Audit_CarePlanSubIntervention");

            migrationBuilder.DropTable(
                name: "Audit_CarePlanSubProblemList");

            migrationBuilder.DropTable(
                name: "Audit_CarePlanSubProblemListGoal");

            migrationBuilder.DropTable(
                name: "Audit_CareReport");

            migrationBuilder.DropTable(
                name: "Audit_CareReportConfig");

            migrationBuilder.DropTable(
                name: "Audit_CareReportRehabilitation");

            migrationBuilder.DropTable(
                name: "Audit_CareReportSocialSupport");

            migrationBuilder.DropTable(
                name: "Audit_CareReportSystemInfo");

            migrationBuilder.DropTable(
                name: "Audit_Chat");

            migrationBuilder.DropTable(
                name: "Audit_Code");

            migrationBuilder.DropTable(
                name: "Audit_CodeType");

            migrationBuilder.DropTable(
                name: "Audit_CPGoals");

            migrationBuilder.DropTable(
                name: "Audit_Diagnosis");

            migrationBuilder.DropTable(
                name: "Audit_DischargeSummaryReport");

            migrationBuilder.DropTable(
                name: "Audit_DischargeSummaryReportAttachment");

            migrationBuilder.DropTable(
                name: "Audit_Disease");

            migrationBuilder.DropTable(
                name: "Audit_DiseaseInfo");

            migrationBuilder.DropTable(
                name: "Audit_DiseaseSubInfo");

            migrationBuilder.DropTable(
                name: "Audit_DiseaseVitalSignType");

            migrationBuilder.DropTable(
                name: "Audit_EBASDEPQuestion");

            migrationBuilder.DropTable(
                name: "Audit_Enquiry");

            migrationBuilder.DropTable(
                name: "Audit_EnquiryAttachment");

            migrationBuilder.DropTable(
                name: "Audit_EnquiryConfig");

            migrationBuilder.DropTable(
                name: "Audit_EnquiryEscPerson");

            migrationBuilder.DropTable(
                name: "Audit_EnquiryLanguage");

            migrationBuilder.DropTable(
                name: "Audit_EnquirySCM");

            migrationBuilder.DropTable(
                name: "Audit_EnquiryServicesRequired");

            migrationBuilder.DropTable(
                name: "Audit_Event");

            migrationBuilder.DropTable(
                name: "Audit_EventUser");

            migrationBuilder.DropTable(
                name: "Audit_EventUserLog");

            migrationBuilder.DropTable(
                name: "Audit_ExternalDoctor");

            migrationBuilder.DropTable(
                name: "Audit_GeoFencing");

            migrationBuilder.DropTable(
                name: "Audit_Group");

            migrationBuilder.DropTable(
                name: "Audit_GroupRole");

            migrationBuilder.DropTable(
                name: "Audit_ICAWoundCare");

            migrationBuilder.DropTable(
                name: "Audit_InitialCareAssessment");

            migrationBuilder.DropTable(
                name: "Audit_InitialCareAssessmentAttachment");

            migrationBuilder.DropTable(
                name: "Audit_InitialCareAssessmentSpecialInstruction");

            migrationBuilder.DropTable(
                name: "Audit_InitialCareAssessmentVitalSign");

            migrationBuilder.DropTable(
                name: "Audit_Intervention");

            migrationBuilder.DropTable(
                name: "Audit_Item");

            migrationBuilder.DropTable(
                name: "Audit_ItemStock");

            migrationBuilder.DropTable(
                name: "Audit_LoginDevice");

            migrationBuilder.DropTable(
                name: "Audit_MailSettings");

            migrationBuilder.DropTable(
                name: "Audit_MedicationVitalSignType");

            migrationBuilder.DropTable(
                name: "Audit_MobileAppVersioning");

            migrationBuilder.DropTable(
                name: "Audit_MultiDisciplinaryMeeting");

            migrationBuilder.DropTable(
                name: "Audit_MultiDisciplinaryMeetingDetail");

            migrationBuilder.DropTable(
                name: "Audit_NotificationChat");

            migrationBuilder.DropTable(
                name: "Audit_NotificationEvent");

            migrationBuilder.DropTable(
                name: "Audit_NotificationMessageTemplates");

            migrationBuilder.DropTable(
                name: "Audit_Notifications");

            migrationBuilder.DropTable(
                name: "Audit_NotificationTask");

            migrationBuilder.DropTable(
                name: "Audit_NotificationVitalSignDetails");

            migrationBuilder.DropTable(
                name: "Audit_NutritionTask");

            migrationBuilder.DropTable(
                name: "Audit_NutritionTaskReference");

            migrationBuilder.DropTable(
                name: "Audit_Otp");

            migrationBuilder.DropTable(
                name: "Audit_Package");

            migrationBuilder.DropTable(
                name: "Audit_Patient");

            migrationBuilder.DropTable(
                name: "Audit_PatientAccessLine");

            migrationBuilder.DropTable(
                name: "Audit_PatientAdditionalInfo");

            migrationBuilder.DropTable(
                name: "Audit_PatientAMT");

            migrationBuilder.DropTable(
                name: "Audit_PatientAMTAnswer");

            migrationBuilder.DropTable(
                name: "Audit_PatientAttachment");

            migrationBuilder.DropTable(
                name: "Audit_PatientBradenScale");

            migrationBuilder.DropTable(
                name: "Audit_PatientClinician");

            migrationBuilder.DropTable(
                name: "Audit_PatientDrugAllergy");

            migrationBuilder.DropTable(
                name: "Audit_PatientEBASDEP");

            migrationBuilder.DropTable(
                name: "Audit_PatientEBASDEPAnswer");

            migrationBuilder.DropTable(
                name: "Audit_PatientFamilyHistory");

            migrationBuilder.DropTable(
                name: "Audit_PatientGCS");

            migrationBuilder.DropTable(
                name: "Audit_PatientImmunisation");

            migrationBuilder.DropTable(
                name: "Audit_PatientLanguage");

            migrationBuilder.DropTable(
                name: "Audit_PatientMBI");

            migrationBuilder.DropTable(
                name: "Audit_PatientMedicalHistory");

            migrationBuilder.DropTable(
                name: "Audit_PatientMedication");

            migrationBuilder.DropTable(
                name: "Audit_PatientMedicationConsume");

            migrationBuilder.DropTable(
                name: "Audit_PatientMedicationConsumeAttachment");

            migrationBuilder.DropTable(
                name: "Audit_PatientMedicationSupply");

            migrationBuilder.DropTable(
                name: "Audit_PatientMFS");

            migrationBuilder.DropTable(
                name: "Audit_PatientMMSE");

            migrationBuilder.DropTable(
                name: "Audit_PatientNutrition");

            migrationBuilder.DropTable(
                name: "Audit_PatientOtherAllergy");

            migrationBuilder.DropTable(
                name: "Audit_PatientPackage");

            migrationBuilder.DropTable(
                name: "Audit_PatientProfile");

            migrationBuilder.DropTable(
                name: "Audit_PatientRAF");

            migrationBuilder.DropTable(
                name: "Audit_PatientReferral");

            migrationBuilder.DropTable(
                name: "Audit_PatientReferralService");

            migrationBuilder.DropTable(
                name: "Audit_PatientSocialSupport");

            migrationBuilder.DropTable(
                name: "Audit_PatientSpecialIndicator");

            migrationBuilder.DropTable(
                name: "Audit_PatientWound");

            migrationBuilder.DropTable(
                name: "Audit_PatientWoundDraft");

            migrationBuilder.DropTable(
                name: "Audit_PatientWoundReviewBy");

            migrationBuilder.DropTable(
                name: "Audit_PatientWoundVisit");

            migrationBuilder.DropTable(
                name: "Audit_PatientWoundVisitAppearance");

            migrationBuilder.DropTable(
                name: "Audit_PatientWoundVisitCleansingItem");

            migrationBuilder.DropTable(
                name: "Audit_PatientWoundVisitClinician");

            migrationBuilder.DropTable(
                name: "Audit_PatientWoundVisitTreatment");

            migrationBuilder.DropTable(
                name: "Audit_PatientWoundVisitTreatmentList");

            migrationBuilder.DropTable(
                name: "Audit_PatientWoundVisitTreatmentObjectives");

            migrationBuilder.DropTable(
                name: "Audit_ProblemList");

            migrationBuilder.DropTable(
                name: "Audit_ProblemListGoal");

            migrationBuilder.DropTable(
                name: "Audit_Receipt");

            migrationBuilder.DropTable(
                name: "Audit_ReceiptForInvoice");

            migrationBuilder.DropTable(
                name: "Audit_RegisteredDevice");

            migrationBuilder.DropTable(
                name: "Audit_RegisteredDeviceV2");

            migrationBuilder.DropTable(
                name: "Audit_ResidentAssessmentCategory");

            migrationBuilder.DropTable(
                name: "Audit_Role");

            migrationBuilder.DropTable(
                name: "Audit_ScheduledTasks");

            migrationBuilder.DropTable(
                name: "Audit_ServiceForBilling");

            migrationBuilder.DropTable(
                name: "Audit_ServiceForBillingCost");

            migrationBuilder.DropTable(
                name: "Audit_ServiceSkillset");

            migrationBuilder.DropTable(
                name: "Audit_SyncPatientLog");

            migrationBuilder.DropTable(
                name: "Audit_SyncWoundLog");

            migrationBuilder.DropTable(
                name: "Audit_SyncWoundVisitLog");

            migrationBuilder.DropTable(
                name: "Audit_SysConfig");

            migrationBuilder.DropTable(
                name: "Audit_SystemForDisease");

            migrationBuilder.DropTable(
                name: "Audit_Task");

            migrationBuilder.DropTable(
                name: "Audit_TaskFileAttachment");

            migrationBuilder.DropTable(
                name: "Audit_TaskServicesRequired");

            migrationBuilder.DropTable(
                name: "Audit_TaskSpecificDate");

            migrationBuilder.DropTable(
                name: "Audit_TaskUser");

            migrationBuilder.DropTable(
                name: "Audit_TaskUserLog");

            migrationBuilder.DropTable(
                name: "Audit_TaskUserLogAttachment");

            migrationBuilder.DropTable(
                name: "Audit_TD_WoundAssessmentFactor");

            migrationBuilder.DropTable(
                name: "Audit_TeleconsultationRecording");

            migrationBuilder.DropTable(
                name: "Audit_TeleconsultationReport");

            migrationBuilder.DropTable(
                name: "Audit_Thresholds");

            migrationBuilder.DropTable(
                name: "Audit_TreatmentListItem");

            migrationBuilder.DropTable(
                name: "Audit_TreatmentTOL");

            migrationBuilder.DropTable(
                name: "Audit_Types");

            migrationBuilder.DropTable(
                name: "Audit_UploadFile");

            migrationBuilder.DropTable(
                name: "Audit_UserAddress");

            migrationBuilder.DropTable(
                name: "Audit_UserBranch");

            migrationBuilder.DropTable(
                name: "Audit_UserCategory");

            migrationBuilder.DropTable(
                name: "Audit_UserCategoryRole");

            migrationBuilder.DropTable(
                name: "Audit_UserLanguage");

            migrationBuilder.DropTable(
                name: "Audit_UserOrganization");

            migrationBuilder.DropTable(
                name: "Audit_UserRole");

            migrationBuilder.DropTable(
                name: "Audit_Users");

            migrationBuilder.DropTable(
                name: "Audit_UserSkillset");

            migrationBuilder.DropTable(
                name: "Audit_UserType");

            migrationBuilder.DropTable(
                name: "Audit_UserUserType");

            migrationBuilder.DropTable(
                name: "Audit_VitalSignDetails");

            migrationBuilder.DropTable(
                name: "Audit_VitalSignRelationships");

            migrationBuilder.DropTable(
                name: "Audit_VitalSigns");

            migrationBuilder.DropTable(
                name: "Audit_VitalSignTypes");

            migrationBuilder.DropTable(
                name: "Audit_VitalSignTypeThreshold");

            migrationBuilder.DropTable(
                name: "Audit_WoundConsolidatedEmail");

            migrationBuilder.DropTable(
                name: "AuditTrail");

            migrationBuilder.DropTable(
                name: "BillingInvoiceConsumable");

            migrationBuilder.DropTable(
                name: "BillingInvoiceService");

            migrationBuilder.DropTable(
                name: "BillingPackage");

            migrationBuilder.DropTable(
                name: "BillingPackageInformation");

            migrationBuilder.DropTable(
                name: "BillingPackageRequest");

            migrationBuilder.DropTable(
                name: "BillingProposalService");

            migrationBuilder.DropTable(
                name: "C4WDeviceToken");

            migrationBuilder.DropTable(
                name: "C4WImage");

            migrationBuilder.DropTable(
                name: "CarePlanDetail");

            migrationBuilder.DropTable(
                name: "CarePlanSubActivity");

            migrationBuilder.DropTable(
                name: "CarePlanSubCPGoals");

            migrationBuilder.DropTable(
                name: "CarePlanSubGoal");

            migrationBuilder.DropTable(
                name: "CarePlanSubIntervention");

            migrationBuilder.DropTable(
                name: "CarePlanSubProblemListGoal");

            migrationBuilder.DropTable(
                name: "CareReportConfig");

            migrationBuilder.DropTable(
                name: "CareReportSocialSupport");

            migrationBuilder.DropTable(
                name: "DischargeSummaryReportAttachment");

            migrationBuilder.DropTable(
                name: "DiseaseInfo");

            migrationBuilder.DropTable(
                name: "DiseaseVitalSignType");

            migrationBuilder.DropTable(
                name: "EmailLog");

            migrationBuilder.DropTable(
                name: "EnquiryAttachment");

            migrationBuilder.DropTable(
                name: "EnquiryEscPerson");

            migrationBuilder.DropTable(
                name: "EnquiryLanguage");

            migrationBuilder.DropTable(
                name: "EnquirySCM");

            migrationBuilder.DropTable(
                name: "EnquiryServicesRequired");

            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.DropTable(
                name: "EventUserLog");

            migrationBuilder.DropTable(
                name: "GeoFencing");

            migrationBuilder.DropTable(
                name: "GroupRole");

            migrationBuilder.DropTable(
                name: "ICAWoundCare");

            migrationBuilder.DropTable(
                name: "InitialCareAssessmentAttachment");

            migrationBuilder.DropTable(
                name: "InitialCareAssessmentSpecialInstruction");

            migrationBuilder.DropTable(
                name: "InitialCareAssessmentVitalSign");

            migrationBuilder.DropTable(
                name: "IntegrationApiRequestLog");

            migrationBuilder.DropTable(
                name: "ItemStock");

            migrationBuilder.DropTable(
                name: "LoginDevice");

            migrationBuilder.DropTable(
                name: "MailSettingsMsgToUserType");

            migrationBuilder.DropTable(
                name: "MedicationVitalSignType");

            migrationBuilder.DropTable(
                name: "MobileAppVersioning");

            migrationBuilder.DropTable(
                name: "MultiDisciplinaryMeetingDetail");

            migrationBuilder.DropTable(
                name: "NotificationChat");

            migrationBuilder.DropTable(
                name: "NotificationEvent");

            migrationBuilder.DropTable(
                name: "NotificationMessageTemplates");

            migrationBuilder.DropTable(
                name: "NotificationTask");

            migrationBuilder.DropTable(
                name: "NotificationVitalSignDetails");

            migrationBuilder.DropTable(
                name: "NutritionTask");

            migrationBuilder.DropTable(
                name: "Otp");

            migrationBuilder.DropTable(
                name: "PatientAccessLine");

            migrationBuilder.DropTable(
                name: "PatientAMTAnswer");

            migrationBuilder.DropTable(
                name: "PatientAttachment");

            migrationBuilder.DropTable(
                name: "PatientBradenScale");

            migrationBuilder.DropTable(
                name: "PatientDrugAllergy");

            migrationBuilder.DropTable(
                name: "PatientEBASDEPAnswer");

            migrationBuilder.DropTable(
                name: "PatientFacility");

            migrationBuilder.DropTable(
                name: "PatientFamilyHistory");

            migrationBuilder.DropTable(
                name: "PatientGCS");

            migrationBuilder.DropTable(
                name: "PatientImmunisation");

            migrationBuilder.DropTable(
                name: "PatientLanguage");

            migrationBuilder.DropTable(
                name: "PatientMedicalHistory");

            migrationBuilder.DropTable(
                name: "PatientMedicationConsumeAttachment");

            migrationBuilder.DropTable(
                name: "PatientMedicationSupply");

            migrationBuilder.DropTable(
                name: "PatientMMSE");

            migrationBuilder.DropTable(
                name: "PatientOtherAllergy");

            migrationBuilder.DropTable(
                name: "PatientPackage");

            migrationBuilder.DropTable(
                name: "PatientReferralService");

            migrationBuilder.DropTable(
                name: "PatientSpecialIndicator");

            migrationBuilder.DropTable(
                name: "PatientWoundDraftTreatmentList");

            migrationBuilder.DropTable(
                name: "PatientWoundDraftTreatmentObjectives");

            migrationBuilder.DropTable(
                name: "PatientWoundReviewBy");

            migrationBuilder.DropTable(
                name: "PatientWoundVisitAppearance");

            migrationBuilder.DropTable(
                name: "PatientWoundVisitCleansingItem");

            migrationBuilder.DropTable(
                name: "PatientWoundVisitClinician");

            migrationBuilder.DropTable(
                name: "PatientWoundVisitTreatment");

            migrationBuilder.DropTable(
                name: "PatientWoundVisitTreatmentList");

            migrationBuilder.DropTable(
                name: "PatientWoundVisitTreatmentObjectives");

            migrationBuilder.DropTable(
                name: "ReceiptForInvoice");

            migrationBuilder.DropTable(
                name: "RecentView");

            migrationBuilder.DropTable(
                name: "RegisteredDevice");

            migrationBuilder.DropTable(
                name: "RegisteredDeviceV2");

            migrationBuilder.DropTable(
                name: "ResidentAssessmentCategory");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "ScheduledTasks");

            migrationBuilder.DropTable(
                name: "ServiceForBillingCost");

            migrationBuilder.DropTable(
                name: "ServiceSkillset");

            migrationBuilder.DropTable(
                name: "SyncPatientLog");

            migrationBuilder.DropTable(
                name: "SyncWoundLog");

            migrationBuilder.DropTable(
                name: "SyncWoundVisitLog");

            migrationBuilder.DropTable(
                name: "SysConfig");

            migrationBuilder.DropTable(
                name: "TaskFileAttachment");

            migrationBuilder.DropTable(
                name: "TaskServicesRequired");

            migrationBuilder.DropTable(
                name: "TaskSpecificDate");

            migrationBuilder.DropTable(
                name: "TaskUser");

            migrationBuilder.DropTable(
                name: "TaskUserLogAttachment");

            migrationBuilder.DropTable(
                name: "TD_WoundAssessmentFactor");

            migrationBuilder.DropTable(
                name: "TeleconsultationRecording");

            migrationBuilder.DropTable(
                name: "TeleconsultationReport");

            migrationBuilder.DropTable(
                name: "TreatmentTOL");

            migrationBuilder.DropTable(
                name: "UploadFile");

            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.DropTable(
                name: "UserBranch");

            migrationBuilder.DropTable(
                name: "UserCategoryFacility");

            migrationBuilder.DropTable(
                name: "UserCategoryParentChild");

            migrationBuilder.DropTable(
                name: "UserCategoryRole");

            migrationBuilder.DropTable(
                name: "UserLanguage");

            migrationBuilder.DropTable(
                name: "UserOrganization");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserSkillset");

            migrationBuilder.DropTable(
                name: "UserUserType");

            migrationBuilder.DropTable(
                name: "UUIDLog");

            migrationBuilder.DropTable(
                name: "VitalSignRelationships");

            migrationBuilder.DropTable(
                name: "VitalSignTypeThreshold");

            migrationBuilder.DropTable(
                name: "WoundConsolidatedEmail");

            migrationBuilder.DropTable(
                name: "WoundUserCategoryParentChild");

            migrationBuilder.DropTable(
                name: "APIOrder");

            migrationBuilder.DropTable(
                name: "BillingService");

            migrationBuilder.DropTable(
                name: "BillingProposal");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "CPGoals");

            migrationBuilder.DropTable(
                name: "Intervention");

            migrationBuilder.DropTable(
                name: "CarePlanSubProblemList");

            migrationBuilder.DropTable(
                name: "ProblemListGoal");

            migrationBuilder.DropTable(
                name: "PatientSocialSupport");

            migrationBuilder.DropTable(
                name: "DischargeSummaryReport");

            migrationBuilder.DropTable(
                name: "EnquiryConfig");

            migrationBuilder.DropTable(
                name: "Enquiry");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "MultiDisciplinaryMeeting");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NutritionTaskReference");

            migrationBuilder.DropTable(
                name: "AMTQuestion");

            migrationBuilder.DropTable(
                name: "PatientAMT");

            migrationBuilder.DropTable(
                name: "EBASDEPQuestion");

            migrationBuilder.DropTable(
                name: "PatientEBASDEP");

            migrationBuilder.DropTable(
                name: "PatientMedicationConsume");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "PatientWoundDraft");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "BillingInvoice");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "ServiceForBilling");

            migrationBuilder.DropTable(
                name: "TaskUserLog");

            migrationBuilder.DropTable(
                name: "TreatmentListItem");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Thresholds");

            migrationBuilder.DropTable(
                name: "MailSettings");

            migrationBuilder.DropTable(
                name: "CarePlanSub");

            migrationBuilder.DropTable(
                name: "ProblemList");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "PatientWoundVisit");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "PatientWound");

            migrationBuilder.DropTable(
                name: "CareReport");

            migrationBuilder.DropTable(
                name: "CarePlan");

            migrationBuilder.DropTable(
                name: "CareReportRehabilitation");

            migrationBuilder.DropTable(
                name: "CareReportSystemInfo");

            migrationBuilder.DropTable(
                name: "CarePlanStatus");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "Disease");

            migrationBuilder.DropTable(
                name: "SystemForDisease");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropTable(
                name: "CodeType");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "PatientNutrition");

            migrationBuilder.DropTable(
                name: "VitalSigns");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "UserCategory");

            migrationBuilder.DropTable(
                name: "PatientClinician");

            migrationBuilder.DropTable(
                name: "DiseaseSubInfo");

            migrationBuilder.DropTable(
                name: "ExternalDoctor");

            migrationBuilder.DropTable(
                name: "InitialCareAssessment");

            migrationBuilder.DropTable(
                name: "PatientAdditionalInfo");

            migrationBuilder.DropTable(
                name: "PatientMBI");

            migrationBuilder.DropTable(
                name: "PatientMFS");

            migrationBuilder.DropTable(
                name: "PatientMedication");

            migrationBuilder.DropTable(
                name: "PatientProfile");

            migrationBuilder.DropTable(
                name: "PatientRAF");

            migrationBuilder.DropTable(
                name: "PatientReferral");

            migrationBuilder.DropTable(
                name: "VitalSignDetails");

            migrationBuilder.DropTable(
                name: "VitalSignTypes");
        }
    }
}
