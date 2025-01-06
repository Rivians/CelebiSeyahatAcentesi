﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebiSeyahat.Application.Features.CustomerFeatures.Queries
{
    public class GetCustomerListWithAllQuery : IRequest<List<GetCustomerListWithAllQueryResponse>>
    {
    }
}
