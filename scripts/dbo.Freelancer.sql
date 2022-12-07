USE [DevEnvolve]
GO

/****** Object: Table [dbo].[Freelancer] Script Date: 07/12/2022 20:55:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Freelancer] (
    [idFreelancer] INT            IDENTITY (1, 1) NOT NULL,
    [nome]         NVARCHAR (MAX) NOT NULL,
    [email]        NVARCHAR (MAX) NOT NULL,
    [senha]        NVARCHAR (MAX) NOT NULL,
    [celular]      VARCHAR (50)   NOT NULL,
    [foto]         NVARCHAR (MAX) NULL,
    [reputacao]    INT            NULL,
    [descricao]    NVARCHAR (MAX) NULL,
    [saldo]        DECIMAL (18)   NULL
);


