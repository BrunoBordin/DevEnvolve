USE [DevEnvolve]
GO

/****** Object: Table [dbo].[EnderecoEmpresa] Script Date: 07/12/2022 20:55:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EnderecoEmpresa] (
    [idEndereco] INT            IDENTITY (1, 1) NOT NULL,
    [idEmpresa]  INT            NOT NULL,
    [cidade]     NVARCHAR (MAX) NOT NULL,
    [estado]     CHAR (2)       NOT NULL,
    [cep]        VARCHAR (8)    NOT NULL,
    [logradouro] NVARCHAR (MAX) NOT NULL,
    [numero]     INT            NOT NULL
);


