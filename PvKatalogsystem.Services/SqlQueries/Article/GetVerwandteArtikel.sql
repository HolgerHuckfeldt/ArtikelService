--DECLARE @id INT;
--Declare @fahrzeugId int;
--Declare @fahrzeugArt varchar(3);

--SET @id = 27662788--165178180
--set @fahrzeugId = 74985
--set @fahrzeugArt = 'PC'


SELECT distinct
		[ArtikelId]
	  ,[UnterartikelId]
	  ,[Typ]
	  ,[SameKTypeOnly]
	  ,[Amount]
  FROM Pims_VerwandteArtikel
  where
  [ArtikelId] = @id
  and
  SameKTypeOnly = 0

 IF(@fahrzeugArt = 'PC')
	BEGIN
	SELECT distinct
			[ArtikelId]
		  ,[UnterartikelId]
		  ,[Typ]
		  ,[SameKTypeOnly]
		  ,[Amount]
	  FROM Pims_VerwandteArtikel
	  INNER JOIN
	  Pims_ArticlesId_PassengerCarsId on  [UnterartikelId] = Pims_ArticlesId_PassengerCarsId.ArticlesId
	  where
	  [ArtikelId] = @id
	  and
	  Pims_ArticlesId_PassengerCarsId.PassengerCarsId = @fahrzeugId
	  and
	  SameKTypeOnly = 1
	END
	ELSE IF(@fahrzeugArt = 'CV')
	BEGIN
	SELECT distinct
			[ArtikelId]
		  ,[UnterartikelId]
		  ,[Typ]
		  ,[SameKTypeOnly]
		  ,[Amount]
	  FROM Pims_VerwandteArtikel
	  INNER JOIN
	  Pims_ArticlesId_CommercialVehiclesId on  [UnterartikelId] = Pims_ArticlesId_CommercialVehiclesId.ArticlesId
	  where
	  [ArtikelId] = @id
	  and
	  Pims_ArticlesId_CommercialVehiclesId.CommercialVehiclesId = @fahrzeugId
	  and
	  SameKTypeOnly = 1
	END
	ELSE IF(@fahrzeugArt = 'ENG')
	BEGIN
	SELECT distinct
			[ArtikelId]
		  ,[UnterartikelId]
		  ,[Typ]
		  ,[SameKTypeOnly]
		  ,[Amount]
	  FROM Pims_VerwandteArtikel
	  INNER JOIN
	  Pims_ArticlesId_EnginesId on  [UnterartikelId] = Pims_ArticlesId_EnginesId.ArticlesId
	  where
	  [ArtikelId] = @id
	  and
	  Pims_ArticlesId_EnginesId.EnginesId = @fahrzeugId
	  and
	  SameKTypeOnly = 1
	END
	ELSE IF(@fahrzeugArt = 'AX')
	BEGIN
	SELECT distinct
			[ArtikelId]
		  ,[UnterartikelId]
		  ,[Typ]
		  ,[SameKTypeOnly]
		  ,[Amount]
	  FROM Pims_VerwandteArtikel
	  INNER JOIN
	  Pims_ArticlesId_AxlesId on  [UnterartikelId] = Pims_ArticlesId_AxlesId.ArticlesId
	  where
	  [ArtikelId] = @id
	  and
	  Pims_ArticlesId_AxlesId.AxlesId = @fahrzeugId
	  and
	  SameKTypeOnly = 1
	END