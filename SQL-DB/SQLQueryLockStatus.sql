USE [VHS]
GO
/****** Object:  StoredProcedure [dbo].[sVehicle_LockStatus]    Script Date: 2021-12-18 20:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sVehicle_LockStatus]
	@Vin varchar (50), 
	@LockStatus bit

AS
BEGIN

	UPDATE
		dbo.Vehicles
	SET 
		LockStatus = @LockStatus, 
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
				@LockStatus,
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