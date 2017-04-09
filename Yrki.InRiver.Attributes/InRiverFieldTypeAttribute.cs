using System;

namespace Yrki.InRiver.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class InRiverFieldTypeAttribute : Attribute
    {
        public int Index { get; set; }
        public string FieldTypeId { get; set; }
        public InRiverDataType DataType { get; set; }
        public Type CVL { get; set; }
        public Type Category { get; set; }
        public string DefaultValue { get; set; }
        public bool Mandatory { get; set; }
        public bool ReadOnly { get; set; }
        public bool IsDisplayName { get; set; }
        public bool IsDisplayDescription { get; set; }
        public bool Multivalue { get; set; }
        public bool Unique { get; set; }
        public bool Hidden { get; set; }
        public bool ExcludeFromDefaultView { get; set; }
        public string Name { get; set; }
		public bool TrackChanges { get; set; }
		public string Description { get; set; }

		//TODO: Settings and units
		// Settings Dictionary
		// Units List<Unit>
	}
}