﻿using System.Collections.Generic;

using CMS.DocumentEngine.Types;

namespace MvcDemo.Web.Repositories
{
    /// <summary>
    /// Represents a contract for a collection of links to social networks.
    /// </summary>
    public abstract class SocialLinkRepository
    {
        /// <summary>
        /// Returns an enumerable collection of links to social networks ordered by a position in the content tree.
        /// </summary>
        /// <returns>An enumerable collection of links to social networks ordered by a position in the content tree.</returns>
        public abstract IEnumerable<SocialLink> GetSocialLinks();
    }
}