namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers Set BirthDate = '08/03/1990' Where Id = 2 ");
        }
        
        public override void Down()
        {
        }
    }
}
