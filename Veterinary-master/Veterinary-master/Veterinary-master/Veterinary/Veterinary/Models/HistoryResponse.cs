﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Veterinary.Models
{
    public class HistoryResponse
    {
        public int Id { get; set; }

        public string ServiceType { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Remarks { get; set; }

    }
}
