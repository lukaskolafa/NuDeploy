﻿using System;
using System.Linq;

using NuDeploy.Core.Common;
using NuDeploy.Core.Services.Installation.Repositories;

using NuGet;

using NUnit.Framework;

namespace NuDeploy.Core.Tests.IntegrationTests.Repositories
{
    [TestFixture]
    public class CommandLineRepositoryFactoryTests
    {
        private IPackageRepositoryFactory commandLineRepositoryFactory;

        [TestFixtureSetUp]
        public void Setup()
        {
            Func<Uri, IHttpClient> httpClientFactory = u => new RedirectedHttpClient(u);
            this.commandLineRepositoryFactory = new CommandLineRepositoryFactory(httpClientFactory);
        }

        [Test]
        public void CreateRepository_PackageSourceParameterIsValid_ResultIsNotNull()
        {
            // Arrange
            string packageSource = NuDeployConstants.DefaultFeedUrl.ToString();

            // Act
            IPackageRepository result = this.commandLineRepositoryFactory.CreateRepository(packageSource);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateRepository_PackageSourceParameterIsValid_GetNugetCorePackageReturnsAPackage()
        {
            // Arrange
            string packageSource = NuDeployConstants.DefaultFeedUrl.ToString();
            IPackageRepository packageRepository = this.commandLineRepositoryFactory.CreateRepository(packageSource);

            // Act
            var package = packageRepository.GetPackages().Where(p => p.Id.Equals("Nuget.Core", StringComparison.OrdinalIgnoreCase));
           
            // Assert
            Assert.IsNotNull(package);
        }
    }
}