using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Attributes;
using SmartStore.Web.Framework;
using SmartStore.Web.Framework.Modelling;

namespace SmartStore.Admin.Models.News
{
    [Validator(typeof(NewsItemValidator))]
    public class NewsItemModel : TabbableModel, IStoreSelector
    {
        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Language")]
        public int LanguageId { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Language")]
        [AllowHtml]
        public string LanguageName { get; set; }

		// Store mapping
		[SmartResourceDisplayName("Admin.Common.Store.LimitedTo")]
		public bool LimitedToStores { get; set; }
		public IEnumerable<SelectListItem> AvailableStores { get; set; }
		public int[] SelectedStoreIds { get; set; }


		[SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Title")]
        [AllowHtml]
        public string Title { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.SeName")]
        [AllowHtml]
        public string SeName { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Short")]
        [AllowHtml]
        public string Short { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Full")]
        [AllowHtml]
        public string Full { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.AllowComments")]
        public bool AllowComments { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.StartDate")]
        public DateTime? StartDate { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.EndDate")]
        public DateTime? EndDate { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.MetaKeywords")]
        [AllowHtml]
        public string MetaKeywords { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.MetaDescription")]
        [AllowHtml]
        public string MetaDescription { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.MetaTitle")]
        [AllowHtml]
        public string MetaTitle { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Published")]
        public bool Published { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.News.NewsItems.Fields.Comments")]
        public int Comments { get; set; }

        [SmartResourceDisplayName("Common.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [UIHint("Picture")]
        [SmartResourceDisplayName("Admin.Catalog.Categories.Fields.Picture")]
        public int? PictureId { get; set; }


        #region Nested classes

        public class NewsProductModel : EntityModelBase
        {
            public int NewsId { get; set; }

            public int ProductId { get; set; }

            [SmartResourceDisplayName("Admin.Catalog.Categories.Products.Fields.Product")]
            public string ProductName { get; set; }

            [SmartResourceDisplayName("Admin.Catalog.Products.Fields.Sku")]
            public string Sku { get; set; }

            [SmartResourceDisplayName("Admin.Catalog.Products.Fields.ProductType")]
            public string ProductTypeName { get; set; }
            public string ProductTypeLabelHint { get; set; }

            [SmartResourceDisplayName("Admin.Catalog.Products.Fields.Published")]
            public bool Published { get; set; }

            [SmartResourceDisplayName("Common.DisplayOrder")]
            //we don't name it DisplayOrder because Telerik has a small bug 
            //"if we have one more editor with the same name on a page, it doesn't allow editing"
            //in our case it's category.DisplayOrder
            public int DisplayOrder1 { get; set; }
        }

        #endregion
    }

    public partial class NewsItemValidator : AbstractValidator<NewsItemModel>
    {
        public NewsItemValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Short).NotEmpty();
            RuleFor(x => x.Full).NotEmpty();
        }
    }
}