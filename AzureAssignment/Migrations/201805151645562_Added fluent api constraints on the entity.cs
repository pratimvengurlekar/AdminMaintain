namespace AzureAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedfluentapiconstraintsontheentity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Employees", "LName", c => c.String(maxLength: 40));
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Address", c => c.String());
            AlterColumn("dbo.Employees", "LName", c => c.String());
            AlterColumn("dbo.Employees", "FName", c => c.String());
        }
    }
}
