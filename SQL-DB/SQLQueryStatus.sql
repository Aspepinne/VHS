USE [VHS]
GO
/****** Object:  StoredProcedure [dbo].[sVehicle_Status]    Script Date: 2021-12-18 20:24:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sVehicle_Status]
	@Vin varchar (50), 
	@LockStatus bit,
	@Longitude float,
	@Latitude float,
	@TirePreassure varchar (50),
	@BatteryLevel int,
	@AlarmStatus bit,
	@TripMeter int

AS
BEGIN

	UPDATE
		dbo.Vehicles
	SET 
		LockStatus = @LockStatus, 
		Longitude = @Longitude,
		Latitude = @Latitude,
		TirePreassure = @TirePreassure,
		BatteryLevel = @BatteryLevel,
		AlarmStatus = @AlarmStatus,
		TripMeter = @TripMeter,
		DateLastModified = GETDATE()
	WHERE
		Vin = @Vin;

	IF (@@ROWCOUNT = 0) BEGIN

		INSERT INTO
			dbo.Vehicles
		VALUES
			(
				@Vin, 
				@TripMeter,
				@LockStatus, 
				@AlarmStatus,
				@BatteryLevel,
				@TirePreassure,
				@Latitude, 
				@Longitude, 
				GETDATE(), 
				GETDATE()
			);
	END


END