namespace FICompliance.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleTypeName = c.String(),
                        RoleType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        FullName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        MartialStatus = c.String(),
                        Nationality = c.String(),
                        DateOfBirth = c.String(),
                        DateOfJoining = c.String(),
                        DateOfConfirm = c.String(),
                        CNIC = c.String(),
                        CNICIssueDate = c.String(),
                        CNICExpiryDate = c.String(),
                        NTN = c.String(),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        ApprovedBy = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsArchive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        IsApprove = c.Boolean(nullable: false),
                        IsPending = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.tblRoles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUsers", "RoleID", "dbo.tblRoles");
            DropIndex("dbo.tblUsers", new[] { "RoleID" });
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblRoles");
        }
    }
}
