USE [Samarth]
GO

CREATE TABLE [dbo].[STUDENTS](
	[StudentId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[StudentName] [varchar](20) NULL,
	[Marks] [decimal](18, 0) NULL,
	[Grade] [char](1) NULL,
)
GO


