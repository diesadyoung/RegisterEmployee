CREATE PROCEDURE EmployeeViewOrInsert
 @mode varchar(50),
 @Surname varchar(50),
 @Name varchar(50),
 @Partonymic varchar(50),
 @Date datetime,
 @CompanyName varchar(50),
 @Id int
AS
BEGIN

		SET NOCOUNT ON;

		if(@mode='getEmptyList')
		Begin
			Select
			Id,
			Surname,
			Name,
			Partonymic,
			Date,
			CompanyName
			From tblTable
		End

		if(@mode='AddEmployee')
		Begin
			INSERT INTO tblTable(
			Surname,
			Name,
			Partonymic,
			Date,
			CompanyName)
			Values(
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
			Partonymic,
			Date,
			CompanyName
			FROM tblTable
			Where Id=@Id

		End

		if(@mode='UpdateEmployee')
		Begin
			Update tblTable
			Set Surname=@Surname,
			Name=@Name,
			Patronymic=@Partonymic,
			Date=@Date,
			CompanyName=@CompanyName
			Where Id=@Id
		End

		if(@mode='DeleteEmployee')
		Begin
			Delete from  tblTable Where Id=@Id
		End
END