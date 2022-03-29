using Microsoft.EntityFrameworkCore.Migrations;

namespace BootcampHomework3_4.DataAccess.EntityFramework.Migrations
{
    public partial class add_SP_AddCompanyProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[AddCompanyProcedure]
                    @CompanyName nvarchar(250),
                    @CompanyAdress nvarchar(max),
                    @CompanyEmployeeCount int,
                    @CreatedDate datetime2,
                    @CreatedBy nvarchar,
                    @IsDeleted bit
                AS
                BEGIN
                    IF NOT EXISTS(SELECT TOP(1) * FROM Companies WHERE CompanyName=@CompanyName)
                        BEGIN
                              INSERT INTO Companies (CompanyName,CompanyAdress,CompanyEmployeeCount,CreatedDate,CreatedBy,IsDeleted) VALUES (@CompanyName,@CompanyAdress,@CompanyEmployeeCount,@CreatedDate,@CreatedBy,@IsDeleted)
                        END
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
