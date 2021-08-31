namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleStudent",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Student_ID })
                .ForeignKey("dbo.Role", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.Student_ID, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Student_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleStudent", "Student_ID", "dbo.Student");
            DropForeignKey("dbo.RoleStudent", "Role_Id", "dbo.Role");
            DropIndex("dbo.RoleStudent", new[] { "Student_ID" });
            DropIndex("dbo.RoleStudent", new[] { "Role_Id" });
            DropTable("dbo.RoleStudent");
            DropTable("dbo.Role");
        }
    }
}
