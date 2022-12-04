using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OA.Repo.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    AboutUs = table.Column<string>(nullable: true),
                    Provide = table.Column<string>(nullable: true),
                    Terms = table.Column<string>(nullable: true),
                    Egabat = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    File = table.Column<string>(nullable: true),
                    Index = table.Column<int>(nullable: false),
                    SlideNumber = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLoggers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text1 = table.Column<string>(nullable: true),
                    Text2 = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLoggers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governorate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mzhb",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mzhb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    WhatsApp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_LibraryType",
                columns: table => new
                {
                    pk_LibraryType_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    Category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LibraryType", x => x.pk_LibraryType_Id);
                    table.UniqueConstraint("AK_tbl_LibraryType_Category", x => x.Category);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Section",
                columns: table => new
                {
                    pk_Section_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    SectionName = table.Column<string>(nullable: true),
                    Index = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Section", x => x.pk_Section_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Semester",
                columns: table => new
                {
                    pk_Semester_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    SemesterName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Index = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Semester", x => x.pk_Semester_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Stage",
                columns: table => new
                {
                    pk_Stage_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    StageName = table.Column<string>(nullable: false),
                    Index = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Stage", x => x.pk_Stage_Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "tbl_Grade",
                columns: table => new
                {
                    pk_Grade_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    GradeName = table.Column<string>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    fk_Stage_Grade_StageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Grade", x => x.pk_Grade_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Grade_tbl_Stage_fk_Stage_Grade_StageId",
                        column: x => x.fk_Stage_Grade_StageId,
                        principalTable: "tbl_Stage",
                        principalColumn: "pk_Stage_Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserFullName = table.Column<string>(nullable: true),
                    OldIdentityId = table.Column<string>(nullable: true),
                    UserImage = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true),
                    DeviceToken = table.Column<string>(nullable: true),
                    GradeId = table.Column<Guid>(nullable: true),
                    SectionId = table.Column<Guid>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tbl_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "tbl_Grade",
                        principalColumn: "pk_Grade_Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tbl_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "tbl_Section",
                        principalColumn: "pk_Section_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Library",
                columns: table => new
                {
                    pk_Library_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    fk_Grade_Library_GradeId = table.Column<Guid>(nullable: false),
                    fk_Semester_Library_SemesterId = table.Column<Guid>(nullable: false),
                    CategoryCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FileImage = table.Column<string>(nullable: true),
                    File = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    IsPremium = table.Column<bool>(nullable: false, defaultValue: true),
                    Index = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Library", x => x.pk_Library_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Library_tbl_LibraryType_CategoryCode",
                        column: x => x.CategoryCode,
                        principalTable: "tbl_LibraryType",
                        principalColumn: "Category");
                    table.ForeignKey(
                        name: "FK_tbl_Library_tbl_Grade_fk_Grade_Library_GradeId",
                        column: x => x.fk_Grade_Library_GradeId,
                        principalTable: "tbl_Grade",
                        principalColumn: "pk_Grade_Id");
                    table.ForeignKey(
                        name: "FK_tbl_Library_tbl_Semester_fk_Semester_Library_SemesterId",
                        column: x => x.fk_Semester_Library_SemesterId,
                        principalTable: "tbl_Semester",
                        principalColumn: "pk_Semester_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_SubjectGrade",
                columns: table => new
                {
                    pk_SubjectGrade_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    fk_Grade_SubjectGrade_GradeId = table.Column<Guid>(nullable: false),
                    SubjectName = table.Column<string>(nullable: false),
                    SubjectImage = table.Column<string>(nullable: true),
                    SubjectSmallImage = table.Column<string>(nullable: true),
                    Index = table.Column<int>(nullable: false),
                    SectionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SubjectGrade", x => x.pk_SubjectGrade_Id);
                    table.ForeignKey(
                        name: "FK_tbl_SubjectGrade_tbl_Grade_fk_Grade_SubjectGrade_GradeId",
                        column: x => x.fk_Grade_SubjectGrade_GradeId,
                        principalTable: "tbl_Grade",
                        principalColumn: "pk_Grade_Id");
                    table.ForeignKey(
                        name: "FK_tbl_SubjectGrade_tbl_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "tbl_Section",
                        principalColumn: "pk_Section_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
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
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "tbl_Message",
                columns: table => new
                {
                    pk_Message_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    fk_ApplicationUser_Message_ApplicationUserSenderId = table.Column<Guid>(nullable: false),
                    fk_ApplicationUser_Message_ApplicationUserReceiverId = table.Column<Guid>(nullable: false),
                    SenderName = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false, defaultValue: false),
                    IsTeacher = table.Column<bool>(nullable: false, defaultValue: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Attachment = table.Column<string>(nullable: true),
                    IsFile = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Message", x => x.pk_Message_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Message_AspNetUsers_fk_ApplicationUser_Message_ApplicationUserReceiverId",
                        column: x => x.fk_ApplicationUser_Message_ApplicationUserReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_Message_AspNetUsers_fk_ApplicationUser_Message_ApplicationUserSenderId",
                        column: x => x.fk_ApplicationUser_Message_ApplicationUserSenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Notification",
                columns: table => new
                {
                    pk_Notification_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    fk_ApplicationUser_Notification_ApplicationUserId = table.Column<Guid>(nullable: false),
                    StudentName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Seen = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Notification", x => x.pk_Notification_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Notification_AspNetUsers_fk_ApplicationUser_Notification_ApplicationUserId",
                        column: x => x.fk_ApplicationUser_Notification_ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Student",
                columns: table => new
                {
                    pk_Student_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Institue_Name = table.Column<string>(nullable: true),
                    GovernorateId = table.Column<Guid>(nullable: false),
                    MzhbId = table.Column<Guid>(nullable: true),
                    SectionId = table.Column<Guid>(nullable: false),
                    StageId = table.Column<Guid>(nullable: false),
                    GradeId = table.Column<Guid>(nullable: false),
                    BranchId = table.Column<Guid>(nullable: true),
                    PremiumSubscription = table.Column<bool>(nullable: false),
                    ProfileImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Student", x => x.pk_Student_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Student_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_Student_Governorate_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_Student_tbl_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "tbl_Grade",
                        principalColumn: "pk_Grade_Id");
                    table.ForeignKey(
                        name: "FK_tbl_Student_AspNetUsers_pk_Student_Id",
                        column: x => x.pk_Student_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_Student_Mzhb_MzhbId",
                        column: x => x.MzhbId,
                        principalTable: "Mzhb",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tbl_Student_tbl_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "tbl_Section",
                        principalColumn: "pk_Section_Id");
                    table.ForeignKey(
                        name: "FK_tbl_Student_tbl_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "tbl_Stage",
                        principalColumn: "pk_Stage_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Teacher",
                columns: table => new
                {
                    pk_Teacher_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    PremiumSubscription = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Teacher", x => x.pk_Teacher_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Teacher_AspNetUsers_pk_Teacher_Id",
                        column: x => x.pk_Teacher_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubjectBranch",
                columns: table => new
                {
                    BranchId = table.Column<Guid>(nullable: false),
                    SubjectGradeId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectBranch", x => new { x.SubjectGradeId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_SubjectBranch_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubjectBranch_tbl_SubjectGrade_SubjectGradeId",
                        column: x => x.SubjectGradeId,
                        principalTable: "tbl_SubjectGrade",
                        principalColumn: "pk_SubjectGrade_Id");
                });

            migrationBuilder.CreateTable(
                name: "SubjectMzhb",
                columns: table => new
                {
                    SubjectGradeId = table.Column<Guid>(nullable: false),
                    MzhbId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectMzhb", x => new { x.SubjectGradeId, x.MzhbId });
                    table.ForeignKey(
                        name: "FK_SubjectMzhb_Mzhb_MzhbId",
                        column: x => x.MzhbId,
                        principalTable: "Mzhb",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubjectMzhb_tbl_SubjectGrade_SubjectGradeId",
                        column: x => x.SubjectGradeId,
                        principalTable: "tbl_SubjectGrade",
                        principalColumn: "pk_SubjectGrade_Id");
                });

            migrationBuilder.CreateTable(
                name: "SubjectSection",
                columns: table => new
                {
                    SectionId = table.Column<Guid>(nullable: false),
                    SubjectGradeId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectSection", x => new { x.SubjectGradeId, x.SectionId });
                    table.ForeignKey(
                        name: "FK_SubjectSection_tbl_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "tbl_Section",
                        principalColumn: "pk_Section_Id");
                    table.ForeignKey(
                        name: "FK_SubjectSection_tbl_SubjectGrade_SubjectGradeId",
                        column: x => x.SubjectGradeId,
                        principalTable: "tbl_SubjectGrade",
                        principalColumn: "pk_SubjectGrade_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Unit",
                columns: table => new
                {
                    pk_Unit_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    fk_Subject_Unit_SubjectId = table.Column<Guid>(nullable: false),
                    fk_Semester_Unit_SemesterId = table.Column<Guid>(nullable: false),
                    UnitName = table.Column<string>(nullable: true),
                    Index = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Unit", x => x.pk_Unit_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Unit_tbl_Semester_fk_Semester_Unit_SemesterId",
                        column: x => x.fk_Semester_Unit_SemesterId,
                        principalTable: "tbl_Semester",
                        principalColumn: "pk_Semester_Id");
                    table.ForeignKey(
                        name: "FK_tbl_Unit_tbl_SubjectGrade_fk_Subject_Unit_SubjectId",
                        column: x => x.fk_Subject_Unit_SubjectId,
                        principalTable: "tbl_SubjectGrade",
                        principalColumn: "pk_SubjectGrade_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_ExtraRequest",
                columns: table => new
                {
                    pk_ExtraRequest_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    fk_Student_ExtraRequest_StudentId = table.Column<Guid>(nullable: false),
                    fk_Subject_ExtraRequest_SubjectId = table.Column<Guid>(nullable: false),
                    RequestCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ExtraRequest", x => x.pk_ExtraRequest_Id);
                    table.ForeignKey(
                        name: "FK_tbl_ExtraRequest_tbl_Student_fk_Student_ExtraRequest_StudentId",
                        column: x => x.fk_Student_ExtraRequest_StudentId,
                        principalTable: "tbl_Student",
                        principalColumn: "pk_Student_Id");
                    table.ForeignKey(
                        name: "FK_tbl_ExtraRequest_tbl_SubjectGrade_fk_Subject_ExtraRequest_SubjectId",
                        column: x => x.fk_Subject_ExtraRequest_SubjectId,
                        principalTable: "tbl_SubjectGrade",
                        principalColumn: "pk_SubjectGrade_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Request",
                columns: table => new
                {
                    pk_Request_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    RequestNo = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Replied = table.Column<bool>(nullable: false, defaultValue: false),
                    RepliedInTime = table.Column<bool>(nullable: false, defaultValue: false),
                    fk_Subject_Request_SubjectId = table.Column<Guid>(nullable: false),
                    fk_Student_Request_StudentId = table.Column<Guid>(nullable: false),
                    fk_Teacher_Request_TeacherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Request", x => x.pk_Request_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Request_tbl_Student_fk_Student_Request_StudentId",
                        column: x => x.fk_Student_Request_StudentId,
                        principalTable: "tbl_Student",
                        principalColumn: "pk_Student_Id");
                    table.ForeignKey(
                        name: "FK_tbl_Request_tbl_SubjectGrade_fk_Subject_Request_SubjectId",
                        column: x => x.fk_Subject_Request_SubjectId,
                        principalTable: "tbl_SubjectGrade",
                        principalColumn: "pk_SubjectGrade_Id");
                    table.ForeignKey(
                        name: "FK_tbl_Request_tbl_Teacher_fk_Teacher_Request_TeacherId",
                        column: x => x.fk_Teacher_Request_TeacherId,
                        principalTable: "tbl_Teacher",
                        principalColumn: "pk_Teacher_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_TeacherSubject",
                columns: table => new
                {
                    pk_TeacherSubject_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    fk_Teacher_TeacherSubject_TeacherId = table.Column<Guid>(nullable: false),
                    fk_Subject_TeacherSubject_SubjectId = table.Column<Guid>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TeacherSubject", x => x.pk_TeacherSubject_Id);
                    table.ForeignKey(
                        name: "FK_tbl_TeacherSubject_tbl_SubjectGrade_fk_Subject_TeacherSubject_SubjectId",
                        column: x => x.fk_Subject_TeacherSubject_SubjectId,
                        principalTable: "tbl_SubjectGrade",
                        principalColumn: "pk_SubjectGrade_Id");
                    table.ForeignKey(
                        name: "FK_tbl_TeacherSubject_tbl_Teacher_fk_Teacher_TeacherSubject_TeacherId",
                        column: x => x.fk_Teacher_TeacherSubject_TeacherId,
                        principalTable: "tbl_Teacher",
                        principalColumn: "pk_Teacher_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Lesson",
                columns: table => new
                {
                    pk_Lesson_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    fk_Unit_Lesson_UnitId = table.Column<Guid>(nullable: false),
                    LessonName = table.Column<string>(nullable: true),
                    Index = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Lesson", x => x.pk_Lesson_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Lesson_tbl_Unit_fk_Unit_Lesson_UnitId",
                        column: x => x.fk_Unit_Lesson_UnitId,
                        principalTable: "tbl_Unit",
                        principalColumn: "pk_Unit_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Answer",
                columns: table => new
                {
                    pk_Answer_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    fk_Teacher_Answer_TeacherId = table.Column<Guid>(nullable: false),
                    fk_Student_Answer_StudentId = table.Column<Guid>(nullable: false),
                    fk_Subject_Answer_SubjectId = table.Column<Guid>(nullable: false),
                    fk_Request_Answer_RequestId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Answer", x => x.pk_Answer_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Answer_tbl_Request_fk_Request_Answer_RequestId",
                        column: x => x.fk_Request_Answer_RequestId,
                        principalTable: "tbl_Request",
                        principalColumn: "pk_Request_Id");
                    table.ForeignKey(
                        name: "FK_tbl_Answer_tbl_Student_fk_Student_Answer_StudentId",
                        column: x => x.fk_Student_Answer_StudentId,
                        principalTable: "tbl_Student",
                        principalColumn: "pk_Student_Id");
                    table.ForeignKey(
                        name: "FK_tbl_Answer_tbl_SubjectGrade_fk_Subject_Answer_SubjectId",
                        column: x => x.fk_Subject_Answer_SubjectId,
                        principalTable: "tbl_SubjectGrade",
                        principalColumn: "pk_SubjectGrade_Id");
                    table.ForeignKey(
                        name: "FK_tbl_Answer_tbl_Teacher_fk_Teacher_Answer_TeacherId",
                        column: x => x.fk_Teacher_Answer_TeacherId,
                        principalTable: "tbl_Teacher",
                        principalColumn: "pk_Teacher_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_RequestAttachment",
                columns: table => new
                {
                    pk_RequestAttachment_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    pk_Request_RequestAttachment_RequestId = table.Column<Guid>(nullable: false),
                    File = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RequestAttachment", x => x.pk_RequestAttachment_Id);
                    table.ForeignKey(
                        name: "FK_tbl_RequestAttachment_tbl_Request_pk_Request_RequestAttachment_RequestId",
                        column: x => x.pk_Request_RequestAttachment_RequestId,
                        principalTable: "tbl_Request",
                        principalColumn: "pk_Request_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_TeacherSubjectPermessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Teacher_Subject_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    Permession = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TeacherSubjectPermessions", x => new { x.Id, x.Teacher_Subject_Id });
                    table.ForeignKey(
                        name: "FK_tbl_TeacherSubjectPermessions_tbl_TeacherSubject_Teacher_Subject_Id",
                        column: x => x.Teacher_Subject_Id,
                        principalTable: "tbl_TeacherSubject",
                        principalColumn: "pk_TeacherSubject_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_LessonAttachment",
                columns: table => new
                {
                    pk_LessonAttachment_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    fk_Lesson_LessonAttachment_LessonId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    FileImage = table.Column<string>(nullable: true),
                    File = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ContentTypeFor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LessonAttachment", x => x.pk_LessonAttachment_Id);
                    table.ForeignKey(
                        name: "FK_tbl_LessonAttachment_tbl_Lesson_fk_Lesson_LessonAttachment_LessonId",
                        column: x => x.fk_Lesson_LessonAttachment_LessonId,
                        principalTable: "tbl_Lesson",
                        principalColumn: "pk_Lesson_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_LessonQuestion",
                columns: table => new
                {
                    pk_LessonQuestion_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    LessonId = table.Column<Guid>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    Index = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LessonQuestion", x => x.pk_LessonQuestion_Id);
                    table.ForeignKey(
                        name: "FK_tbl_LessonQuestion_tbl_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "tbl_Lesson",
                        principalColumn: "pk_Lesson_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_LessonVideoRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    LessonId = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<string>(nullable: true),
                    Attenendence = table.Column<int>(nullable: false),
                    LiveDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LessonVideoRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_LessonVideoRoom_tbl_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "tbl_Lesson",
                        principalColumn: "pk_Lesson_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_AnswerAttachment",
                columns: table => new
                {
                    pk_AnswerAttachment_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    fk_Answer_AnswerAttachment_AnswerId = table.Column<Guid>(nullable: false),
                    File = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AnswerAttachment", x => x.pk_AnswerAttachment_Id);
                    table.ForeignKey(
                        name: "FK_tbl_AnswerAttachment_tbl_Answer_fk_Answer_AnswerAttachment_AnswerId",
                        column: x => x.fk_Answer_AnswerAttachment_AnswerId,
                        principalTable: "tbl_Answer",
                        principalColumn: "pk_Answer_Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_lessonQuestionAnswer",
                columns: table => new
                {
                    pk_lessonQuestionAnswer_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    LessonQuestionId = table.Column<Guid>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    IsRight = table.Column<bool>(nullable: false),
                    Index = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_lessonQuestionAnswer", x => x.pk_lessonQuestionAnswer_Id);
                    table.ForeignKey(
                        name: "FK_tbl_lessonQuestionAnswer_tbl_LessonQuestion_LessonQuestionId",
                        column: x => x.LessonQuestionId,
                        principalTable: "tbl_LessonQuestion",
                        principalColumn: "pk_LessonQuestion_Id");
                });

            migrationBuilder.CreateTable(
                name: "LessonVideoRoomConnections",
                columns: table => new
                {
                    Connection_Id = table.Column<string>(nullable: false),
                    Room_Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    User_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonVideoRoomConnections", x => new { x.Connection_Id, x.Room_Id });
                    table.ForeignKey(
                        name: "FK_LessonVideoRoomConnections_tbl_LessonVideoRoom_Room_Id",
                        column: x => x.Room_Id,
                        principalTable: "tbl_LessonVideoRoom",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_StudentlessonQuestionAnswer",
                columns: table => new
                {
                    pk_StudentlessonQuestionAnswer_Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModifyDate = table.Column<DateTime>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: false),
                    LessonQuestionId = table.Column<Guid>(nullable: false),
                    LessonQuestionAnswerId = table.Column<Guid>(nullable: true),
                    IsRight = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_StudentlessonQuestionAnswer", x => x.pk_StudentlessonQuestionAnswer_Id);
                    table.ForeignKey(
                        name: "FK_tbl_StudentlessonQuestionAnswer_tbl_lessonQuestionAnswer_LessonQuestionAnswerId",
                        column: x => x.LessonQuestionAnswerId,
                        principalTable: "tbl_lessonQuestionAnswer",
                        principalColumn: "pk_lessonQuestionAnswer_Id");
                    table.ForeignKey(
                        name: "FK_tbl_StudentlessonQuestionAnswer_tbl_LessonQuestion_LessonQuestionId",
                        column: x => x.LessonQuestionId,
                        principalTable: "tbl_LessonQuestion",
                        principalColumn: "pk_LessonQuestion_Id");
                    table.ForeignKey(
                        name: "FK_tbl_StudentlessonQuestionAnswer_tbl_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "tbl_Student",
                        principalColumn: "pk_Student_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "IX_AspNetUsers_GradeId",
                table: "AspNetUsers",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SectionId",
                table: "AspNetUsers",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonVideoRoomConnections_Room_Id",
                table: "LessonVideoRoomConnections",
                column: "Room_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectBranch_BranchId",
                table: "SubjectBranch",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectMzhb_MzhbId",
                table: "SubjectMzhb",
                column: "MzhbId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSection_SectionId",
                table: "SubjectSection",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Answer_fk_Request_Answer_RequestId",
                table: "tbl_Answer",
                column: "fk_Request_Answer_RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Answer_fk_Student_Answer_StudentId",
                table: "tbl_Answer",
                column: "fk_Student_Answer_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Answer_fk_Subject_Answer_SubjectId",
                table: "tbl_Answer",
                column: "fk_Subject_Answer_SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Answer_fk_Teacher_Answer_TeacherId",
                table: "tbl_Answer",
                column: "fk_Teacher_Answer_TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_AnswerAttachment_fk_Answer_AnswerAttachment_AnswerId",
                table: "tbl_AnswerAttachment",
                column: "fk_Answer_AnswerAttachment_AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ExtraRequest_fk_Student_ExtraRequest_StudentId",
                table: "tbl_ExtraRequest",
                column: "fk_Student_ExtraRequest_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ExtraRequest_fk_Subject_ExtraRequest_SubjectId",
                table: "tbl_ExtraRequest",
                column: "fk_Subject_ExtraRequest_SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Grade_fk_Stage_Grade_StageId",
                table: "tbl_Grade",
                column: "fk_Stage_Grade_StageId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Lesson_fk_Unit_Lesson_UnitId",
                table: "tbl_Lesson",
                column: "fk_Unit_Lesson_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LessonAttachment_fk_Lesson_LessonAttachment_LessonId",
                table: "tbl_LessonAttachment",
                column: "fk_Lesson_LessonAttachment_LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LessonQuestion_LessonId",
                table: "tbl_LessonQuestion",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_lessonQuestionAnswer_LessonQuestionId",
                table: "tbl_lessonQuestionAnswer",
                column: "LessonQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LessonVideoRoom_LessonId",
                table: "tbl_LessonVideoRoom",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LessonVideoRoom_RoomId_Deleted",
                table: "tbl_LessonVideoRoom",
                columns: new[] { "RoomId", "Deleted" },
                unique: true,
                filter: "[RoomId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Library_CategoryCode",
                table: "tbl_Library",
                column: "CategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Library_fk_Grade_Library_GradeId",
                table: "tbl_Library",
                column: "fk_Grade_Library_GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Library_fk_Semester_Library_SemesterId",
                table: "tbl_Library",
                column: "fk_Semester_Library_SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Message_fk_ApplicationUser_Message_ApplicationUserReceiverId",
                table: "tbl_Message",
                column: "fk_ApplicationUser_Message_ApplicationUserReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Message_fk_ApplicationUser_Message_ApplicationUserSenderId",
                table: "tbl_Message",
                column: "fk_ApplicationUser_Message_ApplicationUserSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Notification_fk_ApplicationUser_Notification_ApplicationUserId",
                table: "tbl_Notification",
                column: "fk_ApplicationUser_Notification_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Request_fk_Student_Request_StudentId",
                table: "tbl_Request",
                column: "fk_Student_Request_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Request_fk_Subject_Request_SubjectId",
                table: "tbl_Request",
                column: "fk_Subject_Request_SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Request_fk_Teacher_Request_TeacherId",
                table: "tbl_Request",
                column: "fk_Teacher_Request_TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RequestAttachment_pk_Request_RequestAttachment_RequestId",
                table: "tbl_RequestAttachment",
                column: "pk_Request_RequestAttachment_RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Student_BranchId",
                table: "tbl_Student",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Student_GovernorateId",
                table: "tbl_Student",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Student_GradeId",
                table: "tbl_Student",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Student_MzhbId",
                table: "tbl_Student",
                column: "MzhbId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Student_SectionId",
                table: "tbl_Student",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Student_StageId",
                table: "tbl_Student",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_StudentlessonQuestionAnswer_LessonQuestionAnswerId",
                table: "tbl_StudentlessonQuestionAnswer",
                column: "LessonQuestionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_StudentlessonQuestionAnswer_LessonQuestionId",
                table: "tbl_StudentlessonQuestionAnswer",
                column: "LessonQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_StudentlessonQuestionAnswer_StudentId",
                table: "tbl_StudentlessonQuestionAnswer",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SubjectGrade_fk_Grade_SubjectGrade_GradeId",
                table: "tbl_SubjectGrade",
                column: "fk_Grade_SubjectGrade_GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_SubjectGrade_SectionId",
                table: "tbl_SubjectGrade",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TeacherSubject_fk_Subject_TeacherSubject_SubjectId",
                table: "tbl_TeacherSubject",
                column: "fk_Subject_TeacherSubject_SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TeacherSubject_fk_Teacher_TeacherSubject_TeacherId",
                table: "tbl_TeacherSubject",
                column: "fk_Teacher_TeacherSubject_TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TeacherSubjectPermessions_Teacher_Subject_Id",
                table: "tbl_TeacherSubjectPermessions",
                column: "Teacher_Subject_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Unit_fk_Semester_Unit_SemesterId",
                table: "tbl_Unit",
                column: "fk_Semester_Unit_SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Unit_fk_Subject_Unit_SubjectId",
                table: "tbl_Unit",
                column: "fk_Subject_Unit_SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "Advertisements");

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
                name: "ExceptionLoggers");

            migrationBuilder.DropTable(
                name: "LessonVideoRoomConnections");

            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.DropTable(
                name: "SubjectBranch");

            migrationBuilder.DropTable(
                name: "SubjectMzhb");

            migrationBuilder.DropTable(
                name: "SubjectSection");

            migrationBuilder.DropTable(
                name: "tbl_AnswerAttachment");

            migrationBuilder.DropTable(
                name: "tbl_ExtraRequest");

            migrationBuilder.DropTable(
                name: "tbl_LessonAttachment");

            migrationBuilder.DropTable(
                name: "tbl_Library");

            migrationBuilder.DropTable(
                name: "tbl_Message");

            migrationBuilder.DropTable(
                name: "tbl_Notification");

            migrationBuilder.DropTable(
                name: "tbl_RequestAttachment");

            migrationBuilder.DropTable(
                name: "tbl_StudentlessonQuestionAnswer");

            migrationBuilder.DropTable(
                name: "tbl_TeacherSubjectPermessions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tbl_LessonVideoRoom");

            migrationBuilder.DropTable(
                name: "tbl_Answer");

            migrationBuilder.DropTable(
                name: "tbl_LibraryType");

            migrationBuilder.DropTable(
                name: "tbl_lessonQuestionAnswer");

            migrationBuilder.DropTable(
                name: "tbl_TeacherSubject");

            migrationBuilder.DropTable(
                name: "tbl_Request");

            migrationBuilder.DropTable(
                name: "tbl_LessonQuestion");

            migrationBuilder.DropTable(
                name: "tbl_Student");

            migrationBuilder.DropTable(
                name: "tbl_Teacher");

            migrationBuilder.DropTable(
                name: "tbl_Lesson");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Governorate");

            migrationBuilder.DropTable(
                name: "Mzhb");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tbl_Unit");

            migrationBuilder.DropTable(
                name: "tbl_Semester");

            migrationBuilder.DropTable(
                name: "tbl_SubjectGrade");

            migrationBuilder.DropTable(
                name: "tbl_Grade");

            migrationBuilder.DropTable(
                name: "tbl_Section");

            migrationBuilder.DropTable(
                name: "tbl_Stage");
        }
    }
}
