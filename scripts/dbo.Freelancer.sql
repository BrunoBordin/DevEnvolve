CREATE TABLE [dbo].[Freelancer] (
    [idFreelancer] INT            IDENTITY (1, 1) NOT NULL,
    [nome]         NVARCHAR (MAX) NOT NULL,
    [email]        NVARCHAR (MAX) NOT NULL,
    [senha]        NVARCHAR (MAX) NOT NULL,
    [telefone]     VARCHAR (MAX)  NULL,
    [celular]      VARCHAR (50)   NOT NULL,
    [cpfCnpj]      VARCHAR (50)   NOT NULL,
    [cidade]       INT            NOT NULL,
    [estado]       VARCHAR (2)    NOT NULL,
    [sobre]        NVARCHAR (MAX) NOT NULL,
    [saldo]        DECIMAL (18)   NOT NULL,
    CONSTRAINT [PK_Freelancer] PRIMARY KEY CLUSTERED ([idFreelancer] ASC)
);

