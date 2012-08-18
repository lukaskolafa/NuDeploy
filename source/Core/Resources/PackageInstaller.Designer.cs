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
    internal class PackageInstaller {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PackageInstaller() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NuDeploy.Core.Resources.PackageInstaller", typeof(PackageInstaller).Assembly);
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
        ///   Looks up a localized string similar to The installation of the package &quot;{0}&quot; failed because the configuration files have not been transformed successfully..
        /// </summary>
        internal static string ConfigurationFileTransformationFailedMessageTemplate {
            get {
                return ResourceManager.GetString("ConfigurationFileTransformationFailedMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Deleting package folder &quot;{0}&quot;..
        /// </summary>
        internal static string DeletingPackageFolderMessageTemplate {
            get {
                return ResourceManager.GetString("DeletingPackageFolderMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Downloading package &quot;{0}&quot; (Version: {1}) to folder &quot;{2}&quot;..
        /// </summary>
        internal static string DownloadingPackageMessageTemplate {
            get {
                return ResourceManager.GetString("DownloadingPackageMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Executing the uninstall script &quot;{0}&quot; failed..
        /// </summary>
        internal static string ExecutingUninstallScriptFailedMessageTemplate {
            get {
                return ResourceManager.GetString("ExecutingUninstallScriptFailedMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Executing uninstall script &quot;{0}&quot;..
        /// </summary>
        internal static string ExecutingUninstallScriptMessageTemplate {
            get {
                return ResourceManager.GetString("ExecutingUninstallScriptMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Installation finished..
        /// </summary>
        internal static string InstallationFinishedMessage {
            get {
                return ResourceManager.GetString("InstallationFinishedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An installation/update of the package &quot;{0}&quot; is not required..
        /// </summary>
        internal static string InstallationIsNotRequiredMessageTemplate {
            get {
                return ResourceManager.GetString("InstallationIsNotRequiredMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The installation script &quot;{0}&quot; has not been executed successfully..
        /// </summary>
        internal static string InstallationScriptExecutionFailedMessageTemplate {
            get {
                return ResourceManager.GetString("InstallationScriptExecutionFailedMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Install script &quot;{0}&quot; not found for package &quot;{1} (Version {2})&quot; in folder &quot;{3}&quot;..
        /// </summary>
        internal static string InstallScriptNotFoundMessageTemplate {
            get {
                return ResourceManager.GetString("InstallScriptNotFoundMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You already have the latest version installed: {0} (Version: {1})..
        /// </summary>
        internal static string LatestVersionAlreadyInstalledMessageTemplate {
            get {
                return ResourceManager.GetString("LatestVersionAlreadyInstalledMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You already have a more recent version installed: {0} (Version: {1}). Use the -{2} option if you still want to install this older version..
        /// </summary>
        internal static string NewerVersionAlreadyInstalledMessageTemplate {
            get {
                return ResourceManager.GetString("NewerVersionAlreadyInstalledMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are no package repositories configured. Please check your package repository configuration..
        /// </summary>
        internal static string NoPackageRepositoryConfigurationsAvailable {
            get {
                return ResourceManager.GetString("NoPackageRepositoryConfigurationsAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The package &quot;{0}&quot; in version &quot;{1}&quot; could not be added the package configuration..
        /// </summary>
        internal static string PackageCouldNotBeAddedToConfigurationMessageTemplate {
            get {
                return ResourceManager.GetString("PackageCouldNotBeAddedToConfigurationMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Package &quot;{0}&quot; (Version: {1}) has been downloaded to folder &quot;{2}&quot;..
        /// </summary>
        internal static string PackageDownloadedMessageTemplate {
            get {
                return ResourceManager.GetString("PackageDownloadedMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not extract the package &quot;{0}&quot; to folder &quot;{1}&quot;..
        /// </summary>
        internal static string PackageExtractionFailedMessageTemplate {
            get {
                return ResourceManager.GetString("PackageExtractionFailedMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Package &quot;{0}&quot; in version &quot;{1}&quot; has been installed successfully..
        /// </summary>
        internal static string PackageHasBeenSuccessfullyInstalledMessageTemplate {
            get {
                return ResourceManager.GetString("PackageHasBeenSuccessfullyInstalledMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Package &quot;{0}&quot; is not installed in the current folder..
        /// </summary>
        internal static string PackageIsNotInstalledMessageTemplate {
            get {
                return ResourceManager.GetString("PackageIsNotInstalledMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Package &quot;{0}&quot; was not found at &quot;{1}&quot;. Please check your spelling or your package source configuration..
        /// </summary>
        internal static string PackageNotFoundMessageTemplate {
            get {
                return ResourceManager.GetString("PackageNotFoundMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The removal of the the previous version of &quot;{0}&quot; failed..
        /// </summary>
        internal static string PackageRemovalFailedMessageTemplate {
            get {
                return ResourceManager.GetString("PackageRemovalFailedMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;{0}&quot; has been successfully removed..
        /// </summary>
        internal static string PackageSuccessfullyRemovedMessageTemplate {
            get {
                return ResourceManager.GetString("PackageSuccessfullyRemovedMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing package &quot;{0}&quot; Version({1}) from the package configuration..
        /// </summary>
        internal static string RemovingPackageFromConfigurationMessageTemplate {
            get {
                return ResourceManager.GetString("RemovingPackageFromConfigurationMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Starting installation of package &quot;{0}&quot; (Version: {1})..
        /// </summary>
        internal static string StartingInstallationMessageTemplate {
            get {
                return ResourceManager.GetString("StartingInstallationMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Uninstalling package &quot;{0} (Version {1})&quot;..
        /// </summary>
        internal static string StartingUninstallMessageTemplate {
            get {
                return ResourceManager.GetString("StartingUninstallMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The installation of the package &quot;{0}&quot; failed because the system settings have not been transformed successfully..
        /// </summary>
        internal static string SystemSettingTransformationFailedMessageTemplate {
            get {
                return ResourceManager.GetString("SystemSettingTransformationFailedMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Uninstall script &quot;{0}&quot; not found for package &quot;{1} (Version {2})&quot; in folder &quot;{3}&quot;..
        /// </summary>
        internal static string UninstallScriptNotFoundMessageTemplate {
            get {
                return ResourceManager.GetString("UninstallScriptNotFoundMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Package &quot;{0}&quot; (Version: {1}) has been successfully removed..
        /// </summary>
        internal static string UninstallSucceededMessageTemplate {
            get {
                return ResourceManager.GetString("UninstallSucceededMessageTemplate", resourceCulture);
            }
        }
    }
}
