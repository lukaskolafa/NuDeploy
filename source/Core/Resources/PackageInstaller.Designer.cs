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
        ///   Looks up a localized string similar to Adding package &quot;{0}&quot; Version({1}) to the package configuration..
        /// </summary>
        internal static string AddingPackageToConfigurationMessageTemplate {
            get {
                return ResourceManager.GetString("AddingPackageToConfigurationMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Applying transformations to the system settings of your deployment package using the &quot;{0}&quot; profile..
        /// </summary>
        internal static string ApplyingSystemSettingsTransformationProfileMessageTemplate {
            get {
                return ResourceManager.GetString("ApplyingSystemSettingsTransformationProfileMessageTemplate", resourceCulture);
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
        ///   Looks up a localized string similar to Executing install script &quot;{0}&quot; with parameter &quot;{1}&quot;..
        /// </summary>
        internal static string ExecutingInstallScriptMessageTemplate {
            get {
                return ResourceManager.GetString("ExecutingInstallScriptMessageTemplate", resourceCulture);
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
        ///   Looks up a localized string similar to Package &quot;{0}&quot; (Version: {1}) has been downloaded to folder &quot;{2}&quot;..
        /// </summary>
        internal static string PackageDownloadedMessageTemplate {
            get {
                return ResourceManager.GetString("PackageDownloadedMessageTemplate", resourceCulture);
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
        ///   Looks up a localized string similar to Please make sure the package has been removed properly before installing a new version or use the -{0} option if you still want to install the new version..
        /// </summary>
        internal static string PackageRemovalFailedForceHintMessageTemplate {
            get {
                return ResourceManager.GetString("PackageRemovalFailedForceHintMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The removal of the the previous version of {0} (Version: {1}) failed..
        /// </summary>
        internal static string PackageRemovalFailedMessageTemplate {
            get {
                return ResourceManager.GetString("PackageRemovalFailedMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} (Version: {1}) has been successfully removed..
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
        ///   Looks up a localized string similar to Removing previous version of {0} from folder {1}..
        /// </summary>
        internal static string RemovingPreviousVersionMessageTemplate {
            get {
                return ResourceManager.GetString("RemovingPreviousVersionMessageTemplate", resourceCulture);
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
        ///   Looks up a localized string similar to Starting the package installation..
        /// </summary>
        internal static string StartingInstallationPowerShellScriptExecutionMessageTemplate {
            get {
                return ResourceManager.GetString("StartingInstallationPowerShellScriptExecutionMessageTemplate", resourceCulture);
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
        ///   Looks up a localized string similar to Uninstall script &quot;{0}&quot; not found for package &quot;{1} (Version {2})&quot; in folder &quot;{3}&quot;..
        /// </summary>
        internal static string UninstallScriptNotFoundMessageTemplate {
            get {
                return ResourceManager.GetString("UninstallScriptNotFoundMessageTemplate", resourceCulture);
            }
        }
    }
}
