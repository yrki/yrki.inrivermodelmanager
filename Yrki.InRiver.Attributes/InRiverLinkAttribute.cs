using System;

namespace Yrki.InRiver.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class InRiverLinkTypeAttribute : Attribute
    {
        public string LinkType { get; set; }
        public int Index { get; set; }
        public Type SourceEntityType { get; set; }
        public Type TargetEntityType { get; set; }
        public Type LinkEntityType { get; set; }
        public string InboundName { get; set; }
        public string OutboundName { get; set; }
    }
}