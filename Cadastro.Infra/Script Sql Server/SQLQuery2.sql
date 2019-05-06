USE [Pessoa]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[pessoa](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[CPF] [varchar](50) NOT NULL,
	[Telefone] [varchar](50) NOT NULL
) ON [PRIMARY]
GO


