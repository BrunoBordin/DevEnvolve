USE [DevEnvolve]
GO

/****** Object: Table [dbo].[EnderecoFreelancer] Script Date: 07/12/2022 20:55:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EnderecoFreelancer] (
    [idEndereco]   INT            IDENTITY (1, 1) NOT NULL,
    [idFreelancer] INT            NOT NULL,
    [cidade]       NVARCHAR (MAX) NOT NULL,
    [estado]       CHAR (2)       NOT NULL,
    [cep]          VARCHAR (8)    NOT NULL,
    [logradouro]   NVARCHAR (MAX) NOT NULL,
    [numero]       INT            NOT NULL
);


