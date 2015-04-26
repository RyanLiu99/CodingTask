CREATE TABLE [dbo].[Region] (
    [region_code]  INT           NOT NULL,
    [region_name] VARCHAR (200) NOT NULL,
    [stat_code]   SMALLINT      NOT NULL,
    CONSTRAINT [PK_Region_1] PRIMARY KEY CLUSTERED ([region_code] ASC),
    CONSTRAINT [FK_Region_State] FOREIGN KEY ([stat_code]) REFERENCES [dbo].[State] ([state_code])
);

