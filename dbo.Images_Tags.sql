CREATE TABLE [dbo].[Images_Tags] (
    [ImageId]        INT           NOT NULL,
    [TagDescription] VARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([ImageId] ASC),
    FOREIGN KEY ([ImageId]) REFERENCES [dbo].[GalleryImages] ([Id])
);

