USE [DevEnvolve]
GO

/****** Object: Table [dbo].[PlanosDevEnvolve] Script Date: 07/12/2022 20:55:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlanosDevEnvolve] (
    [idPlano]   INT            NOT NULL,
    [descricao] NVARCHAR (MAX) NOT NULL,
    [valor]     DECIMAL (18)   NOT NULL,
    [usuario]   CHAR (1)       NOT NULL
);


