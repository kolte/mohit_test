using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_angular.Models;

namespace WebApi_angular.Controllers
{
    public class PatientController : ApiController
    {
        AngularTestDbEntities entity = new AngularTestDbEntities();
        [HttpGet]
        public IHttpActionResult getAllPatient()
        {
            var data = entity.Patients.Select(k => new PatientModel()
            {
                Age = k.Age,
                CheckIn = k.CheckIn,
                Id = k.Id,
                Name = k.Name,
                Sex = k.Sex

            }).ToList();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult getPatientById(int id)
        {
            var data = entity.Patients.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                PatientModel model = new PatientModel();
                model.Age = data.Age;
                model.Id = data.Id;
                model.Name = data.Name;
                model.Sex = data.Sex;
                model.CheckIn = data.CheckIn;
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPost]
        public IHttpActionResult addPatient(PatientModel model)
        {
            Patient mod = new Patient()
            {
                Age = model.Age,
                CheckIn = model.CheckIn,
                Sex = model.Sex,
                Name = model.Name
            };
            entity.Patients.Add(mod);
            entity.SaveChanges();
            return Ok(200);
        }

        [HttpPost]
        public IHttpActionResult updatePatient(PatientModel model)
        {
            var data = entity.Patients.Where(k => k.Id == model.Id).FirstOrDefault();
            if (data != null)
            {
                data.Age = model.Age;
                data.CheckIn = model.CheckIn;
                data.Name = model.Name;
                data.Sex = model.Sex;
                entity.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        public IHttpActionResult deletePatient(int id)
        {
            var patient = new Patient { Id = id };
            entity.Entry(patient).State = EntityState.Deleted;
            entity.SaveChanges();
            return Ok();
        }

    }
}
