﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDoc.Model.Data.Entities
{
    public class Appointment : DbEntityBase
    {
        public DateTime Date { get; set; }
    }
}
