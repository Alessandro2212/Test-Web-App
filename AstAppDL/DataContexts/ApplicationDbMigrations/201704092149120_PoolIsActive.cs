namespace AstAppDL.DataContexts.ApplicationDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoolIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pools", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pools", "IsActive");
        }
    }
}
