--diese SP dient zum Füllen der Katalogsystem-Tabelle Ex_VerwandteArtikel
TRUNCATE TABLE [ExterneArtikeldaten].dbo.Pims_VerwandteArtikel

INSERT INTO [ExterneArtikeldaten].dbo.Pims_VerwandteArtikel
SELECT DISTINCT
	RelationArticles.RelationArticles_ArticlesId,
	Article_ArticlesId, 
	ISNULL(KeyValues.ValueKey, 'K'),
	SameKTypeNumberOnly,
	Amount
FROM 
	RelationArticles
	JOIN Articles ON RelationArticles.Article_ArticlesId = Articles.Id
	JOIN VdbValues ON VdbValues.Id = Articles.VdbArtikelStamm_ArtikelZustand_VdbValuesId
		AND VdbValues.SchluesselWert <> '9'
	JOIN KeyValues on KeyValues.Id = RelationArticles.RelationType_KeyValuesId
WHERE     
	RelationArticles.IsDeleted = 0 
UNION SELECT distinct
	Rel_Articles_GenericArticles.ArticlesId,
	Article_ArticlesId, 
	ISNULL(KeyValues.ValueKey, 'K'),
	SameKTypeNumberOnly,
	Amount
FROM 
	RelationArticles 
	JOIN Rel_Articles_GenericArticles ON Rel_Articles_GenericArticles.GenericArticlesId = RelationArticles.RelationArticles_GenericArticlesId
	JOIN Articles ON RelationArticles.Article_ArticlesId = Articles.Id
	JOIN VdbValues ON VdbValues.Id = Articles.VdbArtikelStamm_ArtikelZustand_VdbValuesId
		AND VdbValues.SchluesselWert <> '9'
	JOIN KeyValues on KeyValues.Id = RelationArticles.RelationType_KeyValuesId
	
WHERE 
	RelationArticles.IsDeleted = 0 
UNION
SELECT DISTINCT
	Articles.Id,
	ag.ArticlesId, 
	ISNULL(KeyValues.ValueKey, 'K'),
	rga.SameKtypeOnly,
	Amount
FROM Articles
INNER JOIN RelationGenericArticles rga on Articles.Id = rga.RelationGenericArticles_ArticlesId
INNER JOIN 
  Rel_Articles_GenericArticles ag on ag.GenericArticlesId = rga.GenericArticle_GenericArticlesId
INNER JOIN Articles art ON ag.ArticlesId = art.Id
INNER JOIN VdbValues ON VdbValues.Id = Articles.VdbArtikelStamm_ArtikelZustand_VdbValuesId
	AND VdbValues.SchluesselWert <> '9'
JOIN
	KeyValues on KeyValues.Id = rga.RelationType_KeyValuesId
--auch Zubehörartikel müssen berücksichtigt werden
UNION
SELECT DISTINCT
Rel_AccessoryLists_Articles.ArticlesId,
AccessoryListParts.Article_ArticlesId, 
'Z',
0, --SameKTypeOnly exisitert nicht bei Zubebör
	0
FROM Rel_AccessoryLists_Articles
JOIN AccessoryListParts ON AccessoryListParts.AccessoryList_AccessoryListsId = Rel_AccessoryLists_Articles.AccessoryListsId
JOIN Articles ON AccessoryListParts.Article_ArticlesId = Articles.Id
JOIN VdbValues ON VdbValues.Id = Articles.VdbArtikelStamm_ArtikelZustand_VdbValuesId
	AND VdbValues.SchluesselWert <> '9'
WHERE AccessoryListParts.IsDeleted = 0 
	AND AccessoryListParts.IsReferenceTargetOnly = 0
--verwandte RelationGenericArticles
UNION
SELECT DISTINCT
Articles.Id,
	art.Id, 
	ISNULL(KeyValues.ValueKey, 'K'),
	RelationGenericArticles.SameKtypeOnly,
	Amount
FROM 
	RelationGenericArticles 
	INNER JOIN
	Rel_Articles_GenericArticles ON 
	  Rel_Articles_GenericArticles.GenericArticlesId = RelationGenericArticles.RelationGenericArticles_GenericArticlesId
	INNER JOIN
	Articles ON Rel_Articles_GenericArticles.ArticlesId = Articles.Id
	INNER JOIN
          Rel_Articles_GenericArticles relArtGen ON 
          relArtGen.GenericArticlesId = RelationGenericArticles.GenericArticle_GenericArticlesId
		INNER JOIN Articles art ON relArtGen.ArticlesId = art.Id
    INNER JOIN VdbValues ON VdbValues.Id = art.VdbArtikelStamm_ArtikelZustand_VdbValuesId
		AND VdbValues.SchluesselWert <> '9'
	JOIN KeyValues on KeyValues.Id = RelationGenericArticles.RelationType_KeyValuesId
WHERE     
	RelationGenericArticles.IsDeleted = 0 
	and
	RelationGenericArticles.SameKtypeOnly = 0
UNION
SELECT
DISTINCT
Articles.Id,
	art.Id, 
	ISNULL(KeyValues.ValueKey, 'K'),
	RelationGenericArticles.SameKtypeOnly,
	Amount
FROM 
	RelationGenericArticles 
	INNER JOIN
	Rel_Articles_GenericArticles ON 
	  Rel_Articles_GenericArticles.GenericArticlesId = RelationGenericArticles.RelationGenericArticles_GenericArticlesId
	INNER JOIN
	Articles ON Rel_Articles_GenericArticles.ArticlesId = Articles.Id
	INNER JOIN
          Rel_Articles_GenericArticles relArtGen ON 
          relArtGen.GenericArticlesId = RelationGenericArticles.GenericArticle_GenericArticlesId
		INNER JOIN Articles art ON relArtGen.ArticlesId = art.Id
    INNER JOIN VdbValues ON VdbValues.Id = art.VdbArtikelStamm_ArtikelZustand_VdbValuesId
		AND VdbValues.SchluesselWert <> '9'
	JOIN KeyValues on KeyValues.Id = RelationGenericArticles.RelationType_KeyValuesId
WHERE     
	RelationGenericArticles.IsDeleted = 0 
	and
	RelationGenericArticles.SameKtypeOnly = 1
	and
	art.Id IN 
	( 
		Select Top 1 Linkages.Article_ArticlesId
		from 
		Linkages
		where
		Linkages.Article_ArticlesId = art.Id
	)
	and
	Articles.Id IN 
	( 
		Select Top 1 Linkages.Article_ArticlesId
		from 
		Linkages
		where
		Linkages.Article_ArticlesId = Articles.Id
	)
	
--SELECT 
--	FROM @verwandteArtikel VerwandteArtikel
--	ORDER BY VerwandteArtikel.ArtikelId, Typ, Grad



