using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_angular.Models;

namespace WebApi_angular.Controllers
{
    public class PatientHistoryController : ApiController
    {
        AngularTestDbEntities entity = new AngularTestDbEntities();

        [HttpPost]
        public IHttpActionResult addPatientHistory(PatientHistory model)
        {
            PatientHistory mod = new PatientHistory()
            {
               Alcohol=model.Alcohol,
               BMI=model.BMI,
               DrugUsage=model.DrugUsage,
               Height=model.Height,
               Smoking=model.Smoking,
               Surgeries=model.Surgeries,
               Weight=model.Weight,
               PatientHistoryId=model.PatientHistoryId
            };
            entity.PatientHistories.Add(mod);
            entity.SaveChanges();
            return Ok(200);
        }
        [HttpGet]
        public IHttpActionResult getPatienHistorytById(int id)
        {
            var data = entity.PatientHistories.Where(x => x.PatientHistoryId == id).FirstOrDefault();
            if (data != null)
            {
                PatientHistoryModel model = new PatientHistoryModel();
                model.Height = data.Height;
                model.Id = data.Id;
                model.Alcohol = data.Alcohol;
                model.Weight = data.Weight;
                model.BMI = data.BMI;
                model.DrugUsage = data.DrugUsage;
                model.Smoking = data.Smoking;
                model.Surgeries = data.Surgeries;
                model.PatientHistoryId = data.PatientHistoryId;
                return Ok(model);
            }
            return Ok(400);
        }


        [HttpPost]
        public IHttpActionResult updatePatientHistory(PatientHistoryModel model)
        {
            var data = entity.PatientHistories.Where(k => k.Id == model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Height = model.Height;
                data.Id = model.Id;
                data.Alcohol = model.Alcohol;
                data.BMI = model.BMI;
                data.DrugUsage = model.DrugUsage;
                data.Smoking = model.Smoking;
                data.Surgeries = model.Surgeries;
                data.PatientHistoryId = model.PatientHistoryId;
                data.Weight = model.Weight;
                entity.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
