﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Settings
{
    public class Division
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Position
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class SponsorCompany
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class WorkInOutTime
    {
        public int ID { get; set; }
        public int StartHour { get; set; }
        public int StartMin { get; set; }
        public int EndHour { get; set; }
        public int EndMin { get; set; }
        public int MinIn { get; set; }
        public int MinOut { get; set; }
        public string Time
        {
            get
            {
                return $"{StartHour}:{StartMin} - {EndHour}:{EndMin}";
            }
        }
    }
}
