USE [VHS]
GO
/****** Object:  StoredProcedure [dbo].[sDrivingJournal_GetJournal]    Script Date: 2021-12-18 20:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sDrivingJournal_GetJournal]
@Vin varchar (50)

AS
BEGIN

	SELECT
		
		u.StartingTime,
		u.StoppingTime,
		u.TripMeter,
		u.PowerConsumption,
		u.AverageConsumption,
		u.AverageSpeed


	FROM dbo.DrivingJournal AS u

	WHERE
		Vin = @Vin

END