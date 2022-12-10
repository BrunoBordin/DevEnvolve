USE [DevEnvolve]
GO

/****** Object: Table [dbo].[Skills] Script Date: 10/12/2022 15:56:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Skills] (
    [idSkill]   INT            IDENTITY (1, 1) NOT NULL,
    [descricao] NVARCHAR (MAX) NOT NULL
);


