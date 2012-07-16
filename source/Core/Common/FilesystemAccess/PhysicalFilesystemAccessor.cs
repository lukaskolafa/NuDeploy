using System;
using System.IO;

using NuDeploy.Core.Common.FileEncoding;

namespace NuDeploy.Core.Common.FilesystemAccess
{
    public class PhysicalFilesystemAccessor : IFilesystemAccessor
    {
        private readonly IEncodingProvider encodingProvider;

        public PhysicalFilesystemAccessor(IEncodingProvider encodingProvider)
        {
            this.encodingProvider = encodingProvider;
        }

        #region file access

        public bool FileExists(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return false;
            }

            return File.Exists(filePath);
        }

        public bool MoveFile(string sourceFilePath, string targetFilePath)
        {
            if (string.IsNullOrWhiteSpace(targetFilePath))
            {
                return false;
            }

            if (!this.FileExists(sourceFilePath))
            {
                return false;
            }

            if (this.FileExists(targetFilePath))
            {
                this.DeleteFile(targetFilePath);
            }

            try
            {
                File.Move(sourceFilePath, targetFilePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return false;
            }

            if (!this.FileExists(filePath))
            {
                return false;
            }

            try
            {
                File.Delete(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetFileContent(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return null;
            }

            if (!this.FileExists(filePath))
            {
                return null;
            }

            try
            {
                return File.ReadAllText(filePath, this.encodingProvider.GetEncoding());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TextReader GetTextReader(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return null;
            }

            if (!this.FileExists(filePath))
            {
                return null;
            }

            try
            {
                TextReader textReader = new StreamReader(File.OpenRead(filePath), this.encodingProvider.GetEncoding());
                return textReader;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TextWriter GetTextWriter(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return null;
            }

            try
            {
                TextWriter textWriter = new StreamWriter(File.OpenWrite(filePath), this.encodingProvider.GetEncoding());
                return textWriter;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Stream GetNewFileStream(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return null;
            }

            try
            {
                this.EnsureParentDirectoryExists(filePath);
                return File.Create(filePath);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool WriteContentToFile(string content, string filePath)
        {
            if (content == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(filePath))
            {
                return false;
            }

            try
            {
                File.WriteAllText(filePath, content, this.encodingProvider.GetEncoding());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CopyFile(string sourceFilePath, string targetPath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(targetPath))
            {
                return false;
            }

            if (!this.FileExists(sourceFilePath))
            {
                return false;
            }

            try
            {
                if (!this.EnsureParentDirectoryExists(targetPath))
                {
                    return false;
                }

                File.Copy(sourceFilePath, targetPath, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region directory access

        public bool DirectoryExists(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                return false;
            }

            return Directory.Exists(directoryPath);
        }

        public bool DeleteDirectory(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                return false;
            }

            if (!this.DirectoryExists(folderPath))
            {
                return false;
            }

            try
            {
                Directory.Delete(folderPath, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            if (this.DirectoryExists(path))
            {
                return false;
            }

            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EnsureParentDirectoryExists(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return false;
            }

            try
            {
                string parentDirectory = Directory.GetParent(filePath).FullName;
                if (!this.DirectoryExists(parentDirectory))
                {
                    if (!this.CreateDirectory(parentDirectory))
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}