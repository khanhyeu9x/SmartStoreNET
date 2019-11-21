using System;
using System.Linq;
using SmartStore.Core;
using SmartStore.Core.Domain.News;

namespace SmartStore.Services.News
{
    /// <summary>
    /// News service interface
    /// </summary>
    public partial interface INewsService
    {
        /// <summary>
        /// Deletes a news
        /// </summary>
        /// <param name="newsItem">News item</param>
        void DeleteNews(NewsItem newsItem);

        /// <summary>
        /// Gets a news
        /// </summary>
        /// <param name="newsId">The news identifier</param>
        /// <returns>News</returns>
        NewsItem GetNewsById(int newsId);

		/// <summary>
		/// Get news by identifiers
		/// </summary>
		/// <param name="newsIds">News identifiers</param>
		/// <returns>News query</returns>
		IQueryable<NewsItem> GetNewsByIds(int[] newsIds);

        /// <summary>
        /// Gets all news
        /// </summary>
        /// <param name="languageId">Language identifier; 0 if you want to get all records</param>
		/// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
		/// <param name="maxAge">The maximum age of returned news</param>
        /// <returns>News items</returns>
		IPagedList<NewsItem> GetAllNews(int languageId, int storeId, int pageIndex, int pageSize, bool showHidden = false, DateTime? maxAge = null);

        /// <summary>
        /// Inserts a news item
        /// </summary>
        /// <param name="news">News item</param>
        void InsertNews(NewsItem news);

        /// <summary>
        /// Updates the news item
        /// </summary>
        /// <param name="news">News item</param>
        void UpdateNews(NewsItem news);

        /// <summary>
        /// Update news item comment totals
        /// </summary>
        /// <param name="newsItem">News item</param>
        void UpdateCommentTotals(NewsItem newsItem);

        IPagedList<ProductNews> GetProductNewsByNewsId(int newsId, int page, int pageSize,
            bool showHidden = false);


        /// <summary>
        /// Gets a product category mapping 
        /// </summary>
        /// <param name="productNewsId">Product category mapping identifier</param>
        /// <returns>Product category mapping</returns>
        ProductNews GetProductNewsById(int productNewsId);


        /// <summary>
        /// Inserts a product category mapping
        /// </summary>
        /// <param name="productNews">>Product category mapping</param>
        void InsertProductNews(ProductNews productNews);

        /// <summary>
        /// Updates the product category mapping 
        /// </summary>
        /// <param name="productNews">>Product category mapping</param>
        void UpdateProductNews(ProductNews productNews);
        /// <summary>
        /// Deletes a product category mapping
        /// </summary>
        /// <param name="productNews">Product category</param>
        void DeleteProductCategory(ProductNews productNews);
    }
}
