using System;
using System.IO;
using System.Xml;

using Microsoft.Web.Publishing.Tasks;

using NuDeploy.Core.Common;

namespace NuDeploy.Core.Services
{
    public class ConfigurationFileTransformer : IConfigurationFileTransformer
    {
        private readonly IUserInterface userInterface;

        public ConfigurationFileTransformer(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }

        public bool Transform(string sourceFilePath, string transformationFilePath, string destinationFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath))
            {
                this.userInterface.WriteLine(
                    string.Format(Resources.ConfigurationFileTransformer.SourceFilePathCannotBeNullOrEmptyMessageTemplate, transformationFilePath));

                return false;
            }

            if (string.IsNullOrWhiteSpace(transformationFilePath))
            {
                this.userInterface.WriteLine(
                    string.Format(Resources.ConfigurationFileTransformer.TransformationFilePathCannotBeNullOrEmptyMessageTemplate, transformationFilePath));

                return false;
            }

            if (string.IsNullOrWhiteSpace(destinationFilePath))
            {
                this.userInterface.WriteLine(
                    string.Format(Resources.ConfigurationFileTransformer.DestinationFilePathCannotBeNullOrEmptyMessageTemplate, destinationFilePath));

                return false;
            }

            if (!File.Exists(sourceFilePath))
            {
                this.userInterface.WriteLine(string.Format(Resources.ConfigurationFileTransformer.SourceFilePathDoesNotExistMessageTemplate, sourceFilePath));
                return false;
            }

            if (!File.Exists(transformationFilePath))
            {
                this.userInterface.WriteLine(
                    string.Format(Resources.ConfigurationFileTransformer.TransformationFilePathDoesNotExistMessageTemplate, transformationFilePath));

                return false;
            }

            this.userInterface.WriteLine(
                string.Format(
                    Resources.ConfigurationFileTransformer.TransformationStartMessageTemplate,
                    sourceFilePath,
                    transformationFilePath,
                    destinationFilePath));

            XmlTransformableDocument transformableDocument = this.GetSourceFile(sourceFilePath);

            bool transformationWasSuccessfull = this.GetTransformationFile(transformationFilePath).Apply(transformableDocument);
            if (transformationWasSuccessfull)
            {
                if (this.SaveTransformedFile(transformableDocument, destinationFilePath))
                {
                    this.userInterface.WriteLine(
                        string.Format(
                            Resources.ConfigurationFileTransformer.TransformationSuccessMessageTemplate,
                            sourceFilePath,
                            transformationFilePath,
                            destinationFilePath));

                    return true;
                }
            }

            this.userInterface.WriteLine(Resources.ConfigurationFileTransformer.TransformationFailedMessage);
            return false;
        }

        private XmlTransformableDocument GetSourceFile(string filePath)
        {
            try
            {
                var transformableDocument = new XmlTransformableDocument { PreserveWhitespace = true };
                transformableDocument.Load(filePath);
                return transformableDocument;
            }
            catch (XmlException xmlException)
            {
                this.userInterface.WriteLine(
                    string.Format(
                        Resources.ConfigurationFileTransformer.GetSourceFileXmlExceptionMessageTemplate,
                        filePath,
                        xmlException));
            }
            catch (Exception generalException)
            {
                this.userInterface.WriteLine(
                    string.Format(
                        Resources.ConfigurationFileTransformer.GetSourceFileGeneralExceptionMessageTemplate,
                        filePath,
                        generalException));
            }

            return null;
        }

        private XmlTransformation GetTransformationFile(string filePath)
        {
            try
            {
                return new XmlTransformation(filePath);
            }
            catch (XmlException xmlException)
            {
                this.userInterface.WriteLine(
                    string.Format(
                        Resources.ConfigurationFileTransformer.GetTransformationFileXmlExceptionMessageTemplate,
                        filePath,
                        xmlException));
            }
            catch (Exception generalException)
            {
                this.userInterface.WriteLine(
                    string.Format(
                        Resources.ConfigurationFileTransformer.GetTransformationFileGeneralExceptionMessageTemplate,
                        filePath,
                        generalException));
            }

            return null;
        }

        private bool SaveTransformedFile(XmlTransformableDocument transformedDocument, string destinationFilePath)
        {
            if (transformedDocument == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(destinationFilePath))
            {
                return false;
            }

            try
            {
                if (File.Exists(destinationFilePath))
                {
                    this.userInterface.WriteLine(string.Format(Resources.ConfigurationFileTransformer.DestinationFileAlreadyExistsMessageTemplate, destinationFilePath));
                    File.Delete(destinationFilePath);
                }

                transformedDocument.Save(destinationFilePath);
                return true;
            }
            catch (XmlException xmlException)
            {
                this.userInterface.WriteLine(
                    string.Format(
                        Resources.ConfigurationFileTransformer.SaveTransformedFileXmlExceptionMessageTemplate,
                        destinationFilePath,
                        xmlException));
            }
            catch (Exception generalException)
            {
                this.userInterface.WriteLine(
                    string.Format(
                        Resources.ConfigurationFileTransformer.SaveTransformedFileGeneralExceptionMessageTemplate,
                        destinationFilePath,
                        generalException));
            }

            return false;
        }
    }
}