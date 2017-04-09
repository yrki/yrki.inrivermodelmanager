using System;

namespace Yrki.InRiver.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InRiverFieldsetAttribute : Attribute
    {
        
        public string FieldsetId { get; set; }
        public string Name { get; set; }
        public Type EntityType { get; set; }
    }
}