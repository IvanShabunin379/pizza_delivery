﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.BL.Users.Entities
{
    public class UsersModelFilter
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? MinOrdersCount { get; set; }
        public int? MaxOrdersCount { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
