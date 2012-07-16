﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuDeploy.Core.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ConfigurationFileTransformer {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ConfigurationFileTransformer() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NuDeploy.Core.Resources.ConfigurationFileTransformer", typeof(ConfigurationFileTransformer).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified destination file &quot;{0}&quot; for the configuration file transformation does already exist. Please note that the file will be overidden..
        /// </summary>
        internal static string DestinationFileAlreadyExistsMessageTemplate {
            get {
                return ResourceManager.GetString("DestinationFileAlreadyExistsMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified destination file path &quot;{0}&quot; for the configuration file transformation cannot be null or empty..
        /// </summary>
        internal static string DestinationFilePathCannotBeNullOrEmptyMessageTemplate {
            get {
                return ResourceManager.GetString("DestinationFilePathCannotBeNullOrEmptyMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Opening the the source file &quot;{0}&quot; for the configuration file transformation failed with the following exception: {1}.
        /// </summary>
        internal static string GetSourceFileGeneralExceptionMessageTemplate {
            get {
                return ResourceManager.GetString("GetSourceFileGeneralExceptionMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not load the source file &quot;{0}&quot; for the configuration file transformation because the file contains invalid XML: {1}.
        /// </summary>
        internal static string GetSourceFileXmlExceptionMessageTemplate {
            get {
                return ResourceManager.GetString("GetSourceFileXmlExceptionMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Opening the the transformation file &quot;{0}&quot; for the configuration file transformation failed with the following exception: {1}.
        /// </summary>
        internal static string GetTransformationFileGeneralExceptionMessageTemplate {
            get {
                return ResourceManager.GetString("GetTransformationFileGeneralExceptionMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not load the transformation file &quot;{0}&quot; for the configuration file transformation because the file contains invalid XML: {1}.
        /// </summary>
        internal static string GetTransformationFileXmlExceptionMessageTemplate {
            get {
                return ResourceManager.GetString("GetTransformationFileXmlExceptionMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Saving the transformed configuration file to the specified path &quot;{0}&quot; failed with the following exception: {1}.
        /// </summary>
        internal static string SaveTransformedFileGeneralExceptionMessageTemplate {
            get {
                return ResourceManager.GetString("SaveTransformedFileGeneralExceptionMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not save the transformed configuration file to the specified path &quot;{0}&quot; because the file contains invalid XML: {1}.
        /// </summary>
        internal static string SaveTransformedFileXmlExceptionMessageTemplate {
            get {
                return ResourceManager.GetString("SaveTransformedFileXmlExceptionMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified source file path &quot;{0}&quot; for the configuration file transformation cannot be null or empty..
        /// </summary>
        internal static string SourceFilePathCannotBeNullOrEmptyMessageTemplate {
            get {
                return ResourceManager.GetString("SourceFilePathCannotBeNullOrEmptyMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified source file &quot;{0}&quot; for the configuration file transformation was not found..
        /// </summary>
        internal static string SourceFilePathDoesNotExistMessageTemplate {
            get {
                return ResourceManager.GetString("SourceFilePathDoesNotExistMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occurred during the XML transformation (Source: {0}, Tranformation: {1}, Destination: {2}). {3}.
        /// </summary>
        internal static string TransformationExceptionMessageTemplate {
            get {
                return ResourceManager.GetString("TransformationExceptionMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transformation failed because the source file &quot;{0}&quot; could not be read..
        /// </summary>
        internal static string TransformationFailedBecauseSourceFileCouldNotBeReadMessageTemplate {
            get {
                return ResourceManager.GetString("TransformationFailedBecauseSourceFileCouldNotBeReadMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transformation failed because the transformation file &quot;{0}&quot; could not be read..
        /// </summary>
        internal static string TransformationFailedBecauseTransformationFileCouldNotBeReadMessageTemplate {
            get {
                return ResourceManager.GetString("TransformationFailedBecauseTransformationFileCouldNotBeReadMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The configuration file transformation failed..
        /// </summary>
        internal static string TransformationFailedMessage {
            get {
                return ResourceManager.GetString("TransformationFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified transformation file path &quot;{0}&quot; for the configuration file transformation cannot be null or empty..
        /// </summary>
        internal static string TransformationFilePathCannotBeNullOrEmptyMessageTemplate {
            get {
                return ResourceManager.GetString("TransformationFilePathCannotBeNullOrEmptyMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified transformation file &quot;{0}&quot; for the configuration file transformation was not found..
        /// </summary>
        internal static string TransformationFilePathDoesNotExistMessageTemplate {
            get {
                return ResourceManager.GetString("TransformationFilePathDoesNotExistMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Starting the transformation of the specified configuration file &quot;{0}&quot; with the transformation file &quot;{1}&quot; into the new file &quot;{2}&quot;..
        /// </summary>
        internal static string TransformationStartMessageTemplate {
            get {
                return ResourceManager.GetString("TransformationStartMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The configuration file has been transformed successfully ({0} + {1} =&gt; {2})..
        /// </summary>
        internal static string TransformationSuccessMessageTemplate {
            get {
                return ResourceManager.GetString("TransformationSuccessMessageTemplate", resourceCulture);
            }
        }
    }
}
