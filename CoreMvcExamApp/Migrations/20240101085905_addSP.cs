using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMvcExamApp.Migrations
{
    /// <inheritdoc />
    public partial class addSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string SpInsertInvoice = @"create or ALTER  PROCEDURE dbo.SpInsertInvoice 
    @InvoiceDate datetime2(7),
    @CustomerName nvarchar(max),  
    @Address nvarchar(max),  
    @ContactNo nvarchar(max)
AS
INSERT INTO [dbo].[Invoices]
           ([InvoiceDate]
           ,[CustomerName]
           ,[Address]
           ,[ContactNo])
     VALUES
           (@InvoiceDate, @CustomerName, @Address, @ContactNo)

		   return @@identity 
GO";

            migrationBuilder.Sql(SpInsertInvoice);


            string SpInsertInvoiceItem = @"create or ALTER  PROCEDURE dbo.SpInsertInvoiceItem 
	@InvoiceId int,
    @ProductId int,
    @Quantity int

	as

INSERT INTO [dbo].[InvoiceItems]
           ([ProductId]
           ,[Quantity]
           ,[InvoiceId])
     VALUES
           (@ProductId, @Quantity, @InvoiceId )

		   return @@rowcount
GO";

            migrationBuilder.Sql(SpInsertInvoiceItem);

            string SpUpdateInvoice = @"create or ALTER  PROCEDURE dbo.SpUpdateInvoice 
    @InvoiceId int,
    @InvoiceDate datetime2(7),
    @CustomerName nvarchar(max),  
    @Address nvarchar(max),  
    @ContactNo nvarchar(max)
AS

UPDATE [dbo].[Invoices]
   SET [InvoiceDate] = @InvoiceDate
      ,[CustomerName] = @CustomerName
      ,[Address] = @Address
      ,[ContactNo] = @ContactNo
	  where Id = @InvoiceId

	  delete from InvoiceItems where InvoiceId = @InvoiceId

	  return @@rowcount
GO";
            migrationBuilder.Sql(SpUpdateInvoice);


            string SpDeleteInvoice = @"create or ALTER  PROCEDURE dbo.SpDeleteInvoice 
    @InvoiceId int
AS
	  delete from InvoiceItems where InvoiceId = @InvoiceId
	   delete from [Invoices] where Id = @InvoiceId

	  return @@rowcount
GO";

            migrationBuilder.Sql(SpDeleteInvoice);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop proc SpInsertInvoice");
            migrationBuilder.Sql("drop proc SpInsertInvoiceItem");
            migrationBuilder.Sql("drop proc SpUpdateInvoice");
            migrationBuilder.Sql("drop proc SpDeleteInvoice");

        }
    }
}
