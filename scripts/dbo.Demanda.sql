USE [DevEnvolve]
GO

/****** Object: Table [dbo].[Demanda] Script Date: 09/12/2022 21:59:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Demanda] (
    [idDemanda]   INT            IDENTITY (1, 1) NOT NULL,
    [idEmpresa]   INT            NOT NULL,
    [nome]        NVARCHAR (MAX) NOT NULL,
    [stack]       INT            NOT NULL,
    [preco]       DECIMAL (18)   NOT NULL,
    [descricao]   NVARCHAR (MAX) NOT NULL,
    [imagem]      NVARCHAR (MAX) NOT NULL,
    [nomeEmpresa] NVARCHAR (MAX) NULL
);


