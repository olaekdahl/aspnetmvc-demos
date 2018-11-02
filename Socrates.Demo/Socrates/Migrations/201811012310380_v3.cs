namespace Socrates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Courses", new[] { "Department_Id1" });
            DropColumn("dbo.Courses", "Department_Id");
            RenameColumn(table: "dbo.Courses", name: "Department_Id1", newName: "Department_Id");
            AlterColumn("dbo.Courses", "Title", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Courses", "Department_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Department_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Courses", new[] { "Department_Id" });
            AlterColumn("dbo.Courses", "Department_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "Title", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Courses", name: "Department_Id", newName: "Department_Id1");
            AddColumn("dbo.Courses", "Department_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "Department_Id1");
        }
    }
}
