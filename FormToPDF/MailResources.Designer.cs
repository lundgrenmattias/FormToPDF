﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FormToPDF {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MailResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MailResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FormToPDF.MailResources", typeof(MailResources).Assembly);
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
        ///   Looks up a localized string similar to Hello {0},
        /// 
        ///Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc maximus ac nulla non vehicula. Maecenas fringilla finibus magna, sollicitudin bibendum nisl consectetur vitae..
        /// </summary>
        public static string BodyTemplate {
            get {
                return ResourceManager.GetString("BodyTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Something went wrong when we calculated your premium. Please contact support..
        /// </summary>
        public static string CannotCalculatePremiumComment {
            get {
                return ResourceManager.GetString("CannotCalculatePremiumComment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Copy..
        /// </summary>
        public static string EmailCopyPrefix {
            get {
                return ResourceManager.GetString("EmailCopyPrefix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RFQ-FormToPDF.
        /// </summary>
        public static string EmptyCompanyNameFilename {
            get {
                return ResourceManager.GetString("EmptyCompanyNameFilename", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Something went wrong when we calculated your premium. Please contact support..
        /// </summary>
        public static string NotApplicableCompanySizeComment {
            get {
                return ResourceManager.GetString("NotApplicableCompanySizeComment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RFQ.
        /// </summary>
        public static string ProposalPrefix {
            get {
                return ResourceManager.GetString("ProposalPrefix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FormToPDF.
        /// </summary>
        public static string SenderName {
            get {
                return ResourceManager.GetString("SenderName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RFQ from Form To PDF.
        /// </summary>
        public static string Subject {
            get {
                return ResourceManager.GetString("Subject", resourceCulture);
            }
        }
    }
}
