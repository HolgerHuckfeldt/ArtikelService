--DECLARE @stripId INT;

--SET @stripId = 40968


DECLARE @ids TABLE 
( 
      StripNummer varchar(22), 
      Articles_Id INT,
--      Linkages_Id INT,
      HS_Height INT, 
      HS_PosX INT, 
      HS_PosY INT,
      HS_Width INT, 
      SortNumber INT,
      StripElementsId INT,
      StripImagePath varchar(128), 
      ImgWidth INT, ImgHeight INT
)

INSERT INTO @ids
SELECT DISTINCT 
      Ti_Strips.StripNumber, 
      Ti_Rel_StripElements_Articles.ArticleId,
      Ti_StripElements.HS_Height,
      Ti_StripElements.HS_PosX,
      Ti_StripElements.HS_PosY,
      Ti_StripElements.HS_Width,
      Ti_StripElements.SortNumber,
      Ti_StripElements.Id as StripElementsId,
      Ti_Strips.StripImagePath,
      Ti_Strips.ImgWidth,
      Ti_Strips.ImgHeight
FROM Ti_Strips
INNER JOIN Ti_StripElements ON Ti_StripElements.Strip_Ti_StripsId = Ti_Strips.Id
INNER JOIN Ti_Rel_StripElements_Articles ON Ti_Rel_StripElements_Articles.StripElementId = Ti_StripElements.Id
WHERE 
      Ti_Strips.Id = @stripId
      
SELECT DISTINCT 
      Ids.HS_Height,
      Ids.HS_PosX,
      Ids.HS_PosY,
      Ids.HS_Width,
      Ids.SortNumber,
      Ids.StripElementsId
FROM @ids Ids

SELECT DISTINCT 
      Ids.StripImagePath,
      Ids.ImgWidth,
      Ids.ImgHeight
FROM @ids Ids

-- ArtikelIds
SELECT DISTINCT 
	Ids.Articles_Id as ArticleId,
	Ids.StripElementsId
	FROM @ids Ids