//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
    // with the /str option or rebuild the Visual Studio project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "14.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ExchangeRates {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExchangeRates() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.ExchangeRates", global::System.Reflection.Assembly.Load("App_GlobalResources"));
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
        ///   Looks up a localized string similar to Get exchange rates.
        /// </summary>
        internal static string Btn_GetExchangeRates {
            get {
                return ResourceManager.GetString("Btn_GetExchangeRates", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error when retrieving data. Please try again later..
        /// </summary>
        internal static string Err_DataLoading {
            get {
                return ResourceManager.GetString("Err_DataLoading", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please input a date between {0} and {1}.
        /// </summary>
        internal static string Err_WrongDateInput {
            get {
                return ResourceManager.GetString("Err_WrongDateInput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exchange rates of Litas to foreign currencies difference.
        /// </summary>
        internal static string Hdr_ExchangeRatesDifference {
            get {
                return ResourceManager.GetString("Hdr_ExchangeRatesDifference", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Choose a date. The exchange rate difference of the chosen day and the day before will be displayed..
        /// </summary>
        internal static string Hdr_ExchangeRatesDifferenceGuideline {
            get {
                return ResourceManager.GetString("Hdr_ExchangeRatesDifferenceGuideline", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Choose the date:.
        /// </summary>
        internal static string Lbl_ChooseDate {
            get {
                return ResourceManager.GetString("Lbl_ChooseDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Currency.
        /// </summary>
        internal static string Tbl_Heading_Currency {
            get {
                return ResourceManager.GetString("Tbl_Heading_Currency", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exchange rate difference.
        /// </summary>
        internal static string Tbl_Heading_RateDifference {
            get {
                return ResourceManager.GetString("Tbl_Heading_RateDifference", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No exchange rate differences found for the provided date..
        /// </summary>
        internal static string Txt_NoResultFound {
            get {
                return ResourceManager.GetString("Txt_NoResultFound", resourceCulture);
            }
        }
    }
}
