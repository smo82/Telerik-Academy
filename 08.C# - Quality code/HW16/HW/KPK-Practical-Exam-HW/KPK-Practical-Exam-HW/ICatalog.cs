namespace FreeContent
{
    using System.Collections.Generic;

    /// <summary>
    /// Indentifies the properies and methods that should be present in the Calatog implementation classes
    /// </summary>
    public interface ICatalog
    {
        /// <summary>
        /// Adds a new Content item in the catalog
        /// </summary>
        /// <param name="content">The content item to be added</param>
        void Add(IContent content);

        /// <summary>
        /// Gets a collection of items of the catalog that have a specific title.
        /// The maximal number of results is determined by the "numberOfElements" parameter.
        /// If the number of results is less then the value of the "numberOfElements" parameter, then the method returns
        /// all the results it has found.
        /// </summary>
        /// <param name="title">The title of the search items</param>
        /// <param name="numberOfElements">The maximal number of results to be returned by the method</param>
        /// <returns>Returns a collection of items that have a specific title</returns>
        IEnumerable<IContent> GetListContent(string title, int numberOfElements);

        /// <summary>
        /// Replaces for all items a specific URL with a new URL
        /// </summary>
        /// <param name="oldUrl">The URL that needs to be replaced</param>
        /// <param name="newUrl">The new URL to be set</param>
        /// <returns>Returns the number of updated elements</returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}
