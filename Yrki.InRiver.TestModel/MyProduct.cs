using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using Yrki.InRiver.Attributes;

namespace Yrki.InRiver.TestModel
{
	[InRiverEntityType(EntityTypeId = "Product")]
    public class MyProduct
    {
		[InRiverFieldType(FieldTypeId = "ProductNumber")]
		public string ProductNumber { get; set; }

		[InRiverFieldType(FieldTypeId = "ProductName")]
		public string ProductName { get; set; }

		[InRiverFieldType(FieldTypeId = "ProductShortDescription")]
		public string ProductShortDescription { get; set; }

		[InRiverLinkType(LinkType = "ProductItem", SourceEntityType = typeof(MyProduct), TargetEntityType = typeof(MyItem))]
		public List<MyItem> Items { get; set; }

	}
}
