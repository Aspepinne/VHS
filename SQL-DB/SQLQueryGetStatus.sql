USE [VHS]
GO
/****** Object:  StoredProcedure [dbo].[sVehicle_GetStatus]    Script Date: 2021-12-18 20:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sVehicle_GetStatus]
@Vin varchar (50)

AS
BEGIN

	SELECT
		
		u.TripMeter,
		u.BatteryLevel,
		u.LockStatus,
		u.Longitude,
		u.Latitude,
		u.TirePreassure,
		u.AlarmStatus


	FROM dbo.Vehicles AS u

	WHERE
		Vin = @Vin

END