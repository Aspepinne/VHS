USE [VHS]
GO
/****** Object:  StoredProcedure [dbo].[sVehicle_Position]    Script Date: 2021-12-18 20:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sVehicle_Position]
	@Vin varchar (50), 
	@Longitude float,
	@Latitude float

AS
BEGIN

	UPDATE
		dbo.Vehicles
	SET 
		Longitude = @Longitude,
		Latitude = @Latitude,
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
				100,
				'low',
				@Latitude, 
				@Longitude, 
				GETDATE(), 
				GETDATE()
			);
	END


END