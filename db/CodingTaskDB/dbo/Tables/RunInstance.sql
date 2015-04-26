CREATE TABLE [dbo].[RunInstance] (
    [run_instance_id] INT            IDENTITY (1, 1) NOT NULL,
    [setup_id]        INT            NOT NULL,
    [run_start]       DATETIME2 (7)  NULL,
    [run_end]         DATETIME2 (7)  NULL,
    [path] NVARCHAR(500) NULL, 
	[note]            NVARCHAR (500) NULL,    
    CONSTRAINT [PK_RunInstance] PRIMARY KEY CLUSTERED ([run_instance_id] ASC),
    CONSTRAINT [FK_RunInstance_Setup] FOREIGN KEY ([setup_id]) REFERENCES [dbo].[Setup] ([setup_id])
);

