﻿namespace AppHarbor.Commands
{
	public class RemoveHostnameCommand : ICommand
	{
		private readonly IApplicationConfiguration _applicationConfiguration;
		private readonly IAppHarborClient _appharborClient;

		public RemoveHostnameCommand(IApplicationConfiguration applicationConfiguration, IAppHarborClient appharborClient)
		{
			_applicationConfiguration = applicationConfiguration;
			_appharborClient = appharborClient;
		}

		public void Execute(string[] arguments)
		{
			if (arguments.Length == 0)
			{
				throw new CommandException("No hostname was specified");
			}

			var applicationId = _applicationConfiguration.GetApplicationId();

			_appharborClient.RemoveHostname(applicationId, arguments[0]);
		}
	}
}
