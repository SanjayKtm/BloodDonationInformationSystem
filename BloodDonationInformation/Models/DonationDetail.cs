using System;
using System.Collections.Generic;
namespace BloodDonationInformation.Models
{


    public class DonationDetail
    {
        public int DonationDetailID { get; set; }
        public int DonorID { get; set; }
        public int BloodBankID { get; set; }


        public DateTime Date { get; set; }
        public int Amount { get; set; }


        public virtual Donor Donor { get; set; }
        public virtual BloodBank BloodBank { get; set; }
    }
}
