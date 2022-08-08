﻿using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.PayRollModel
{
    public class MaritalStatus
    {
        public int ID { get; set; }

        [Display(Name = "marital status")]
        public string Name { get; set; }
        public virtual ICollection<StaffProfile> Staffprofile { get; set; }
    }
}