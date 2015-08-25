---------------------------------------------
--RssChannel查询(视图)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'V_RssChannel' AND user_name(uid) = 'dbo')
	DROP VIEW V_RssChannel;
GO

CREATE VIEW dbo.V_RssChannel
AS

SELECT Title AS Title, '' AS Image, Remarks AS Description, Url AS Link, '' AS Language, 
      '' AS Docs, '' AS Generator, '' AS Ttl,Id
FROM dbo.Channel

GO
---------------------------------------------
--RssItem查询(视图)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'V_RssItem' AND user_name(uid) = 'dbo')
	DROP VIEW V_RssItem;
GO

CREATE VIEW dbo.V_RssItem
AS

SELECT dbo.Article.Title AS Title, '' AS Link, dbo.ContentBase.CreatedByDate AS PubDate, 
      dbo.Article.CopyFrom AS Source, dbo.Article.Author AS Author, 
      dbo.Article.Summary AS Description, dbo.Article.Id, dbo.ContentBase.ChannelId
FROM dbo.Article 
INNER JOIN dbo.ContentBase ON dbo.Article.ContentBaseId = dbo.ContentBase.Id
UNION ALL
SELECT '' AS Title, '' AS Link, dbo.ContentBase.CreatedByDate AS PubDate, '' AS Source, 
      '' AS Author, dbo.SinglePage.Summary AS Description, dbo.SinglePage.Id, 
      dbo.ContentBase.ChannelId
FROM dbo.ContentBase INNER JOIN
      dbo.SinglePage ON dbo.ContentBase.Id = dbo.SinglePage.ContentBaseId
      
GO
