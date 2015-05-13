//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at http://docs.kentico.com. 
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Data;

using CMS.Base;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.Helpers;

namespace CMS.DocumentEngine.Types
{
    /// <summary>
    /// Provider class for strongly-typed content items.
    /// </summary>
    public partial class AboutUsProvider
    {
        /// <summary>
        /// Returns all AboutUs objects.
        /// </summary>
        public static DocumentQuery<AboutUs> GetAboutUs()
        {
            return DocumentHelper.GetDocuments<AboutUs>();
        }


        /// <summary>
        /// Returns AboutUs object with specified ID.
        /// </summary>
        /// <param name="id">ID of the object</param>
        public static AboutUs GetAboutUs(int id)
        {
            return DocumentHelper.GetDocuments<AboutUs>().WithID(id).FirstObject;
        }


        /// <summary>
        /// Returns AboutUs object of a specified GUID.
        /// </summary>
        /// <param name="guid">Object GUID</param>
        public static AboutUs GetAboutUs(Guid guid)
        {
            return DocumentHelper.GetDocuments<AboutUs>().WithGuid(guid).FirstObject;
        }
    }
}