ALTER TABLE [TranslationValue]
	ADD [TranslationId] INT NOT NULL,
	FOREIGN KEY ([TranslationId]) REFERENCES [Translation] ([Id]);