﻿USE [Heroes.mdf]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Hero_GetByName]
	@nazev_hero VARCHAR(30)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.Hero
	WHERE nazev_hero=@nazev_hero;
END