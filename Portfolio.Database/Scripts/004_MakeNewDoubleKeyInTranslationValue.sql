DECLARE @PrimaryKeyName NVARCHAR(MAX);

SELECT @PrimaryKeyName = CONSTRAINT_NAME  
FROM   INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE  TABLE_NAME = 'TranslationValue'
       AND TABLE_SCHEMA = 'dbo'
       AND CONSTRAINT_TYPE = 'PRIMARY KEY';

DECLARE @KeyDropSQL NVARCHAR(MAX) = 'ALTER TABLE TranslationValue DROP CONSTRAINT ' + @PrimaryKeyName + ';';

EXECUTE sp_executesql @KeyDropSQL;

ALTER TABLE TranslationValue 
	DROP COLUMN Id;

ALTER TABLE TranslationValue
	ADD PRIMARY KEY (LanguageCountryCode, TranslationId);