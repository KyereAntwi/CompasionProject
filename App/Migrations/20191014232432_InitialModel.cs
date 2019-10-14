using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicTerms",
                columns: table => new
                {
                    AcademicTermID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Term = table.Column<string>(maxLength: 6, nullable: false),
                    Year = table.Column<string>(maxLength: 9, nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateStarted = table.Column<DateTime>(nullable: false),
                    DateEnded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicTerms", x => x.AcademicTermID);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    ChallengeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChallengeTitle = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.ChallengeID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK_Classes_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentSubject",
                columns: table => new
                {
                    DepartmentSubjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectID = table.Column<int>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSubject", x => x.DepartmentSubjectID);
                    table.ForeignKey(
                        name: "FK_DepartmentSubject_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentSubject_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 15, nullable: false),
                    MiddleNames = table.Column<string>(maxLength: 15, nullable: true),
                    Surname = table.Column<string>(maxLength: 15, nullable: false),
                    User = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(maxLength: 1, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    DateAdmitted = table.Column<DateTime>(nullable: true),
                    ClassID = table.Column<int>(nullable: true),
                    EducationalLevel = table.Column<string>(maxLength: 500, nullable: true),
                    Occupation = table.Column<string>(maxLength: 500, nullable: true),
                    MaritalStatus = table.Column<string>(maxLength: 8, nullable: true),
                    PreferedCommunication = table.Column<string>(maxLength: 500, nullable: true),
                    Worker_EducationalLevel = table.Column<string>(nullable: true),
                    Worker_MaritalStatus = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Person_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildChallenges",
                columns: table => new
                {
                    ChildChallengeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChildID = table.Column<int>(nullable: false),
                    ChallengeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildChallenges", x => x.ChildChallengeID);
                    table.ForeignKey(
                        name: "FK_ChildChallenges_Challenges_ChallengeID",
                        column: x => x.ChallengeID,
                        principalTable: "Challenges",
                        principalColumn: "ChallengeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildChallenges_Person_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildNeeds",
                columns: table => new
                {
                    ChildNeedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChildID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildNeeds", x => x.ChildNeedID);
                    table.ForeignKey(
                        name: "FK_ChildNeeds_Person_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PostalAddress = table.Column<string>(nullable: true),
                    WebUrl = table.Column<string>(nullable: true),
                    PersonID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_Contacts_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Letters",
                columns: table => new
                {
                    LetterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChildID = table.Column<int>(nullable: false),
                    SponcerID = table.Column<int>(nullable: false),
                    SponserPersonID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Read = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.LetterID);
                    table.ForeignKey(
                        name: "FK_Letters_Person_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Letters_Person_SponserPersonID",
                        column: x => x.SponserPersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TakeCares",
                columns: table => new
                {
                    TakeCareID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChildID = table.Column<int>(nullable: false),
                    SponserID = table.Column<int>(nullable: false),
                    DateStarted = table.Column<DateTime>(nullable: false),
                    PolicySigned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakeCares", x => x.TakeCareID);
                    table.ForeignKey(
                        name: "FK_TakeCares_Person_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Talents",
                columns: table => new
                {
                    TalentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TalentTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ChildID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talents", x => x.TalentID);
                    table.ForeignKey(
                        name: "FK_Talents_Person_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transcripts",
                columns: table => new
                {
                    TranscriptID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChildID = table.Column<int>(nullable: false),
                    AcademicTermID = table.Column<int>(nullable: false),
                    SubjectID = table.Column<int>(nullable: false),
                    ClassScore = table.Column<double>(nullable: false),
                    ExamScore = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcripts", x => x.TranscriptID);
                    table.ForeignKey(
                        name: "FK_Transcripts_AcademicTerms_AcademicTermID",
                        column: x => x.AcademicTermID,
                        principalTable: "AcademicTerms",
                        principalColumn: "AcademicTermID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transcripts_Person_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transcripts_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    VisitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SponserID = table.Column<int>(nullable: false),
                    VisitDate = table.Column<DateTime>(nullable: false),
                    LeavingDate = table.Column<DateTime>(nullable: false),
                    Visited = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.VisitID);
                    table.ForeignKey(
                        name: "FK_Visit_Person_SponserID",
                        column: x => x.SponserID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    VolunteerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SponserID = table.Column<int>(nullable: false),
                    VolunteeringType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.VolunteerID);
                    table.ForeignKey(
                        name: "FK_Volunteers_Person_SponserID",
                        column: x => x.SponserID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildChallenges_ChallengeID",
                table: "ChildChallenges",
                column: "ChallengeID");

            migrationBuilder.CreateIndex(
                name: "IX_ChildChallenges_ChildID",
                table: "ChildChallenges",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_ChildNeeds_ChildID",
                table: "ChildNeeds",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_DepartmentID",
                table: "Classes",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PersonID",
                table: "Contacts",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSubject_DepartmentID",
                table: "DepartmentSubject",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSubject_SubjectID",
                table: "DepartmentSubject",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Letters_ChildID",
                table: "Letters",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Letters_SponserPersonID",
                table: "Letters",
                column: "SponserPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ClassID",
                table: "Person",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_TakeCares_ChildID",
                table: "TakeCares",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_ChildID",
                table: "Talents",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_AcademicTermID",
                table: "Transcripts",
                column: "AcademicTermID");

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_ChildID",
                table: "Transcripts",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_SubjectID",
                table: "Transcripts",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_SponserID",
                table: "Visit",
                column: "SponserID");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_SponserID",
                table: "Volunteers",
                column: "SponserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildChallenges");

            migrationBuilder.DropTable(
                name: "ChildNeeds");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "DepartmentSubject");

            migrationBuilder.DropTable(
                name: "Letters");

            migrationBuilder.DropTable(
                name: "TakeCares");

            migrationBuilder.DropTable(
                name: "Talents");

            migrationBuilder.DropTable(
                name: "Transcripts");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "AcademicTerms");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
