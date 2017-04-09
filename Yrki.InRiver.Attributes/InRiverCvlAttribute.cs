using System;

namespace Yrki.InRiver.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class InRiverCvlAttribute : Attribute
    {
        public string CvlId { get; set; }
        public Type ParentCvl { get; set; }
        public bool CustomCvl { get; set; }
        public bool IsLocaleString { get; set; }

    }
}