using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VHSApi.Web.Repository;
using VHSApi.Web.Entity;
using System.Collections.Generic;
using System;

namespace VHSApi.Web.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        [HttpPost]
        [Route("{vin}/lockstatus/update")]
        public ActionResult<bool> UpdateLockStatus(string vin, bool lockStatus)
        {
            var vehicleRepository = new VehicleRepository();

            vehicleRepository.UpdateLockStatus(vin, lockStatus);
            return true;


        }

        [HttpPost]
        [Route("{vin}/position/update")]
        public ActionResult<bool> UpdatePosition(string vin, float longitude, float latitude)
        {
            var vehicleRepository = new VehicleRepository();

            vehicleRepository.UpdatePosition(vin, longitude, latitude);
            return true;


        }

        [HttpPost]
        [Route("{vin}/tirepreassure/update")]
        public ActionResult<bool> UpdateStatus(string vin, string tirePreassure)
        {
            var vehicleRepository = new VehicleRepository();

            vehicleRepository.UpdateTirePreassure(vin, tirePreassure);
            return true;


        }

        [HttpPost]
        [Route("{vin}/batterylevel/update")]
        public ActionResult<bool> UpdateBatteryLevel(string vin, int batteryLevel)
        {
            var vehicleRepository = new VehicleRepository();

            vehicleRepository.UpdateBatteryLevel(vin, batteryLevel);
            return true;


        }

        [HttpPost]
        [Route("{vin}/alarmstatus/update")]
        public ActionResult<bool> UpdateAlarmStatus(string vin, bool alarmStatus)
        {
            var vehicleRepository = new VehicleRepository();

            vehicleRepository.UpdateAlarmStatus(vin, alarmStatus);
            return true;


        }


        [HttpPost]
        [Route("{vin}/tripmeter/update")]
        public ActionResult<bool> UpdateTripMeter(string vin, int tripMeter)
        {
            var vehicleRepository = new VehicleRepository();

            vehicleRepository.UpdateTripMeter(vin, tripMeter);
            return true;

        }

        [HttpPost]
        [Route("{vin}/status/update")]
        public ActionResult<bool> UpdateStatus(string vin, bool lockStatus, float longitude, float latitude, string tirePreassure, int batteryLevel, bool alarmStatus, int tripMeter)
        {
            var vehicleRepository = new VehicleRepository();

            vehicleRepository.UpdateStatus(vin, lockStatus, longitude, latitude, tirePreassure, batteryLevel, alarmStatus, tripMeter);
            return true;

        }


        [HttpGet]
        [Route("/Status/{vin}")]
        public ActionResult<IList<Status>> GetStatus(string vin)
        {
            var vehicleRepository = new VehicleRepository();

            var userList = vehicleRepository.GetStatus(vin);
            if (userList == null)
            {
                return new BadRequestResult();
            }
            if (userList.Count != 0)
            {
                return new OkObjectResult(userList);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpPost]
        [Route("{vin}/drivingjournal/update")]
        public ActionResult<bool> UpdateDrivingJournal(string vin, int tripMeter, DateTime startingTime, DateTime stoppingTime, int powerConsumption, int averageConsumption, int averageSpeed)
        {
            var vehicleRepository = new VehicleRepository();

            vehicleRepository.UpdateDrivingJournal(vin, tripMeter, startingTime, stoppingTime, powerConsumption, averageConsumption, averageSpeed);
            return true;

        }

        [HttpGet]
        [Route("/drivingjournal/{vin}")]
        public ActionResult<IList<Status>> GetDrivingJournal(string vin)
        {
            var vehicleRepository = new VehicleRepository();

            var journalList = vehicleRepository.GetDrivingJournal(vin);
            if (journalList == null)
            {
                return new BadRequestResult();
            }
            if (journalList.Count != 0)
            {
                return new OkObjectResult(journalList);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpGet]
        [Route("/drivingjournal/{vin}/{date}")]
        public ActionResult<IList<Status>> GetDrivingJournal(string vin ,DateTime date)
        {
            var vehicleRepository = new VehicleRepository();

            var journalList = vehicleRepository.GetDrivingJournalByVinAndDate(vin, date);
            if (journalList == null)
            {
                return new BadRequestResult();
            }
            if (journalList.Count != 0)
            {
                return new OkObjectResult(journalList);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpGet]
        [Route("/drivingjournal/date/{date}")]
        public ActionResult<IList<Status>> GetDrivingJournalByDate(DateTime date)
        {
            var vehicleRepository = new VehicleRepository();

            var journalList = vehicleRepository.GetDrivingJournalByDate(date);
            if (journalList == null)
            {
                return new BadRequestResult();
            }
            if (journalList.Count != 0)
            {
                return new OkObjectResult(journalList);
            }
            else
            {
                return new NotFoundResult();
            }
        }

    }
}
