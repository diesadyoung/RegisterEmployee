CREATE PROCEDURE [dbo].[EmployeeViewOrInsert]
 @mode nvarchar(max),
 @Surname nvarchar(max)=null,
 @Name nvarchar(max)=null,
 @Partonymic nvarchar(max)=null,
 @Date datetime=null,
 @CompanyName nvarchar(max)=null,
 @Id int = null
AS
BEGIN

		

		if(@mode='getEmptyList')
		Begin
			Select
			Id
			Surname,
			Name,
			Patronymic,
			Date,
			CompanyName
			From [Table]
		End

		if(@mode='AddEmployee')
		Begin
			INSERT INTO [Table](
			Id,
			Surname,
			Name,
			Patronymic,
			Date,
			CompanyName)
			Values(
			@Id,
			@Surname,
			@Name,
			@Partonymic,
			@Date,
			@CompanyName
			)

		End

		if(@mode='GetEmployeeById')
		Begin
			Select
			Id,
			Surname,
			Name,
			Patronymic,
			Date,
			CompanyName
			FROM [Table]
			Where Id=@Id

		End

		if(@mode='UpdateEmployee')
		Begin
			Update [Table]
			Set Surname=@Surname,
			Name=@Name,
			Patronymic=@Partonymic,
			Date=@Date,
			CompanyName=@CompanyName
			Where Id=@Id
		End

		if(@mode='DeleteEmployee')
		Begin
			Delete from  [Table] Where Id=@Id
		End
RETURN
END