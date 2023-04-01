SELECT	PassengerCars.KTypNumber,
		Ti_StripCategories.Designation AS Level1, 
		Ti_TiCars.ModelDesignation AS Level21, 
		Ti_TiCars.TypDesignation AS Level22, 
		Ti_StripLinks.Designation AS Level3, 
		Ti_Strips.Id AS StripId,
		Ti_Strips.StripNumber

FROM	Ti_Strips 
		INNER JOIN Ti_TiCars 
		INNER JOIN Ti_Rel_TiCars_PassengerCars ON Ti_TiCars.Id = Ti_Rel_TiCars_PassengerCars.TiCarsId 
		INNER JOIN PassengerCars ON Ti_Rel_TiCars_PassengerCars.PassengerCarsId = PassengerCars.Id 
		INNER JOIN Ti_StripLinks ON Ti_TiCars.Id = Ti_StripLinks.Car_Ex_Ti_TiCarsId ON Ti_Strips.Id = Ti_StripLinks.Links_Ex_Ti_StripsId 
		INNER JOIN Ti_StripCategories ON Ti_Strips.Category_Ex_Ti_StripCategoriesId = Ti_StripCategories.Id AND Ti_Strips.Category_Ex_Ti_StripCategoriesId = Ti_StripCategories.Id

WHERE	PassengerCars.Id = @PassengerCarId