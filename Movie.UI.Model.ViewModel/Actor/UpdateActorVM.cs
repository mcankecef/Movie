﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.UI.Model.ViewModel.Actor
{
    public class UpdateActorVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public float Height { get; set; }
        public DateTime BirthOfDate { get; set; }
    }
}
