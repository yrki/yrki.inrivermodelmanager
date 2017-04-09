using System;

namespace Yrki.InRiver.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class InRiverEntityTypeAttribute : Attribute
    {
        public string EntityTypeId { get; set; }
        public string Name { get; set; }
        public bool IsLinkEntityType { get; set; }
        
    }
}