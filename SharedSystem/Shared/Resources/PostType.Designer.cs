﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class PageUrls {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PageUrls() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.PageUrls", typeof(PageUrls).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /Products/Categories.
        /// </summary>
        public static string Categories {
            get {
                return ResourceManager.GetString("Categories", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /Products/Products/List.
        /// </summary>
        public static string ListProducts {
            get {
                return ResourceManager.GetString("ListProducts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /Products/Notification.
        /// </summary>
        public static string Notifications {
            get {
                return ResourceManager.GetString("Notifications", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /Products/Notification/Settings.
        /// </summary>
        public static string NotificationSettings {
            get {
                return ResourceManager.GetString("NotificationSettings", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /Products/NotificationType.
        /// </summary>
        public static string NotificationType {
            get {
                return ResourceManager.GetString("NotificationType", resourceCulture);
            }
        }
    }
}
