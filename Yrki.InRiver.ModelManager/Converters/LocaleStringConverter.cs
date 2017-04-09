using System;
using System.ComponentModel;
using System.Globalization;
using inRiver.Remoting.Objects;

namespace Yrki.InRiver.Converters
{
    public class LocaleStringConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(LocaleString);

        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {

            LocaleString source = (LocaleString) value;
            string target = string.Empty;

            foreach (var language in source.Languages)
            {
                target += language.Name + "=" + System.Net.WebUtility.UrlEncode(source[language]) + ";";
            }

            return target;
        }
    }
}
