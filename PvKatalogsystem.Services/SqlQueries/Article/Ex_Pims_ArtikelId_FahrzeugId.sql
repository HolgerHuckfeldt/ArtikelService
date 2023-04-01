TRUNCATE Table [ExterneArtikeldaten].[dbo].Pims_ArticlesId_PassengerCarsId
TRUNCATE Table [ExterneArtikeldaten].[dbo].Pims_ArticlesId_CommercialVehiclesId
TRUNCATE Table [ExterneArtikeldaten].[dbo].Pims_ArticlesId_EnginesId
TRUNCATE Table [ExterneArtikeldaten].[dbo].Pims_ArticlesId_AxlesId

Insert Into [ExterneArtikeldaten].[dbo].Pims_ArticlesId_PassengerCarsId
Select 
distinct
Linkages.Article_ArticlesId,
PassengerCars.Id
from
Linkages
INNER JOIN
LinkingTargetAssignments ON Linkages.Id = LinkingTargetAssignments.LinkingTargetAssignments_LinkagesId 
INNER JOIN
LinkingTargetChoices ON LinkingTargetAssignments.LinkingTarget_LinkingTargetChoicesId = LinkingTargetChoices.Id 
INNER JOIN
PassengerCars ON LinkingTargetChoices.Vehicle_PassengerCar_PassengerCarsId = PassengerCars.Id
where
Linkages.IsDeleted = 0

Insert Into [ExterneArtikeldaten].[dbo].Pims_ArticlesId_CommercialVehiclesId
Select 
distinct
Linkages.Article_ArticlesId,
CommercialVehicles.Id
from
Linkages
	  INNER JOIN
	  LinkingTargetAssignments ON Linkages.Id = LinkingTargetAssignments.LinkingTargetAssignments_LinkagesId 
	  INNER JOIN
	  LinkingTargetChoices ON LinkingTargetAssignments.LinkingTarget_LinkingTargetChoicesId = LinkingTargetChoices.Id 
	  INNER JOIN
	  CommercialVehicles ON LinkingTargetChoices.Vehicle_CommercialVehicle_CommercialVehiclesId = CommercialVehicles.Id
where
Linkages.IsDeleted = 0

Insert Into [ExterneArtikeldaten].[dbo].Pims_ArticlesId_EnginesId
Select 
distinct
Linkages.Article_ArticlesId,
Engines.Id
from
Linkages
INNER JOIN
LinkingTargetAssignments ON Linkages.Id = LinkingTargetAssignments.LinkingTargetAssignments_LinkagesId 
INNER JOIN
LinkingTargetChoices ON LinkingTargetAssignments.LinkingTarget_LinkingTargetChoicesId = LinkingTargetChoices.Id 
INNER JOIN
Engines ON LinkingTargetChoices.Engine_EnginesId = Engines.Id	
where
Linkages.IsDeleted = 0

Insert Into [ExterneArtikeldaten].[dbo].Pims_ArticlesId_AxlesId
Select 
distinct
Linkages.Article_ArticlesId,
Axles.Id
from
Linkages 
INNER JOIN
LinkingTargetAssignments ON Linkages.Id = LinkingTargetAssignments.LinkingTargetAssignments_LinkagesId 
INNER JOIN
LinkingTargetChoices ON LinkingTargetAssignments.LinkingTarget_LinkingTargetChoicesId = LinkingTargetChoices.Id 
INNER JOIN
Axles ON LinkingTargetChoices.Axle_AxlesId = Axles.Id
where  
Linkages.IsDeleted = 0