CREATE TABLE [Translation] (
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
);

CREATE TABLE [TranslationValue] (
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[LanguageCountryCode] NVARCHAR(10) NOT NULL,
	[Value] NVARCHAR(MAX) NOT NULL
);

CREATE TABLE [TechnologyKnownLevel] (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(32) NOT NULL
);

CREATE TABLE [MainPageConfiguration] (
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Title] NVARCHAR(64) NOT NULL,
	[SubTitle] NVARCHAR(64) NOT NULL,
	[TopDescriptionTranslationId] INT NOT NULL,
	[AboutMeDescriptionTranslationId] INT NOT NULL,
	FOREIGN KEY ([TopDescriptionTranslationId]) REFERENCES [Translation] ([Id]),
	FOREIGN KEY ([AboutMeDescriptionTranslationId]) REFERENCES [Translation] ([Id])
);

CREATE TABLE [KnownTechnology] (
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[KnownLevel] INT NOT NULL,
	[Name] NVARCHAR(32) NOT NULL,
	[MainPageConfigurationId] INT NOT NULL,
	FOREIGN KEY ([MainPageConfigurationId]) REFERENCES [MainPageConfiguration] ([Id])
);

CREATE TABLE [OfferItem] (
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Icon] NVARCHAR(64) NOT NULL,
	[TitleTranslationId] INT NOT NULL,
	[DescriptionTranslationId] INT NOT NULL,
	[MainPageConfigurationId] INT NOT NULL,
	FOREIGN KEY ([TitleTranslationId]) REFERENCES [Translation] ([Id]),
	FOREIGN KEY ([DescriptionTranslationId]) REFERENCES [Translation] ([Id]),
	FOREIGN KEY ([MainPageConfigurationId]) REFERENCES [MainPageConfiguration] ([Id])
);