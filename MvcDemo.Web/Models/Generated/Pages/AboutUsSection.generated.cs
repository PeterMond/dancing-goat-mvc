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

using CMS;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine.Types;
using CMS.DocumentEngine;

[assembly: RegisterDocumentType(AboutUsSection.CLASS_NAME, typeof(AboutUsSection))]

namespace CMS.DocumentEngine.Types 
{
    /// <summary>
    /// Sample item class.
    /// </summary>
    public partial class AboutUsSection : TreeNode
    {
        #region "Constants"

        /// <summary>
        /// Class name of the item.
        /// </summary>
        public const string CLASS_NAME = "TestMvcDemo.AboutUsSection";

        #endregion


        #region "Properties"

        /// <summary>
        /// TestMvcDemoAboutUsSectionID.
        /// </summary>
        [DatabaseField]
        public int TestMvcDemoAboutUsSectionID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("TestMvcDemoAboutUsSectionID"), 0);
            }
            set
            {
                SetValue("TestMvcDemoAboutUsSectionID", value);
            }
        }


        /// <summary>
        /// Heading.
        /// </summary>
        [DatabaseField]
        public string AboutUsSectionHeading
        {
            get
            {
                return ValidationHelper.GetString(GetValue("AboutUsSectionHeading"), "");
            }
            set
            {
                SetValue("AboutUsSectionHeading", value);
            }
        }


        /// <summary>
        /// Image.
        /// </summary>
        [DatabaseField]
        public Guid AboutUsSectionImage
        {
            get
            {
                return ValidationHelper.GetGuid(GetValue("AboutUsSectionImage"), Guid.Empty);
            }
            set
            {
                SetValue("AboutUsSectionImage", value);
            }
        }


        /// <summary>
        /// Text.
        /// </summary>
        [DatabaseField]
        public string AboutUsSectionText
        {
            get
            {
                return ValidationHelper.GetString(GetValue("AboutUsSectionText"), "");
            }
            set
            {
                SetValue("AboutUsSectionText", value);
            }
        }

        #endregion


        #region "Constructors"

        /// <summary>
        /// Constructor.
        /// </summary>
        public AboutUsSection()
            : base(CLASS_NAME)
        {
        }

        #endregion
    }
}