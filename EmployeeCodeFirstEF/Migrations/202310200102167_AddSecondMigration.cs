namespace EmployeeCodeFirstEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Department_Id", c => c.Int());
            CreateIndex("dbo.Departments", "Department_Id");
            AddForeignKey("dbo.Departments", "Department_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Departments", new[] { "Department_Id" });
            DropColumn("dbo.Departments", "Department_Id");
        }
    }
}
