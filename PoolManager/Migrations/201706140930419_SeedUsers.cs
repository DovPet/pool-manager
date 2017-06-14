namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [IsBlocked]) VALUES (N'5147af15-39a1-476c-8df1-93f4a04554b2', N'Dovydas@poolmanager.com', 0, N'AM3HfE8Zwq78KUjOGdGEa976F085wngDZ7EvZsfUAzmd2rs1poEzCQfBK53vHqBtGQ==', N'4f0cfde6-1817-4178-b84d-45f762364e14', NULL, 0, 0, NULL, 1, 0, N'Dovydas@poolmanager.com', NULL, NULL, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [IsBlocked]) VALUES (N'c36ba724-0b93-4bec-a4ea-2e88a96afd3d', N'user@user.com', 0, N'AIVw9Oy0GjhbM78MOoeXKf5TUtEkgW5MMTvLpTwM4JwCyJbvmyOKmWc5vQyLqoGyBQ==', N'c74ba879-8210-46d6-9322-8a7c2236432f', NULL, 0, 0, NULL, 1, 0, N'user@user.com', NULL, NULL, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [IsBlocked]) VALUES (N'f8bcb06b-a015-4b7d-a8ab-3984c47500ab', N'Rokas@poolmanager.com', 0, N'AP8zWGwINECmdiIN55wNFwCEysBQCfnyDXMDUGIX6Ofhem6v3d8cytkQJ10SWxEKbQ==', N'f1c37114-16be-40c7-85af-4bd5b6cfaa29', NULL, 0, 0, NULL, 1, 0, N'Rokas@poolmanager.com', NULL, NULL, 0)

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'80caa6b8-50d4-403e-83a9-33759e45f3a7', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7048d1cf-cd18-47a6-b62f-c1a4a3fc3bfd', N'User')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c36ba724-0b93-4bec-a4ea-2e88a96afd3d', N'7048d1cf-cd18-47a6-b62f-c1a4a3fc3bfd')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5147af15-39a1-476c-8df1-93f4a04554b2', N'80caa6b8-50d4-403e-83a9-33759e45f3a7')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f8bcb06b-a015-4b7d-a8ab-3984c47500ab', N'80caa6b8-50d4-403e-83a9-33759e45f3a7')


");
        }
        
        public override void Down()
        {
        }
    }
}
