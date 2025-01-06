﻿using CelebiSeyahat.Application.Features.CustomerFeatures.Queries;
using CelebiSeyahat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomerListWithAllAsync();
    }
}