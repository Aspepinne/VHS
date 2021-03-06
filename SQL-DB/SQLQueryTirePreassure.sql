USE [VHS]
GO
/****** Object:  StoredProcedure [dbo].[sVehicle_TirePreassure]    Script Date: 2021-12-18 20:24:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sVehicle_TirePreassure]
	@Vin varchar (50), 
	@TirePreassure varchar (50)

AS
BEGIN

	UPDATE
		dbo.Vehicles
	SET 
		TirePreassure = @TirePreassure,
		DateLastModified = GETDATE()
	WHERE
		Vin = @Vin;

	IF (@@ROWCOUNT = 0) BEGIN

		INSERT INTO
			dbo.Vehicles
		VALUES
			(
				@Vin, 
				1,
				0,
				100,
				@TirePreassure,
				55.0, 
				11.0,  
				GETDATE(), 
				GETDATE()
			);
	END


END