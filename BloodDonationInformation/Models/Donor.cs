using System;
	using System.Collections.Generic;  
	namespace BloodDonationInformation.Models
	{
		
		
		public class Donor
		{         
		public int ID { get; set; }
		public string Name { get; set; } 
		public char Gender{get; set;}
		public string BloodGroup{get; set;}
		public DateTime DOB { get; set; }
		public string Address { get; set; }
		public string Contact { get; set; }
		

		public virtual ICollection<DonationDetail> DonationDetails { get; set; }
		}
	} 