﻿using System;
using TIKSN.PowerShell;

namespace TIKSN.Cmdlets.Commands
{
    public abstract class Command : CommandBase
    {
        protected override IServiceProvider GetServiceProvider() => CompositionRootSetup.ServiceProvider;
    }
}