using Microsoft.EntityFrameworkCore.Migrations;

namespace ChangeControl.Migrations
{
    public partial class AddImpacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Impacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    QmsProceduresProcesses = table.Column<string>(nullable: true),
                    OtherDocumentation = table.Column<string>(nullable: true),
                    FinishedProduct = table.Column<string>(nullable: true),
                    ExistMaterialStockFinishProd = table.Column<string>(nullable: true),
                    ProdCustSpec = table.Column<string>(nullable: true),
                    MaterialQualification = table.Column<string>(nullable: true),
                    ProductValidation = table.Column<string>(nullable: true),
                    ProcessValidation = table.Column<string>(nullable: true),
                    TestEquipMethodsCalib = table.Column<string>(nullable: true),
                    RegulatoryReq = table.Column<string>(nullable: true),
                    SupplierAgreementsSpec = table.Column<string>(nullable: true),
                    CustomerReqSpec = table.Column<string>(nullable: true),
                    NewExistEquipSoftware = table.Column<string>(nullable: true),
                    Cleaning = table.Column<string>(nullable: true),
                    Maintenance = table.Column<string>(nullable: true),
                    Environment = table.Column<string>(nullable: true),
                    ManufWorkFlowAncillaryPkgEquip = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true),
                    ChangeLogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Impacts_ChangeLogs_ChangeLogId",
                        column: x => x.ChangeLogId,
                        principalTable: "ChangeLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Impacts_ChangeLogId",
                table: "Impacts",
                column: "ChangeLogId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Impacts");
        }
    }
}
