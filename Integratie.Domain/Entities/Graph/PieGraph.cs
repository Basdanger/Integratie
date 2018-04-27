﻿using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Graph
{
    public class PieGraph : Graph
    {
        public Subject Subject { get; set; }
    }
    public enum PieType
    {
        GENDER,
        POSNEG
    }
}
