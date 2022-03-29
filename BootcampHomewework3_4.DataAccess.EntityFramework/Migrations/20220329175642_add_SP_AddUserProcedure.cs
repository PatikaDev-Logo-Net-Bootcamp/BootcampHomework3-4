using Microsoft.EntityFrameworkCore.Migrations;

namespace BootcampHomework3_4.DataAccess.EntityFramework.Migrations
{
    public partial class add_SP_AddUserProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[AddUserProcedure]
                    @UserName nvarchar(250),
                    @UserSurname nvarchar(max),
                    @UserAge int,
                    @Password nvarchar(max),
                    @UserGender int,
                    @CompanyID int,
                    @CreatedDate datetime2,
                    @CreatedBy nvarchar,
                    @IsDeleted bit
                AS
                BEGIN
                    IF NOT EXISTS(SELECT TOP(1) * FROM Users WHERE UserName=@UserName)
                        BEGIN
                              INSERT INTO Users (UserName,UserSurname,UserAge,Password,UserGender,CompanyID,CreatedDate,CreatedBy,IsDeleted) VALUES (@UserName,@UserSurname,@UserAge,@Password,@UserGender,@CompanyID,@CreatedDate,@CreatedBy,@IsDeleted)
                        END
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
