USE [VHS]
GO
/****** Object:  StoredProcedure [dbo].[sDrivingJournal_Update]    Script Date: 2021-12-18 20:24:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sDrivingJournal_Update]
	@Vin varchar (50), 
	@StartingTime datetime,
	@StoppingTime datetime,
	@PowerConsumption int,
	@AverageConsumption int,
	@AverageSpeed int,
	@TripMeter int

	

AS
BEGIN

		INSERT INTO
			dbo.DrivingJournal
		VALUES
			(
				@Vin, 
				@StartingTime,
				@StoppingTime,
				@PowerConsumption,
				@AverageConsumption,
				@AverageSpeed,
				@TripMeter, 
				GETDATE(), 
				GETDATE(),
				GETDATE()
			);



END