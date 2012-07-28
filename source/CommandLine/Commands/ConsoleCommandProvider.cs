using System;
using System.Collections.Generic;
using System.Linq;

using NuDeploy.CommandLine.Commands.Console;

namespace NuDeploy.CommandLine.Commands
{
    public class ConsoleCommandProvider : ICommandProvider
    {
        private readonly IList<ICommand> commands;

        public ConsoleCommandProvider(InstallationStatusCommand installationStatus, InstallCommand install, UninstallCommand uninstall, CleanupCommand cleanup, PackageSolutionCommand package, RepositorySourceConfigurationCommand configureSources, SelfUpdateCommand selfUpdate, IHelpCommand helpCommand)
        {
            if (installationStatus == null)
            {
                throw new ArgumentNullException("installationStatus");
            }

            if (install == null)
            {
                throw new ArgumentNullException("install");
            }

            if (uninstall == null)
            {
                throw new ArgumentNullException("uninstall");
            }

            if (cleanup == null)
            {
                throw new ArgumentNullException("cleanup");
            }

            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            if (configureSources == null)
            {
                throw new ArgumentNullException("configureSources");
            }

            if (selfUpdate == null)
            {
                throw new ArgumentNullException("selfUpdate");
            }

            if (helpCommand == null)
            {
                throw new ArgumentNullException("helpCommand");
            }

            this.commands = new List<ICommand> { installationStatus, install, uninstall, cleanup, package, configureSources, selfUpdate, helpCommand };
        }

        public ConsoleCommandProvider(IEnumerable<ICommand> commands)
        {
            if (commands == null)
            {
                throw new ArgumentNullException("commands");
            }

            this.commands = commands.ToList();
        }

        public IList<ICommand> GetAvailableCommands()
        {
            return this.commands;
        }
    }
}