﻿using System.Collections.Generic;

using Moq;

using NuDeploy.Core.Commands;
using NuDeploy.Core.Common;

using NUnit.Framework;

namespace NuDeploy.Tests.IntegrationTests
{
    [TestFixture]
    public class CommandLineArgumentInterpreterTests
    {
        private ICommand packackageSolutionCommand;

        private IEnumerable<ICommand> commands;

        private ICommand helpCommand;

        private ICommandLineArgumentInterpreter commandLineArgumentInterpreter;

        [SetUp]
        public void Setup()
        {
            var userInterfaceMock = new Mock<IUserInterface>();
            this.helpCommand = new HelpCommand(userInterfaceMock.Object);

            this.packackageSolutionCommand = new PackageSolutionCommand();
            this.commands = new List<ICommand> { this.packackageSolutionCommand, this.helpCommand };

            ICommandProvider commandProvider = new CommandProvider(this.commands);
            ICommandNameMatcher commandNameMatcher = new CommandNameMatcher();
            ICommandArgumentParser commandArgumentParser = new CommandArgumentParser();
            ICommandArgumentNameMatcher commandArgumentNameMatcher = new CommandArgumentNameMatcher();

            this.commandLineArgumentInterpreter = new CommandLineArgumentInterpreter(
                commandProvider, commandNameMatcher, commandArgumentParser, commandArgumentNameMatcher);            
        }

        [Test]
        public void GetCommand_UnknownCommandNameIsSupplied_ResultIsNull()
        {
            // Arrange
            var arguments = new[] { "Jdfklsajdlkjsadlkjasdlö" };

            // Act
            ICommand result = this.commandLineArgumentInterpreter.GetCommand(arguments);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetCommand_PackageSolutionCommand_ArternativeCommandNameIsSupplied_ResultIsThePackageSolutionCommand()
        {
            // Arrange
            var arguments = new[] { "pack" };

            // Act
            ICommand result = this.commandLineArgumentInterpreter.GetCommand(arguments);

            // Assert
            Assert.AreEqual(this.packackageSolutionCommand.Attributes.CommandName, result.Attributes.CommandName);
        }

        [Test]
        public void GetCommand_PackageSolutionCommand_PartialCommandNameIsSupplied_ResultIsThePackageSolutionCommand()
        {
            // Arrange
            var arguments = new[] { "pa" };

            // Act
            ICommand result = this.commandLineArgumentInterpreter.GetCommand(arguments);

            // Assert
            Assert.AreEqual(this.packackageSolutionCommand.Attributes.CommandName, result.Attributes.CommandName);
        }

        [Test]
        public void GetCommand_PackageSolutionCommand_FullCommandNameIsSupplied_NoArguments_ResultIsThePackageSolutionCommandWithoutArgumentValues()
        {
            // Arrange
            var arguments = new[] { "package" };

            // Act
            ICommand result = this.commandLineArgumentInterpreter.GetCommand(arguments);

            // Assert
            Assert.AreEqual(this.packackageSolutionCommand.Attributes.CommandName, result.Attributes.CommandName);
            foreach (var key in result.Arguments.Keys)
            {
                Assert.IsNull(result.Arguments[key]);
            }
        }

        [Test]
        public void GetCommand_PackageSolutionCommand_FullCommandNameAndAllArgumentsAreSupplied_SingleDashArguments_NoQuotesForValues_ResultIsThePackageSolutionCommandWithAllArgumentValuesSet()
        {
            // Arrange
            string commandLine = @"package -SolutionPath=C:\dev\project\project.sln -BuildConfiguration=Release -MSBuildProperties=IsAutoBuild=True";

            // Act
            ICommand result = this.commandLineArgumentInterpreter.GetCommand(commandLine.Split(' '));

            // Assert
            Assert.AreEqual(this.packackageSolutionCommand.Attributes.CommandName, result.Attributes.CommandName);
            foreach (var key in result.Arguments.Keys)
            {
                Assert.IsNotNull(result.Arguments[key]);
            }
        }

        [Test]
        public void GetCommand_PackageSolutionCommand_FullCommandNameAndAllArgumentsAreSupplied_SingleDashArguments_SingleQuotesForValues_ResultIsThePackageSolutionCommandWithAllArgumentValuesSet()
        {
            // Arrange
            string commandLine = @"package -SolutionPath='C:\dev\project\project.sln' -BuildConfiguration='Release' -MSBuildProperties='IsAutoBuild=True'";

            // Act
            ICommand result = this.commandLineArgumentInterpreter.GetCommand(commandLine.Split(' '));

            // Assert
            Assert.AreEqual(this.packackageSolutionCommand.Attributes.CommandName, result.Attributes.CommandName);
            foreach (var key in result.Arguments.Keys)
            {
                Assert.IsNotNull(result.Arguments[key]);
            }
        }

        [Test]
        public void GetCommand_PackageSolutionCommand_FullCommandNameAndAllArgumentsAreSupplied_SingleDashArguments_DoubleQuotesForValues_ResultIsThePackageSolutionCommandWithAllArgumentValuesSet()
        {
            // Arrange
            string commandLine = "package -SolutionPath=\"C:\\dev\\project\\project.sln' -BuildConfiguration=\"Release\" -MSBuildProperties=\"IsAutoBuild=True\"";

            // Act
            ICommand result = this.commandLineArgumentInterpreter.GetCommand(commandLine.Split(' '));

            // Assert
            Assert.AreEqual(this.packackageSolutionCommand.Attributes.CommandName, result.Attributes.CommandName);
            foreach (var key in result.Arguments.Keys)
            {
                Assert.IsNotNull(result.Arguments[key]);
            }
        }

        [Test]
        public void GetCommand_PackageSolutionCommand_UnmappableNamedArgumentIsSupplied_ResultIsThePackageSolutionCommandWithAdditionalArgument()
        {
            // Arrange
            string commandLine = @"package -UnmappableArgumentName=UnmappableArgumentValue";

            // Act
            ICommand result = this.commandLineArgumentInterpreter.GetCommand(commandLine.Split(' '));

            // Assert: Package Command is returned
            Assert.AreEqual(this.packackageSolutionCommand.Attributes.CommandName, result.Attributes.CommandName);

            // Assert: Unmappable argument is added to argument list
            Assert.IsTrue(result.Arguments.Keys.Contains("UnmappableArgumentName"));
            Assert.AreEqual("UnmappableArgumentValue", result.Arguments["UnmappableArgumentName"]);
        }

        [Test]
        public void GetCommand_PackageSolutionCommand_UnmappableUnnamedArgumentIsSupplied_ResultIsThePackageSolutionCommandWithAdditionalUnnamedArgument()
        {
            // Arrange
            string commandLine = @"package SomeValueWithoutAnArgumentName";

            // Act
            ICommand result = this.commandLineArgumentInterpreter.GetCommand(commandLine.Split(' '));

            // Assert: Package Command is returned
            Assert.AreEqual(this.packackageSolutionCommand.Attributes.CommandName, result.Attributes.CommandName);

            // Assert: Unnamed argument is added to the argument list
            Assert.IsTrue(result.Arguments.Values.Contains("SomeValueWithoutAnArgumentName"));
        }

        [Test]
        public void GetCommand_PackageSolutionCommand_FullCommandNameIsSupplied_AllArguments_ResultIsThePackageSolutionCommandWithAllArgumentValues()
        {
            // Arrange
            string commandName = "package";

            string argumentPrefix = "-";
            string argumentValueAssignmentOperator = "=";

            string argument1Name = "SolutionPath";
            string argument1Value = @"C:\dev\project\project.sln";
            string argument1 = argumentPrefix + argument1Name + argumentValueAssignmentOperator + argument1Value;

            string argument2Name = "BuildConfiguration";
            string argument2Value = @"Release";
            string argument2 = argumentPrefix + argument2Name + argumentValueAssignmentOperator + argument2Value;

            string argument3Name = "MSBuildProperties";
            string argument3Value = @"IsAutoBuild=True";
            string argument3 = argumentPrefix + argument3Name + argumentValueAssignmentOperator + argument3Value;

            var arguments = new[] { commandName, argument1, argument2, argument3 };

            // Act
            ICommand result = this.commandLineArgumentInterpreter.GetCommand(arguments);

            // Assert
            Assert.AreEqual(this.packackageSolutionCommand.Attributes.CommandName, result.Attributes.CommandName);
            Assert.AreEqual(argument1Value, result.Arguments[argument1Name]);
            Assert.AreEqual(argument2Value, result.Arguments[argument2Name]);
            Assert.AreEqual(argument3Value, result.Arguments[argument3Name]);
        }
    }
}
