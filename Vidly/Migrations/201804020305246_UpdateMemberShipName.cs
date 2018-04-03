namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberShipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes Set MemberShipName = 'Pay as You Go' Where Id = 1 ");
            Sql("UPDATE MembershipTypes Set MemberShipName = 'Monthly' Where Id = 2 ");
            Sql("UPDATE MembershipTypes Set MemberShipName = 'Quarterly' Where Id = 3 ");
            Sql("UPDATE MembershipTypes Set MemberShipName = 'Annual' Where Id = 4 ");
           
        }
        
        public override void Down()
        {
        }
    }
}
