
Create procedure GetImageId
	(@Title Varchar(100), @username Varchar(100))
AS
Begin
	Select Id from GalleryImages where Title = @Title and Username = @username
End