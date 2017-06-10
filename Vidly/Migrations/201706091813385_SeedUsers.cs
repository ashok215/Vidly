namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'02b393fe-4ee5-4608-9993-c860fbb6c040', N'guest@vidly.com', 0, N'AK63bcRdVDIeUx/29/hxuEgZVxDOkUJn+hUoKqck2ifp4Pv4F4ZgwkcHyXHQ+yKPAQ==', N'd0866d3b-7bc4-4ba2-b90b-edf84f906f3c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd225b17f-d737-42cf-896d-7beedce26c7d', N'admin@vidly.com', 0, N'ABU0IKIswokszpQnOp/fcMqGusrmzf7kq9nxmgii0fKNRYlaHg55sHRy/qzbNPlpXA==', N'ca58f467-d702-49bb-87a8-80e2ccbea8b0', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7f156979-c504-4ab5-b9c9-7d91392194e2', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd225b17f-d737-42cf-896d-7beedce26c7d', N'7f156979-c504-4ab5-b9c9-7d91392194e2')

");
        }
        
        public override void Down()
        {
        }
    }
}
