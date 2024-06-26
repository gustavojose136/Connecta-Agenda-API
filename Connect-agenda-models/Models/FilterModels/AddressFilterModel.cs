﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_agenda_models.Models.FilterModels
{
    public class AddressFilterModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }   
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public bool IsActive { get; set; }
    }
}
