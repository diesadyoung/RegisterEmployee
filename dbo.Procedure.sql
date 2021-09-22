CREATE PROCEDURE [dbo].[Procedure]
	@mode nvarchar(max),
	@Id int=null,
	@CompanyName nvarchar(max)=null,
	@Opf nvarchar(max)=null
AS
BEGIN

		if(@mode='GetCompaniesList')
		Begin
			Select
			Id,
			CompanyName,
			Opf
			From [Company]
		End

		if(@mode='AddCompany')
		Begin
			INSERT INTO [Company]
			(Id,
			CompanyName,
			Opf)
			Values
			(@Id,
			@CompanyName,
			@Opf)
		End

		if(@mode='GetCompanyById')
		Begin
			Select
			Id,
			CompanyName,
			Opf
			From [Company]
			Where Id = @Id
		End

		if(@mode='UpdateCompany')
		Begin
			Update [Company]
			Set
			CompanyName = @CompanyName,
			Opf = @Opf
			Where Id = @Id
		End

		if(@mode='DeleteCompany')
		Begin
			Delete from [Company] Where Id = @Id
		End
RETURN 0
End