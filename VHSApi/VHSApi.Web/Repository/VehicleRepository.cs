using HiQ.NetStandard.Util.Data;
using System.Data.SqlClient;
using System.Data;
using VHSApi.Web.Entity;
using System.Collections.Generic;
using System;

namespace VHSApi.Web.Repository
{
    public class VehicleRepository : ADbRepositoryBase
    {
        public void UpdateLockStatus(string vin, bool lockStatus)
        {

            var parameters = new SqlParameters();
            parameters.AddVarChar("@Vin", 50, vin);
            parameters.AddBoolean("@LockStatus", lockStatus);

            DbAccess.ExecuteNonQuery("dbo.sVehicle_LockStatus", ref parameters, CommandType.StoredProcedure);


        }

        public void UpdatePosition(string vin, float longitude, float latitude)
        {

            var parameters = new SqlParameters();
            parameters.AddVarChar("@Vin", 50, vin);
            parameters.AddFloat("@Longitude", longitude);
            parameters.AddFloat("@Latitude", latitude);

            DbAccess.ExecuteNonQuery("dbo.sVehicle_Position", ref parameters, CommandType.StoredProcedure);


        }

        public void UpdateTirePreassure(string vin, string tirePreassure)
        {

            var parameters = new SqlParameters();
            parameters.AddVarChar("@Vin", 50, vin);
            parameters.AddVarChar("@TirePreassure",50, tirePreassure);

            DbAccess.ExecuteNonQuery("dbo.sVehicle_TirePreassure", ref parameters, CommandType.StoredProcedure);


        }

        public void UpdateBatteryLevel(string vin, int batteryLevel)
        {

            var parameters = new SqlParameters();
            parameters.AddVarChar("@Vin", 50, vin);
            parameters.AddInt("@BatteryLevel", batteryLevel);

            DbAccess.ExecuteNonQuery("dbo.sVehicle_BatteryLevel", ref parameters, CommandType.StoredProcedure);


        }

        public void UpdateAlarmStatus(string vin, bool alarmStatus)
        {

            var parameters = new SqlParameters();
            parameters.AddVarChar("@Vin", 50, vin);
            parameters.AddBoolean("@AlarmStatus", alarmStatus);

            DbAccess.ExecuteNonQuery("dbo.sVehicle_AlarmStatus", ref parameters, CommandType.StoredProcedure);


        }

        public void UpdateTripMeter(string vin, int tripMeter)
        {

            var parameters = new SqlParameters();
            parameters.AddVarChar("@Vin", 50, vin);
            parameters.AddInt("@TripMeter", tripMeter);

            DbAccess.ExecuteNonQuery("dbo.sVehicle_TripMeter", ref parameters, CommandType.StoredProcedure);


        }

        public void UpdateStatus(string vin, bool lockStatus, float longitude, float latitude, string tirePreassure, int batteryLevel, bool alarmStatus, int tripMeter)
        {

            var parameters = new SqlParameters();
            parameters.AddVarChar("@Vin", 50, vin);
            parameters.AddBoolean("@LockStatus", lockStatus);
            parameters.AddFloat("@Longitude", longitude);
            parameters.AddFloat("@Latitude", latitude);
            parameters.AddVarChar("@TirePreassure", 50, tirePreassure);
            parameters.AddInt("@BatteryLevel", batteryLevel);
            parameters.AddBoolean("@AlarmStatus", alarmStatus);
            parameters.AddInt("@TripMeter", tripMeter);

            DbAccess.ExecuteNonQuery("dbo.sVehicle_Status", ref parameters, CommandType.StoredProcedure);

        }

        public IList<Status> GetStatus(string vin)
        {
            List<Status> statList = new List<Status>();
            SqlConnection conn = new SqlConnection("Server=*********;Initial Catalog=VHS;UID=sa;Password=*********;");

            conn.Open();

            var parameters = new SqlParameters();
            parameters.AddVarChar("@Vin", 50, vin);
            var dr = DbAccess.ExecuteReader("dbo.sVehicle_GetStatus", ref parameters, CommandType.StoredProcedure);


            while (dr.Read())
            {
                statList.Add(new Status()
                {
                    Vin = vin,
                    TripMeter = dr.GetInt32(0),
                    BatteryLevel = dr.GetInt32(1),
                    LockStatus = dr.GetBoolean(2),
                    Longitude = dr.GetDouble(3),
                    Latitude = dr.GetDouble(4),
                    TirePressure = dr.GetString(5),
                    AlarmStatus = dr.GetBoolean(6)
                });
            }

            dr.Close();

            conn.Close();

            return statList;
        }

        public void UpdateDrivingJournal(string vin, int tripMeter, DateTime startingTime, DateTime stoppingTime, int powerConsumption, int averageConsumption, int averageSpeed)
        {

            var parameters = new SqlParameters();
            parameters.AddVarChar("@Vin", 50, vin);
            parameters.AddInt("@TripMeter", tripMeter);
            parameters.AddDateTime("@StartingTime", startingTime);
            parameters.AddDateTime("@StoppingTime", stoppingTime);
            parameters.AddInt("@PowerConsumption", powerConsumption); 
            parameters.AddInt("@AverageConsumption", averageConsumption);
            parameters.AddInt("@AverageSpeed", averageSpeed);


            DbAccess.ExecuteNonQuery("dbo.sDrivingJournal_Update", ref parameters, CommandType.StoredProcedure);

        }

        public IList<Journal> GetDrivingJournal(string vin)
        {
            List<Journal> journalList = new List<Journal>();
            SqlConnection conn = new SqlConnection("Server=********;Initial Catalog=VHS;UID=sa;Password=**********;");

            conn.Open();

            var parameters = new SqlParameters();
            parameters.AddVarChar("@Vin", 50, vin);
            var dr = DbAccess.ExecuteReader("dbo.sDrivingJournal_GetJournal", ref parameters, CommandType.StoredProcedure);


            while (dr.Read())
            {
                journalList.Add(new Journal()
                {
                    Vin = vin,
                    StartingTime = dr.GetDateTime(0),
                    StoppingTime = dr.GetDateTime(1),
                    TripMeter = dr.GetInt32(2),
                    PowerConsumption = dr.GetInt32(3),
                    AverageConsumption = dr.GetInt32(4),
                    AverageSpeed = dr.GetInt32(5)
                });
            }

            dr.Close();

            conn.Close();

            return journalList;
        }

        public IList<Journal> GetDrivingJournalByVinAndDate(String vin , DateTime date)
        {
            List<Journal> journalList = new List<Journal>();
            SqlConnection conn = new SqlConnection("Server=*********;Initial Catalog=VHS;UID=sa;Password=**********;");

            conn.Open();

            var parameters = new SqlParameters();
            parameters.AddVarChar("@Vin", 50, vin);
            parameters.AddDateTime("@Date", date);
            var dr = DbAccess.ExecuteReader("dbo.sDrivingJournal_GetJournalByVinAndDate", ref parameters, CommandType.StoredProcedure);


            while (dr.Read())
            {
                journalList.Add(new Journal()
                {
                    Vin = vin,
                    StartingTime = dr.GetDateTime(1),
                    StoppingTime = dr.GetDateTime(2),
                    TripMeter = dr.GetInt32(3),
                    PowerConsumption = dr.GetInt32(4),
                    AverageConsumption = dr.GetInt32(5),
                    AverageSpeed = dr.GetInt32(6)
                });
            }

            dr.Close();

            conn.Close();

            return journalList;
        }

        public IList<Journal> GetDrivingJournalByDate(DateTime date)
        {
            List<Journal> journalList = new List<Journal>();
            SqlConnection conn = new SqlConnection("Server=**********;Initial Catalog=VHS;UID=sa;Password=*********;");

            conn.Open();

            var parameters = new SqlParameters();
            parameters.AddDateTime("@Date", date);
            var dr = DbAccess.ExecuteReader("dbo.sDrivingJournal_GetJournalByDate", ref parameters, CommandType.StoredProcedure);


            while (dr.Read())
            {
                journalList.Add(new Journal()
                {
                    Vin = dr.GetString(0),
                    StartingTime = dr.GetDateTime(1),
                    StoppingTime = dr.GetDateTime(2),
                    TripMeter = dr.GetInt32(3),
                    PowerConsumption = dr.GetInt32(4),
                    AverageConsumption = dr.GetInt32(5),
                    AverageSpeed = dr.GetInt32(6)
                });
            }

            dr.Close();

            conn.Close();

            return journalList;
        }


    }
}
