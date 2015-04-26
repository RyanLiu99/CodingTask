CREATE TABLE [dbo].[State] (
    [state_code] SMALLINT     NOT NULL,
    [state_name] VARCHAR (50) NOT NULL,    
    CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED ([state_code] ASC)  
);

