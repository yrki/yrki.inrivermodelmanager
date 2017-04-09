using System;
using System.Collections.Generic;

namespace Yrki.InRiver.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InRiverCategoryAttribute : Attribute
    {
		public int Index { get; set; }
		public string Name { get; set; }
		public string CategoryId { get; set; }
    }

}