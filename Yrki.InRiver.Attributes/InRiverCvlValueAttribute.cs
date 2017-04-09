using System;

namespace Yrki.InRiver.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InRiverCvlValueAttribute : Attribute
    {
		public string Key { get; set; }
		public int SortOrder { get; set; }
		public string Name { get; set; } // TODO: Locale string
	}
}