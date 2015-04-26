CREATE TABLE [dbo].[Setup] (
    [setup_id]                INT           IDENTITY (1, 1) NOT NULL,
    [optimization_goal_id]    TINYINT       NOT NULL,
    [optimization_goal_value] INT           NOT NULL,
    [date_start]              DATETIME2 (7) NOT NULL,
    [date_end]                DATETIME2 (7) NOT NULL,
    [input_increment]         INT           NOT NULL,
    CONSTRAINT [PK_Setup] PRIMARY KEY CLUSTERED ([setup_id] ASC),
    CONSTRAINT [FK_Setup_optimization_goal] FOREIGN KEY ([optimization_goal_id]) REFERENCES [dbo].[optimization_goal] ([optimization_goal_id])
);

