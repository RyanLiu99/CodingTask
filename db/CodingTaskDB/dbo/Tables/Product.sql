CREATE TABLE [dbo].[Product] (
    [product_code] INT           NOT NULL,
    [product_name] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([product_code] ASC)
);

