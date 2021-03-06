﻿using System;
using System.Collections.Generic;

using Moq;

using NuDeploy.Core.Services;
using NuDeploy.Core.Services.Packaging;
using NuDeploy.Core.Services.Packaging.Build;
using NuDeploy.Core.Services.Packaging.Nuget;
using NuDeploy.Core.Services.Packaging.PrePackaging;

using NUnit.Framework;

namespace NuDeploy.Core.Tests.UnitTests.Packaging
{
    [TestFixture]
    public class SolutionPackagingServiceTests
    {
        #region constructor

        [Test]
        public void Constructor_AllParametersAreValid_ObjectIsInstantiated()
        {
            // Arrange
            ISolutionBuilder solutionBuilder = new Mock<ISolutionBuilder>().Object;
            IPrepackagingService prepackagingService = new Mock<IPrepackagingService>().Object;
            IPackagingService packagingService = new Mock<IPackagingService>().Object;
            IBuildFolderPathProvider buildFolderPathProvider = new Mock<IBuildFolderPathProvider>().Object;

            // Act
            var result = new SolutionPackagingService(solutionBuilder, prepackagingService, packagingService, buildFolderPathProvider);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_SolutionBuilderParameterIsNull_ArgumentNullExceptionIsThrown()
        {
            // Arrange
            IPrepackagingService prepackagingService = new Mock<IPrepackagingService>().Object;
            IPackagingService packagingService = new Mock<IPackagingService>().Object;
            IBuildFolderPathProvider buildFolderPathProvider = new Mock<IBuildFolderPathProvider>().Object;

            // Act
            new SolutionPackagingService(null, prepackagingService, packagingService, buildFolderPathProvider);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_PrepackagingServiceParameterIsNull_ArgumentNullExceptionIsThrown()
        {
            // Arrange
            ISolutionBuilder solutionBuilder = new Mock<ISolutionBuilder>().Object;
            IPackagingService packagingService = new Mock<IPackagingService>().Object;
            IBuildFolderPathProvider buildFolderPathProvider = new Mock<IBuildFolderPathProvider>().Object;

            // Act
            new SolutionPackagingService(solutionBuilder, null, packagingService, buildFolderPathProvider);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_PackagingServiceParameterIsNull_ArgumentNullExceptionIsThrown()
        {
            // Arrange
            ISolutionBuilder solutionBuilder = new Mock<ISolutionBuilder>().Object;
            IPrepackagingService prepackagingService = new Mock<IPrepackagingService>().Object;
            IBuildFolderPathProvider buildFolderPathProvider = new Mock<IBuildFolderPathProvider>().Object;

            // Act
            new SolutionPackagingService(solutionBuilder, prepackagingService, null, buildFolderPathProvider);
        }

        #endregion

        #region PackageSolution

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void PackageSolution_SolutionPathParameterIsInvalid_ResultIsFalse(string solutionPath)
        {
            // Arrange
            var solutionBuilderMock = new Mock<ISolutionBuilder>();
            var prepackagingServiceMock = new Mock<IPrepackagingService>();
            var packagingServiceMock = new Mock<IPackagingService>();
            var buildFolderPathProvider = new Mock<IBuildFolderPathProvider>();
            buildFolderPathProvider.Setup(b => b.GetBuildFolderPath()).Returns("C:\\build");

            var solutionPackagingService = new SolutionPackagingService(solutionBuilderMock.Object, prepackagingServiceMock.Object, packagingServiceMock.Object, buildFolderPathProvider.Object);

            string buildConfiguration = "Debug";
            var buildProperties = new[] { new KeyValuePair<string, string>("IsAutoBuild", "True") };

            // Act
            var result = solutionPackagingService.PackageSolution(solutionPath, buildConfiguration, buildProperties);

            // Assert
            Assert.AreEqual(ServiceResultType.Failure, result.Status);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void PackageSolution_BuildConfigurationParameterIsInvalid_ResultIsFalse(string buildConfiguration)
        {
            // Arrange
            var solutionBuilderMock = new Mock<ISolutionBuilder>();
            var prepackagingServiceMock = new Mock<IPrepackagingService>();
            var packagingServiceMock = new Mock<IPackagingService>();
            var buildFolderPathProvider = new Mock<IBuildFolderPathProvider>();
            buildFolderPathProvider.Setup(b => b.GetBuildFolderPath()).Returns("C:\\build");

            var solutionPackagingService = new SolutionPackagingService(solutionBuilderMock.Object, prepackagingServiceMock.Object, packagingServiceMock.Object, buildFolderPathProvider.Object);

            string solutionPath = @"C:\dev\someproject\some-solution.sln";
            var buildProperties = new[] { new KeyValuePair<string, string>("IsAutoBuild", "True") };

            // Act
            var result = solutionPackagingService.PackageSolution(solutionPath, buildConfiguration, buildProperties);

            // Assert
            Assert.AreEqual(ServiceResultType.Failure, result.Status);
        }

        [Test]
        public void PackageSolution_BuildPropertiesParameterIsNull_ResultIsFalse()
        {
            // Arrange
            var solutionBuilderMock = new Mock<ISolutionBuilder>();
            var prepackagingServiceMock = new Mock<IPrepackagingService>();
            var packagingServiceMock = new Mock<IPackagingService>();
            var buildFolderPathProvider = new Mock<IBuildFolderPathProvider>();
            buildFolderPathProvider.Setup(b => b.GetBuildFolderPath()).Returns("C:\\build");

            var solutionPackagingService = new SolutionPackagingService(solutionBuilderMock.Object, prepackagingServiceMock.Object, packagingServiceMock.Object, buildFolderPathProvider.Object);

            string solutionPath = @"C:\dev\someproject\some-solution.sln";
            string buildConfiguration = "Debug";
            KeyValuePair<string, string>[] buildProperties = null;

            // Act
            var result = solutionPackagingService.PackageSolution(solutionPath, buildConfiguration, buildProperties);

            // Assert
            Assert.AreEqual(ServiceResultType.Failure, result.Status);
        }

        [Test]
        public void PackageSolution_ParametersAreValid_BuildFails_ResultIsFalse()
        {
            // Arrange
            string solutionPath = @"C:\dev\someproject\some-solution.sln";
            string buildConfiguration = "Debug";
            var buildProperties = new[] { new KeyValuePair<string, string>("IsAutoBuild", "True") };

            var solutionBuilderMock = new Mock<ISolutionBuilder>();
            solutionBuilderMock.Setup(b => b.Build(solutionPath, buildConfiguration, buildProperties)).Returns(new FailureResult());

            var prepackagingServiceMock = new Mock<IPrepackagingService>();
            var packagingServiceMock = new Mock<IPackagingService>();
            var buildFolderPathProvider = new Mock<IBuildFolderPathProvider>();
            buildFolderPathProvider.Setup(b => b.GetBuildFolderPath()).Returns("C:\\build");

            var solutionPackagingService = new SolutionPackagingService(solutionBuilderMock.Object, prepackagingServiceMock.Object, packagingServiceMock.Object, buildFolderPathProvider.Object);

            // Act
            var result = solutionPackagingService.PackageSolution(solutionPath, buildConfiguration, buildProperties);

            // Assert
            Assert.AreEqual(ServiceResultType.Failure, result.Status);
        }

        [Test]
        public void PackageSolution_ParametersAreValid_BuildSucceeds_PrepackagingFails_ResultIsFalse()
        {
            // Arrange
            string solutionPath = @"C:\dev\someproject\some-solution.sln";
            string buildConfiguration = "Debug";
            var buildProperties = new[] { new KeyValuePair<string, string>("IsAutoBuild", "True") };

            var solutionBuilderMock = new Mock<ISolutionBuilder>();
            solutionBuilderMock.Setup(b => b.Build(solutionPath, buildConfiguration, buildProperties)).Returns(new SuccessResult());

            var prepackagingServiceMock = new Mock<IPrepackagingService>();
            prepackagingServiceMock.Setup(p => p.Prepackage(It.IsAny<string>())).Returns(new FailureResult());

            var packagingServiceMock = new Mock<IPackagingService>();
            var buildFolderPathProvider = new Mock<IBuildFolderPathProvider>();
            buildFolderPathProvider.Setup(b => b.GetBuildFolderPath()).Returns("C:\\build");

            var solutionPackagingService = new SolutionPackagingService(solutionBuilderMock.Object, prepackagingServiceMock.Object, packagingServiceMock.Object, buildFolderPathProvider.Object);

            // Act
            var result = solutionPackagingService.PackageSolution(solutionPath, buildConfiguration, buildProperties);

            // Assert
            Assert.AreEqual(ServiceResultType.Failure, result.Status);
        }

        [Test]
        public void PackageSolution_ParametersAreValid_BuildSucceeds_PrepackagingSucceeds_PackaginFails_ResultIsFalse()
        {
            // Arrange
            string solutionPath = @"C:\dev\someproject\some-solution.sln";
            string buildConfiguration = "Debug";
            var buildProperties = new[] { new KeyValuePair<string, string>("IsAutoBuild", "True") };

            var solutionBuilderMock = new Mock<ISolutionBuilder>();
            solutionBuilderMock.Setup(b => b.Build(solutionPath, buildConfiguration, buildProperties)).Returns(new SuccessResult());

            var prepackagingServiceMock = new Mock<IPrepackagingService>();
            prepackagingServiceMock.Setup(p => p.Prepackage(It.IsAny<string>())).Returns(new SuccessResult());

            var packagingServiceMock = new Mock<IPackagingService>();
            packagingServiceMock.Setup(p => p.Package()).Returns(new FailureResult());
            var buildFolderPathProvider = new Mock<IBuildFolderPathProvider>();
            buildFolderPathProvider.Setup(b => b.GetBuildFolderPath()).Returns("C:\\build");

            var solutionPackagingService = new SolutionPackagingService(solutionBuilderMock.Object, prepackagingServiceMock.Object, packagingServiceMock.Object, buildFolderPathProvider.Object);

            // Act
            var result = solutionPackagingService.PackageSolution(solutionPath, buildConfiguration, buildProperties);

            // Assert
            Assert.AreEqual(ServiceResultType.Failure, result.Status);
        }

        [Test]
        public void PackageSolution_ParametersAreValid_BuildSucceeds_PrepackagingSucceeds_PackaginSucceeds_ResultIsTrue()
        {
            // Arrange
            string solutionPath = @"C:\dev\someproject\some-solution.sln";
            string buildConfiguration = "Debug";
            var buildProperties = new[] { new KeyValuePair<string, string>("IsAutoBuild", "True") };

            var solutionBuilderMock = new Mock<ISolutionBuilder>();
            solutionBuilderMock.Setup(b => b.Build(solutionPath, buildConfiguration, buildProperties)).Returns(new SuccessResult());

            var prepackagingServiceMock = new Mock<IPrepackagingService>();
            prepackagingServiceMock.Setup(p => p.Prepackage(It.IsAny<string>())).Returns(new SuccessResult());

            var packagingServiceMock = new Mock<IPackagingService>();
            packagingServiceMock.Setup(p => p.Package()).Returns(new SuccessResult());

            var buildFolderPathProvider = new Mock<IBuildFolderPathProvider>();
            buildFolderPathProvider.Setup(b => b.GetBuildFolderPath()).Returns("C:\\build");

            var solutionPackagingService = new SolutionPackagingService(solutionBuilderMock.Object, prepackagingServiceMock.Object, packagingServiceMock.Object, buildFolderPathProvider.Object);

            // Act
            var result = solutionPackagingService.PackageSolution(solutionPath, buildConfiguration, buildProperties);

            // Assert
            Assert.AreEqual(ServiceResultType.Success, result.Status);
        }

        #endregion
    }
}