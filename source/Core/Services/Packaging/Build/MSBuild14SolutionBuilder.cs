using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NuDeploy.Core.Common.UserInterface;

namespace NuDeploy.Core.Services.Packaging.Build
{
    public class MSBuild14SolutionBuilder : ISolutionBuilder
    {
        private const string DefaultTargetPlatform = "Any CPU";

        private readonly string buildFolder;

        private readonly IBuildPropertyProvider buildPropertyProvider;
        private readonly IUserInterface userInterface;

        public MSBuild14SolutionBuilder(IBuildFolderPathProvider buildFolderPathProvider, IBuildPropertyProvider buildPropertyProvider, IUserInterface userInterface)
        {
            if (buildFolderPathProvider == null)
            {
                throw new ArgumentNullException("buildFolderPathProvider");
            }

            if (buildPropertyProvider == null)
            {
                throw new ArgumentNullException("buildPropertyProvider");
            }

            this.buildFolder = buildFolderPathProvider.GetBuildFolderPath();
            this.buildPropertyProvider = buildPropertyProvider;
            this.userInterface = userInterface;
        }

        public IServiceResult Build(string solutionPath, string buildConfiguration, IEnumerable<KeyValuePair<string, string>> additionalBuildProperties)
        {
            if (string.IsNullOrWhiteSpace(solutionPath))
            {
                throw new ArgumentException("solutionPath");
            }

            if (string.IsNullOrWhiteSpace(buildConfiguration))
            {
                throw new ArgumentException("buildConfiguration");
            }

            if (additionalBuildProperties == null)
            {
                throw new ArgumentNullException("additionalBuildProperties");
            }

            // prepare build parameters
            IDictionary<string, string> buildProperties = this.buildPropertyProvider.GetBuildProperties(
                buildConfiguration, DefaultTargetPlatform, this.buildFolder, additionalBuildProperties.ToList());

            bool success;
            int exitCode = 999;

            try
            {
                string buildPropertiesArgument = string.Join(" ", buildProperties.Select(x => string.Format("/p:{0}=\"{1}\"", x.Key, x.Value)));
                this.userInterface.WriteLine("MSBuild: Starting Build with MSBuild... Max 10 Minutes for Build allowed!!!");

                var process = new Process();
                process.StartInfo = new ProcessStartInfo(@"c:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe");
                process.StartInfo.Arguments = string.Format("{0} {1}", solutionPath, buildPropertiesArgument);
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.OutputDataReceived += Process_OutputDataReceived;
                process.Start();
                process.BeginOutputReadLine();

                this.userInterface.WriteLine("MSBuild: Waiting for exit...");
                process.WaitForExit(600000);

                exitCode = process.ExitCode;
                success = exitCode == 0; 
            }
            catch (Exception e)
            {
                success = false;
                this.userInterface.WriteLine("MSBuild: ERROR FAILED " + e);
            }

            if (success)
            {
                this.userInterface.WriteLine("MSBuild: Success!");

                return new SuccessResult(
                    Resources.SolutionBuilder.SuccessMessageTemplate,
                    solutionPath,
                    buildConfiguration,
                    string.Join(",", buildProperties.Select(p => p.Key + "=" + p.Value)));
            }
            
            if (exitCode != 0)
            {
                this.userInterface.WriteLine("MSBuild: ERROR FAILED process did not exited with code 0. Exit code was: " + exitCode);
            }

            return new FailureResult(
                Resources.SolutionBuilder.FailureMessageTemplate,
                solutionPath,
                buildConfiguration,
                string.Join(",", buildProperties.Select(p => p.Key + "=" + p.Value)));
        }
        
        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    this.userInterface.WriteLine(e.Data);
                }
            }
            catch (Exception)
            {
                try
                {
                    this.userInterface.WriteLine("Error Occured while loggin output from MSBuild Process");
                }
                catch (Exception)
                {
                    // no error here
                }
            }
        }
    }
}