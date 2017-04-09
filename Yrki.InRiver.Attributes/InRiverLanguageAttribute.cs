using System;

namespace Yrki.InRiver.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InRiverLanguageAttribute : Attribute
    {
        public string Language { get; set; }
    }
}
