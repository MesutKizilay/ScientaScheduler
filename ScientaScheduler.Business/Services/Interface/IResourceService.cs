﻿using ScientaScheduler.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientaScheduler.Business.Services.Interface
{
    public interface IResourceService
    {
        Task<List<IKCalisan>> GetResourceList();
    }
}