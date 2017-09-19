﻿using System;
using TIKSN.PowerShell;

namespace TIKSN.Cmdlets.Core.Commands
{
	public abstract class Command : CommandBase
	{
		protected override IServiceProvider CreateServiceProvider()
		{
			var compositionRootSetup = new CompositionRootSetup(this, ConfigurationRootSetup.ConfigurationRoot);

			return compositionRootSetup.CreateServiceProvider();
		}
	}
}
