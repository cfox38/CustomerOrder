﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerOrderProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CreditLimit { get; set; }
        public bool Active { get; set; }

    }
}