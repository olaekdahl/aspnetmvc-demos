namespace Socrates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "Department_Id" });
            AddColumn("dbo.Courses", "Department_Id1", c => c.Int());
            AlterColumn("dbo.Courses", "Department_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "Department_Id1");
            AddForeignKey("dbo.Courses", "Department_Id1", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Department_Id1", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "Department_Id1" });
            AlterColumn("dbo.Courses", "Department_Id", c => c.Int());
            DropColumn("dbo.Courses", "Department_Id1");
            CreateIndex("dbo.Courses", "Department_Id");
            AddForeignKey("dbo.Courses", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
