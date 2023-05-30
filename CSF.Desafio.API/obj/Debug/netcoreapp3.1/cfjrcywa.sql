IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [TB_CIDADE] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(100) NOT NULL,
    [Estado] nvarchar(2) NOT NULL,
    CONSTRAINT [PK_TB_CIDADE] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TB_CLIENTE] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(150) NOT NULL,
    [Rg] nvarchar(20) NOT NULL,
    [Cpf] nvarchar(20) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Telefone] nvarchar(20) NOT NULL,
    [Email] nvarchar(150) NULL,
    [CodEmpresa] int NOT NULL,
    CONSTRAINT [PK_TB_CLIENTE] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TB_ENDERECO] (
    [Id] int NOT NULL IDENTITY,
    [Rua] nvarchar(255) NOT NULL,
    [Bairro] nvarchar(50) NOT NULL,
    [Numero] nvarchar(50) NOT NULL,
    [Complemento] nvarchar(100) NOT NULL,
    [Cep] nvarchar(10) NOT NULL,
    [TipoEndereco] int NOT NULL,
    [CidadeId] int NOT NULL,
    CONSTRAINT [PK_TB_ENDERECO] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_ENDERECO_TB_CIDADE_CidadeId] FOREIGN KEY ([CidadeId]) REFERENCES [TB_CIDADE] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [TB_CLIENTE_ENDERECO] (
    [ClienteId] int NOT NULL,
    [EnderecoId] int NOT NULL,
    [Id] int NOT NULL,
    CONSTRAINT [PK_TB_CLIENTE_ENDERECO] PRIMARY KEY ([ClienteId], [EnderecoId]),
    CONSTRAINT [FK_TB_CLIENTE_ENDERECO_TB_CLIENTE_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [TB_CLIENTE] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TB_CLIENTE_ENDERECO_TB_ENDERECO_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [TB_ENDERECO] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Estado', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_CIDADE]'))
    SET IDENTITY_INSERT [TB_CIDADE] ON;
INSERT INTO [TB_CIDADE] ([Id], [Estado], [Nome])
VALUES (1, N'RS', N'Santa Cruz do Sul'),
(2, N'RS', N'Vera Cruz');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Estado', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_CIDADE]'))
    SET IDENTITY_INSERT [TB_CIDADE] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CodEmpresa', N'Cpf', N'DataNascimento', N'Email', N'Nome', N'Rg', N'Telefone') AND [object_id] = OBJECT_ID(N'[TB_CLIENTE]'))
    SET IDENTITY_INSERT [TB_CLIENTE] ON;
INSERT INTO [TB_CLIENTE] ([Id], [CodEmpresa], [Cpf], [DataNascimento], [Email], [Nome], [Rg], [Telefone])
VALUES (1, 1, N'01552764095', '1650-07-23T00:00:00.0000000', N'rafaelv_s@hotmail.com', N'Rafael Vieira Suarez', N'6096800117', N'51999708050'),
(2, 2, N'00460801040', '1987-07-30T00:00:00.0000000', N'caroline_splett@gmail.com', N'Caroline Seer Splett', N'6096800618', N'51996013891');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CodEmpresa', N'Cpf', N'DataNascimento', N'Email', N'Nome', N'Rg', N'Telefone') AND [object_id] = OBJECT_ID(N'[TB_CLIENTE]'))
    SET IDENTITY_INSERT [TB_CLIENTE] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bairro', N'Cep', N'CidadeId', N'Complemento', N'Numero', N'Rua', N'TipoEndereco') AND [object_id] = OBJECT_ID(N'[TB_ENDERECO]'))
    SET IDENTITY_INSERT [TB_ENDERECO] ON;
INSERT INTO [TB_ENDERECO] ([Id], [Bairro], [Cep], [CidadeId], [Complemento], [Numero], [Rua], [TipoEndereco])
VALUES (1, N'Ana Nery', N'96835422', 1, N'150 m', N'3322', N'Euclides Kliemann', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bairro', N'Cep', N'CidadeId', N'Complemento', N'Numero', N'Rua', N'TipoEndereco') AND [object_id] = OBJECT_ID(N'[TB_ENDERECO]'))
    SET IDENTITY_INSERT [TB_ENDERECO] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bairro', N'Cep', N'CidadeId', N'Complemento', N'Numero', N'Rua', N'TipoEndereco') AND [object_id] = OBJECT_ID(N'[TB_ENDERECO]'))
    SET IDENTITY_INSERT [TB_ENDERECO] ON;
INSERT INTO [TB_ENDERECO] ([Id], [Bairro], [Cep], [CidadeId], [Complemento], [Numero], [Rua], [TipoEndereco])
VALUES (2, N'Centro', N'96835344', 2, N'456 A', N'3322', N'Euclides Kliemann', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bairro', N'Cep', N'CidadeId', N'Complemento', N'Numero', N'Rua', N'TipoEndereco') AND [object_id] = OBJECT_ID(N'[TB_ENDERECO]'))
    SET IDENTITY_INSERT [TB_ENDERECO] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClienteId', N'EnderecoId', N'Id') AND [object_id] = OBJECT_ID(N'[TB_CLIENTE_ENDERECO]'))
    SET IDENTITY_INSERT [TB_CLIENTE_ENDERECO] ON;
INSERT INTO [TB_CLIENTE_ENDERECO] ([ClienteId], [EnderecoId], [Id])
VALUES (1, 1, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClienteId', N'EnderecoId', N'Id') AND [object_id] = OBJECT_ID(N'[TB_CLIENTE_ENDERECO]'))
    SET IDENTITY_INSERT [TB_CLIENTE_ENDERECO] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClienteId', N'EnderecoId', N'Id') AND [object_id] = OBJECT_ID(N'[TB_CLIENTE_ENDERECO]'))
    SET IDENTITY_INSERT [TB_CLIENTE_ENDERECO] ON;
INSERT INTO [TB_CLIENTE_ENDERECO] ([ClienteId], [EnderecoId], [Id])
VALUES (2, 2, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ClienteId', N'EnderecoId', N'Id') AND [object_id] = OBJECT_ID(N'[TB_CLIENTE_ENDERECO]'))
    SET IDENTITY_INSERT [TB_CLIENTE_ENDERECO] OFF;

GO

CREATE INDEX [IX_TB_CLIENTE_ENDERECO_EnderecoId] ON [TB_CLIENTE_ENDERECO] ([EnderecoId]);

GO

CREATE INDEX [IX_TB_ENDERECO_CidadeId] ON [TB_ENDERECO] ([CidadeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230524052814_inicial', N'3.1.8');

GO

