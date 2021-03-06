USE [VHS]
GO
/****** Object:  StoredProcedure [dbo].[sVehicle_BatteryLevel]    Script Date: 2021-12-18 20:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sVehicle_BatteryLevel]
	@Vin varchar (50), 
	@BatteryLevel int

AS
BEGIN

	UPDATE
		dbo.Vehicles
	SET 
		BatteryLevel = @BatteryLevel,
		DateLastModified = GETDATE()
	WHERE
		Vin = @Vin;

	IF (@@ROWCOUNT = 0) BEGIN

		INSERT INTO
			dbo.Vehicles
		VALUES
			(
				@Vin,
				1000,
				1, 
				0,
				@BatteryLevel,
				'low',
				55.0, 
				11.0,  
				GETDATE(), 
				GETDATE()
			);
	END


END