USE [DevEnvolve]
GO

/****** Object: Table [dbo].[SkillsFreelancer] Script Date: 10/12/2022 15:56:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SkillsFreelancer] (
    [idSkillsFreelancer] INT IDENTITY (1, 1) NOT NULL,
    [idSkill]            INT NOT NULL,
    [idFreelancer]       INT NOT NULL
);


