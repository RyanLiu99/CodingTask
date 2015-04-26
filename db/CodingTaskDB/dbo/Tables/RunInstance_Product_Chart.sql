CREATE TABLE [dbo].[RunInstance_Product_Chart] (
    [run_instance_id] INT      NOT NULL,
    [product_code]    INT      NOT NULL,
    [year]            SMALLINT NOT NULL,
    [month]           TINYINT  NOT NULL,
    [result]          INT      CONSTRAINT [DF_RunInstance_Product_Chart_result] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_RunInstance_Product_Chart] PRIMARY KEY CLUSTERED ([run_instance_id] ASC, [product_code] ASC, [year] ASC, [month] ASC),
    CONSTRAINT [FK_RunInstance_Product_Chart_Product] FOREIGN KEY ([product_code]) REFERENCES [dbo].[Product] ([product_code]),
    CONSTRAINT [FK_RunInstance_Product_Chart_RunInstance] FOREIGN KEY ([run_instance_id]) REFERENCES [dbo].[RunInstance] ([run_instance_id])
);

