
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BloodDonationInformation.Models;
using System;
	
	namespace BloodDonationInformation.DAL
	{ 
    public class BloodInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<BloodContext>
	{         
		protected override void Seed(BloodContext context)
		{
			var donors = new List<Donor>
			{
				new Donor{Name="Sanjay Bhandari",Gender='M',BloodGroup="O+",DOB=DateTime.Parse("2051-09-10"),Address="Koteshwor",Contact="9841930824"},
				new Donor{Name="Bijay Pandey",Gender='M',BloodGroup="A+",DOB=DateTime.Parse("2050-12-13"),Address="Kalanki",Contact="9841930825"},
				new Donor{Name="Usha Poudel",Gender='F',BloodGroup="B+",DOB=DateTime.Parse("2050-11-14"),Address="Pharping",Contact="9841930824"}
			};
			
			 donors.ForEach(d => context.Donors.Add(d));
             context.SaveChanges(); 
			 
			 
			var banks = new List<BloodBank>
			{
				new BloodBank{BloodBankID=1001,Name="Central Blood Bank",Address="Exhibition Road",Contact="01-4484753"},
				new BloodBank{BloodBankID=1002,Name="Nepal Red Cross Society Blood Bank",Address="Kalanki",Contact="01-4489753"},
				new BloodBank{BloodBankID=1003,Name="Nepal Red Cross Society Emergency Blood Bank ",Address="Balkumari",Contact="01-5584753"}
				};
			
			 banks.ForEach(d => context.BloodBanks.Add(d));
             context.SaveChanges();
			 
			 
			var details = new List<DonationDetail>
			{
				new DonationDetail{DonorID=001,BloodBankID=1001,Date=System.DateTime.Parse("2071-01-10"),Amount=2},
				new DonationDetail{DonorID=001,BloodBankID=1001,Date=DateTime.Parse("2072-10-15"),Amount=1},
				new DonationDetail{DonorID=002,BloodBankID=1002,Date=DateTime.Parse("2072-09-20"),Amount=2}
				};
			
			 details.ForEach(d => context.DonationDetails.Add(d));
             context.SaveChanges();
			  
		 }
	}
}
					
	
