using FluentValidation;
using FluentValidation.Attributes;
using SmartStore.Web.Framework;
using SmartStore.Web.Framework.Modelling;
using SmartStore.Web.Models.Common;
using SmartStore.Web.Models.Media;
using System;

namespace SmartStore.Web.Models.News
{
    [Validator(typeof(NewsItemValidator))]
    public partial class NewsItemModel : EntityModelBase
    {
        public NewsItemModel()
        {
            PictureModel = new PictureModel();
            AddNewComment = new AddNewsCommentModel();
			Comments = new CommentListModel();
		}
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SeName { get; set; }
		public DateTime CreatedOn { get; set; }

		public string Title { get; set; }
        public string Short { get; set; }
        public string Full { get; set; }
        public PictureModel PictureModel { get; set; }

        public AddNewsCommentModel AddNewComment { get; set; }
		public CommentListModel Comments { get; set; }

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

    public class NewsItemValidator : AbstractValidator<NewsItemModel>
    {
        public NewsItemValidator()
        {
            RuleFor(x => x.AddNewComment.CommentTitle)
                .NotEmpty()
                .When(x => x.AddNewComment != null);

            RuleFor(x => x.AddNewComment.CommentTitle)
                .Length(1, 200)
                .When(x => x.AddNewComment != null && !string.IsNullOrEmpty(x.AddNewComment.CommentTitle));

            RuleFor(x => x.AddNewComment.CommentText)
                .NotEmpty()
                .When(x => x.AddNewComment != null);
        }
    }
}