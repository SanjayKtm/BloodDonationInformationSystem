using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace BloodDonationInformation.Models
{


    public class BloodBank
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BloodBankID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<DonationDetail> DonationDetails { get; set; }
    }
}


