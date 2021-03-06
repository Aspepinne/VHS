USE [VHS]
GO
/****** Object:  StoredProcedure [dbo].[sVehicle_TripMeter]    Script Date: 2021-12-18 20:24:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sVehicle_TripMeter]
	@Vin varchar (50), 
	@TripMeter int

AS
BEGIN

	UPDATE
		dbo.Vehicles
	SET 
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
				1, 
				0,
				100,
				'low',
				55.0, 
				11.0,  
				GETDATE(), 
				GETDATE()
			);
	END


END