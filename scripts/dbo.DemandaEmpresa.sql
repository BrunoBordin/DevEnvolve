USE [DevEnvolve]
GO

/****** Object: Table [dbo].[DemandaEmpresa] Script Date: 07/12/2022 20:54:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DemandaEmpresa] (
    [idDemandaEmpresa] INT NOT NULL,
    [idDemanda]        INT NOT NULL,
    [idEmpresa]        INT NOT NULL
);


