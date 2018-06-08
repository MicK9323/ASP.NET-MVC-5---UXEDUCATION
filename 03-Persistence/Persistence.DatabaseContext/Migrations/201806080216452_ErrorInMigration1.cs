namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorInMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Credit", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Credit", c => c.String());
        }
    }
}
