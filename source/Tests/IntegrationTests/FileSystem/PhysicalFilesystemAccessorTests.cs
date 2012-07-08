﻿using System;
using System.IO;

using Moq;

using NuDeploy.Core.Common;

using NUnit.Framework;

namespace NuDeploy.Tests.IntegrationTests.FileSystem
{
    [TestFixture]
    public class PhysicalFilesystemAccessorTests
    {
        private const string SampleFileFolder = "samples";

        private IFilesystemAccessor filesystemAccessor;

        private IEncodingProvider encodingProvider;

        [TestFixtureSetUp]
        public void Setup()
        {
            var logger = new Mock<IActionLogger>();
            this.encodingProvider = new DefaultFileEncodingProvider();
            this.filesystemAccessor = new PhysicalFilesystemAccessor(logger.Object, this.encodingProvider);
        }

        [SetUp]
        public void BeforeEachTest()
        {
            if (Directory.Exists(SampleFileFolder))
            {
                Directory.Delete(SampleFileFolder, true);
            }

            Directory.CreateDirectory(SampleFileFolder);
        }

        #region FileExists

        [Test]
        public void FileExists_SuppliedPathIsNull_ResultIsFalse()
        {
            // Arrange
            string path = null;

            // Act
            bool result = this.filesystemAccessor.FileExists(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void FileExists_SuppliedPathIsEmpty_ResultIsFalse()
        {
            // Arrange
            string path = string.Empty;

            // Act
            bool result = this.filesystemAccessor.FileExists(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void FileExists_SuppliedPathIsWhitespace_ResultIsFalse()
        {
            // Arrange
            string path = " ";

            // Act
            bool result = this.filesystemAccessor.FileExists(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void FileExists_SuppliedPathIsDirectory_ResultIsFalse()
        {
            // Arrange
            string path = Environment.CurrentDirectory;
            
            // Act
            bool result = this.filesystemAccessor.FileExists(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void FileExists_SuppliedPathIsNotExistingFile_ResultIsFalse()
        {
            // Arrange
            var path = "There-Is-No-Way-This-File-Can-Exist-salkfjaskjksad43242jf.txt";

            // Act
            bool result = this.filesystemAccessor.FileExists(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void FileExists_SuppliedPathIsExistingFile_ResultIsTrue()
        {
            // Arrange
            var path = this.CreateFile("test-file.txt").FullName;

            // Act
            bool result = this.filesystemAccessor.FileExists(path);

            // Assert
            Assert.IsTrue(result);
        }

        #endregion

        #region DirectoryExists

        [Test]
        public void DirectoryExists_SuppliedPathIsNull_ResultIsFalse()
        {
            // Arrange
            string path = null;

            // Act
            bool result = this.filesystemAccessor.DirectoryExists(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DirectoryExists_SuppliedPathIsEmpty_ResultIsFalse()
        {
            // Arrange
            string path = string.Empty;

            // Act
            bool result = this.filesystemAccessor.DirectoryExists(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DirectoryExists_SuppliedPathIsWhitespace_ResultIsFalse()
        {
            // Arrange
            string path = " ";

            // Act
            bool result = this.filesystemAccessor.DirectoryExists(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DirectoryExists_SuppliedPathIsAnExistingFile_ResultIsFalse()
        {
            // Arrange
            var path = this.CreateFile("test-file.txt").FullName;

            // Act
            bool result = this.filesystemAccessor.DirectoryExists(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DirectoryExists_SuppliedPathIsAnNonExistingFile_ResultIsFalse()
        {
            // Arrange
            var path = "There-Is-No-Way-This-File-Can-Exist-salkfjaskjksad43242jf.txt";

            // Act
            bool result = this.filesystemAccessor.DirectoryExists(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DirectoryExists_SuppliedPathIsNonExistingDirectory_ResultIsFalse()
        {
            // Arrange
            var path = "NonExistingTestDirectory";

            // Act
            bool result = this.filesystemAccessor.DirectoryExists(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DirectoryExists_SuppliedPathIsExistingDirectory_ResultIsTrue()
        {
            // Arrange
            var path = this.CreateDirectory("TestDirectory").FullName;

            // Act
            bool result = this.filesystemAccessor.DirectoryExists(path);

            // Assert
            Assert.IsTrue(result);
        }

        #endregion

        #region MoveFile

        [Test]
        public void MoveFile_SourceFilePathIsEmpty_ResultIsFalse()
        {
            // Arrange
            string sourceFilePath = string.Empty;

            string targetFilePath = string.Empty;

            // Act
            bool result = this.filesystemAccessor.MoveFile(sourceFilePath, targetFilePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void MoveFile_SourceFilePathIsNull_ResultIsFalse()
        {
            // Arrange
            string sourceFilePath = null;

            string targetFilePath = this.GetPath("Target-File.txt");

            // Act
            bool result = this.filesystemAccessor.MoveFile(sourceFilePath, targetFilePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void MoveFile_SourceFilePathIsWhiteSpace_ResultIsFalse()
        {
            // Arrange
            string sourceFilePath = " ";

            string targetFilePath = this.GetPath("Target-File.txt");

            // Act
            bool result = this.filesystemAccessor.MoveFile(sourceFilePath, targetFilePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void MoveFile_SourceFilePathDoesNotExist_ResultIsFalse()
        {
            // Arrange
            string sourceFilePath = "Non-Existing-File-3123123123123.txt";

            string targetFilePath = this.GetPath("Target-File.txt");

            // Act
            bool result = this.filesystemAccessor.MoveFile(sourceFilePath, targetFilePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void MoveFile_SourceFileExist_TargetFileParameterIsNull_ResultIsFalse()
        {
            // Arrange
            string sourceFilePath = this.CreateFile("File-Move-Test-Source.txt").FullName;

            string targetFilePath = null;

            // Act
            bool result = this.filesystemAccessor.MoveFile(sourceFilePath, targetFilePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void MoveFile_SourceFileExist_TargetFileParameterIsEmpty_ResultIsFalse()
        {
            // Arrange
            string sourceFilePath = this.CreateFile("File-Move-Test-Source.txt").FullName;

            string targetFilePath = string.Empty;

            // Act
            bool result = this.filesystemAccessor.MoveFile(sourceFilePath, targetFilePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void MoveFile_SourceFileExist_TargetFileParameterIsWhitespace_ResultIsFalse()
        {
            // Arrange
            string sourceFilePath = this.CreateFile("File-Move-Test-Source.txt").FullName;

            string targetFilePath = " ";

            // Act
            bool result = this.filesystemAccessor.MoveFile(sourceFilePath, targetFilePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void MoveFile_SourceFileExist_TargetFileExists_ResultIsTrue_TargetFileContainsContentOfSourceFile()
        {
            // Arrange
            string sourceFilePath = this.CreateFile("File-Move-Test-Source.txt").FullName;
            string sourceContent = File.ReadAllText(sourceFilePath);

            string targetFilePath = this.CreateFile("Target-File.txt").FullName;

            // Act
            bool result = this.filesystemAccessor.MoveFile(sourceFilePath, targetFilePath);

            // Assert
            string targetContent = File.ReadAllText(targetFilePath);
            Assert.IsTrue(result);
            Assert.AreEqual(sourceContent, targetContent);
        }

        [Test]
        public void MoveFile_SourceFileExist_TargetFileIsInUse_ResultIsFalse()
        {
            // Arrange
            string sourceFilePath = this.CreateFile("File-Move-Test-Source.txt").FullName;
            string targetFilePath = this.CreateFile("Target-File.txt").FullName;

            var targetFileStreamReader = new StreamReader(targetFilePath);

            // Act
            bool result = this.filesystemAccessor.MoveFile(sourceFilePath, targetFilePath);

            // Assert
            Assert.IsFalse(result);
            targetFileStreamReader.Close();
        }

        [Test]
        public void MoveFile_SourceFileExist_SourceFileIsInUse_ResultIsFalse()
        {
            // Arrange
            string sourceFilePath = this.CreateFile("File-Move-Test-Source.txt").FullName;
            string targetFilePath = this.CreateFile("Target-File.txt").FullName;

            var sourceFileStreamReader = new StreamReader(sourceFilePath);

            // Act
            bool result = this.filesystemAccessor.MoveFile(sourceFilePath, targetFilePath);

            // Assert
            Assert.IsFalse(result);
            sourceFileStreamReader.Close();
        }

        [Test]
        public void MoveFile_SourceFileExist_TargetFileDoesNotExist_ResultIsTrue_SourceFileIsRemoved_TargetFileContainsContentOfSource()
        {
            // Arrange
            string sourceFilePath = this.CreateFile("File-Move-Test-Source.txt").FullName;
            string sourceFileContent = File.ReadAllText(sourceFilePath);

            string targetFilePath = this.CreateFile("Target-File.txt").FullName;

            // Act
            bool result = this.filesystemAccessor.MoveFile(sourceFilePath, targetFilePath);

            // Assert
            string targetFileContent = File.ReadAllText(targetFilePath);

            Assert.IsTrue(result);
            Assert.IsFalse(File.Exists(sourceFilePath));
            Assert.IsTrue(File.Exists(targetFilePath));
            Assert.AreEqual(sourceFileContent, targetFileContent);
        }

        [Test]
        public void MoveFile_SourceFileExist_TargetFileExist_ResultIsTrue_TargetFileContentChanged()
        {
            // Arrange
            string sourceFilePath = this.CreateFile("File-Move-Test-Source.txt").FullName;
            string sourceFileContent = File.ReadAllText(sourceFilePath);

            string targetFilePath = this.CreateFile("Target-File.txt").FullName;
            string targetFileContentBefore = File.ReadAllText(targetFilePath);

            // Act
            bool result = this.filesystemAccessor.MoveFile(sourceFilePath, targetFilePath);

            // Assert
            string targetFileContentAfter = File.ReadAllText(targetFilePath);

            Assert.IsTrue(result);
            Assert.AreNotEqual(targetFileContentBefore, targetFileContentAfter);
            Assert.AreEqual(sourceFileContent, targetFileContentAfter);
        }

        #endregion

        #region DeleteFile

        [Test]
        public void DeleteFile_FilePathIsNull_ResultIsFalse()
        {
            // Arrange
            string filePath = null;

            // Act
            bool result = this.filesystemAccessor.DeleteFile(filePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteFile_FilePathIsEmpty_ResultIsFalse()
        {
            // Arrange
            string filePath = string.Empty;

            // Act
            bool result = this.filesystemAccessor.DeleteFile(filePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteFile_FilePathIsWhitespace_ResultIsFalse()
        {
            // Arrange
            string filePath = " ";

            // Act
            bool result = this.filesystemAccessor.DeleteFile(filePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteFile_FileDoesNotExist_ResultIsFalse()
        {
            // Arrange
            string filePath = "There-Is-No-Way-This-File-Can-Exist-salkfjaskjksad43242jf.txt";

            // Act
            bool result = this.filesystemAccessor.DeleteFile(filePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteFile_FileExistButIsInUse_ResultIsFalse()
        {
            // Arrange
            string filePath = this.CreateFile("Existing-File-That-Is-Going-To-Be-Deleted.txt").FullName;
            var streamReader = new StreamReader(filePath);

            // Act
            bool result = this.filesystemAccessor.DeleteFile(filePath);

            // Assert
            Assert.IsFalse(result);
            streamReader.Close();
        }

        [Test]
        public void DeleteFile_FileExist_ResultIsTrue_FileDoesNoLongerExist()
        {
            // Arrange
            string filePath = this.CreateFile("Existing-File-That-Is-Going-To-Be-Deleted.txt").FullName;

            // Act
            bool result = this.filesystemAccessor.DeleteFile(filePath);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(File.Exists(filePath));
        }

        #endregion

        #region DeleteFolder

        [Test]
        public void DeleteFolder_FolderPathIsNull_ResultIsFalse()
        {
            // Arrange
            string path = null;

            // Act
            bool result = this.filesystemAccessor.DeleteFolder(path);

            // Assert
            Assert.IsFalse(result);            
        }

        [Test]
        public void DeleteFolder_FolderPathIsEmpty_ResultIsFalse()
        {
            // Arrange
            string path = string.Empty;

            // Act
            bool result = this.filesystemAccessor.DeleteFolder(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteFolder_FolderPathIsWhitespace_ResultIsFalse()
        {
            // Arrange
            string path = " ";

            // Act
            bool result = this.filesystemAccessor.DeleteFolder(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteFolder_FolderDoesNotExist_ResultIsFalse()
        {
            // Arrange
            string path = this.GetPath("non-existing-folder");

            // Act
            bool result = this.filesystemAccessor.DeleteFolder(path);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteFolder_FolderExistsButOneFileInItIsInUse_ResultIsFalse()
        {
            // Arrange
            string path = this.CreateDirectory("new folder").FullName;
            string filePath = this.CreateFile("new folder\\test-file.txt").FullName;
            var streamReader = new StreamReader(filePath);

            // Act
            bool result = this.filesystemAccessor.DeleteFolder(path);

            // Assert
            Assert.IsFalse(result);
            streamReader.Close();
        }

        [Test]
        public void DeleteFolder_FolderExists_FolderIsEmpty_ResultIsTrue_FolderIsRemoved()
        {
            // Arrange
            string path = this.CreateDirectory("new folder").FullName;

            // Act
            bool result = this.filesystemAccessor.DeleteFolder(path);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(Directory.Exists(path));
        }

        [Test]
        public void DeleteFolder_FolderExists_ContainsContent_ResultIsTrue_FolderIsRemoved()
        {
            // Arrange
            string path = this.CreateDirectory("new folder").FullName;
            this.CreateFile("new folder\\test-file.txt");

            // Act
            bool result = this.filesystemAccessor.DeleteFolder(path);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(Directory.Exists(path));
        }

        #endregion

        #region GetFileContent

        [Test]
        public void GetFileContent_FilePathIsNull_ResultIsNull()
        {
            // Arrange
            string filePath = null;

            // Act
            string result = this.filesystemAccessor.GetFileContent(filePath);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetFileContent_FilePathIsEmpty_ResultIsNull()
        {
            // Arrange
            string filePath = string.Empty;

            // Act
            string result = this.filesystemAccessor.GetFileContent(filePath);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetFileContent_FilePathIsWhitespace_ResultIsNull()
        {
            // Arrange
            string filePath = " ";

            // Act
            string result = this.filesystemAccessor.GetFileContent(filePath);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetFileContent_FileDoesNotExist_ResultIsNull()
        {
            // Arrange
            string filePath = "There-Is-No-Way-This-File-Can-Exist-salkfjaskjksad43242jf.txt";

            // Act
            string result = this.filesystemAccessor.GetFileContent(filePath);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetFileContent_FileExists_ButIsBeingWrittenTo_ResultIsNull()
        {
            // Arrange
            string filePath = this.CreateFile("File-That-Is-Being-Written-To-By-Another-Process.txt").FullName;
            var streamWriter = new StreamWriter(filePath);

            // Act
            string result = this.filesystemAccessor.GetFileContent(filePath);

            // Assert
            Assert.IsNull(result);
            streamWriter.Close();
        }

        [Test]
        public void GetFileContent_FileExists_IsBeingRead_ResultIsNotNull()
        {
            // Arrange
            string filePath = this.CreateFile("File-That-Is-Being-Read-By-Another-Process.txt").FullName;
            var streamWriter = new StreamReader(filePath);

            // Act
            string result = this.filesystemAccessor.GetFileContent(filePath);

            // Assert
            Assert.IsNotNull(result);
            streamWriter.Close();
        }

        [Test]
        public void GetFileContent_FileExists_ResultIsContentOfTheSpecifiedFilePath()
        {
            // Arrange
            string filePath = this.CreateFile("File-That-Is-Being-Read-By-Another-Process.txt").FullName;
            var fileContent = this.GetFileContent(filePath);

            // Act
            string result = this.filesystemAccessor.GetFileContent(filePath);

            // Assert
            Assert.AreEqual(fileContent, result);
        }

        #endregion

        #region WriteContentToFile

        [Test]
        public void WriteContentToFile_ContentIsNull_ResultIsFalse_TargetFileIsNotCreated()
        {
            // Arrange
            string content = null;
            string filePath = this.GetPath("Target-File.txt");

            // Act
            bool result = this.filesystemAccessor.WriteContentToFile(content, filePath);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(File.Exists(filePath));
        }

        [Test]
        public void WriteContentToFile_FilePathIsNull_ResultIsFalse()
        {
            // Arrange
            string content = "Some Content";
            string filePath = null;

            // Act
            bool result = this.filesystemAccessor.WriteContentToFile(content, filePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void WriteContentToFile_FilePathIsEmpty_ResultIsFalse()
        {
            // Arrange
            string content = "Some Content";
            string filePath = string.Empty;

            // Act
            bool result = this.filesystemAccessor.WriteContentToFile(content, filePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void WriteContentToFile_FilePathIsWhitespace_ResultIsFalse()
        {
            // Arrange
            string content = "Some Content";
            string filePath = " ";

            // Act
            bool result = this.filesystemAccessor.WriteContentToFile(content, filePath);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void WriteContentToFile_TargetFileExistAndIsBeingRead_ResultIsFalse()
        {
            // Arrange
            string content = "Some Content";
            string filePath = this.CreateFile("Target-File.txt").FullName;
            var streamReader = new StreamReader(filePath);

            // Act
            bool result = this.filesystemAccessor.WriteContentToFile(content, filePath);

            // Assert
            Assert.IsFalse(result);
            streamReader.Close();
        }

        [Test]
        public void WriteContentToFile_TargetFileExistAndIsWrittenTo_ResultIsFalse()
        {
            // Arrange
            string content = "Some Content";
            string filePath = this.CreateFile("Target-File.txt").FullName;
            var streamWriter = new StreamWriter(filePath);

            // Act
            bool result = this.filesystemAccessor.WriteContentToFile(content, filePath);

            // Assert
            Assert.IsFalse(result);
            streamWriter.Close();
        }

        [Test]
        public void WriteContentToFile_TargetFileExist_ResultIsTrue_FileContainsSuppliedContent()
        {
            // Arrange
            string content = "Some Content";
            string filePath = this.CreateFile("Target-File.txt").FullName;
            string previousFileContent = this.GetFileContent(filePath);

            // Act
            bool result = this.filesystemAccessor.WriteContentToFile(content, filePath);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(content, this.GetFileContent(filePath));
            Assert.AreNotEqual(previousFileContent, this.GetFileContent(filePath));
        }

        [Test]
        public void WriteContentToFile_ContentIsNotNull_FilePathIsValidAndDoesNotExist_ResultIsTrue_FileContainsSuppliedContent()
        {
            // Arrange
            string content = "Some Content";
            string filePath = this.GetPath("Target-File.txt");

            // Act
            bool result = this.filesystemAccessor.WriteContentToFile(content, filePath);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(content, this.GetFileContent(filePath));
        }

        #endregion

        #region utility methods

        private string GetFileContent(string filePath)
        {
            return File.ReadAllText(filePath, this.encodingProvider.GetEncoding());
        }

        private string GetPath(string relativeFilePath)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, SampleFileFolder, relativeFilePath);
            return filePath;
        }

        private FileInfo CreateFile(string relativeFilePath)
        {
            string filePath = this.GetPath(relativeFilePath);
            File.WriteAllText(filePath, Guid.NewGuid().ToString());
            var fileInfo = new FileInfo(filePath);
            return fileInfo;
        }

        private DirectoryInfo CreateDirectory(string relativeDirectoryPath)
        {
            string directoryPath = this.GetPath(relativeDirectoryPath);
            Directory.CreateDirectory(directoryPath);

            var directoryInfo = new DirectoryInfo(directoryPath);
            return directoryInfo;
        }

        #endregion
    }
}
