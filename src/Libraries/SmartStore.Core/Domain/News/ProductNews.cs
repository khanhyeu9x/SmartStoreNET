using SmartStore.Core.Domain.News;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SmartStore.Core.Domain.News
{
    /// <summary>
    /// Represents a product category mapping
    /// </summary>
    [DataContract]
    public partial class ProductNews : BaseEntity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
		[DataMember]
		public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the category identifier
        /// </summary>
		[DataMember]
		public int NewsId { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets the category
        /// </summary>
        [DataMember]
        public virtual NewsItem News { get; set; }

        /// <summary>
        /// Gets the product
        /// </summary>
        [DataMember]
        public virtual Product Product { get; set; }

    }

}
