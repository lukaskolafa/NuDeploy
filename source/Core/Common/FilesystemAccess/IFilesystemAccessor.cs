using System.IO;

namespace NuDeploy.Core.Common.FilesystemAccess
{
    public interface IFilesystemAccessor
    {
        #region file access

        bool FileExists(string filePath);

        bool DirectoryExists(string directoryPath);

        bool MoveFile(string sourceFilePath, string targetFilePath);

        bool DeleteFile(string filePath);

        string GetFileContent(string filePath);

        TextReader GetTextReader(string filePath);

        TextWriter GetTextWriter(string filePath);

        Stream GetNewFileStream(string filePath);

        bool WriteContentToFile(string content, string filePath);

        bool CopyFile(string sourceFilePath, string targetPath);

        #endregion

        #region directory access

        bool DeleteFolder(string folderPath);

        bool CreateDirectory(string path);

        bool EnsurePathExists(string path);

        #endregion
    }
}
