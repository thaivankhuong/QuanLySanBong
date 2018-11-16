namespace FootballGround.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTablePermission : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Permissions", "Action");
            DropColumn("dbo.Permissions", "Controller");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Permissions", "Controller", c => c.String());
            AddColumn("dbo.Permissions", "Action", c => c.String());
        }
    }
}
