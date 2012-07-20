using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Build.Execution;

namespace NuDeploy.Core.Services.Packaging.Build
{
    public class SolutionBuilder : ISolutionBuilder
    {
        private const string DefaultBuildTarget = "Rebuild";

        private const string DefaultTargetPlatform = "Any CPU";

        private readonly string buildFolder;

        private readonly IBuildPropertyProvider buildPropertyProvider;

        public SolutionBuilder(IBuildFolderPathProvider buildFolderPathProvider, IBuildPropertyProvider buildPropertyProvider)
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
        }

        public bool Build(string solutionPath, string buildConfiguration, IEnumerable<KeyValuePair<string, string>> additionalBuildProperties)
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
            var buildProperties = this.buildPropertyProvider.GetBuildProperties(
                buildConfiguration, DefaultTargetPlatform, this.buildFolder, additionalBuildProperties.ToList());

            // prepare build request
            var buildRequestData = new BuildRequestData(solutionPath, buildProperties, null, new[] { DefaultBuildTarget }, null);
            var buildParameters = new BuildParameters();
            
            // build
            BuildResult result = BuildManager.DefaultBuildManager.Build(buildParameters, buildRequestData);

            return result.OverallResult == BuildResultCode.Success;
        }
    }
}