﻿using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.PayRollModel
{
    public class BankBranch
    {
        public int ID { get; set; }

        [Display(Name = "bank")]
        public string Name { get; set; }
        public virtual ICollection<StaffProfile> Staffprofile { get; set; }
    }
}