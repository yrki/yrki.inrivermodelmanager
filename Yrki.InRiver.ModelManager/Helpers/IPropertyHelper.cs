using System;
using System.Reflection;

namespace Yrki.InRiver.Helpers
{
	public interface IPropertyHelper
	{
		PropertyInfo GetFieldForLink(Type sourceType, Type targetType);
		PropertyInfo GetPropertyForFieldType(Type type, string fieldTypeId);
		PropertyInfo GetPropertyForLinkType(Type type);
		void SetPropertyValue(PropertyInfo property, object ownerClass, object data);
	}
}