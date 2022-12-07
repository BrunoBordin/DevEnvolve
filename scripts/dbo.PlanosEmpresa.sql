USE [DevEnvolve]
GO

/****** Object: Table [dbo].[PlanosEmpresa] Script Date: 07/12/2022 20:55:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlanosEmpresa] (
    [idPlanoEmpresa] INT IDENTITY (1, 1) NOT NULL,
    [idPlano]        INT NOT NULL,
    [idEmpresa]      INT NOT NULL
);


