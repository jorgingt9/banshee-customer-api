INSERT INTO [dbo].[Cities]([Name],[IdState]) SELECT 'MEDELLIN', Id FROM [States] WHERE Name LIKE 'ANT%';--MEDELLIN
INSERT INTO [dbo].[Cities]([Name],[IdState]) SELECT 'BOGOTA DC', Id FROM [States] WHERE Name LIKE 'CUND%';--BOGOTA DC
INSERT INTO [dbo].[Cities]([Name],[IdState]) SELECT 'SANTA MARTA', Id FROM [States] WHERE Name LIKE 'MAGD%';--SANTA MARTA
INSERT INTO [dbo].[Cities]([Name],[IdState]) SELECT 'CARTAGENA', Id FROM [States] WHERE Name LIKE 'BOL%'--CARTAGENA
GO

INSERT INTO [dbo].[Cities]([Name],[IdState]) SELECT 'QUITO', Id FROM [States] WHERE Name LIKE 'PICHIN%'; --QUITO
INSERT INTO [dbo].[Cities]([Name],[IdState]) SELECT 'GUAYAQUIL', Id FROM [States] WHERE Name LIKE 'GUAY%'; --GUAYAQUIL
GO

INSERT INTO [dbo].[Cities]([Name],[IdState]) SELECT 'PANAMA', Id FROM [States] WHERE Name LIKE 'PAN%';--PANAMA
GO