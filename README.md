README Prueba Tecnica Luis Martinez

para el inicio del aplicativo se debe configurar la cadena de conexion en appsettings.Json en el proyecto web api de la capa presentacion

abrir una ventana de Package Manager Console y ejecutar update-database -context AppDbContext  las  migraciones estan listas

Ejecutar en Base de Datos

INSERT INTO [dbo].[TypePurchases]
           ([PurchaseDescription]
           ,[MonthDuration])
     VALUES
			('Monthly',1),
           ('Yearly',2)


INSERT INTO [dbo].[SuscriptionTypes]
           ([TypeSuscription]
           ,[Price]
           ,[Status])
     VALUES
           ('Basic',5,'A'),
		   ('Standard',8,'A'),
		   ('Premium',12,'A')
