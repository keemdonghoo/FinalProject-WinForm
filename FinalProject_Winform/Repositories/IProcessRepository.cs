﻿using FinalProject_Winform.Models.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Winform.Repositories
{
    internal interface IProcessRepository
    {
        Task<IEnumerable<Process>> GetAllAsync();
    }
}