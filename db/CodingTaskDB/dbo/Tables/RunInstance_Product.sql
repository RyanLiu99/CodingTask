CREATE TABLE [dbo].[RunInstance_Product] (
    [run_instance_id] INT NOT NULL,
    [product_code]    INT NOT NULL,
    [result]          INT CONSTRAINT [DF_RunInstance_Product_result] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_RunInstance_Product] PRIMARY KEY CLUSTERED ([run_instance_id] ASC, [product_code] ASC),
    CONSTRAINT [FK_RunInstance_Product_Product] FOREIGN KEY ([product_code]) REFERENCES [dbo].[Product] ([product_code]),
    CONSTRAINT [FK_RunInstance_Product_RunInstance] FOREIGN KEY ([run_instance_id]) REFERENCES [dbo].[RunInstance] ([run_instance_id])
);

