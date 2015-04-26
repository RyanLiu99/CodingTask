/* not in use
CREATE TABLE [dbo].[City] (
    [city_code]   VARCHAR (50)  NOT NULL,
    [city_name]   VARCHAR (100) NOT NULL,
    [region_code] INT           NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([city_code] ASC),
    CONSTRAINT [FK_City_Region1] FOREIGN KEY ([region_code]) REFERENCES [dbo].[Region] ([region_code])
);

*/