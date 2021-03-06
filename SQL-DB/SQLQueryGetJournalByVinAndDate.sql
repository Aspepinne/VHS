USE [VHS]
GO
/****** Object:  StoredProcedure [dbo].[sDrivingJournal_GetJournalByVinAndDate]    Script Date: 2021-12-18 20:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sDrivingJournal_GetJournalByVinAndDate]
@Date date,
@Vin varchar (50)

AS
BEGIN

	SELECT
		
		u.Vin,
		u.StartingTime,
		u.StoppingTime,
		u.TripMeter,
		u.PowerConsumption,
		u.AverageConsumption,
		u.AverageSpeed


	FROM dbo.DrivingJournal AS u

	WHERE
		Date = @Date
	AND
		Vin = @Vin

END