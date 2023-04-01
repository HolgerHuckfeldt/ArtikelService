

/****** Object:  Index [ArticlesId_AxlesId]    Script Date: 10/22/2012 09:32:26 ******/
CREATE NONCLUSTERED INDEX [ArticlesId_AxlesId] ON [dbo].[Pims_ArticlesId_AxlesId] 
(
	[ArticlesId] ASC,
	[AxlesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [ArticlesId_CommercialVehiclesId]    Script Date: 10/22/2012 09:31:54 ******/
CREATE NONCLUSTERED INDEX [ArticlesId_CommercialVehiclesId] ON [dbo].[Pims_ArticlesId_CommercialVehiclesId] 
(
	[ArticlesId] ASC,
	[CommercialVehiclesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [ArticlesId_EnginesId]    Script Date: 10/22/2012 09:32:15 ******/
CREATE NONCLUSTERED INDEX [ArticlesId_EnginesId] ON [dbo].[Pims_ArticlesId_EnginesId] 
(
	[ArticlesId] ASC,
	[EnginesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [ArticlesId_PassengerCarsId]    Script Date: 10/22/2012 09:32:37 ******/
CREATE NONCLUSTERED INDEX [ArticlesId_PassengerCarsId] ON [dbo].[Pims_ArticlesId_PassengerCarsId] 
(
	[ArticlesId] ASC,
	[PassengerCarsId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [Artikel_UnterartikelId]    Script Date: 10/22/2012 09:32:54 ******/
CREATE NONCLUSTERED INDEX [Artikel_UnterartikelId] ON [dbo].[Pims_VerwandteArtikel] 
(
	[ArtikelId] ASC,
	[UnterartikelId] ASC,
	[SameKTypeOnly] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

