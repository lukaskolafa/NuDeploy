using System;
using System.Management.Automation.Host;
using System.Runtime.InteropServices;

using NuDeploy.CommandLine.Commands;
using NuDeploy.CommandLine.DependencyResolution;
using NuDeploy.CommandLine.Infrastructure.Console;
using NuDeploy.CommandLine.UserInterface;
using NuDeploy.Core.Common;
using NuDeploy.Core.Common.FileEncoding;
using NuDeploy.Core.Common.FilesystemAccess;
using NuDeploy.Core.Common.Infrastructure;
using NuDeploy.Core.Common.Logging;
using NuDeploy.Core.Common.Persistence;
using NuDeploy.Core.Common.Serialization;
using NuDeploy.Core.Common.UserInterface;
using NuDeploy.Core.Services.AssemblyResourceAccess;
using NuDeploy.Core.Services.Cleanup;
using NuDeploy.Core.Services.Filesystem;
using NuDeploy.Core.Services.Installation;
using NuDeploy.Core.Services.Installation.PowerShell;
using NuDeploy.Core.Services.Installation.Repositories;
using NuDeploy.Core.Services.Installation.Status;
using NuDeploy.Core.Services.Packaging;
using NuDeploy.Core.Services.Packaging.Build;
using NuDeploy.Core.Services.Packaging.Configuration;
using NuDeploy.Core.Services.Packaging.Nuget;
using NuDeploy.Core.Services.Packaging.PrePackaging;
using NuDeploy.Core.Services.Publishing;
using NuDeploy.Core.Services.Transformation;
using NuDeploy.Core.Services.Update;

using NuGet;

using NUnit.Framework;

using StructureMap;

namespace NuDeploy.CommandLine.Tests.IntegrationTests.DependencyResolution
{
    [TestFixture]
    public class StructureMapSetupTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            StructureMapSetup.Setup();
        }

        [TestCase(typeof(IEncodingProvider))]
        [TestCase(typeof(IActionLogger))]
        [TestCase(typeof(ApplicationInformation))]
        [TestCase(typeof(IFilesystemAccessor))]
        [TestCase(typeof(IUserInterface))]
        [TestCase(typeof(IConsoleTextManipulation))]
        [TestCase(typeof(IServiceResultVisualizer))]
        [TestCase(typeof(IPowerShellSessionFactory))]
        [TestCase(typeof(IPowerShellExecutor))]
        [TestCase(typeof(IPowerShellHost))]
        [TestCase(typeof(PSHostUserInterface))]
        [TestCase(typeof(IPackageRepositoryFactory))]
        [TestCase(typeof(_Assembly))]
        [TestCase(typeof(IAssemblyResourceFilePathProvider))]
        [TestCase(typeof(IAssemblyFileResourceProvider))]
        [TestCase(typeof(IAssemblyResourceDownloader))]
        [TestCase(typeof(ICleanupService))]
        [TestCase(typeof(IRelativeFilePathInfoFactory))]
        [TestCase(typeof(ISourceRepositoryProvider))]
        [TestCase(typeof(ISourceRepositoryConfigurationFactory))]
        [TestCase(typeof(Func<Uri, IHttpClient>))]
        [TestCase(typeof(IPackageRepositoryBrowser))]
        [TestCase(typeof(IPackageConfigurationAccessor))]
        [TestCase(typeof(IInstallationLogicProvider))]
        [TestCase(typeof(IDeploymentTypeParser))]
        [TestCase(typeof(IRepositoryConfigurationCommandActionParser))]
        [TestCase(typeof(IPackageInstaller))]
        [TestCase(typeof(INugetPackageExtractor))]
        [TestCase(typeof(IPackageUninstaller))]
        [TestCase(typeof(ISolutionPackagingService))]
        [TestCase(typeof(IBuildOutputPackagingService))]
        [TestCase(typeof(IBuildFolderPathProvider))]
        [TestCase(typeof(ISolutionBuilder))]
        [TestCase(typeof(IBuildResultFilePathProvider))]
        [TestCase(typeof(IBuildPropertyProvider))]
        [TestCase(typeof(ICommandArgumentNameMatcher))]
        [TestCase(typeof(ICommandArgumentParser))]
        [TestCase(typeof(ICommandLineArgumentInterpreter))]
        [TestCase(typeof(ICommandNameMatcher))]
        [TestCase(typeof(IBuildPropertyParser))]
        [TestCase(typeof(IPackagingFolderPathProvider))]
        [TestCase(typeof(IPackagingService))]
        [TestCase(typeof(IPrePackagingFolderPathProvider))]
        [TestCase(typeof(IPrepackagingService))]
        [TestCase(typeof(IInstallationStatusProvider))]
        [TestCase(typeof(IConfigurationFileTransformationService))]
        [TestCase(typeof(IPackageConfigurationTransformationService))]
        [TestCase(typeof(IConfigurationFileTransformer))]
        [TestCase(typeof(ISelfUpdateService))]
        [TestCase(typeof(IHelpProvider))]
        [TestCase(typeof(ICommandProvider))]
        [TestCase(typeof(IObjectSerializer<PackageInfo[]>))]
        [TestCase(typeof(IObjectSerializer<PublishConfiguration[]>))]
        [TestCase(typeof(IObjectSerializer<SourceRepositoryConfiguration[]>))]
        [TestCase(typeof(IFilesystemPersistence<PackageInfo[]>))]
        [TestCase(typeof(IFilesystemPersistence<PublishConfiguration[]>))]
        [TestCase(typeof(IFilesystemPersistence<SourceRepositoryConfiguration[]>))]
        public void CanInstantiate_Interface(Type interfaceType)
        {
            // Act
            var result = ObjectFactory.TryGetInstance(interfaceType);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}