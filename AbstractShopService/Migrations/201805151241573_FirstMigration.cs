namespace AbstractShopService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BonusFineTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BonusFineId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BonusFines", t => t.BonusFineId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.BonusFineId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.BonusFines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BonusFineName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherFIO = c.String(nullable: false),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MessageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.String(),
                        FromMailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        DateDelivery = c.DateTime(nullable: false),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Zakazs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        StudentId = c.Int(),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SectionId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SectionPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionId = c.Int(nullable: false),
                        PaymentId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zakazs", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Zakazs", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Zakazs", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.SectionPayments", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.SectionPayments", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.MessageInfoes", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.BonusFineTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.BonusFineTeachers", "BonusFineId", "dbo.BonusFines");
            DropIndex("dbo.SectionPayments", new[] { "PaymentId" });
            DropIndex("dbo.SectionPayments", new[] { "SectionId" });
            DropIndex("dbo.Zakazs", new[] { "StudentId" });
            DropIndex("dbo.Zakazs", new[] { "SectionId" });
            DropIndex("dbo.Zakazs", new[] { "TeacherId" });
            DropIndex("dbo.MessageInfoes", new[] { "TeacherId" });
            DropIndex("dbo.BonusFineTeachers", new[] { "TeacherId" });
            DropIndex("dbo.BonusFineTeachers", new[] { "BonusFineId" });
            DropTable("dbo.Students");
            DropTable("dbo.Payments");
            DropTable("dbo.SectionPayments");
            DropTable("dbo.Sections");
            DropTable("dbo.Zakazs");
            DropTable("dbo.MessageInfoes");
            DropTable("dbo.Teachers");
            DropTable("dbo.BonusFines");
            DropTable("dbo.BonusFineTeachers");
        }
    }
}
