CREATE PROCEDURE InsertTags
	(@Created Datetime2(7), @Title Varchar(100), @Url Varchar(200), @Username Varchar(100))
AS
begin
	insert into GalleryImages
	values (@Created, @Title, @Url, @Username)

	Declare @id int
	set @id = SCOPE_IDENTITY
	return @id
end