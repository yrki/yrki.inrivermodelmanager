using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Yrki.InRiver.Attributes;

namespace Yrki.InRiver.Helpers
{
	internal class PropertyHelper : IPropertyHelper
	{
		public PropertyInfo GetPropertyForFieldType(Type type, string fieldTypeId)
		{
			var allProperties = type.GetProperties();

			foreach (var property in allProperties)
			{
				var fieldTypeAttributes = property.GetCustomAttributes<InRiverFieldTypeAttribute>();

				if (fieldTypeAttributes.Any())
				{
					var attribute = fieldTypeAttributes.FirstOrDefault();

					if (string.Equals(attribute.FieldTypeId, fieldTypeId, StringComparison.InvariantCultureIgnoreCase))
					{
						return property;
					}
				}
			}

			return null;
		}

		public PropertyInfo GetPropertyForLinkType(Type type)
		{
			var allProperties = type.GetProperties();

			foreach (var property in allProperties)
			{
				var customAttributes = property.GetCustomAttributes<InRiverLinkTypeAttribute>();
				
				if (customAttributes.Any())
				{
					return property;
				}
			}

			return null;
		}

		public PropertyInfo GetFieldForLink(Type sourceType, Type targetType)
		{
			var allProperties = sourceType.GetProperties();

			foreach (var property in allProperties)
			{
				var linkTypeAttributes = property.GetCustomAttributes(typeof(InRiverLinkTypeAttribute));

				if (linkTypeAttributes.Any())
				{
					foreach (var linkTypeAttribute in linkTypeAttributes)
					{
						var attribute = (InRiverLinkTypeAttribute) linkTypeAttribute;

						if (attribute.SourceEntityType == sourceType && attribute.TargetEntityType == targetType)
						{
							return property;
						}
					}					
				}
			}

			return null;
		}

		public void SetPropertyValue(PropertyInfo property, object ownerClass, object data)
		{
			var typeOfSourceField = data.GetType();

			if (property != null)
			{
				if (property.PropertyType != typeOfSourceField)
				{
					var converter = TypeDescriptor.GetConverter(typeOfSourceField);

					if (converter.CanConvertFrom(typeOfSourceField))
					{
						property.SetValue(ownerClass, converter.ConvertFrom(data));
					}
				}
				else
				{
					property.SetValue(ownerClass, data);
				}
			}
		}
	}
}
