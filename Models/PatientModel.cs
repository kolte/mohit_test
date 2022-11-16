using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_angular.Models
{
	public class PatientModel
	{
	    public int Id { get; set; }
		public string Name { get; set; }
		public string Sex { get; set; }
		public string CheckIn { get; set; }
		public Nullable<int> Age { get; set; }
	}
	public class PatientHistoryModel
	{
		public int Id { get; set; }
		public Nullable<decimal> Height { get; set; }
		public Nullable<decimal> Weight { get; set; }
		public Nullable<decimal> BMI { get; set; }
		public string Smoking { get; set; }
		public string Alcohol { get; set; }
		public string DrugUsage { get; set; }
		public string Surgeries { get; set; }
		public int PatientHistoryId { get; set; }
	}
}