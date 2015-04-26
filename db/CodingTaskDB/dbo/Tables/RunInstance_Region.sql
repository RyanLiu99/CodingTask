CREATE TABLE [dbo].[RunInstance_Region] (
    [run_instance_id] INT NOT NULL,
    [region_code]     INT NOT NULL,
    [result]          INT CONSTRAINT [DF_RunInstance_Region_result] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_RunInstance_Region] PRIMARY KEY CLUSTERED ([run_instance_id] ASC, [region_code] ASC),
    CONSTRAINT [FK_RunInstance_Region_Region] FOREIGN KEY ([region_code]) REFERENCES [dbo].[Region] ([region_code]),
    CONSTRAINT [FK_RunInstance_Region_RunInstance] FOREIGN KEY ([run_instance_id]) REFERENCES [dbo].[RunInstance] ([run_instance_id])
);

