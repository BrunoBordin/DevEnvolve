USE [DevEnvolve]
GO

/****** Object: Table [dbo].[CandidatoDemanda] Script Date: 07/12/2022 20:54:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CandidatoDemanda] (
    [idCandidatoDemanda] INT IDENTITY (1, 1) NOT NULL,
    [idFreelancer]       INT NOT NULL,
    [idDemanda]          INT NOT NULL,
    [idEmpresa]          INT NOT NULL,
    [ativo]              INT NOT NULL
);


