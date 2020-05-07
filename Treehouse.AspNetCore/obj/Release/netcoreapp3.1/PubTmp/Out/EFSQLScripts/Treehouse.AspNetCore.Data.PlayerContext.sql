IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE TABLE [Conference] (
        [Id] int NOT NULL IDENTITY,
        [name] nvarchar(max) NULL,
        [link] nvarchar(max) NULL,
        CONSTRAINT [PK_Conference] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE TABLE [Division] (
        [Id] int NOT NULL IDENTITY,
        [DivisionNumber] int NOT NULL,
        [name] nvarchar(max) NULL,
        [link] nvarchar(max) NULL,
        CONSTRAINT [PK_Division] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE TABLE [Person] (
        [Id] int NOT NULL IDENTITY,
        [ApiNr] int NOT NULL,
        [fullName] nvarchar(max) NULL,
        [link] nvarchar(max) NULL,
        CONSTRAINT [PK_Person] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE TABLE [Players] (
        [Id] int NOT NULL IDENTITY,
        [link] nvarchar(max) NULL,
        CONSTRAINT [PK_Players] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE TABLE [Position] (
        [Id] int NOT NULL IDENTITY,
        [code] nvarchar(max) NULL,
        [name] nvarchar(max) NULL,
        [type] nvarchar(max) NULL,
        [abbreviation] nvarchar(max) NULL,
        CONSTRAINT [PK_Position] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE TABLE [User] (
        [Id] nvarchar(450) NOT NULL,
        [isVerified] bit NOT NULL,
        [MongoNr] nvarchar(max) NULL,
        [username] nvarchar(max) NULL,
        [email] nvarchar(max) NULL,
        [password] nvarchar(max) NULL,
        [__v] int NOT NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE TABLE [Venue] (
        [Id] nvarchar(450) NOT NULL,
        [name] nvarchar(max) NULL,
        [link] nvarchar(max) NULL,
        [city] nvarchar(max) NULL,
        CONSTRAINT [PK_Venue] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE TABLE [Roster] (
        [Id] int NOT NULL IDENTITY,
        [personId] int NULL,
        [jerseyNumber] nvarchar(max) NULL,
        [PositionId] int NULL,
        [RootobjectId] int NULL,
        CONSTRAINT [PK_Roster] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Roster_Position_PositionId] FOREIGN KEY ([PositionId]) REFERENCES [Position] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Roster_Players_RootobjectId] FOREIGN KEY ([RootobjectId]) REFERENCES [Players] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Roster_Person_personId] FOREIGN KEY ([personId]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE TABLE [Token] (
        [Id] int NOT NULL IDENTITY,
        [_id] nvarchar(max) NULL,
        [token] nvarchar(max) NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_Token] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Token_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE TABLE [Team2] (
        [Id] int NOT NULL IDENTITY,
        [name] nvarchar(max) NULL,
        [VenueId] nvarchar(450) NULL,
        [Abbreviation] nvarchar(max) NULL,
        [TeamName] nvarchar(max) NULL,
        [LocationName] nvarchar(max) NULL,
        [DivisionId] int NULL,
        [Points] nvarchar(max) NULL,
        [GamesPlayed] int NOT NULL,
        CONSTRAINT [PK_Team2] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Team2_Division_DivisionId] FOREIGN KEY ([DivisionId]) REFERENCES [Division] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Team2_Venue_VenueId] FOREIGN KEY ([VenueId]) REFERENCES [Venue] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE TABLE [Player] (
        [Id] int NOT NULL IDENTITY,
        [ApiNr] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [Position] nvarchar(max) NULL,
        [Skill] int NOT NULL,
        [TeamId] int NOT NULL,
        CONSTRAINT [PK_Player] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Player_Team2_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Team2] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE INDEX [IX_Player_TeamId] ON [Player] ([TeamId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE INDEX [IX_Roster_PositionId] ON [Roster] ([PositionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE INDEX [IX_Roster_RootobjectId] ON [Roster] ([RootobjectId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE INDEX [IX_Roster_personId] ON [Roster] ([personId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE INDEX [IX_Team2_DivisionId] ON [Team2] ([DivisionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE INDEX [IX_Team2_VenueId] ON [Team2] ([VenueId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    CREATE INDEX [IX_Token_UserId] ON [Token] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200111201949_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200111201949_Initial', N'3.1.2');
END;

GO

