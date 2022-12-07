USE [DevEnvolve]
GO

/****** Object: Table [dbo].[PlanosFreelancer] Script Date: 07/12/2022 20:55:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlanosFreelancer] (
    [idPlanoFreelancer] INT IDENTITY (1, 1) NOT NULL,
    [idPlano]           INT NOT NULL,
    [idFreelancer]      INT NOT NULL
);


