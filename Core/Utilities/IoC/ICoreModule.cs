﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
