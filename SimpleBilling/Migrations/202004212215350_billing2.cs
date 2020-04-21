namespace SimpleBilling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billing2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "UserInfo");
            AlterColumn("dbo.UserInfo", "Username", c => c.String(nullable: false, maxLength: 50));
            CreateStoredProcedure(
                "dbo.Users_Insert",
                p => new
                    {
                        Username = p.String(maxLength: 50),
                        Password = p.String(),
                        UserType = p.Int(),
                        IsDeleted = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[UserInfo]([Username], [Password], [UserType], [IsDeleted])
                      VALUES (@Username, @Password, @UserType, @IsDeleted)
                      
                      DECLARE @UserId int
                      SELECT @UserId = [UserId]
                      FROM [dbo].[UserInfo]
                      WHERE @@ROWCOUNT > 0 AND [UserId] = scope_identity()
                      
                      SELECT t0.[UserId]
                      FROM [dbo].[UserInfo] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[UserId] = @UserId"
            );
            
            CreateStoredProcedure(
                "dbo.Users_Update",
                p => new
                    {
                        UserId = p.Int(),
                        Username = p.String(maxLength: 50),
                        Username_Original = p.String(maxLength: 50),
                        Password = p.String(),
                        UserType = p.Int(),
                        IsDeleted = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[UserInfo]
                      SET [Username] = @Username, [Password] = @Password, [UserType] = @UserType, [IsDeleted] = @IsDeleted
                      WHERE (([UserId] = @UserId) AND (([Username] = @Username_Original) OR ([Username] IS NULL AND @Username_Original IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.Users_Delete",
                p => new
                    {
                        UserId = p.Int(),
                        Username_Original = p.String(maxLength: 50),
                    },
                body:
                    @"DELETE [dbo].[UserInfo]
                      WHERE (([UserId] = @UserId) AND (([Username] = @Username_Original) OR ([Username] IS NULL AND @Username_Original IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Users_Delete");
            DropStoredProcedure("dbo.Users_Update");
            DropStoredProcedure("dbo.Users_Insert");
            AlterColumn("dbo.UserInfo", "Username", c => c.String());
            RenameTable(name: "dbo.UserInfo", newName: "Users");
        }
    }
}
