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

		[InRiverFieldType(FieldTypeId = "ProductLongDescription")]
		public string ProductLongDescription { get; set; }

	}
}
