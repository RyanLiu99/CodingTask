CREATE TABLE [dbo].[optimization_goal] (
    [optimization_goal_id] TINYINT       NOT NULL,
    [optimization_goal]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_optimization_goal] PRIMARY KEY CLUSTERED ([optimization_goal_id] ASC)
);

