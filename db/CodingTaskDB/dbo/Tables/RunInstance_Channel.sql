CREATE TABLE [dbo].[RunInstance_Channel] (
    [run_instance_id] INT NOT NULL,
    [channel_code]    INT NOT NULL,
    [result]          INT CONSTRAINT [DF_RunInstance_Channel_result] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_RunInstance_Channel] PRIMARY KEY CLUSTERED ([run_instance_id] ASC, [channel_code] ASC),
    CONSTRAINT [FK_RunInstance_Channel_Channel] FOREIGN KEY ([channel_code]) REFERENCES [dbo].[Channel] ([channel_code]),
    CONSTRAINT [FK_RunInstance_Channel_RunInstance] FOREIGN KEY ([run_instance_id]) REFERENCES [dbo].[RunInstance] ([run_instance_id])
);

