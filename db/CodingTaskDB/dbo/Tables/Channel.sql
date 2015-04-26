CREATE TABLE [dbo].[Channel] (
    [channel_code] INT          NOT NULL,
    [channel_name] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Channel_1] PRIMARY KEY CLUSTERED ([channel_code] ASC)
);

