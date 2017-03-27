namespace AstAppDL.DataContexts.ApplicationDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFounderFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        StartingPrice = c.Double(nullable: false),
                        Pool_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pools", t => t.Pool_Id)
                .Index(t => t.Pool_Id);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        TmpInsert = c.DateTime(nullable: false),
                        Item_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsFounder = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        PoolRoom_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PoolRooms", t => t.PoolRoom_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.PoolRoom_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Pools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PoolFounder_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PoolFounder_Id)
                .Index(t => t.PoolFounder_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserJoinPoolRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserState = c.Int(nullable: false),
                        PoolRoom_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PoolRooms", t => t.PoolRoom_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.PoolRoom_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.PoolRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item_Id = c.Int(),
                        Pool_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.Pools", t => t.Pool_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.Pool_Id);
            
            CreateTable(
                "dbo.PoolStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PoolRoomState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.PoolStatePoolRooms",
                c => new
                    {
                        PoolState_Id = c.Int(nullable: false),
                        PoolRoom_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PoolState_Id, t.PoolRoom_Id })
                .ForeignKey("dbo.PoolStates", t => t.PoolState_Id, cascadeDelete: true)
                .ForeignKey("dbo.PoolRooms", t => t.PoolRoom_Id, cascadeDelete: true)
                .Index(t => t.PoolState_Id)
                .Index(t => t.PoolRoom_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserJoinPoolRooms", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "PoolRoom_Id", "dbo.PoolRooms");
            DropForeignKey("dbo.PoolStatePoolRooms", "PoolRoom_Id", "dbo.PoolRooms");
            DropForeignKey("dbo.PoolStatePoolRooms", "PoolState_Id", "dbo.PoolStates");
            DropForeignKey("dbo.UserJoinPoolRooms", "PoolRoom_Id", "dbo.PoolRooms");
            DropForeignKey("dbo.PoolRooms", "Pool_Id", "dbo.Pools");
            DropForeignKey("dbo.PoolRooms", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pools", "PoolFounder_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Items", "Pool_Id", "dbo.Pools");
            DropForeignKey("dbo.Offers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Offers", "Item_Id", "dbo.Items");
            DropIndex("dbo.PoolStatePoolRooms", new[] { "PoolRoom_Id" });
            DropIndex("dbo.PoolStatePoolRooms", new[] { "PoolState_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PoolRooms", new[] { "Pool_Id" });
            DropIndex("dbo.PoolRooms", new[] { "Item_Id" });
            DropIndex("dbo.UserJoinPoolRooms", new[] { "User_Id" });
            DropIndex("dbo.UserJoinPoolRooms", new[] { "PoolRoom_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Pools", new[] { "PoolFounder_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "PoolRoom_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Offers", new[] { "User_Id" });
            DropIndex("dbo.Offers", new[] { "Item_Id" });
            DropIndex("dbo.Items", new[] { "Pool_Id" });
            DropTable("dbo.PoolStatePoolRooms");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PoolStates");
            DropTable("dbo.PoolRooms");
            DropTable("dbo.UserJoinPoolRooms");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Pools");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Offers");
            DropTable("dbo.Items");
        }
    }
}
