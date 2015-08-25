USE CMS;
GO

---------------------------------------------
--ͳ�Ƹſ�(��ѯ)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountProfiles_Query' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountProfiles_Query;
GO

CREATE PROCEDURE dbo.CountProfiles_Query
WITH ENCRYPTION
AS	
	--���������
	SELECT ISNULL(SUM(Ips),0) AS Ips, ISNULL(SUM(Pvs),0) AS Pvs, ISNULL(SUM(Cookies),0) AS Cookies
	FROM (
		SELECT * 
		FROM CountHour
		WHERE DATEDIFF(d,AddTime,GETDATE())=0
	) AS CountHourToday

	--���������
	SELECT TOP 1 ISNULL(SUM(Ips),0) AS Ips, ISNULL(SUM(Pvs),0) AS Pvs, ISNULL(SUM(Cookies),0) AS Cookies
	FROM (
		SELECT * 
		FROM CountHour 
		WHERE DATEDIFF(d,AddTime,GETDATE())=1
	) AS CountHourYesterday
	
	--��ʷ��߷�����
	SELECT TOP 1  ISNULL(MAX(Ips),0) AS Ips,ISNULL(MAX(Pvs),0) AS Pvs,ISNULL(MAX(Cookies),0) AS Cookies
	FROM (
		SELECT SUM(Ips) AS Ips, SUM(Pvs) AS Pvs, SUM(Cookies) AS Cookies 
		FROM CountHour 
		GROUP BY CONVERT(varchar(10), AddTime, 120)
	) AS CountHourMax
			
	--�ۼƷ�����
	SELECT ISNULL(SUM(Ips),0) AS Ips, ISNULL(SUM(Pvs),0) AS Pvs, ISNULL(SUM(Cookies),0) AS Cookies
	FROM CountHour AS CountHourTotal	
	
	--ͳ�Ƹſ�
	SELECT TOP 1 * FROM CountProfiles	
        
	RETURN @@ROWCOUNT
Go

---------------------------------------------
--�������ͳ��(��ѯ)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountOnline_Query' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountOnline_Query;
GO

CREATE PROCEDURE dbo.CountOnline_Query
	@OnlineTime int,	--����ʱ�䣨��λ���ӣ�
	@BeginTime smalldatetime,
	@EndTime smalldatetime
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	DELETE FROM dbo.CountOnline WHERE DATEDIFF(n,Addtime,GETDATE())>@OnlineTime

	Select Id,Ip,DATEDIFF(n,Addtime,GETDATE()) as Addtime
	FROM dbo.CountOnline
	WHERE AddTime Between @BeginTime and @EndTime
	ORDER BY AddTime

	RETURN @@ROWCOUNT
Go

---------------------------------------------
--�շ�����ͳ��(��ѯ)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountDays_Query' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountDays_Query;
GO

CREATE PROCEDURE dbo.CountDays_Query
	@BeginTime smalldatetime,
	@EndTime smalldatetime
WITH ENCRYPTION
AS
	SET NOCOUNT ON;

	SELECT TOP 100 SUM(Ips) AS Ips, SUM(Pvs) AS Pvs, SUM(Cookies) AS Cookies, 
      CONVERT(varchar(10), AddTime, 120) AS AddTime
	FROM CountHour
	WHERE (AddTime BETWEEN @BeginTime AND @EndTime)
	GROUP BY CONVERT(varchar(10), AddTime, 120)
	ORDER BY AddTime

	RETURN @@ROWCOUNT
Go

---------------------------------------------
--24Сʱ������ͳ��(��ѯ)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountHour_Query' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountHour_Query;
GO

CREATE PROCEDURE dbo.CountHour_Query
	@BeginTime smalldatetime,
	@EndTime smalldatetime
WITH ENCRYPTION
AS
	SET NOCOUNT ON;

	SELECT TOP 100 SUM(Ips) AS Ips, SUM(Pvs) AS Pvs, SUM(Cookies) AS Cookies, 
      DATEPART(hh, AddTime) AS AddTime
	FROM CountHour
	WHERE (AddTime BETWEEN @BeginTime AND @EndTime)
	GROUP BY DATEPART(hh, AddTime)
	ORDER BY AddTime

	RETURN @@ROWCOUNT
Go

---------------------------------------------
--���������ͳ��(��ѯ)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountArea_Query' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountArea_Query;
GO

CREATE PROCEDURE dbo.CountArea_Query
	@BeginTime smalldatetime,
	@EndTime smalldatetime
WITH ENCRYPTION
AS
	SET NOCOUNT ON;

	SELECT TOP 100 SUM(Visits) AS Visits,Area 
	FROM CountArea
	WHERE (AddTime BETWEEN @BeginTime AND @EndTime)
	GROUP BY Area
	ORDER BY Visits DESC

	RETURN @@ROWCOUNT
Go

---------------------------------------------
--��Դվ�������ͳ��(��ѯ)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountReferSite_Query' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountReferSite_Query;
GO

CREATE PROCEDURE dbo.CountReferSite_Query
	@BeginTime smalldatetime,
	@EndTime smalldatetime
WITH ENCRYPTION
AS
	SET NOCOUNT ON;

	SELECT TOP 100 SUM(Visits) AS Visits,ReferSite 
	FROM CountReferSite
	WHERE (AddTime BETWEEN @BeginTime AND @EndTime)
	GROUP BY ReferSite
	ORDER BY Visits DESC

	RETURN @@ROWCOUNT
Go

---------------------------------------------
--��Դҳ�������ͳ��(��ѯ)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountReferUrl_Query' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountReferUrl_Query;
GO

CREATE PROCEDURE dbo.CountReferUrl_Query
	@BeginTime smalldatetime,
	@EndTime smalldatetime
WITH ENCRYPTION
AS
	SET NOCOUNT ON;

	SELECT TOP 100 SUM(Visits) AS Visits,ReferUrl 
	FROM CountReferUrl
	WHERE (AddTime BETWEEN @BeginTime AND @EndTime)
	GROUP BY ReferUrl
	ORDER BY Visits DESC

	RETURN @@ROWCOUNT
Go

---------------------------------------------
--����ϵͳ������ͳ��(��ѯ)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountOs_Query' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountOs_Query;
GO

CREATE PROCEDURE dbo.CountOs_Query
	@BeginTime smalldatetime,
	@EndTime smalldatetime
WITH ENCRYPTION
AS
	SET NOCOUNT ON;

	SELECT TOP 100 SUM(Visits) AS Visits,Os 
	FROM CountOs
	WHERE (AddTime BETWEEN @BeginTime AND @EndTime)
	GROUP BY Os
	ORDER BY Visits DESC

	RETURN @@ROWCOUNT
Go

---------------------------------------------
--�����������ͳ��(��ѯ)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountBrowser_Query' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountBrowser_Query;
GO

CREATE PROCEDURE dbo.CountBrowser_Query
	@BeginTime smalldatetime,
	@EndTime smalldatetime
WITH ENCRYPTION
AS
	SET NOCOUNT ON;

	SELECT TOP 100 SUM(Visits) AS Visits,Browser 
	FROM CountBrowser
	WHERE (AddTime BETWEEN @BeginTime AND @EndTime)
	GROUP BY Browser
	ORDER BY Visits DESC

	RETURN @@ROWCOUNT
Go

---------------------------------------------
--�ֱ��ʷ�����ͳ��(��ѯ)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountResolution_Query' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountResolution_Query;
GO

CREATE PROCEDURE dbo.CountResolution_Query
	@BeginTime smalldatetime,
	@EndTime smalldatetime
WITH ENCRYPTION
AS
	SET NOCOUNT ON;

	SELECT TOP 100 SUM(Visits) AS Visits,Resolution 
	FROM CountResolution
	WHERE (AddTime BETWEEN @BeginTime AND @EndTime)
	GROUP BY Resolution
	ORDER BY Visits DESC

	RETURN @@ROWCOUNT
Go

---------------------------------------------
--�ܷ�ҳ������ͳ��(��ѯ)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountRespondents_Query' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountRespondents_Query;
GO

CREATE PROCEDURE dbo.CountRespondents_Query
	@BeginTime smalldatetime,
	@EndTime smalldatetime
WITH ENCRYPTION
AS
	SET NOCOUNT ON;

	SELECT TOP 100 SUM(Visits) AS Visits,Respondents 
	FROM CountRespondents
	WHERE (AddTime BETWEEN @BeginTime AND @EndTime)
	GROUP BY Respondents
	ORDER BY Visits DESC

	RETURN @@ROWCOUNT
Go

---------------------------------------------
--��ͷ�ʷ�����ͳ��(��ѯ)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountBack_Query' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountBack_Query;
GO

CREATE PROCEDURE dbo.CountBack_Query
	@BeginTime smalldatetime,
	@EndTime smalldatetime
WITH ENCRYPTION
AS
	SET NOCOUNT ON;

	SELECT TOP 100 Count(*) AS C,Visits 
	FROM CountBack
	WHERE (AddTime BETWEEN @BeginTime AND @EndTime)
	GROUP BY Visits
	ORDER BY Visits DESC

	RETURN @@ROWCOUNT
Go

---------------------------------------------
--ͳ�ƹ���(���)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountDelete' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountDelete;
GO

CREATE PROCEDURE dbo.CountDelete
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	DELETE FROM dbo.CountArea
			
	DELETE FROM dbo.CountBack
	
	DELETE FROM dbo.CountBrowser
	
	DELETE FROM dbo.CountHour
	
	DELETE FROM dbo.CountOnline
	
	DELETE FROM dbo.CountOs
	
	DELETE FROM dbo.CountReferSite	
	
	DELETE FROM dbo.CountReferUrl
	
	DELETE FROM dbo.CountResolution
	
	DELETE FROM dbo.CountRespondents

	IF @@ERROR=0
		RETURN 1

	RETURN 0
GO

---------------------------------------------
--ͳ�ƹ���(����)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountInsert' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountInsert;
GO

CREATE PROCEDURE dbo.CountInsert
	@Id	int output,
	@Ip	varchar(15),
	@Pvs	int,
	@Ips	int,
	@Cookies	int,
	@Area	varchar(50),
	@Province	varchar(50),
	@City	varchar(50),
	@Visits	int,
	@AddTime	smalldatetime,
	@ReferSite	varchar(100),
	@ReferUrl	varchar(100),
	@Os	varchar(100),
	@Browser	varchar(100),
	@Resolution	varchar(100),
	@Respondents	varchar(100),
	@OnlineTime		int
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	EXEC dbo.CountHour_Insert @Id,@Ip,@Pvs,@Ips,@Cookies,@AddTime
			
	EXEC dbo.CountArea_Insert @Id,@Area,@Province,@City,@Visits,@AddTime,@Ip
	
	EXEC dbo.CountReferSite_Insert @Id,@ReferSite,@Visits,@AddTime
	
	EXEC dbo.CountReferUrl_Insert @Id,@ReferUrl,@Visits,@AddTime
	
	EXEC dbo.CountOs_Insert @Id,@Os,@Visits,@AddTime
	
	EXEC dbo.CountBrowser_Insert @Id,@Browser,@Visits,@AddTime
	
	EXEC dbo.CountResolution_Insert @Id,@Resolution,@Visits,@AddTime
	
	EXEC dbo.CountRespondents_Insert @Id,@Respondents,@Visits,@AddTime
	
	EXEC dbo.CountBack_Insert @Id,@Ip,@Visits,@AddTime
	
	EXEC dbo.CountOnline_Insert @Id,@Ip,@AddTime,@OnlineTime
	
	---վ����Ϣ---
	EXEC dbo.CountProfiles_Insert @Id,'','',@AddTime

	IF @@ERROR=0
		RETURN 1

	RETURN 0
GO

---------------------------------------------
--ͳ�Ƹſ�(����)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountProfiles_Insert' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountProfiles_Insert;
GO

CREATE PROCEDURE dbo.CountProfiles_Insert
	@Id	int output,
	@Sitename	varchar(50),
	@Siteurl	varchar(100),
	@BeginDate	smalldatetime
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	SET @Id = (SELECT TOP 1 Id FROM dbo.CountProfiles)
			
	IF @Id IS NULL
	BEGIN
		INSERT dbo.CountProfiles(Sitename,Siteurl,BeginDate)
		VALUES(@Sitename,@Siteurl,@BeginDate)
	END

	IF @@ERROR=0 AND @@IDENTITY IS NOT NULL
		SELECT @Id = @@IDENTITY
		
	RETURN 0
GO

---------------------------------------------
--�������(����)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountOnline_Insert' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountOnline_Insert;
GO

CREATE PROCEDURE dbo.CountOnline_Insert
	@Id	int output,
	@Ip	varchar(15),
	@AddTime	smalldatetime,
	@OnlineTime int	--����ʱ�䣨��λ���ӣ�
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	DELETE FROM dbo.CountOnline WHERE DATEDIFF(n,Addtime,GETDATE())>@OnlineTime
	
	SET @Id = (SELECT TOP 1 Id FROM dbo.CountOnline WHERE Ip Like @Ip)
	
	IF @Id IS NULL
	BEGIN
		INSERT dbo.CountOnline(Ip,AddTime)	
		VALUES(@Ip,@AddTime)
	END
	ELSE
	BEGIN
		UPDATE dbo.CountOnline
		SET	AddTime	= @AddTime
		WHERE Id = @Id
	END

	IF @@ERROR=0 AND @@IDENTITY IS NOT NULL
		SELECT @Id = @@IDENTITY
		
	RETURN 0
GO

---------------------------------------------
--ʱ�����(����)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountHour_Insert' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountHour_Insert;
GO

CREATE PROCEDURE dbo.CountHour_Insert
	@Id	int output,
	@Ip	varchar(15),
	@Pvs	int,
	@Ips	int,
	@Cookies	int,
	@AddTime	smalldatetime
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	SET @Id = (SELECT TOP 1 Id FROM dbo.CountHour WHERE Ip Like @Ip And DATEDIFF(d,Addtime,@Addtime)=0)		

	IF @Id IS NULL
	BEGIN
		INSERT dbo.CountHour(Ip,Pvs,Ips,Cookies,AddTime)
		VALUES(@Ip,@Pvs,@Ips,@Cookies,@AddTime)
	END
	ELSE
	BEGIN
		UPDATE dbo.CountHour
		SET	Pvs	= Pvs + @Pvs,
			Cookies	= Cookies + @Cookies
		WHERE Id = @Id
	END

	IF @@ERROR=0 AND @@IDENTITY IS NOT NULL
		SELECT @Id = @@IDENTITY

	RETURN 0
GO

---------------------------------------------
--����ͳ��(����)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountArea_Insert' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountArea_Insert;
GO

CREATE PROCEDURE dbo.CountArea_Insert
	@Id	int output,
	@Area	varchar(50),
	@Province	varchar(50),
	@City	varchar(50),
	@Visits	int,
	@AddTime	smalldatetime,
	@Ip varchar(15)
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	SET @Id = (SELECT TOP 1 Id FROM dbo.CountArea WHERE Area Like (SELECT TOP 1 Area FROM CountIp WHERE CONVERT(numeric(15,0),REPLACE(@Ip,'.','')) BETWEEN Ip1 And Ip2) And DATEDIFF(d,Addtime,@Addtime)=0)					
			
	IF @Id IS NULL
	BEGIN
		INSERT dbo.CountArea(Area,Province,City,Visits,AddTime)
		VALUES(@Area,@Province,@City,@Visits,@AddTime)
	END
	ELSE
	BEGIN
		UPDATE dbo.CountArea
		SET	Visits	= Visits + @Visits
		WHERE Id = @Id
	END

	IF @@ERROR=0 AND @@IDENTITY IS NOT NULL
		SELECT @Id = @@IDENTITY

	RETURN 0
GO

---------------------------------------------
--��·վ��ͳ��(����)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountReferSite_Insert' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountReferSite_Insert;
GO

CREATE PROCEDURE dbo.CountReferSite_Insert
	@Id	int output,
	@ReferSite	varchar(100),
	@Visits	int,
	@Addtime	smalldatetime
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	SET @Id = (SELECT TOP 1 Id FROM dbo.CountReferSite WHERE ReferSite LIKE @ReferSite And DATEDIFF(d,Addtime,@Addtime)=0)					
			
	IF @Id IS NULL
	BEGIN
		INSERT dbo.CountReferSite(ReferSite,Visits,Addtime)
		VALUES(@ReferSite,@Visits,@Addtime)
	END
	ELSE
	BEGIN
		UPDATE dbo.CountReferSite
		SET	Visits	= Visits + @Visits
		WHERE Id = @Id
	END

	IF @@ERROR=0 AND @@IDENTITY IS NOT NULL
		SELECT @Id = @@IDENTITY

	RETURN 0
GO

---------------------------------------------
--��·ҳ��ͳ��(����)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountReferUrl_Insert' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountReferUrl_Insert;
GO

CREATE PROCEDURE dbo.CountReferUrl_Insert
	@Id	int output,
	@ReferUrl	varchar(100),
	@Visits	int,
	@Addtime	smalldatetime
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	SET @Id = (SELECT TOP 1 Id FROM dbo.CountReferUrl WHERE ReferUrl LIKE @ReferUrl And DATEDIFF(d,Addtime,@Addtime)=0)					
			
	IF @Id IS NULL
	BEGIN
		INSERT dbo.CountReferUrl(ReferUrl,Visits,Addtime)
		VALUES(@ReferUrl,@Visits,@Addtime)
	END
	ELSE
	BEGIN
		UPDATE dbo.CountReferUrl
		SET	Visits	= Visits + @Visits
		WHERE Id = @Id
	END

	IF @@ERROR=0 AND @@IDENTITY IS NOT NULL
		SELECT @Id = @@IDENTITY

	RETURN 0
GO

---------------------------------------------
--����ϵͳͳ��(����)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountOs_Insert' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountOs_Insert;
GO

CREATE PROCEDURE dbo.CountOs_Insert
	@Id	int output,
	@Os	varchar(100),
	@Visits	int,
	@Addtime	smalldatetime
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	SET @Id = (SELECT TOP 1 Id FROM dbo.CountOs WHERE Os LIKE @Os And DATEDIFF(d,Addtime,@Addtime)=0)
			
	IF @Id IS NULL
	BEGIN
		INSERT dbo.CountOs(Os,Visits,Addtime)
		VALUES(@Os,@Visits,@Addtime)
	END
	ELSE
	BEGIN
		UPDATE dbo.CountOs
		SET	Visits	= Visits + @Visits
		WHERE Id = @Id
	END

	IF @@ERROR=0 AND @@IDENTITY IS NOT NULL
		SELECT @Id = @@IDENTITY

	RETURN 0
GO

---------------------------------------------
--�����ͳ��(����)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountBrowser_Insert' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountBrowser_Insert;
GO

CREATE PROCEDURE dbo.CountBrowser_Insert
	@Id	int output,
	@Browser	varchar(100),
	@Visits	int,
	@Addtime	smalldatetime
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	SET @Id = (SELECT TOP 1 Id FROM dbo.CountBrowser WHERE Browser LIKE @Browser And DATEDIFF(d,Addtime,@Addtime)=0)					
			
	IF @Id IS NULL
	BEGIN
		INSERT dbo.CountBrowser(Browser,Visits,Addtime)
		VALUES(@Browser,@Visits,@Addtime)
	END
	ELSE
	BEGIN
		UPDATE dbo.CountBrowser
		SET	Visits	= Visits + @Visits
		WHERE Id = @Id
	END

	IF @@ERROR=0 AND @@IDENTITY IS NOT NULL
		SELECT @Id = @@IDENTITY

	RETURN 0
GO

---------------------------------------------
--�ֱ���ͳ��(����)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountResolution_Insert' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountResolution_Insert;
GO

CREATE PROCEDURE dbo.CountResolution_Insert
	@Id	int output,
	@Resolution	varchar(100),
	@Visits	int,
	@Addtime	smalldatetime
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	SET @Id = (SELECT TOP 1 Id FROM dbo.CountResolution WHERE Resolution LIKE @Resolution And DATEDIFF(d,Addtime,@Addtime)=0)					
			
	IF @Id IS NULL
	BEGIN
		INSERT dbo.CountResolution(Resolution,Visits,Addtime)
		VALUES(@Resolution,@Visits,@Addtime)
	END
	ELSE
	BEGIN
		UPDATE dbo.CountResolution
		SET	Visits	= Visits + @Visits
		WHERE Id = @Id
	END

	IF @@ERROR=0 AND @@IDENTITY IS NOT NULL
		SELECT @Id = @@IDENTITY

	RETURN 0
GO

---------------------------------------------
--�ܷ�ҳͳ��(����)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountRespondents_Insert' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountRespondents_Insert;
GO

CREATE PROCEDURE dbo.CountRespondents_Insert
	@Id	int output,
	@Respondents	varchar(100),
	@Visits	int,
	@Addtime	smalldatetime
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	SET @Id = (SELECT TOP 1 Id FROM dbo.CountRespondents WHERE Respondents LIKE @Respondents And DATEDIFF(d,Addtime,@Addtime)=0)					
			
	IF @Id IS NULL
	BEGIN
		INSERT dbo.CountRespondents(Respondents,Visits,Addtime)
		VALUES(@Respondents,@Visits,@Addtime)
	END
	ELSE
	BEGIN
		UPDATE dbo.CountRespondents
		SET	Visits	= Visits + @Visits
		WHERE Id = @Id
	END

	IF @@ERROR=0 AND @@IDENTITY IS NOT NULL
		SELECT @Id = @@IDENTITY

	RETURN 0
GO

---------------------------------------------
--��ͷ��ͳ��(����)
---------------------------------------------
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'CountBack_Insert' AND user_name(uid) = 'dbo')
	DROP PROCEDURE CountBack_Insert;
GO

CREATE PROCEDURE dbo.CountBack_Insert
	@Id	int output,
	@Ip	varchar(100),
	@Visits	int,
	@Addtime	smalldatetime
WITH ENCRYPTION
AS
	SET XACT_ABORT ON;
	SET NOCOUNT ON;

	SET @Id = (SELECT TOP 1 Id FROM dbo.CountBack WHERE Ip LIKE @Ip)					
			
	IF @Id IS NULL
	BEGIN
		INSERT dbo.CountBack(Ip,Visits,Addtime)
		VALUES(@Ip,@Visits,@Addtime)
	END
	ELSE
	BEGIN
		SET @Id = (SELECT TOP 1 Id FROM dbo.CountBack WHERE Ip LIKE @Ip And DATEDIFF(hh,Addtime,@Addtime)>=12)
		IF @Id IS NOT NULL
		BEGIN
			UPDATE dbo.CountBack
			SET	Visits	= Visits + @Visits,
			Addtime = @Addtime
			WHERE Id = @Id
		END
	END

	IF @@ERROR=0 AND @@IDENTITY IS NOT NULL
		SELECT @Id = @@IDENTITY

	RETURN 0
GO