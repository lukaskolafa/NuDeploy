﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuDeploy.CommandLine.Resources {
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
    internal class CleanupCommand {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CleanupCommand() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NuDeploy.CommandLine.Resources.CleanupCommand", typeof(CleanupCommand).Assembly);
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
        ///   Looks up a localized string similar to The id of the NuGet package to install (e.g. &quot;NuDeploy.CommandLine&quot;). If you don&apos;t specifiy a package id, the cleanup will be performed for all packages in the current folder..
        /// </summary>
        internal static string ArgumentDescriptionNugetPackageId {
            get {
                return ResourceManager.GetString("ArgumentDescriptionNugetPackageId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removes previously installed versions of a specific package or for all packages in the current folder..
        /// </summary>
        internal static string CommandDescriptionText {
            get {
                return ResourceManager.GetString("CommandDescriptionText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove all package folders of all NuGet packages which are currently not installed..
        /// </summary>
        internal static string CommandExampleDescription1 {
            get {
                return ResourceManager.GetString("CommandExampleDescription1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove all package folders which are not the currently installed version of the given NuGet package id..
        /// </summary>
        internal static string CommandExampleDescription2 {
            get {
                return ResourceManager.GetString("CommandExampleDescription2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cleanup failed..
        /// </summary>
        internal static string GeneralCleanupFailed {
            get {
                return ResourceManager.GetString("GeneralCleanupFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cleanup succeeded..
        /// </summary>
        internal static string GeneralCleanupSucceeded {
            get {
                return ResourceManager.GetString("GeneralCleanupSucceeded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cleanup for package &quot;{0}&quot; failed..
        /// </summary>
        internal static string PackageCleanupFailedMessageTemplate {
            get {
                return ResourceManager.GetString("PackageCleanupFailedMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cleanup for package &quot;{0}&quot; succeeded..
        /// </summary>
        internal static string PackageCleanupSucceededMessageTemplate {
            get {
                return ResourceManager.GetString("PackageCleanupSucceededMessageTemplate", resourceCulture);
            }
        }
    }
}
