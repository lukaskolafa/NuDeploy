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
    internal class PublishingService {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PublishingService() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NuDeploy.Core.Resources.PublishingService", typeof(PublishingService).Assembly);
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
        ///   Looks up a localized string similar to Publishing failed because the the supplied package path &quot;{0}&quot; does not exist..
        /// </summary>
        internal static string ErrorPackagePathDoesNotExistMessageTemplate {
            get {
                return ResourceManager.GetString("ErrorPackagePathDoesNotExistMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Packaging failed because it was impossible to instantiate a package server for the location &quot;{0}&quot;..
        /// </summary>
        internal static string ErrorPackageServerCouldNotBeInstantiatedMessageTemplate {
            get {
                return ResourceManager.GetString("ErrorPackageServerCouldNotBeInstantiatedMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Packaging failed because the package &quot;{0}&quot; could not be opened for reading..
        /// </summary>
        internal static string ErrorPackageStreamCouldNotBeOpenedMessageTemplate {
            get {
                return ResourceManager.GetString("ErrorPackageStreamCouldNotBeOpenedMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Publishing failed because the publishing configuration &quot;{0}&quot; is invalid..
        /// </summary>
        internal static string ErrorPublishingConfigurationIsInvalidMessageTemplate {
            get {
                return ResourceManager.GetString("ErrorPublishingConfigurationIsInvalidMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Packaging failed because the the specified publishing configuration &quot;{0}&quot; was not found..
        /// </summary>
        internal static string ErrorPublishingConfigurationWasNotFoundMessageTemplate {
            get {
                return ResourceManager.GetString("ErrorPublishingConfigurationWasNotFoundMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Publishing the package &quot;{0}&quot; with the publish configuration &quot;{1}&quot; failed with an exception. Error details: {2}.
        /// </summary>
        internal static string FailureMessageTemplate {
            get {
                return ResourceManager.GetString("FailureMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The package &quot;{0}&quot; has been published successfully using the &quot;{1}&quot; publishing configuration..
        /// </summary>
        internal static string SuccessMessageTemplate {
            get {
                return ResourceManager.GetString("SuccessMessageTemplate", resourceCulture);
            }
        }
    }
}