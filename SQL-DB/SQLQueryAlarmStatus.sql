USE [VHS]
GO
/****** Object:  StoredProcedure [dbo].[sVehicle_AlarmStatus]    Script Date: 2021-12-18 20:24:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sVehicle_AlarmStatus]
	@Vin varchar (50), 
	@AlarmStatus bit

AS
BEGIN

	UPDATE
		dbo.Vehicles
	SET 
		AlarmStatus = @AlarmStatus,
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
				@AlarmStatus,
				100,
				'low',
				55.0, 
				11.0,  
				GETDATE(), 
				GETDATE()
			);
	END


END